using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Pengeplan.Core;

namespace Pengeplan.Droid
{
	public class PieView : View
	{
		LinearLayout layout;
		SecuritiesViewModel securitiesViewModel = ServiceContainer.Resolve<SecuritiesViewModel> ();

		public PieView (Context context, LinearLayout layout) : base (context)
		{
			this.layout = layout;
		}

		public override void Draw (Android.Graphics.Canvas canvas)
		{
			base.Draw (canvas);



			Paint mBgPaints = new Paint ();
			mBgPaints.AntiAlias = true;
			mBgPaints.SetStyle (Paint.Style.Fill);
			mBgPaints.Color = Color.Blue;
			mBgPaints.StrokeWidth = 0.5f;

			Paint tPaint = new Paint ();
			tPaint.Alpha = 0;
			canvas.DrawColor (tPaint.Color);

			RectF mOvals = new RectF (40, 40, layout.MeasuredWidth - 40, layout.MeasuredHeight - 40);

			decimal total = 0;
			foreach (SecuritiesViewModel.PieChartValue value in securitiesViewModel.DataForPieChart ()) {
				total += value.amount;
			}

			decimal degressPerAmount = 360 / total;
			decimal currentAngle = 0;
			foreach (SecuritiesViewModel.PieChartValue value in securitiesViewModel.DataForPieChart ()) {
				canvas.DrawArc (mOvals, (float)currentAngle, (float)(degressPerAmount * value.amount), true, mBgPaints);
				currentAngle += (degressPerAmount * value.amount);
				mBgPaints.SetARGB (255, new Random ().Next (256), new Random ().Next (256), new Random ().Next (256));
			}
		}
	}
}

