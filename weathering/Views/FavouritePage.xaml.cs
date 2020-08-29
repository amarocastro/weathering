﻿using System;
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
using weathering.Model;
using weathering.Data;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace weathering.Views
{
	/// <summary>
	/// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
	/// </summary>
	public sealed partial class FavouritePage : Page
	{
		private List<LookUp> favourites;
		public FavouritePage()
		{
			this.InitializeComponent();
			OpenFavList();
		}

		private async void OpenFavList()
		{
			List<LookUp> items = await DataAccess.GetFavList();
			this.favourites = items;
			FavouriteAdaptativeGrid.ItemsSource = this.favourites;
		}

		private async void btn_DeleteBTN_Click(Object sender, RoutedEventArgs args)
		{
			Button s = (Button)sender;
			string btn_tag = s.Tag.ToString();
			LookUp item = this.favourites.Find(x => x.id == btn_tag);
			await DataAccess.DeleteFromList(item);
			OpenFavList();
		}
	}
}
