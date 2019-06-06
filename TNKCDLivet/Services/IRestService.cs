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

        Task<List<TNKCD>> GetTNKCDAsync();

        //Workの情報やり取り用
        Task<List<Work>> GetWorkAsync();

        //Employeeの情報やり取り用
        Task<List<Employee>> GetEmployeeAsync();

        //Kaの情報やり取り専用
        Task<List<Ka>> GetKa();
        Task<List<Ka>> PostKaAsync();
        Task LogonAsync(Ka ka);

        //Busyoの情報のやり取り専用
        Task<List<Busyo>> GetBusyoAsync();
    }
}
