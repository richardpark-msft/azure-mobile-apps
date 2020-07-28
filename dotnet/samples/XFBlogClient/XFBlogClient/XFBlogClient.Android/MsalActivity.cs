using Android.App;
using Android.Content;
using Microsoft.Identity.Client;

namespace XFBlogClient.Droid
{
    [Activity]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
        DataHost = "auth",
        DataScheme = "msal787c6673-aec2-46cb-a82c-b89a629af5df")]
    public class MsalActivity : BrowserTabActivity
    {

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
        }
    }
}