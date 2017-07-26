using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using MSATodo.Droid;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(FlatButtonRenderer))]
namespace MSATodo.Droid
{
    public class FlatButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            // Control is Android.Widget.Button, Element is Xamarin.Forms.Button
            if (Control != null && Element != null)
            {
                // remove default background image
                Control.Background = null;

                // set background color
                Control.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "BackgroundColor")
            {
                // You have to set background color here again, because the background color can be changed later.
                Control.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
            }
        }
    }
}