using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinUsers.CustomRenderers;
using XamarinUsers.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]

namespace XamarinUsers.Droid.CustomRenderers
{
    public class CustomFrameRenderer : VisualElementRenderer<Frame>
    {
        [Obsolete]
        public CustomFrameRenderer()
        {
            SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.rect));
        }
    }
}
