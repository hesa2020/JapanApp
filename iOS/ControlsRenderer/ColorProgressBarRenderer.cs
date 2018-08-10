using System.ComponentModel;
using JapanApp.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(JapanApp.ColorProgressBar), typeof(ColorProgressBarRenderer))]
namespace JapanApp.iOS
{
    public class ColorProgressBarRenderer : ProgressBarRenderer
    {
        public ColorProgressBarRenderer() { }

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
            Control.TintColor = element.BarColor.ToUIColor();
            Control.BackgroundColor = element.BgColor.ToUIColor();
        }
    }
}
