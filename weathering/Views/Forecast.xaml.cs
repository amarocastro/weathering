using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using weathering.Helper;
using weathering.Helper.GetForecastHelper;
using weathering.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using weathering.ViewModel;
using System.Threading.Tasks;
using weathering.Data;
using Windows.UI.Xaml;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace weathering.Views
{
	/// <summary>
	/// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
	/// </summary>
	public sealed partial class Forecast : Page
	{
		//private Position position;
		private CurrentWeatherMask currentWeather;
		private GetForecastHelper getForecastHelper = new GetForecastHelper();
		public ForecastViewModel ViewModel;

		public Forecast()
		{
			this.InitializeComponent();
		}
		
		protected override async void OnNavigatedTo(NavigationEventArgs e)
		{
			if (e != null)
			{
				SimpleItem item = e.Parameter as SimpleItem;
				item.isFavourite = await DataAccess.FavExists(item);
				string provider = SettingsManager.GetProviderSetting();
				currentWeather = await this.LoadCurrentWeather(item, provider);
				ViewModel = new ForecastViewModel(currentWeather);
				ViewModel.Title = item.title + item.subtitle;
				SetCommandBar(item.isFavourite);
				PopulateCurrentView();
			}
		}
		private void PopulateCurrentView()
		{
			title.Text = ViewModel.Title;
			temperature.Text = ViewModel.Temp;

		}

		private void SetCommandBar(bool isFav)
		{
			if (!isFav)
			{
				ManageFavourite.Icon = new SymbolIcon(Symbol.UnFavorite);
			}
			else
			{
				ManageFavourite.Icon = new SymbolIcon(Symbol.Favorite);
			}
		}
		private async Task<CurrentWeatherMask> LoadCurrentWeather(SimpleItem item, string provider)
		{
			CurrentWeatherMask current = await getForecastHelper.GetCurrentForecast(item.position, provider);
			return current;
		}

		private void ManageFavourite_Click(object sender, RoutedEventArgs e)
		{
			
		}
	}


}
