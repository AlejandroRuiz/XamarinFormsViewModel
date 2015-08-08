using System;

using Xamarin.Forms;
using ListViewText.ViewModel;

namespace ListViewText.Pages
{
	public class EditUserPage : ContentPage
	{
		
		UserVM UserVM {
			get{
				return this.BindingContext as UserVM;
			}
		}

		Entry UserName { get; set; } = new Entry(){
			Placeholder = "Name"
		};

		Entry UserAge { get; set; } = new Entry(){
			Placeholder = "Age",
			Keyboard = Keyboard.Numeric
		};

		Button Savedata { get; set; } = new Button(){
			Text = "Save"
		};

		public EditUserPage (UserVM uservm)
		{
			BindingContext = uservm;

			UserName.SetBinding (Entry.TextProperty, "Name", BindingMode.TwoWay);

			UserAge.SetBinding (Entry.TextProperty, "Age", BindingMode.TwoWay);

			Savedata.Clicked += Savedata_Clicked;

			Content = new StackLayout { 
				Padding = new Thickness(50,20),
				Spacing = 20,
				Children = {
					UserName,
					UserAge,
					Savedata
				}
			};
		}

		async void Savedata_Clicked (object sender, EventArgs e)
		{
			await Navigation.PopModalAsync (true);
		}
	}
}


