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
        #region LOGON
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
        #endregion

        #region ALLGET        
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


        public async Task<List<Work>> GetWorkAsync()
        {
            List<Work> responseWork = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Work");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseWork = JsonConvert.DeserializeObject<List<Work>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetWorkAsync: " + e);
            }
            return responseWork;
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


        public async Task<List<Ka>> GetKaAsync()
        {
            List<Ka> responseKa = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Ka");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseKa = JsonConvert.DeserializeObject<List<Ka>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetTAsync: " + e);
            }
            return responseKa;
        }

        public async Task<List<Busyo>> GetBusyoAsync()
        {
            List<Busyo> responseBusyo = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Busyoes");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseBusyo = JsonConvert.DeserializeObject<List<Busyo>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetTAsync: " + e);
            }
            return responseBusyo;
        }
        #endregion

        public async Task<Employee> PostEmployeeAsync(Employee employee)
        {
            var jObject = JsonConvert.SerializeObject(employee);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Employee responseEmployee = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Employee", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseEmployee = JsonConvert.DeserializeObject<Employee>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostEmployeeAsync: " + e);
            }
            return responseEmployee;
        }



        public async Task<Work> PostWorkAsync(Work work)
        {
            var jObject = JsonConvert.SerializeObject(work);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Work responseWork = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Work", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseWork = JsonConvert.DeserializeObject<Work>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostWorkAsync: " + e);
            }
            return responseWork;
        }

    }
}