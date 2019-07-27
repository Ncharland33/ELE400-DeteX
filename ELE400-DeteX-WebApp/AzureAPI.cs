using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ELE400_DeteX_WebApp
{
    public class AzureAPI
    {
        private string AuthorizeMatricisAPI()
        {
            /*TO-DO:  Will Read JSON file and fill in Paramater automatically. */
            //var path = Path.Combine(Directory.GetCurrentDirectory(), @"Json_Info\auth_info.json");
            //var login_info = JsonConvert.DeserializeObject<string>(File.ReadAllText(path));  // Read info from external file, can contain all user information.
            
            /* Generate Authentification request to API. */ 
            var client = new RestClient("https://matricis-iot-api-app.azurewebsites.net/api/login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("content-length", "82");
            request.AddHeader("accept-encoding", "gzip, deflate");
            request.AddHeader("Host", "matricis-iot-api-app.azurewebsites.net");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\r\n\t\"email\": \"benoit.lemieux.1@ens.etsmtl.ca\",\r\n    \"password\": \"TeamDeteX@430\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var AuthPacket = new ELE400_DeteX_WebApp.models.Authorization();
            JsonConvert.PopulateObject(response.Content, AuthPacket);
            var token = AuthPacket.token;

            return token;
        }
        private string BuildURL(DateTime LastRequest)
        {
            string BaseURL = "https://matricis-iot-api-app.azurewebsites.net/api/telemetry?deviceId=ele400-equipe4&startTime=";

            /* Obtain current time to stamp the EndTime parameter of the URL. */
            TimeSpan t2 = DateTime.UtcNow - new DateTime(1970,1,1);       //Unix-epoch.  
            int secondsSinceEpoch = (int)t2.TotalSeconds;
            string EpochEnd = secondsSinceEpoch.ToString();

            /* Obtain Epoch value for last request to stamp the StartTime parameter of the URL. */
            LastRequest = DateTime.UtcNow.AddMinutes(-5);                 // Will obtain data from 5 minutes ago.  NOTE:  REMOVE WHEN ACTUALLY USING LastRequest STAMPS.
            TimeSpan t1 = LastRequest - new DateTime(1970, 1, 1);         // Unix-epoch.
            int secondsSinceStartEpoch = (int)t1.TotalSeconds;
            string EpochStart = secondsSinceStartEpoch.ToString();

            /* Concatenate strings to return full URL. */
            string URL = String.Concat(BaseURL, EpochStart, "&endTime=", EpochEnd);

            return URL;
        }
        public async Task GetDataMatricis()
        {
            var token = this.AuthorizeMatricisAPI();                 // Authorize API.
            var DateStampURL = this.BuildURL(DateTime.MinValue);     // Create URL.  NOTE:  Need to figure out data request intervals.
            var client = new RestClient(DateStampURL);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "matricis-iot-api-app.azurewebsites.net");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Authorization", String.Concat("Bearer ", token));    // Authorization-type: Bearer token.
            IRestResponse response = client.Execute(request);

            var DataPacket = new ELE400_DeteX_WebApp.models.Data();
            JsonConvert.PopulateObject(response.Content, DataPacket);   
            var data = DataPacket.RawData;
            // To-Do:  Parse data properly, will need to fix model once we start obtaining data.
            // To-Do:  Return data.
        }
    }
}

