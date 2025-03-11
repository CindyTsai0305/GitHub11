using Microsoft.AspNetCore.Mvc.Rendering;

namespace eHR.Service
{
    public interface ICodeService
    {
        List<SelectListItem> GetCodeData(string type);
        List<SelectListItem> GetEmployeeCodeData(string ignoreEmployeeId);
    }
}