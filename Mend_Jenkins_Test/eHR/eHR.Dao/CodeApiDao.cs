using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHR.Dao
{
    public class CodeApiDao : ICodeDao
    {
        /// <summary>
        /// 取得代碼資料
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<SelectListItem> GetCodeData(string type)
        {
            var result = new List<SelectListItem>();
            switch (type)
            {
                case "CITY":
                    result.Add(new SelectListItem() { Value = "0001", Text = "Kirkland" });
                    result.Add(new SelectListItem() { Value = "0002", Text = "London" });
                    result.Add(new SelectListItem() { Value = "0003", Text = "NY" });
                    break;
                case "COUNTRY":
                    result.Add(new SelectListItem() { Value = "UK", Text = "United Kingdom" });
                    result.Add(new SelectListItem() { Value = "USA", Text = "United States of America" });
                    break;
                case "GENDER":
                    result.Add(new SelectListItem() { Value = "F", Text = "Female" });
                    result.Add(new SelectListItem() { Value = "M", Text = "Male" });
                    break;
                case "TITLE":
                    result.Add(new SelectListItem() { Value = "0001", Text = "CEO" });
                    result.Add(new SelectListItem() { Value = "0002", Text = "Sales Manager" });
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// 將員工代碼資料的 DataTable 轉換成 強行別的 List<SelectListItem>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<SelectListItem> GetEmployeeCodeData(string ignoreEmployeeId)
        {
            var result = new List<SelectListItem>();
            result.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Sara Davis"
            });
            result.Add(new SelectListItem()
            {
                Value = "2",
                Text = "Don Funk"
            });
            result.Add(new SelectListItem()
            {
                Value = "3",
                Text = "Judy Lew"
            });

            return result;
        }
    }
}
