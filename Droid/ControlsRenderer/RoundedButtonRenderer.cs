using System.ComponentModel;
using Xamarin.Forms;
using JapanApp.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Android.Graphics.Drawables;
using System;

[assembly: ExportRenderer(typeof(JapanApp.RoundedButton), typeof(RoundedButtonRenderer))]
namespace JapanApp.Droid
{
    public class RoundedButtonRenderer : ButtonRenderer
    {
        /*GradientDrawable _normal, _pressed;
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var button = (RoundedButton)e.NewElement;
                button.SizeChanged += (s, args) =>
                {
                    var radius = (float)button.RoundRadius;

                    // Create a drawable for the button's normal state
                    _normal = new GradientDrawable();
                    _normal.SetColor(button.BackgroundColor.ToAndroid());

                    // Create a drawable for the button's pressed state
                    _pressed = new GradientDrawable();
                    var highlight = Context.ObtainStyledAttributes(new int[] { Android.Resource.Attribute.ColorActivatedHighlight }).GetColor(0, Android.Graphics.Color.Gray);
                    _pressed.SetColor(highlight);

                    //Button Radius
                    if(button.RoundLeftSide && button.RoundRightSide)
                    {
                        _normal.SetCornerRadii(new float[] { radius, radius, radius, radius, radius, radius, radius, radius });//Both Side
                        _pressed.SetCornerRadii(new float[] { radius, radius, radius, radius, radius, radius, radius, radius });//Both Side
                    }else if(button.RoundLeftSide)
                    {
                        _normal.SetCornerRadii(new float[] { radius, radius, 0, 0, 0, 0, radius, radius });//Left Side
                        _pressed.SetCornerRadii(new float[] { radius, radius, 0, 0, 0, 0, radius, radius });//Left Side
                    }else if(button.RoundRightSide)
                    {
                        _normal.SetCornerRadii(new float[] { 0, 0, radius, radius, radius, radius, 0, 0 });//Right Side
                        _pressed.SetCornerRadii(new float[] { 0, 0, radius, radius, radius, radius, 0, 0 });//Right Side
                    }

                    // Add the drawables to a state list and assign the state list to the button
                    var sld = new StateListDrawable();
                    sld.AddState(new int[] { Android.Resource.Attribute.StatePressed }, _pressed);
                    sld.AddState(new int[] { }, _normal);
                    Control.SetBackgroundDrawable(sld);
                };
            }
        }*/
    }
}
