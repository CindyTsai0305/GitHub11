using eHR.Dao;
using eHR.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHR.Service
{
    public class CodeService : ICodeService
    {

        eHR.Dao.ICodeDao _codeDao;
        public CodeService(eHR.Dao.ICodeDao codeDao) 
        { 
            _codeDao = codeDao;
        }
        /// <summary>
        /// 取得代碼資料
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<SelectListItem> GetCodeData(string type)
        {
            //eHR.Dao.CodeDao codeDao = new eHR.Dao.CodeDao();
            //return codeDao.GetCodeData(type);
            //eHR.Dao.CodeApiDao codeApiDao= new eHR.Dao.CodeApiDao();

            //eHR.Dao.CodeFactory codeFactory = new eHR.Dao.CodeFactory();
            //eHR.Dao.ICodeDao codeDao = codeFactory.GetCodeDao();

            return _codeDao.GetCodeData(type);
        }


        /// <summary>
        /// 取得員工資料(代碼)
        /// </summary>
        /// <param name="ignoreEmployeeId"></param>
        /// <returns></returns>
        public List<SelectListItem> GetEmployeeCodeData(string ignoreEmployeeId)
        {
            //eHR.Dao.CodeDao codeDao = new eHR.Dao.CodeDao();
            return _codeDao.GetEmployeeCodeData(ignoreEmployeeId);

        }


    }
}
