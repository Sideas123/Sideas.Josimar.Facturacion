using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sideas.Josimar.Facturacion.Models;
using Sideas.Josimar.Facturacion.Services.Interfaces;
using System.Text.Json;

namespace Sideas.Josimar.Facturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawController : ControllerBase
    {
        private readonly IRawService _rwService;
        private readonly ILogger _logger;
        private readonly ITransactionLogService _transactionLogService;
        private string _id;

        public RawController(IRawService rwService, ILoggerFactory logger, ITransactionLogService transactionLogService)
        {
            _rwService = rwService;
            _logger = logger.CreateLogger<RawController>();
            _transactionLogService = transactionLogService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Save([FromBody] RawRequest request) 
        {
            try
            {
                using var jsonDoc = JsonDocument.Parse(request.payload);
                var root = jsonDoc.RootElement;
                var metadata = root.GetProperty("metadata");
               _id= metadata.GetProperty("id").GetString();

                _transactionLogService.AddLog(_id);

                
                _logger.LogDebug("Start save RawData");
                if(string.IsNullOrWhiteSpace(request.payload))
                {
                    return BadRequest("required Payload");
                }
                if (string.IsNullOrWhiteSpace(request.entityName))
                {
                    return BadRequest("required EntityName");
                }
                _rwService.Save(request.payload, request.entityName);
                _logger.LogDebug("End save RawData");
                _transactionLogService.UpdateLog(_id, true);
                return Ok(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _transactionLogService.UpdateLog(_id, false);
                return BadRequest($"Failed to save {ex.Message}");
            }
        }
    }
}
