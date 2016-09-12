#r "Microsoft.WindowsAzure.Storage"
#r "Newtonsoft.Json.Linq"
#r "Newtonsoft.Json"
#r "System.Data.SqlClient"

using System.Net;
public static void Run(string myQueueItem, TraceWriter log)
{
    try
    {
        log.Info($"Queue message: {myQueueItem}");

        log.Info("******************Start****************");

        SqlConnection MainConnection = new MainConnection();
        SqlCommand MainCommand = new MainCommand();


        MainConnection.ConnectionString = "Data Source=kayledemo.database.windows.net;Initial Catalog=DEMO;Persist Security Info=True;User ID=vmadmin;Password=P@ssw0rd123";

        MainCommand.Connection = MainConnection;
        MainCommand.CommandText = myQueueItem;
        MainConnection.Open();
        MainCommand.ExecuteNonQuery();



        log.Info("******************End****************");
    }
    catch(Exception e)
    {
        log.Info("KK Exception:" + e);
    }
    


}