using Xamarin.Forms;
using MSATodo.Droid;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DatePicker), typeof(NoLineDatePickRenderer))]
namespace MSATodo.Droid
{
    public class NoLineDatePickRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}