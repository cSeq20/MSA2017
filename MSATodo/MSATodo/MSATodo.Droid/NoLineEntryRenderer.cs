using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using MSATodo.Droid;

[assembly: ExportRenderer(typeof(Entry), typeof(NoLineEntryRenderer))]
namespace MSATodo.Droid
{
    public class NoLineEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}