using MSATodo.Models;
using MSATodo.Services;
using System;
using System.Diagnostics;
using System.Linq;

using Xamarin.Forms;

namespace MSATodo.Views
{
    public partial class AddItemPage : ContentPage
    {
        IBingSCService spellChecker;
        TodoTable item;

        public AddItemPage()
        {
            InitializeComponent();
            spellChecker = new BingSpellCheckService();
            item = new TodoTable();

            check.Clicked += checkEntry;
            Time_Changed();
        }

        private void OnClose(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void addTodo(object sender, EventArgs e)
        {
            item.date = date.Date.ToString("dd/MM/yyyy");
            await AzureManager.AzureManagerInstance.PostTodoItem(item);
            MessagingCenter.Send(this, "save", item);
            await Navigation.PopAsync();
        }

        public async void checkEntry(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(taskEntry.Text))
                {
                    var spellCheckRes = await spellChecker.CheckSpelling(taskEntry.Text);
                    foreach (var flagged in spellCheckRes.FlaggedTokens)
                    {
                        taskEntry.Text = taskEntry.Text.Replace(flagged.Token, flagged.suggestions.FirstOrDefault().Suggestion);   // not working
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #region fields
        public void Time_Changed()
        {
            tPicker.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
                {
                    item.time = tPicker.Time.ToString();
                }
            };
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            item.note = e.NewTextValue;
        }

        private void Date_Changed(object sender, DateChangedEventArgs e)
        {
            item.date = date.Date.ToString("dd/MM/yyyy");
        }

        private void OnPrioritySelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = priority.SelectedIndex;

            if (selectedIndex != -1)
            {
                item.priority = (string)priority.ItemsSource[selectedIndex];
            }
        }
        #endregion
    }
}
