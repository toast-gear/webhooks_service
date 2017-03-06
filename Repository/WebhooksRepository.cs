using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using webhooks_service.Singletons;
using webhooks_service.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace webhooks_service.Repository
{
    public class WebhooksRepository
    {

        HttpClient Client = HttpClientSingleton.Instance();
        public async Task<HttpResponseMessage> HttpStartPipelinePostRequestSync(PushRoot PushRoot)
        {
            // TO DO : WORK OUT HOW TO GET THE PIPELINE NAME FROM THE PUSH EVEN DETAILS
            string Json = JsonConvert.SerializeObject(PushRoot);
            string PipelineName = "";

            StringContent StringContent = new StringContent("", Encoding.UTF8, "application/vnd.go.cd.v1+json");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Confirm", "true");

            string GocdBaseUrl = "http://localhost:8153/go";
            string GocdUrl = Path.Combine(GocdBaseUrl, string.Format("api/pipelines/{0}/schedule", PipelineName)).Replace("\\", "/");
            return await Client.PostAsync(GocdUrl, StringContent);
        }
    }
}