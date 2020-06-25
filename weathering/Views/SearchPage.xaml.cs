using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using weathering.Data;
using weathering.Helper.AutocompleteHereHelper;
using weathering.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace weathering
{
	/// <summary>
	/// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
	/// </summary>
	public sealed partial class SearchPage : Page
	{
		private AutocompleteHelper autocompleteHelper = new AutocompleteHelper();
		public List<Item> suggestions = new List<Item>();
		public SearchPage()
		{
			this.InitializeComponent();
		}
		public async void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
		{
			if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
			{
				if (sender.Text.Length >= 2)
				{
					//Set the ItemsSource to be your filtered dataset
					//sender.ItemsSource = dataset;
					suggestions = await this.autocompleteHelper.GetSuggestions(sender.Text);
					SuggestList.ItemsSource = suggestions;
				}
			}
		}
		public void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args) 
		{
			
		}
		private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
		{
			// Set sender.Text. You can use args.SelectedItem to build your text string.
		}

		private void SuggestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
		private async void btn_FavButton_Click(Object sender, RoutedEventArgs args)
		{
			Button s = (Button)sender;
			string btn_tag = s.Tag.ToString();
			Item item = this.suggestions.Find(x => x.locationId == btn_tag);
			await DataAccess.AddItemToFav(item);
		}
	}
}
