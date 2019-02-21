using BrekkenScan.Domain.Infrastructure;
using System;
using System.Threading.Tasks;

namespace BrekkenScan.Business.Business.Consume.Commands
{
    public class PostConsumeService
    {
        private readonly BrekkenScanDbContext _context;

        public PostConsumeService(BrekkenScanDbContext context) => _context = context;

        public async Task PostConsume(string barcode)
        {
            await _context.Consume.AddAsync(new Domain.Entities.Consume
            {
                TimeStamp = DateTime.Now,
                Barcode = barcode,
            });
            await _context.SaveChangesAsync();
        }
    }
}
