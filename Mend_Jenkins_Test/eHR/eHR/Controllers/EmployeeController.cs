using eHR.Model;
using eHR.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace eHR.Controllers
{
    public class EmployeeController : Controller
    {
        //private EmployeeService employeeService = new EmployeeService();
        //private CodeService codeService = new CodeService();

        //private eHR.Service.EmployeeService employeeService = new eHR.Service.EmployeeService();
        //private eHR.Service.CodeService _codeService = new eHR.Service.CodeService();
        
        private readonly eHR.Service.ICodeService _codeService;
        private readonly eHR.Service.IEmployeeService _employeeService;

        public EmployeeController(eHR.Service.ICodeService codeService, eHR.Service.IEmployeeService employeeService) 
        {
            _codeService = codeService;
            _employeeService = employeeService;
        }
        /// <summary>
        /// 查詢畫面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                ViewBag.JobTitleCodeData = _codeService.GetCodeData("TITLE");

                fun1();
                return View("Index");
            }
            catch (Exception ex)
            {
                eHR.Common.Logger.Write(ex.ToString(), Common.Logger.LogCategoryEnum.Error);
                return View("Error");
            }            
        }

        private void fun1()
        {
            try
            {
                fun2();
            }
            catch (Exception ex)
            {
                eHR.Common.Logger.Write(ex.ToString(), Common.Logger.LogCategoryEnum.Error);
            }
        }

        private void fun2()
        {
            try
            {
                throw new Exception("error fun2");
            }
            catch (Exception ex)
            {
                eHR.Common.Logger.Write(ex.ToString(), Common.Logger.LogCategoryEnum.Error);
                throw ex;
            }
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="employeeSearchArg"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(EmployeeSearchArg employeeSearchArg)
        {

            var result= _employeeService.GetEmployeesByCondition(employeeSearchArg);
            result=_employeeService.MaskBossPayment(result);
            ViewBag.JobTitleCodeData = _codeService.GetCodeData("TITLE");
            ViewBag.SearchResult = result;

            return View();
        }

        /// <summary>
        /// 新增員工畫面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InsertEmployee()
        {
            
            ViewBag.JobTitleCodeData = _codeService.GetCodeData("TITLE");
            ViewBag.CountryCodeData = _codeService.GetCodeData("COUNTRY");
            ViewBag.GenderCodeData = _codeService.GetCodeData("GENDER");
            ViewBag.CityCodeData = _codeService.GetCodeData("CITY");
            ViewBag.EmployeeCodeData = _codeService.GetEmployeeCodeData("");


            return View();
        }

        /// <summary>
        /// 新增員工存檔
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertEmployee(Employee employee)
        {

            if (ModelState.IsValid)
            {
                _employeeService.InsertEmployee(employee);
            }
            ViewBag.JobTitleCodeData = _codeService.GetCodeData("TITLE");
            ViewBag.CountryCodeData = _codeService.GetCodeData("COUNTRY");
            ViewBag.GenderCodeData = _codeService.GetCodeData("GENDER");
            ViewBag.CityCodeData = _codeService.GetCodeData("CITY");
            ViewBag.EmployeeCodeData = _codeService.GetEmployeeCodeData("");
            return View(employee);
        }

        /// <summary>
        /// 修改員工畫面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UpdateEmployee(string id) 
        {
            return View();
        }

        /// <summary>
        /// 刪除員工
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteEmployee(string employeeId) 
        {
            try
            {
                _employeeService.DeleteEmployeeById(employeeId);
                return this.Json(true);
            }
            catch (Exception)
            {
                return this.Json(false);
            }

        }
    }
}
