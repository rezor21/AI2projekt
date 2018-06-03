using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AI2raportyMobile
{
    public class RestService 
    {


        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }


        private string url= "https://ai2projekt.azurewebsites.net/api/transactions";
        private HttpClient client;
        private List<Transaction> teams;


        public async Task<List<Transaction>> RefreshDataAsync()
        {

            List<Transaction> items = null;
  var uri = new Uri(string.Format(url, string.Empty));
 
  var response = await client.GetStringAsync(uri);
            
            
                var content = response;
                items = JsonConvert.DeserializeObject<List<Transaction>>(content);
            
            return items;
}


        public List<Transaction> TeamAll()
        {
            url = "https://ai2projekt.azurewebsites.net/api/transactions";
            client = new HttpClient();
            teams = new List<Transaction>();
            try
            {
                List<Transaction> teamList = new List<Transaction>();
                string jsonStringChris = "";

                var task = client.GetStringAsync(url).ContinueWith((taskResponse) => {
                    var response = taskResponse;
                    var jsonString = response;

                    jsonString.Wait();
                    jsonStringChris = jsonString.Result;
                    teamList = JsonConvert.DeserializeObject<List<Transaction>>(jsonString.Result);
                    
                });

                task.Wait();

                teams = teamList;

                return teams;

            }
            catch (Exception Ex)
            {
                Debug.WriteLine("in exceptionHandling");
                Debug.WriteLine(Ex.Message);
                throw;
            }
        }

        public async Task SaveTransactionAsync(Transaction item)
        {
            
            var uri = "https://ai2projekt.azurewebsites.net/api/transactions";

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            
                response = await client.PostAsync(uri, content);
            

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"             TodoItem successfully saved.");

            }
        }
    }

}

