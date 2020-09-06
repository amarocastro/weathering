using System.Collections.Generic;
using System.Reflection;
using weathering.Data;
using weathering.Helper.AutocompleteHereHelper;
using weathering.Model;
using Windows.UI.Xaml.Controls;
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
        private NavigationViewItem _lastitem;
        private AutocompleteHelper autocompleteHelper = new AutocompleteHelper();
        public List<SimpleItem> suggestions = new List<SimpleItem>();

        public MainPage()
        {
            this.InitializeComponent();
            //this.HideTitleBar();

            DataAccess.InitializeFile();
        }
        //private void HideTitleBar()
        //{
        //    ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
        //    titleBar.BackgroundColor = Colors.Transparent;
        //    titleBar.ButtonBackgroundColor = Colors.Transparent;
        //    titleBar.InactiveBackgroundColor = Colors.Transparent;
        //    CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
        //    coreTitleBar.ExtendViewIntoTitleBar = true;
        //    //Window.Current.SetTitleBar(titleBar);
        //}
        //private void NavigateClick(object sender, ItemClickEventArgs e)
        //{
        //    //StackPanel item = new StackPanel();
        //    var obj = sender;
        //    var item = e; 
        //    switch (item.ToString())
        //    {
        //        case "search":
        //            NavigateToView("SearchPage");
        //            break;
        //        case "favourites":
        //            NavigateToView("FavouritePage");
        //            break;
        //    }
        //}
        private void NavigationView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            if (item == null || item == _lastitem)
            {
                return;
            }
            
            var clickedView = item.Tag?.ToString() ?? "ContentSettingsView";
            if (args.IsSettingsInvoked)
            {
                clickedView = "SettingsPage";
            }
            if (!(NavigateToView(clickedView, args))) return;
            _lastitem = item;
        }
        private bool NavigateToView(string clickedView, NavigationViewItemInvokedEventArgs args)
        {
            var view = Assembly.GetExecutingAssembly().GetType($"weathering.Views.{clickedView}");
            FrameNavigationOptions navigationOptions = new FrameNavigationOptions();
            navigationOptions.TransitionInfoOverride = args.RecommendedNavigationTransitionInfo;
            if (string.IsNullOrWhiteSpace(clickedView) || view == null)
            {
                return false;
            }
            ContentFrame.NavigateToType(view, null, navigationOptions); //abrir página
            return true;
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
                    SearchPlace.ItemsSource = suggestions;
                }
            }
        }
        public void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            //Abrir vista de Forecast y cargar los datos
            var view = Assembly.GetExecutingAssembly().GetType($"weathering.Views.Forecast");
            if (args.ChosenSuggestion != null)
            {
                SimpleItem selected = args.ChosenSuggestion as SimpleItem;

                NavMenu.IsPaneOpen = false;
                sender.Text = string.Empty;
                suggestions.Clear();
                SearchPlace.ItemsSource = suggestions;
                ContentFrame.Navigate(view, selected, new EntranceNavigationTransitionInfo());
            }
        }
        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.
            
        }

        private void SuggestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
