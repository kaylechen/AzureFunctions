#r "System.Configuration"
#r "System.Data"
#r "Newtonsoft.Json"

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.json;


public static void Run(string myQueueItem, TraceWriter log)
{
    JObject restoredObject = JsonConvert.DeserializeObject<JObject>(myQueueItem);  //將序列化的資料還原成JSON
    //string Guid = restoredObject["GUID"].ToString();
    //string TenantID = restoredObject["TenantID"].ToString();
    //string JobMome = restoredObject["JobMome"].ToString();
    //log.Info($"myQueueItem:{myQueueItem}");
    log.Info($"Guid:{Guid}");
    //log.Info($"TenantID:{TenantID}");
    //log.Info($"JobMome:{JobMome}");


    var str = ConfigurationManager.ConnectionStrings["sqldb_connection"].ConnectionString;
    using (SqlConnection conn = new SqlConnection(str))
    {
        conn.Open();
        var text = "insert into TableB(A01, A02) Values('11', getdate())";
        using (SqlCommand cmd = new SqlCommand(text, conn))
        {
            // Execute the command and log the # rows deleted.
            var rows = cmd.ExecuteNonQuery();

            log.Info($"{rows} rows were insert");
        }
    }
}