using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ELE400_DeteX_WebApp
{
    public class AzureAPI
    {
        public async Task AuthorizeMatricisAPI()
        {
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

            var AuthPacket = new ELE400_DeteX_WebApp.models.Authorization(response);

            // TO DO: initialize the Authorization class and obtain token.
        }

        public async Task GetDataMatricis()
        {
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

            // ToDo:  Initialize the Data class and obtain data from device to display.
        }
    }
}

