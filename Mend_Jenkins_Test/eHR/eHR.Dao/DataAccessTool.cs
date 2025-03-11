using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHR.Dao
{
    public class DataAccessTool : IDataAccessTool
    {
        public DataTable Query(string connStr, string sql, List<KeyValuePair<string, object>> parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (var item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
            }
            return dt;
        }
    }
}
