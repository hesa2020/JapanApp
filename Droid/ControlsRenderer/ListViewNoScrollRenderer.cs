using System.ComponentModel;
using Xamarin.Forms;
using JapanApp.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;

[assembly: ExportRenderer(typeof(JapanApp.ListViewNoScroll), typeof(ListViewNoScrollRenderer))]
namespace JapanApp.Droid
{
    public class ListViewNoScrollRenderer : ListViewRenderer
    {
        int _mPosition;

        public override bool DispatchTouchEvent(Android.Views.MotionEvent e)
        {
            if(e.ActionMasked == Android.Views.MotionEventActions.Down)
            {
                //Record the position the list the touch landed on
                _mPosition = this.Control.PointToPosition((int)e.GetX(), (int)e.GetY());
            }
            if(e.ActionMasked == Android.Views.MotionEventActions.Move)
            {
                //Ignore move events
                return true;
            }
            if (e.ActionMasked == Android.Views.MotionEventActions.Up)
            {
                //Check if we are still within the same view
                if(this.Control.PointToPosition((int)e.GetX(), (int) e.GetY()) == _mPosition)
                {
                    base.DispatchTouchEvent(e);
                }else{
                    //Clear pressed state, cancel action
                    Pressed = false;
                    Invalidate();
                    return true;
                }
            }
            return base.DispatchTouchEvent(e);
        }
    }
}
