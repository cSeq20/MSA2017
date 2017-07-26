using Microsoft.WindowsAzure.MobileServices;
using MSATodo.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MSATodo
{
    public class AzureManager
    {
        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<TodoTable> todoItem;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://todolistmsa.azurewebsites.net");
            this.todoItem = this.client.GetTable<TodoTable>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task<ObservableCollection<TodoTable>> getTodoItems()
        {
            return await this.todoItem.ToCollectionAsync();
        }

        public async Task PostTodoItem(TodoTable item)
        {
            await this.todoItem.InsertAsync(item);
        }

        public async Task DeleteTodoITem(TodoTable delItem)
        {
            await this.todoItem.DeleteAsync(delItem);
        }
    }
}
