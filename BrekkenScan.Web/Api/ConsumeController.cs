﻿using BrekkenScan.Domain;
using BrekkenScan.Domain.Consume.Create;
using BrekkenScan.Domain.Consume.Read;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<Paginated<Domain.Models.ConsumeReading>>> ReadConsume([FromServices] ReadConsumeService consume)
        {
            return Ok(await consume.Read());
        }
    }

    public class CreateConsumeRequest
    {
        public string Barcode { get; set; }
    }
}
