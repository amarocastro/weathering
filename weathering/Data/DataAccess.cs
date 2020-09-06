using AppStudio.Uwp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using weathering.Model;
using Windows.Devices.Geolocation;
using Windows.Storage;
using Windows.UI.Xaml;
using Microsoft.Toolkit.Uwp.Helpers;
using Windows.UI.Xaml.Controls.Maps;

namespace weathering.Data
{
	public static class DataAccess
	{
		private static StorageFolder localFolder = ApplicationData.Current.LocalFolder;
		private static StorageFile fileFavourites;
		private static string fileNameFav = "favlocs.json";

		public static async void InitializeFile()
		{
			
			bool exists = await localFolder.FileExistsAsync(fileNameFav);

			if (exists)
			{
				fileFavourites = await localFolder.GetFileAsync(fileNameFav);
			}
			else
			{
				fileFavourites = await localFolder.CreateFileAsync(fileNameFav);
			}
		}

		public static async Task<bool> FavExists(SimpleItem item)
		{
			bool result = false;
			if (await GetFavItem(fileNameFav, item) != null)
			{
				result = true;
			}
			return result;
		}

		public static async Task<List<LookUp>> GetFavList()
		{
			List<LookUp> result = new List<LookUp>();
			result = await ReadJsonFIleFromLocalFolder<List<LookUp>>(fileNameFav);
			return result;
		}

		public static async Task<bool> AddItemToFav(LookUp newitem)
		{
			var result = true;
			result = await WriteJsonFileFromLocalFolfer<LookUp>(fileNameFav, newitem);
			return result;
		}

		public static async Task<bool> DeleteFromList(LookUp item)
		{
			return await DeleteItemFromFavList(fileNameFav, item);
		}
		private static async Task<LookUp> GetFavItem(string filename, SimpleItem item)
		{
			StorageFile file = await localFolder.GetFileAsync(filename);
			string content = await FileIO.ReadTextAsync(file);
			List<LookUp> data = JsonConvert.DeserializeObject<List<LookUp>>(content);
			LookUp result = data.Find(x => x.id == item.id);
			return result;
		}
		//leer las entradas
		private static async Task<T> ReadJsonFIleFromLocalFolder<T>(string filename)
		{
			StorageFile file = await localFolder.GetFileAsync(filename);
			string content = await FileIO.ReadTextAsync(file);
			T data = JsonConvert.DeserializeObject<T>(content);
			return data;
		}
		//escribir una nueva entrada
		private static async Task<bool> WriteJsonFileFromLocalFolfer<T>(string filename, T newData)
		{
			StorageFile file = await localFolder.GetFileAsync(filename);
			string content = await FileIO.ReadTextAsync(file);
			List<T> contentData = JsonConvert.DeserializeObject<List<T>>(content);
			if (contentData != null)
			{
				contentData.Add(newData);
			}
			else
			{
				contentData = new List<T>();
				contentData.Add(newData);
			}
			content = JsonConvert.SerializeObject(contentData);
			await FileIO.WriteTextAsync(file,content);
			return true;
		}

		private static async Task<bool> DeleteItemFromFavList(string filename, LookUp item)
		{
			StorageFile file = await localFolder.GetFileAsync(filename);
			string content = await FileIO.ReadTextAsync(file);
			List<LookUp> contentData = JsonConvert.DeserializeObject<List<LookUp>>(content);
			if (content != null)
			{
				contentData.RemoveAt(contentData.FindIndex(x => x.id == item.id));
			}
			content = JsonConvert.SerializeObject(contentData);
			await FileIO.WriteTextAsync(file, content);
			return true;
		}
	}
}
