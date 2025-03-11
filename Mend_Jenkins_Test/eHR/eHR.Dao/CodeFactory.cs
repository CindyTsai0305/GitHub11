using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHR.Dao
{
    public class CodeFactory
    {
        public ICodeDao GetCodeDao()
        {
            string implement = eHR.Common.ConfigTool.GetAppSetting("CodeDaoImplement");
            ICodeDao result;
            switch (implement)
            {
                case "CodeDao":
                    result = new CodeDao(new DataAccessTool());
                    break;
                case "CodeApiDao":
                    result = new CodeApiDao();
                    break ;
                case "CodeOracleDao":
                    result = new CodeOracleDao();
                    break ;
                default:
                    result = new CodeDao(new DataAccessTool());
                    break ;
            }
            return result;
        }
    }
}
