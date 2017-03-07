using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace KrispyKreme
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			app.Tap(x => x.Class("android.widget.ImageButton"));
			app.Screenshot("Let's start by Tapping on the 'Hamburger' Icon");

			app.Tap("frag_nav_menu_settings_tv");
			app.Screenshot("Next, we Tapped on the 'Settings' Button");

			app.Tap("frag_settings_clear_notification_button_tv");
			app.Screenshot("We Tapped on 'Find a Shop'");

			app.Tap(x => x.Class("android.widget.TextView").Index(0));
			app.Screenshot("Then we Tapped on the 'Search' icon");

			app.EnterText("San Francisco");
			app.Screenshot("Next we entered our seach, 'San Francisco'");

			app.PressEnter();
			app.Screenshot("Next, we 'Pressed Enter' on the keyboard");

			Thread.Sleep(30000);
			app.Tap("view_panel_site_details_tv_name");
			app.Screenshot("Then we Tapped on the 'Mountain View' banner");

			app.Tap("view_panel_favorite_site_check_box");
			app.Screenshot("Lastly, we Tapped on the 'Heart' Icon");
		}

	}
}
