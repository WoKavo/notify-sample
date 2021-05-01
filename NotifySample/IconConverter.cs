using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace NotifySample
{
	public class IconConverter : IMultiValueConverter
	{
		private BitmapImage high;
		private BitmapImage High => high ??= App.Current.FindResource("High") as BitmapImage;

		private BitmapImage mid;
		private BitmapImage Mid => mid ??= App.Current.FindResource("Mid") as BitmapImage;

		private BitmapImage low;
		private BitmapImage Low => low ??= App.Current.FindResource("Low") as BitmapImage;

		private BitmapImage mute;
		private BitmapImage Mute => mute ??= App.Current.FindResource("Mute") as BitmapImage;

		private BitmapImage noDev;
		private BitmapImage NoDevice => noDev ??= App.Current.FindResource("NoDevice") as BitmapImage;

		private BitmapImage currentIcon;
		
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			BitmapImage newIcon = null;
			if(values[0] is true) //no devices
			{
				newIcon = NoDevice;
			}
			else
			{
				if(values[2] is true) //is muted
					newIcon = Mute;
				else if(values[1] is int newVol)
					newIcon = newVol > 65 ? High : (newVol < 35) ? Low : Mid;
			}
			if(newIcon == null || this.currentIcon == newIcon)
				return Binding.DoNothing;
			this.currentIcon = newIcon;
			return newIcon;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => null;
	}
}