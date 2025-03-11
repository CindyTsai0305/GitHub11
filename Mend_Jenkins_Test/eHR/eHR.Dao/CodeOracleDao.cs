using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHR.Dao
{
    public class CodeOracleDao : ICodeDao
    {
        public List<SelectListItem> GetCodeData(string type)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetEmployeeCodeData(string ignoreEmployeeId)
        {
            throw new NotImplementedException();
        }
    }
}
