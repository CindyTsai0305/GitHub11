using Microsoft.AspNetCore.Mvc.Rendering;

namespace eHR.Dao
{
    public interface ICodeDao
    {
        List<SelectListItem> GetCodeData(string type);
        public List<SelectListItem> GetEmployeeCodeData(string ignoreEmployeeId);
    }
}