using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MSATodo.Droid;

[assembly: ExportRenderer(typeof(TimePicker), typeof(NoLineTimePickerRenderer))]
namespace MSATodo.Droid
{
    public class NoLineTimePickerRenderer : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}