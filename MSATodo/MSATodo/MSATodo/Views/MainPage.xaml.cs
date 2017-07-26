using MSATodo.Models;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace MSATodo.Views
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<TodoTable> todoList = new ObservableCollection<TodoTable>();
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            getData();
            addClicked();
            MessagingCenter.Subscribe<AddItemPage, TodoTable>(this, "save", (s, a) => {
                getData();
            });
            sync.Clicked += syncClicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            getData();
            MessagingCenter.Subscribe<AddItemPage, TodoTable>(this, "save", (s, a) => {
                getData();
            });
        }

        public async void getData()
        {
            todoList = await AzureManager.AzureManagerInstance.getTodoItems();
            TodoList.ItemsSource = todoList;
        }

        public void addClicked()
        {
            add.Clicked += OpenPopup;
        }

        private void syncClicked(object sender, EventArgs e)
        {
            getData();
        }

        private async void OpenPopup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }
    }
}
