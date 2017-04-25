using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DemoAPI.Data
{
    public class Tables
    {

        public static CloudTableClient GetClient()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("storage"));

            return storageAccount.CreateCloudTableClient();
        }

        public static Task AddEntity(CloudTableClient client, string tableName, ITableEntity entity)
        {
            CloudTable table = client.GetTableReference(tableName);
            table.CreateIfNotExists();
            return table.ExecuteAsync(TableOperation.Insert(entity));
        }

        public static IEnumerable<T> GetAll<T>(CloudTableClient client, string tableName) where T: ITableEntity, new()
        {
            CloudTable table = client.GetTableReference(tableName);
            table.CreateIfNotExists();

            var query = table.CreateQuery<T>();
            return table.ExecuteQuery(query);
            
        }
    }
}