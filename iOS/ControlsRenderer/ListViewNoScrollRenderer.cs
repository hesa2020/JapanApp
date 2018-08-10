using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(JapanApp.ListViewNoScroll), typeof(JapanApp.iOS.ListViewNoScrollRenderer))]
namespace JapanApp.iOS
{
    public class ListViewNoScrollRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            Control.ScrollEnabled = false;
        }
    }
}
