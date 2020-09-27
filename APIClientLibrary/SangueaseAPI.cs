using APIClientLibrary.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Runtime.CompilerServices;

namespace APIClientLibrary
{
    public class SangueaseAPI : ISangueaseAPI
    {
        private string _apiRoute = "https://localhost:44326/api";
        private string _mapQuestAPIKey = "ydnF6HbioBGujYxOiv5bFjy0J4AcZH3w";

        public async Task<List<BDEvent>> GetBDEventsAsync()
        {
            RestClient client = new RestClient($"{_apiRoute}/BDevent");

            RestRequest request = new RestRequest(Method.GET);

            return await Task.Run(
                () =>
                {
                    IRestResponse response = client.Execute(request);

                    Thread.Sleep(3000);

                    CheckForResponseErrors(response);

                    return JsonConvert.DeserializeObject<List<BDEvent>>(response.Content);
                });
        }
        public async Task<BDEvent> GetBDEventByIdAsync(int id)
        {
            RestClient client = new RestClient($"{_apiRoute}/BDevent/{id}");

            RestRequest request = new RestRequest(Method.GET);

            return await Task.Run(
                () =>
                {
                    IRestResponse response = client.Execute(request);

                    Thread.Sleep(3000);

                    CheckForResponseErrors(response);

                    return JsonConvert.DeserializeObject<BDEvent>(response.Content);
                });
        }

        public async Task AddBDEventAsync(BDEvent model)
        {
            RestClient client = new RestClient($"{_apiRoute}/BDevent");

            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(model);

            await Task.Run(
                () =>
                {
                    IRestResponse response = client.Execute(request);

                    Thread.Sleep(3000);

                    CheckForResponseErrors(response);
                });
        }

        public async Task UpdateBDEventAsync(int id, BDEvent model)
        {
            RestClient client = new RestClient($"{_apiRoute}/BDevent/{id}");

            RestRequest request = new RestRequest(Method.PUT);
            request.AddJsonBody(model);

            await Task.Run(
                () =>
                {
                    IRestResponse response = client.Execute(request);

                    Thread.Sleep(3000);

                    CheckForResponseErrors(response);
                });
        }

        public async Task DeleteBDEventAsync(int id)
        {
            RestClient client = new RestClient($"{_apiRoute}/BDevent/{id}");

            RestRequest request = new RestRequest(Method.DELETE);

            await Task.Run(
                () =>
                {
                    IRestResponse response = client.Execute(request);

                    Thread.Sleep(3000);

                    CheckForResponseErrors(response);
                });
        }

        public async Task<string> GetLocationByCoordinatesAsync(decimal latitude, decimal longitude)
        {
            RestClient client = new RestClient(
                "http://www.mapquestapi.com/geocoding/v1/reverse?key="
                + _mapQuestAPIKey
                + "&location=" + latitude + "," + longitude);

            RestRequest request = new RestRequest(Method.GET);

            IRestResponse response = await Task.Run(
                () =>
                {
                    IRestResponse resp = client.Execute(request);

                    Thread.Sleep(3000);

                    CheckForResponseErrors(resp);

                    return resp;
                });

            JsonObject responseObj = (JsonObject)SimpleJson.DeserializeObject(response.Content);

            JsonArray resultsArr = (JsonArray)responseObj["results"];
            if (resultsArr.Count == 0)
            {
                throw new Exception("no matching results found.");
            }
            JsonObject firstResult = (JsonObject)resultsArr[0];

            JsonArray locationsArr = (JsonArray)firstResult["locations"];
            JsonObject firstLocation = (JsonObject)locationsArr[0];

            string fullAddress = "";

            AppendAddressComponent(firstLocation["street"].ToString());
            AppendAddressComponent(firstLocation["adminArea6"].ToString());
            AppendAddressComponent(firstLocation["adminArea5"].ToString());
            AppendAddressComponent(firstLocation["adminArea4"].ToString());
            AppendAddressComponent(firstLocation["adminArea3"].ToString());
            AppendAddressComponent(firstLocation["adminArea1"].ToString());

            if (firstLocation["postalCode"].ToString() != "")
            {
                fullAddress = fullAddress + $"Kode Pos {firstLocation["postalCode"]}";
            }

            return fullAddress;

            void AppendAddressComponent(string addressComponent)
            {
                if (addressComponent != "")
                {
                    fullAddress = fullAddress + $"{addressComponent},";
                }
            }
        }

        private void CheckForResponseErrors(IRestResponse response)
        {
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.NoContent))
            {
                throw new Exception($"{response.StatusCode}\n{response.ErrorException}");
            }
        }
    }
}
