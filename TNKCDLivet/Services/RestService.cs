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
        #region Employee        
        #region Get
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
        #endregion
        #region Post
        public async Task<Employee> PostEmployeeAsync(Employee employee)
        {
            //部署の実体を持たなくする
            employee.Ka = null;

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
        #endregion
        #region Del
        public async Task<Employee> DeleteEmployeeAsync(int Id)
        {
            Employee responseEmployee = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Employee/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseEmployee = JsonConvert.DeserializeObject<Employee>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteUserAsync: " + e);
            }
            return responseEmployee;
        }
        #endregion
        public async Task<Employee> PutEmployeeAsync(Employee employee)
        {
            var jObject = JsonConvert.SerializeObject(employee);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Employee responseUser = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Employee/" + employee.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<Employee>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutEmployeeAsync: " + e);
            }
            return responseUser;
        }
        #endregion
        #region Ka        
        #region Get
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
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetKaAsync: " + e);
            }
            return responseKa;
        }
        #endregion
        #region Post
        public async Task<Ka> PostKaAsync(Ka ka)
        {
            var jObject = JsonConvert.SerializeObject(ka);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Ka responseKa = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Ka", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseKa = JsonConvert.DeserializeObject<Ka>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostKaAsync: " + e);
            }
            return responseKa;
        }
        #endregion
        #region Del
        public async Task<Ka> DeleteKaAsync(int Id)
        {
            Ka responseKa = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Ka/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseKa = JsonConvert.DeserializeObject<Ka>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteKaAsync: " + e);
            }
            return responseKa;
        }
        #endregion
        #endregion
        #region Busyo      
        #region Get
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
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetBusyoAsync: " + e);
            }
            return responseBusyo;
        }
        #endregion
        #region Post
        public async Task<Busyo> PostBusyoAsync(Busyo busyo)
        {
            var jObject = JsonConvert.SerializeObject(busyo);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Busyo responsebusyo = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Busyoes", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responsebusyo = JsonConvert.DeserializeObject<Busyo>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostBusyoAsync: " + e);
            }
            return responsebusyo;
        }
        #endregion
        #region Del
        public async Task<Busyo> DeleteBusyoAsync(int Id)
        {
            Busyo responseBusyo = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Busyoes/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseBusyo = JsonConvert.DeserializeObject<Busyo>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteBusyoAsync: " + e);
            }
            return responseBusyo;
        }
        #endregion

        #endregion
        #region TNKCD
        #region Get
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
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetTNKCDAsync: " + e);
            }
            return responseTNKCD;
        }
        #endregion
        #region Post
        public async Task<TNKCD> PostTNKCDAsync(TNKCD TNKCD)
        {
            var jObject = JsonConvert.SerializeObject(TNKCD);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            TNKCD responseTNKCD = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/TNKCD", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseTNKCD = JsonConvert.DeserializeObject<TNKCD>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostTNKCDAsync: " + e);
            }
            return responseTNKCD;
        }
        #endregion
        #region Del
        public async Task<TNKCD> DeleteTNKCDAsync(int Id)
        {
            TNKCD responseTNKCD = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/TNKCD/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseTNKCD = JsonConvert.DeserializeObject<TNKCD>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteTNKCDAsync: " + e);
            }
            return responseTNKCD;
        }
        #endregion
        #endregion
        #region Work      
        #region Get
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
        #endregion
        #region Post
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
        #endregion
        public async Task<Work> PutWorkAsync(Work work)
        {
            var jObject = JsonConvert.SerializeObject(work);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Work responseUser = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Work/" + work.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<Work>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutWorkAsync: " + e);
            }
            return responseUser;
        }
        #region Del

        public async Task<Work> DeleteWorkAsync(int Id)
        {
            Work responseWork = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Work/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseWork = JsonConvert.DeserializeObject<Work>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteWorkAsync: " + e);
            }
            return responseWork;
        }
        #endregion
        #endregion
    }
}