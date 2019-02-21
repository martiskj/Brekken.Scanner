using System.Threading.Tasks;
using BrekkenScan.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BrekkenScan.Application.Consume
{
    public class GetConsumeService
    {
        private readonly BrekkenScanDbContext _context;

        public GetConsumeService(BrekkenScanDbContext context) => _context = context;

        public async Task<ConsumeModel> GetConsume() => new ConsumeModel
        {
            Total = await _context.Consume.CountAsync(),
            Tonight = await _context.Consume.CountAsync(c => c.Date > System.DateTime.Now.AddHours(-13)),
        };
    }
}