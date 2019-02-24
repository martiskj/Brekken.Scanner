using System.Threading.Tasks;
using BrekkenScan.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BrekkenScan.Application.Consume
{
    public class ViewConsumeService
    {
        private readonly BrekkenScanDbContext _context;

        public ViewConsumeService(BrekkenScanDbContext context) => _context = context;

        public async Task<ConsumeModel> GetConsume() => new ConsumeModel
        {
            Total = await _context.Consume.CountAsync(),
            Tonight = await _context.Consume.CountAsync(c => c.TimeStamp > System.DateTime.Now.AddHours(-13)),
        };
    }
}