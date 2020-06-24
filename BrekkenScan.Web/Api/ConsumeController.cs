using BrekkenScan.Domain;
using BrekkenScan.Domain.Consume.Create;
using BrekkenScan.Domain.Consume.Read;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrekkenScan.Web.Api
{
    public class ConsumeController : Controller
    {
        [HttpPost("api/consume")]
        public async Task<IActionResult> CreateConsume([FromBody] CreateConsumeRequest request, [FromServices] CreateConsumeService consume)
        {
            await consume.CreateConsume(new Domain.Models.Consume
            {
                Barcode = request.Barcode
            });

            return Created(string.Empty, null);
        }

        [HttpGet("api/consume")]
        public async Task<ActionResult<Paginated<Domain.Models.ConsumeReading>>> ReadConsume([FromServices] ReadConsumeService consume, [FromQuery] ReadConsumeQuery query)
        {
            return Ok(await consume.Read(new ConsumeFilter
            {
                From = query.From
            }));
        }
    }

    public class ReadConsumeQuery
    {
        public System.DateTime? From { get; set; }
    }

    public class CreateConsumeRequest
    {
        public string Barcode { get; set; }
    }
}
