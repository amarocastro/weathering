using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using weathering.Data;
using weathering.Model;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace weathering.Views
{
	/// <summary>
	/// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
	/// </summary>
	public sealed partial class FavouritePage : Page
	{
		private List<Item> fav_List = new List<Item>();
		public FavouritePage()
		{
			this.InitializeComponent();
			OpenFavouriteList();
		}
		private async void OpenFavouriteList()
		{
			this.fav_List = await DataAccess.GetFavList();
			FavouriteList.ItemsSource = this.fav_List;
		}
		private void btn_DelButton_Click(Object sender, RoutedEventArgs args)
		{
			Button s = (Button)sender;
			string btn_tag = s.Tag.ToString();
			Item item = this.fav_List.Find(x => x.locationId == btn_tag);
			DataAccess.DeleteItemFromFav(item);
			this.OpenFavouriteList();
		}
	}
}
