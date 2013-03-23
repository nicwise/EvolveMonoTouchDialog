using System;
using MonoTouch.UIKit;

namespace styling
{
	public static class ExtensionMethods
	{
		public static UIColor ToUIColor(this string hexString)
		{
			if (hexString.Contains("#")) hexString = hexString.Replace("#", "");

			if (hexString.Length != 6) return UIColor.Red;

			int red = Int32.Parse(hexString.Substring(0,2), System.Globalization.NumberStyles.AllowHexSpecifier);
			int green = Int32.Parse(hexString.Substring(2,2), System.Globalization.NumberStyles.AllowHexSpecifier);
			int blue = Int32.Parse(hexString.Substring(4,2), System.Globalization.NumberStyles.AllowHexSpecifier);

			return UIColor.FromRGB(red, green, blue);
		}
	}
}

