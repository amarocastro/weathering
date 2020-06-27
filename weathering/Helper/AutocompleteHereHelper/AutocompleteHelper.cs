﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using weathering.Model;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using weathering.Config;
using System.Collections.ObjectModel;

namespace weathering.Helper.AutocompleteHereHelper
{
    public class AutocompleteHelper
	{
        public async Task<List<Item>> GetSuggestions(string text)
        {   
            List<Item> result = new List<Item>();
            string query = AutocompleteAPIVars.AUTOCOMPLETE_SUGGEST_HEREapi;
            query = query.Replace("{key}",Consts.HERE_APIKEY);
            query = query.Replace("{text}", text);
            //Type suggestionsType = typeof(Suggestions);
            await Task.Run(() =>
            {
                this.ExecuteQueryGetSuggestions(query,
                    (response) =>
                    {
                        IAsyncAction a = CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            if (response != null)
                            {
                                foreach (Item item in response.suggestions)
                                {
                                    if (item.matchlevel == "city")
                                    {
                                        result.Add(item);
                                    }
                                }
                            }

                        });
                        return true;
                    },
                    (error) =>
                    {
                        IAsyncAction a = CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            System.Diagnostics.Debug.WriteLine(error);
                        });
                        return false;
                    });
              
            });
            return result;
        }

        private async void ExecuteQueryGetSuggestions(string query, Func<Suggestions, bool> success, Func<string, bool> error) 
        {
            try
            {
                success(await ApiConnector.DoQueryAsync<Suggestions>(query));
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }

        public async Task<LookUpByID> GetLocationByID(string loc_ID)
        {
            LookUpByID place = new LookUpByID();
            string query = AutocompleteAPIVars.HERE_LOOKUP_BY_ID_API;
            query = query.Replace("{key}", Consts.HERE_APIKEY);
            query = query.Replace("{id}", loc_ID);

            await Task.Run(() =>
            {
                this.ExecuteQueryGetLocationByID(query,
                    (response) =>
                    {
                        IAsyncAction a = CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            if (response != null)
                            {
                                place = response;                                
                            }

                        });
                        return true;
                    },
                    (error) =>
                    {
                        IAsyncAction a = CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            System.Diagnostics.Debug.WriteLine(error);
                        });
                        return false;
                    });

            });
            return place;
        }
        private async void ExecuteQueryGetLocationByID(string query, Func<LookUpByID, bool> success, Func<string, bool> error)
        {
            try
            {
                success(await ApiConnector.DoQueryAsync<LookUpByID>(query));
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }
    }
}
