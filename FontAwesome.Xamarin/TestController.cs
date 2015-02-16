using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FontAwesomeXamarin
{
	partial class TestController : UIViewController
	{
		public TestController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//item2 = new FABarButtonItem (FontAwesomeXamarin.FontAwesome.FAGithub, "GitHub", UIColor.Blue, null);
		}
	}
}
