using System;
using System.ComponentModel;
using ListViewText.Model;

namespace ListViewText.ViewModel
{
	public class UserVM:INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string property)
		{
			if (PropertyChanged != null) {
				PropertyChanged (this, new PropertyChangedEventArgs (property));
			}
		}

		#endregion

		private User User { get; set; }

		public string Name
		{
			get{
				return User.Name;
			}set{
				User.Name = value;
				OnPropertyChanged (nameof(Name));
			}
		}

		public int Age
		{
			get{
				return User.Age;
			}set{
				User.Age = value;
				OnPropertyChanged (nameof(Age));
			}
		}

		public UserVM (User @user)
		{
			User = @user;
		}
	}
}

