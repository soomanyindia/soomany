using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Webkit;
using Android.Views;

namespace Soomany
{
    [Activity(Label = "", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        WebView webview;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            webview = FindViewById<WebView>(Resource.Id.webView);
            webview.SetWebViewClient(new MyWebViewClient());
            webview.Settings.LoadsImagesAutomatically = true;
            webview.Settings.JavaScriptEnabled = true;
            webview.LoadUrl("http://soomany.in");
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public override void OnBackPressed()
        {
            webview.GoBack();
        }
    }
    internal class MyWebViewClient: WebViewClient
    {
        public override void OnPageFinished(WebView view, string url)
        {
            view.LoadUrl("javascript:var elements = document.getElementsByClassName('hide'); console.log( elements[0].parentNode.removeChild(elements[0]));");
            base.OnPageFinished(view, url);

        }
    }
}