using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using webhooks_service.Models;
using webhooks_service.Repository;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webhooks_service.Controllers
{
    [Route("api/v1/[controller]")]
    public class WebhooksController : Controller
    {
        private readonly WebhooksRepository WebhooksRepo;
        public WebhooksController()
        {
            WebhooksRepo = new WebhooksRepository();
        }
        [HttpPost]
        [Route("push")]
        public async Task<HttpResponseMessage> PushEvent([FromBody] PushRoot PushEventModel)
        {
            try
            {
                return await WebhooksRepo.HttpStartPipelinePostRequestSync(PushEventModel);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
