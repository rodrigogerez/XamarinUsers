using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinUsers.CustomRenderers;
using XamarinUsers.iOS.CustomRenderers;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]

namespace XamarinUsers.iOS.CustomRenderers
{
    public class CustomFrameRenderer : VisualElementRenderer<Frame>
    {
        public CustomFrameRenderer()
        {
        }
    }
}
