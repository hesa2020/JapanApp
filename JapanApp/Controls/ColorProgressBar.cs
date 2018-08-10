using Xamarin.Forms;

namespace JapanApp
{
    public class ColorProgressBar : ProgressBar
    {
        public static BindableProperty BarColorProperty = BindableProperty.Create<ColorProgressBar, Color>(p => p.BarColor, default(Color));
        public Color BarColor
        {
            get { return (Color)GetValue(BarColorProperty); }
            set { SetValue(BarColorProperty, value); }
        }
        public static BindableProperty BgColorProperty = BindableProperty.Create<ColorProgressBar, Color>(p => p.BgColor, default(Color));
        public Color BgColor
        {
            get { return (Color)GetValue(BgColorProperty); }
            set { SetValue(BgColorProperty, value); }
        }
    }
}
