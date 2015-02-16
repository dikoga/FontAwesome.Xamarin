//
// FABarButtonItem.cs
//
// Author:
//       Neil Kennedy <neil.p.kennedy@outlook.com>
//
// Copyright (c) 2014 neilkennedy
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using CoreGraphics;
using UIKit;
using System.ComponentModel;
using Foundation;

namespace FontAwesomeXamarin
{
	public class FABarButtonItem : UIBarButtonItem
	{
		private UILabel _iconLabel = null;
		private UIButton _iconButton = null;

		/// <summary>
		/// Gets or sets the Title of the button.
		/// Throws <see cref="FontAwesome.Xamarin.FontAwesomeException"/> if this button does not have a title
		/// </summary>
		/// <value>The title.</value>
		public string IconText{
			get{
					return _iconLabel.Text;
			}
			set{
					_iconLabel.Text = value;
			
			}
		}

		/// <summary>
		/// Gets or sets the icon for the button. Should be from <see cref="FontAwesome.Xamarin.FontAwesome"/>.
		/// Throws <see cref="FontAwesome.Xamarin.FontAwesomeException"/> if the button has not been initialized yet
		/// </summary>
		/// <value>The icon.</value>
		public string Icon {
			get {
					return _iconButton.Title (UIControlState.Normal);
			}
			set {
					_iconButton.SetTitle (value, UIControlState.Normal);

			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FontAwesome.Xamarin.FABarButtonItem"/> class.
		/// Use the CustomView property to access the button that we create with the new icon
		/// </summary>
		/// <param name="icon">An icon from <see cref="FontAwesome.Xamarin.FontAwesome"/></param>
		/// <param name="fontColor">The UIColor for the icon and title</param>
		/// <param name="handler">The event handler for when the button is pressed</param>
		public FABarButtonItem (string icon, UIColor fontColor, EventHandler handler) : base()
		{
			_iconButton = new UIButton (new CGRect (0, 0, 32, 32)) {
				Font = FontAwesome.Font (25)
			};
			_iconButton.SetTitleColor (fontColor, UIControlState.Normal);
			_iconButton.TouchUpInside += (sender, e) => handler(this, null);

			this.Icon = icon;

			CustomView = _iconButton;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FontAwesomeXamarin.FABarButtonItem"/> class.
		/// </summary>
		/// <param name="icon">An icon from <see cref="FontAwesome.Xamarin.FontAwesome"/></param>
		/// <param name="title">A title to display under the icon</param>
		/// <param name="fontColor">The UIColor for the icon and title</param>
		/// <param name="handler">The event handler for when the button is pressed</param>
		public FABarButtonItem (string icon, string title, UIColor fontColor, EventHandler handler) : base()
		{
			UIView view = new UIView (new CGRect (2, 0, 56, 32));
			view.AddGestureRecognizer (new UITapGestureRecognizer (() =>  {
				handler (this, null);
			}));

			_iconButton = new UIButton (new CGRect (14, 0, 32, 21)) {
				Font = FontAwesome.Font (20),
			};
			_iconButton.SetTitleColor (fontColor, UIControlState.Normal);
			_iconButton.AddGestureRecognizer (new UITapGestureRecognizer (() =>  {
				handler (this, null);
			}));

			_iconLabel = new UILabel (new CGRect (0, 22, 56, 10)) {
				TextColor = fontColor,
				Font = UIFont.SystemFontOfSize(10f),
				TextAlignment = UITextAlignment.Center
			};
			_iconLabel.AddGestureRecognizer (new UITapGestureRecognizer (() => {
				handler (this, null);
			}));

			this.IconText = title;
			this.Icon = icon;

			view.Add (_iconButton);
			view.Add (_iconLabel);

			CustomView = view;
		}
	}
}
