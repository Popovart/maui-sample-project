using Android.Content.Res;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Platform;

namespace MauiApp1.Presentation.Controls;

public class CustomEntry : Entry
{
	protected override void OnHandlerChanged()
	{
		base.OnHandlerChanged();
#if ANDROID
		if (Handler?.PlatformView is AppCompatEditText native)
		{
			native.BackgroundTintList = ColorStateList.ValueOf(
				Colors.Black.ToPlatform()
			);
		}
#endif
	}
}
