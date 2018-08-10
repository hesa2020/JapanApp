using System;
using Xamarin.Forms;

namespace JapanApp
{
    public class RoundedButton : Button
    {
        public static BindableProperty RoundLeftSideProperty = BindableProperty.Create<RoundedButton, bool>(p => p.RoundLeftSide, default(bool));
        public bool RoundLeftSide
        {
            get { return (bool)GetValue(RoundLeftSideProperty); }
            set { SetValue(RoundLeftSideProperty, value); }
        }

        public static BindableProperty RoundRightSideProperty = BindableProperty.Create<RoundedButton, bool>(p => p.RoundRightSide, default(bool));
        public bool RoundRightSide
        {
            get { return (bool)GetValue(RoundRightSideProperty); }
            set { SetValue(RoundRightSideProperty, value); }
        }

        public static BindableProperty RoundRadiusProperty = BindableProperty.Create<RoundedButton, int>(p => p.RoundRadius, default(int));
        public int RoundRadius
        {
            get { return (int)GetValue(RoundRadiusProperty); }
            set { SetValue(RoundRadiusProperty, value); }
        }
    }
}
