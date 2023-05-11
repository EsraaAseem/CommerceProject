using AspCoreCommerce.Model;
using AspCorePartCommerce.DataAccess.PaymentServ;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace AspCorePartCommerce.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController
    {
        private readonly IPaymentService _paymentService;
        private const string WhSecret = "";
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomBasket>>CreateOrUpdateBasket(string basketId)
        {
            return await _paymentService.AddOrUpdatePaymentIntent(basketId);
        }
       /* [HttpPost("{webhook}")]
        public async Task<ActionResult> StripWebhook()
        {
            var json=await new StreamReader(HttpContext.R).ReadToEndAsync();
        }*/

    }
}
