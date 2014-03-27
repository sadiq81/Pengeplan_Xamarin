using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Pengeplan.Core
{
	public class Database: SQLiteConnection
	{
		protected static Database me = null;
		protected static string dbLocation;

		protected Database (String path) : base (path)
		{
			CreateTable<Transaction> ();
		}

		static Database ()
		{
			// set the db location
			dbLocation = DatabaseFilePath;
			// instantiate a new db
			me = new Database (dbLocation);
		}

		static object locker = new object ();

		public static string DatabaseFilePath {
			get { 
				var sqliteFilename = "PengeplanDB.db3";

				#if NETFX_CORE
					var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
				#else

				#if SILVERLIGHT
					// Windows Phone expects a local path, not absolute
					var path = sqliteFilename;
				#else

				#if __ANDROID__
						// Just use whatever directory SpecialFolder.Personal returns
						string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
				#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string libraryPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				#endif

				var path = Path.Combine (libraryPath, sqliteFilename);
				#endif		

				#endif
				return path;	
			}
		}

		public static IEnumerable<T> GetItems<T> () where T : BaseEntity, new()
		{
			lock (locker) {
				return me.Table<T> ();
			}
		}

		public static T GetItem<T> (long id) where T : BaseEntity, new()
		{
			lock (locker) {
				return me.Get<T> (id);
			}
		}

		public static long SaveItem<T> (T item) where T : BaseEntity
		{
			lock (locker) {
				if (item.id != 0) {
					return me.Update (item);
				} else {
					return me.Insert (item);
				}
			}
		}

		public static void SaveItems<T> (IEnumerable<T> items) where T : BaseEntity
		{
			lock (locker) {
				me.BeginTransaction ();

				foreach (T item in items) {
					SaveItem<T> (item);
				}

				me.Commit ();
			}
		}

		public static int DeleteItem<T> (long id) where T : BaseEntity, new()
		{
			lock (locker) {
				return me.Delete<T> (new T () { id = id });
			}
		}

		public static void ClearTable<T> () where T : BaseEntity, new()
		{
			lock (locker) {
				me.Execute (string.Format ("delete from \"{0}\"", typeof(T).Name));
			}
		}
		// helper for checking if database has been populated
		public static int CountTable<T> () where T : BaseEntity, new()
		{
			lock (locker) {
				string sql = string.Format ("select count (*) from \"{0}\"", typeof(T).Name);
				var c = me.CreateCommand (sql, new object[0]);
				return c.ExecuteScalar<int> ();
			}
		}
	}
}
