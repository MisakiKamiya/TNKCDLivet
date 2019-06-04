using TNKCDLivet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNKCDLivet.Services
{
    interface IRestService
    {
        // Logon REST API Client
        Task<Employee> LogonAsync(Employee employee);

        
    }
}
