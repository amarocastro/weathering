using Microsoft.Toolkit.Uwp.UI.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using weathering.Data;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace weathering
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.HideTitleBar();
            DataAccess.InitializeFile();
            NavigateToView("SearchPage");
        }
        private void HideTitleBar()
        {
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Colors.Transparent;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.InactiveBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            //Window.Current.SetTitleBar(titleBar);
        }
        private void NavigateClick(object sender, ItemClickEventArgs e)
        {
            //StackPanel item = new StackPanel();
            var obj = sender;
            var item = e; 
            switch (item.ToString())
            {
                case "search":
                    NavigateToView("SearchPage");
                    break;
                case "favourites":
                    NavigateToView("FavouritePage");
                    break;
            }
        }
        private bool NavigateToView(string clickedView)
        {
            var view = Assembly.GetExecutingAssembly().GetType($"weathering.{clickedView}");
            if (string.IsNullOrWhiteSpace(clickedView) || view == null)
            {
                return false;
            }
            //if (clickedView == "SearchPage") { }
            //if (clickedView == "FavouritePage")
            //{
            //}
            ContentFrame.Navigate(view, null, new EntranceNavigationTransitionInfo()); //abrir página
            //NavView.IsPaneOpen = false; //minimizar menu
            return true;
        }
    }
}
