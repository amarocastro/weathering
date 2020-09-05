using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weathering.Model;
using weathering.Helper;
using weathering.Views;
using weathering.Helper.GetForecastHelper;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using weathering.ViewModel;

namespace weathering.ViewModel
{
	public class ForecastViewModel : BindBase
	{
		private GetForecastHelper getForecastHelper = new GetForecastHelper();
		public ForecastViewModel(CurrentWeatherMask currentForecast)
		{
			this.Temp = currentForecast.getCurrentTemp();
			this.Humidity = currentForecast.getHumidity();
			this.Preassure = currentForecast.getPressure();
			this.WindSpeed = currentForecast.getWindSpeed();
			this.Feeling = currentForecast.getFeelingTemp();
			this.Rocio = currentForecast.getRocio();
			this.Visibility = currentForecast.getVisibility();
		}

		//public async void LoadCurrentForecast(Position position, string title, string provider)
		//{
		//	CurrentWeatherMask currentForecast = await getForecastHelper.GetCurrentForecast(position, provider);
		//	this.PopulateCurrentData(currentForecast);
		//}
		//private void PopulateCurrentData(CurrentWeatherMask currentForecast)
		//{
		//	this.Title = currentForecast.getCurrentTemp();
		//	this.Humidity = currentForecast.getHumidity();
		//	this.Preassure = currentForecast.getPressure();
		//	this.WindSpeed = currentForecast.getWindSpeed();
		//	this.Feeling = currentForecast.getFeelingTemp();
		//	this.Rocio = currentForecast.getRocio();
		//	this.Visibility = currentForecast.getVisibility();
		//}

		private string _title;
		public string Title
		{
			get { return this._title; }
			set
			{
				this._title = value;
				this.OnPropertyChanged();
			}
		}
		private string _temp;
		public string Temp
		{
			get { return this._temp; }
			set	{
				this._temp = value;
				this.OnPropertyChanged();
			}
		}

		private string _humidity;
		public string Humidity {
			get { return this._humidity; }
			set {
				this._humidity = value;
				this.OnPropertyChanged();
			}
		}
		
		private string _windspeed;
		public string WindSpeed {
			get { return this._windspeed; }
			set {
				this._windspeed = value;
				this.OnPropertyChanged();
			}
		}
		private string _feeling;
		public string Feeling {
			get { return this._feeling; }
			set {
				this._feeling = value;
				this.OnPropertyChanged();
			}
		}
		private string _preassure;
		public string Preassure {
			get { return this._preassure; }
			set {
				this._preassure = value;
				this.OnPropertyChanged();
			}
		}
		private string _visibility;
		public string Visibility {
			get { return this._visibility; }
			set {
				this._visibility = value;
				this.OnPropertyChanged();
			}
		}
		private string _rocio;
		public string Rocio {
			get { return this._rocio; }
			set {
				this._rocio = value;
				this.OnPropertyChanged();
			}
		}
		private string _description;
		public string Description {
			get { return this._description; }
			set {
				this._description = value;
				this.OnPropertyChanged();
			}
		}
	}
}
