using System.ComponentModel;
using Xamarin.Forms;
using JapanApp.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;

[assembly: ExportRenderer(typeof(JapanApp.ColorProgressBar), typeof(ColorProgressBarRenderer))]
namespace JapanApp.Droid
{
    public class ColorProgressBarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (Control != null)
            {
                UpdateBarColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ColorProgressBar.BarColorProperty.PropertyName)
            {
                UpdateBarColor();
            }
        }

        void UpdateBarColor()
        {
            var element = Element as ColorProgressBar;
            // http://stackoverflow.com/a/29199280
            Control.IndeterminateDrawable.SetColorFilter(element.BarColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            Control.ProgressDrawable.SetColorFilter(element.BarColor.ToAndroid(), PorterDuff.Mode.SrcIn);
        }
    }
}
