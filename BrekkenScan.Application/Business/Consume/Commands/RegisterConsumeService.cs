using BrekkenScan.Domain.Infrastructure;
using System;
using System.Threading.Tasks;

namespace BrekkenScan.Business.Business.Consume.Commands
{
    public class RegisterConsumeService
    {
        private readonly BrekkenScanDbContext _context;

        public RegisterConsumeService(BrekkenScanDbContext context) => _context = context;

        public async Task RegisterConsume(ConsumeModel consume)
        {
            await _context.Consume.AddAsync(new Domain.Entities.Consume
            {
                TimeStamp = DateTime.Now,
                Barcode = consume.Barcode,
            });
            await _context.SaveChangesAsync();
        }
    }
}
