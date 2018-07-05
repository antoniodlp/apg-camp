using NopCore = Nop.Core;
using System.Data;
using System.Data.SqlClient;

namespace Odegi.Nop.Plugin.AuditLog.Infrastructure
{
    public class DataHelper
    {
      
        public static void ExecuteSql(string sql)
        {
            SqlConnection scon = new SqlConnection(GetConnectionString());
            scon.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, scon);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { scon.Close(); }
        }

        public static object ExecuteScalar(string sql)
        {
            SqlConnection scon = new SqlConnection(GetConnectionString());
            scon.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, scon);
                return cmd.ExecuteScalar();
            }
            catch { }
            finally { scon.Close(); }

            return null;
        }

        public static DataSet Query(string sql)
        {
            SqlConnection scon = new SqlConnection(GetConnectionString());
            scon.Open();
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, scon);
                da.Fill(ds);
                return ds;
            }
            catch { }
            finally { scon.Close(); }

            return null;
        }

        private static string GetConnectionString()
        {
            return new NopCore.Data.DataSettingsManager().LoadSettings().DataConnectionString;
        }

    }
}
