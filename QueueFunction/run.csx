#r "System.Configuration"
#r "System.Data"

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

public static void Run(string myQueueItem, TraceWriter log)
{

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