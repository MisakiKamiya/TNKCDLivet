using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TNKCDLivet.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace TNKCDLivet.Services
{
    class RestService : IRestService
    {
        private HttpClient Client;
        private string BaseUrl;

        public RestService()
        {
            this.Client = new HttpClient();
            this.BaseUrl = "https://localhost:5000";
        }
        

        public async Task<Employee> LogonAsync(Employee employee)
        {
            var jObject = JsonConvert.SerializeObject(employee);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Employee responseEmployee = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Logon", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseEmployee = JsonConvert.DeserializeObject<Employee>(responseContent);
                }
            }
            catch (Exception e)
            {
                // TODO
                System.Diagnostics.Debug.WriteLine("Exception in RestService.LogonAsync: " + e);
            }
            return responseEmployee;
        }

        public async Task<List<TNKCD>> GetTNKCDAsync()
        {
            List<TNKCD> responseTNKCD = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/TNKCD");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseTNKCD = JsonConvert.DeserializeObject<List<TNKCD>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetTAsync: " + e);
            }
            return responseTNKCD;
        }

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            List<Employee> responseEmployee = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Employee");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseEmployee = JsonConvert.DeserializeObject<List<Employee>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetEmployeeAsync: " + e);
            }
            return responseEmployee;
        }
    }
}


