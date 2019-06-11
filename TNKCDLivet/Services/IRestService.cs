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


        //Workの情報やり取り用
        Task<List<Work>> GetWorkAsync();
        Task<Work> PostWorkAsync(Work work);
        Task<Work> DeleteWorkAsync(int Id);
        Task<Work> PutWorkAsync(Work work);
        

        //Employeeの情報やり取り用
        Task<List<Employee>> GetEmployeeAsync();
        Task<Employee> PostEmployeeAsync(Employee employee);
        Task<Employee> DeleteEmployeeAsync(int Id);


        //Busyoの情報やり取り用
        Task<List<Busyo>> GetBusyoAsync();
        Task<Busyo> PostBusyoAsync(Busyo busyo);
        Task<Busyo> DeleteBusyoAsync(int Id);


        //Kaの情報やり取り用
        Task<List<Ka>> GetKaAsync();
        Task<Ka> PostKaAsync(Ka ka);
        Task<Ka> DeleteKaAsync(int Id);


        //TNKCDの情報やり取り用
        Task<List<TNKCD>> GetTNKCDAsync();
        Task<TNKCD> PostTNKCDAsync(TNKCD TNKCD);
        Task<TNKCD> DeleteTNKCDAsync(int Id);


    }
}
