#r "Microsoft.WindowsAzure.Storage"

using System.Net;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using Newtonsoft.Json;

public static void Run(string myQueueItem, TraceWriter log)
{
    try
    {
        log.Info($"Queue message: {myQueueItem}");

        log.Info("******************Start****************");
        MainConnection.ConnectionString = "Data Source=kayledemo.database.windows.net;Initial Catalog=DEMO;Persist Security Info=True;User ID=vmadmin;Password=P@ssw0rd123";

        //JObject restoredObject = JsonConvert.DeserializeObject<JObject>(myQueueItem);  //將序列化的資料還原成JSON
        //string Guid = restoredObject["GUID"].ToString();
        //string TenantID = restoredObject["TenantID"].ToString();
        //string JobMome = restoredObject["JobMome"].ToString();


        MainCommand.Connection = MainConnection;
        MainCommand.CommandText = myQueueItem;
        MainConnection.Open();
        MainCommand.ExecuteNonQuery();



        log.Info("******************End****************");
    }
    catch(Exception e)
    {
        log.Info("Exception:" + e);
    }
    


}