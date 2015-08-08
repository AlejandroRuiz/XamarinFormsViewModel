using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using ListViewText.ViewModel;
using ListViewText.Model;

namespace ListViewText.Pages
{
	public class MainPage : ContentPage
	{
		public ListView ListView { get; set; } = new ListView();

		public Button Button { get; set; } = new Button(){
			Text = "Add New User"
		};

		public ObservableCollection<UserVM> ListViewData { get; set; } = new ObservableCollection<UserVM>();

		public MainPage ()
		{
			Title = "ListViewVM Page";

			Button.Clicked += Button_Clicked;

			//Set ItemsSource
			ListView.ItemsSource = ListViewData;

			//Set ItemTemplate
			ListView.ItemTemplate = new DataTemplate (GetCustomCell);
			ListView.ItemTemplate.SetBinding (TextCell.TextProperty, "Name");
			ListView.ItemTemplate.SetBinding (TextCell.DetailProperty, "Age");

			//Set Content View
			Content = new StackLayout { 
				Children = {
					Button,
					ListView
				}
			};
		}

		private Cell GetCustomCell()
		{
			var cell = new TextCell ();
			var editItem = new MenuItem () {
				Text = "Edit"
			};
			editItem.Clicked += EditItem_Clicked;
			editItem.SetBinding (MenuItem.CommandParameterProperty, ".");
			cell.ContextActions.Add(editItem);

			var deleteItem = new MenuItem () {
				Text = "Delete",
				IsDestructive = true
			};
			deleteItem.SetBinding (MenuItem.CommandParameterProperty, ".");
			deleteItem.Clicked += DeleteItem_Clicked;
			cell.ContextActions.Add(deleteItem);
			return cell;
		}

		void DeleteItem_Clicked (object sender, EventArgs e)
		{
			var userItem = (sender as MenuItem).CommandParameter as UserVM;
			ListViewData.Remove (userItem);
		}

		async void EditItem_Clicked (object sender, EventArgs e)
		{
			var userItem = (sender as MenuItem).CommandParameter as UserVM;
			await Navigation.PushModalAsync (new EditUserPage(userItem));
		}


		async void Button_Clicked (object sender, EventArgs e)
		{
			var userItem = new UserVM(new User());
			ListViewData.Add (userItem);
			await Navigation.PushModalAsync (new EditUserPage(userItem));
		}
	}
}


