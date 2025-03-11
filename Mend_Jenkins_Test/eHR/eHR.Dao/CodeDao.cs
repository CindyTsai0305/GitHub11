using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eHR.Dao
{
    public class CodeDao : ICodeDao
    {

        private readonly IDataAccessTool _dataAccessTool;

        public CodeDao(IDataAccessTool dataAccessTool)
        {
            _dataAccessTool= dataAccessTool;
        }
        /// <summary>
        /// 取得代碼資料
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<SelectListItem> GetCodeData(string type)
        {
            try
            {
              
                DataTable dt=new DataTable();
                string sql = "Select CodeId,CodeVal From CodeTable Where CodeType=@CodeType";
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>("@CodeType", type));
                dt = _dataAccessTool.Query(eHR.Common.ConfigTool.GetDBConnectionString(), sql, parameters);
              
                return MapCodeDataToList(dt);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 將代碼資料的 DataTable 轉換成 強行別的 List<SelectListItem>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<SelectListItem> MapCodeDataToList(DataTable dt)
        {
            var result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["CodeVal"].ToString(),
                    Value = row["CodeId"].ToString()
                });
            }
            return result;
        }
        /// <summary>
        /// 取得員工資料(代碼)
        /// </summary>
        /// <param name="ignoreEmployeeId"></param>
        /// <returns></returns>
        public List<SelectListItem> GetEmployeeCodeData(string ignoreEmployeeId)
        {
            DataTable dt = new DataTable();
            string sql = "Select EmployeeID,FirstName+' '+LastName As Name From HR.Employees Where EmployeeID<>@EmployeeID";
            List<KeyValuePair<string,object>> parameters= new List<KeyValuePair<string,object>>();
            parameters.Add(new KeyValuePair<string, object>("@EmployeeID", "ignoreEmployeeId"));

            dt=_dataAccessTool.Query(eHR.Common.ConfigTool.GetDBConnectionString(),sql,parameters);

            return MapEmployeeCodeDataToList(dt);

        }

        /// <summary>
        /// 將員工代碼資料的 DataTable 轉換成 強行別的 List<SelectListItem>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<SelectListItem> MapEmployeeCodeDataToList(DataTable dt)
        {
            var result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["Name"].ToString(),
                    Value = row["EmployeeID"].ToString()
                });
            }
            return result;
        }
    }
}
