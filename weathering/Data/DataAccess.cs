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

		public static async Task<List<Item>> GetFavList()
		{
			List<Item> result = new List<Item>();
			result = await ReadJsonFIleFromLocalFolder<List<Item>>(fileNameFav);
			return result;
		}

		public static async Task<bool> AddItemToFav(Item newitem)
		{
			var result = true;
			result = await WriteJsonFileFromLocalFolfer<Item>(fileNameFav, newitem);
			return result;
		}

		public static async void DeleteItemFromFav(Item item)
		{
			var result = false;
			result = await DeleteItemJsonFileFromLocalFolder(fileNameFav, item);
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
		private static async Task<bool> DeleteItemJsonFileFromLocalFolder(string filename, Item data) 
		{
			StorageFile file = await localFolder.GetFileAsync(filename);
			string content = await FileIO.ReadTextAsync(file);
			List<Item> contentData = JsonConvert.DeserializeObject<List<Item>>(content);
			if (content != null)
			{
				contentData.RemoveAt(contentData.FindIndex(x => x.locationId == data.locationId));
			}
			content = JsonConvert.SerializeObject(contentData);
			await FileIO.WriteTextAsync(file,content);
			return true;
		}
	}
}
