using JapanApp.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;

[assembly: ExportRenderer(typeof(JapanApp.RoundedButton), typeof(RoundedButtonRenderer))]
namespace JapanApp.iOS
{
    public class RoundedButtonRenderer : ButtonRenderer
    {
        public override void LayoutSubviews()
        {
            var element = Element as RoundedButton;
            if(element.RoundLeftSide && element.RoundRightSide)
            {
                Layer.Mask = new CoreAnimation.CAShapeLayer()
                {
                    Path = UIBezierPath.FromRoundedRect(Bounds, UIRectCorner.BottomLeft | UIRectCorner.TopLeft | UIRectCorner.BottomRight | UIRectCorner.TopRight, new CGSize(element.RoundRadius, element.RoundRadius)).CGPath
                };
            }else if(element.RoundLeftSide)
            {
                Layer.Mask = new CoreAnimation.CAShapeLayer()
                {
                    Path = UIBezierPath.FromRoundedRect(Bounds, UIRectCorner.BottomLeft | UIRectCorner.TopLeft, new CGSize(element.RoundRadius, element.RoundRadius)).CGPath
                };
            }else if (element.RoundRightSide)
            {
                Layer.Mask = new CoreAnimation.CAShapeLayer()
                {
                    Path = UIBezierPath.FromRoundedRect(Bounds, UIRectCorner.BottomRight | UIRectCorner.TopRight, new CGSize(element.RoundRadius, element.RoundRadius)).CGPath
                };
            }
            base.LayoutSubviews();
        }
    }
}
