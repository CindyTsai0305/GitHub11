using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHR.Dao
{
    public class MockCodeDao : ICodeDao
    {
        private string rootCodeDataFilePath = @"C:\MyBox\SideProject\新人訓教材\Backend\Sample\Section2\Data\";
        public List<SelectListItem> GetCodeData(string type)
        {
            string bookClassFilePath = rootCodeDataFilePath + "CodeTable.txt";

            var lines = File.ReadAllLines(bookClassFilePath);
            List<SelectListItem> result = new List<SelectListItem>();
            string splitChar = "\t";

            foreach (var item in lines)
            {
                if (item.Split(splitChar.ToCharArray())[0] == type)
                {
                    result.Add(new SelectListItem()
                    {
                        Text = item.Split(splitChar.ToCharArray())[2],
                        Value = item.Split(splitChar.ToCharArray())[1]
                    });
                }
            }
            return result;
        }

        public List<SelectListItem> GetEmployeeCodeData(string ignoreEmployeeId)
        {
            string bookClassFilePath = rootCodeDataFilePath + "Employees.txt";

            var lines = File.ReadAllLines(bookClassFilePath);
            List<SelectListItem> result = new List<SelectListItem>();
            string splitChar = "\t";

            foreach (var item in lines)
            {
                result.Add(new SelectListItem()
                {
                    Text = item.Split(splitChar.ToCharArray())[1]+"-" +item.Split(splitChar.ToCharArray())[2],
                    Value = item.Split(splitChar.ToCharArray())[0]
                });   
            }
            return result;
        }
    }
}
