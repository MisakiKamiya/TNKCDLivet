﻿using TNKCDLivet.Models;
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

        //TNKCDの情報やり取り用
        Task<List<TNKCD>> GetTNKCDAsync();

        //Workの情報やり取り用
        Task<List<Work>> GetWorkAsync();
    }
}
