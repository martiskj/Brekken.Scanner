using System.Linq;
using BrekkenScan.Domain.Infrastructure;

namespace BrekkenScan.Application.Consume
{
    public class GetConsumeService
    {
        private readonly BrekkenScanDbContext _context;

        public GetConsumeService(BrekkenScanDbContext context) => _context = context;

        public ConsumeModel GetConsume() => new ConsumeModel
        {
            Total = _context.Consume.Count(),
            Tonight = _context.Consume.Count(c => c.Date > System.DateTime.Now.AddHours(-13)),
        };
    }
}