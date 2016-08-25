using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using yaus.Services;
using yaus.Storage;
using yaus.ViewModels.In;
using yaus.ViewModels.Out;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace yaus.Controllers.api
{
    [Route("api/[controller]")]
    public class UrlController : Controller
    {
        private readonly ILogger _logger;
        private readonly ISlotStorage _slotStorage;
        private readonly IUrlStore _urlStore;

        public UrlController(ILoggerFactory loggerFactory, ISlotStorage slotStorage, IUrlStore urlStore)
        {
            _logger = loggerFactory.CreateLogger<UrlController>();
            _slotStorage = slotStorage;
            _urlStore = urlStore;
        }

        [HttpGet("{token}", Name = "GetByToken")]
        public async Task<IActionResult> Get(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return this.BadRequest("a url to shorten is required.");

            var fullUrl = await _urlStore.Fetch(token);

            if (string.IsNullOrWhiteSpace(fullUrl))
                return this.NotFound("No url registered for that token");

            var responseModel = new FetchUrlResponse
            {
                FullUrl = fullUrl,
                Token = token
            };

            return this.Ok(responseModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ShortenUrlRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.FullUrl))
                return this.BadRequest("a url to shorten is required.");

            if (!request.IsValid())
                return this.BadRequest("the supplied url is not valid.");

            try
            {
                var slotNumber = await this._slotStorage.GetNextAvailableSlot();
                var shorten = SlotEncoder.Encode(slotNumber);
                await this._urlStore.Store(shorten, request.FullUrl);

                var responseModel = new ShortenUrlResponse {Token = shorten};

                var fetchUrl = this.Url.Link("GetByToken", new {Token = shorten});

                return this.Created(fetchUrl, responseModel);
            }
            catch (Exception ex)
            {
                this._logger.LogError(1, ex, "Unable to register url");
                return this.StatusCode(500, "Unable to register url");
            }

        }

    }
}
