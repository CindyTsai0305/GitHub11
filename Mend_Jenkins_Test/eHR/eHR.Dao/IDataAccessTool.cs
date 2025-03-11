using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHR.Dao
{
    public interface IDataAccessTool
    {
        DataTable Query(string connStr, string sql, List<KeyValuePair<string, object>> parameters);
    }
}
