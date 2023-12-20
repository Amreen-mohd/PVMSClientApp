using Newtonsoft.Json;
using PVMSClientApp.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

namespace PVMSClientApp.Models.BL
{
    public class DbValidation
    {
        public List<State> validateState()
        {
            List<State> states = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/");
                var responseTalk = client.GetAsync("Validation/GetStates");
                responseTalk.Wait();
                var result = responseTalk.Result;
                var readData = result.Content.ReadAsStringAsync().Result;
                if(result.IsSuccessStatusCode)
                {
                    states = JsonConvert.DeserializeObject<List<State>>(readData);
                }
                else
                {

                }
            }
            return states;
        }
        public List<city> validateCity(string sId)
        {

            List<city> cities = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/");
                var responseTalk = client.GetAsync("Validation/GetCities?sId="+sId);
                responseTalk.Wait();
                var result = responseTalk.Result;
                var readData = result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    cities = JsonConvert.DeserializeObject<List<city>>(readData);
                }
                else
                {

                }
            }
            return cities;
        }
        
        public List<Visa_form> getvisa()
        {
            List<Visa_form> visaForms = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/");
                var responseTalk = client.GetAsync("Validation/GetVisaForms");
                responseTalk.Wait();
                var result = responseTalk.Result;
                var readData = result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    visaForms = JsonConvert.DeserializeObject<List<Visa_form>>(readData);
                }
                else
                {

                }
            }
            return visaForms;
        }
        public List<Visa_type> getvisaType1()
        {
            List<Visa_type> visaTypes = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/");
                var responseTalk = client.GetAsync("Validation/GetVisaTypes");
                responseTalk.Wait();
                var result = responseTalk.Result;
                var readData = result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    visaTypes = JsonConvert.DeserializeObject<List<Visa_type>>(readData);
                }
                else
                {

                }
            }
            return visaTypes;
        }
        public List<string> GetActiveVisaCountries(string res)
        {
            List<string> ActiveVisaCountries = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/");
                var responseTalk = client.GetAsync("VisaCancellation/GetCountries?res="+res);
                responseTalk.Wait();
                var result = responseTalk.Result;
                var readData = result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    ActiveVisaCountries = JsonConvert.DeserializeObject<List<string>>(readData);
                }
                else
                {

                }
            }
            return ActiveVisaCountries;
        }
        public string GetVisaIdByCountry(string res)
        {
            string vid=null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/");
                var responseTalk = client.GetAsync("VisaCancellation/GetVisaId?res=" + res);
                responseTalk.Wait();
                var result = responseTalk.Result;
                var readData = result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    vid = JsonConvert.DeserializeObject<string>(readData);
                }
                else
                {

                }
            }
            return vid;
        }

        public string GetVisaCountryValidation(visa v)
        {
            string vid = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44386/api/");
                var responseTalk = client.PostAsJsonAsync<visa>("VisaCancellation/GetVisaCountryValidation",v);
                responseTalk.Wait();
                var result = responseTalk.Result;
                var readData = result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    vid = JsonConvert.DeserializeObject<string>(readData);
                }
                else
                {

                }
            }
            return vid;
        }

    }
}