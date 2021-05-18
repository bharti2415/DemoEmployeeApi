using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApi.Models;

namespace DemoApi.DataAccessLayer
{
    public  interface IEmployeeDataAccessLayer
    {
         IList<EmpModel> GetALL();
    }
}
