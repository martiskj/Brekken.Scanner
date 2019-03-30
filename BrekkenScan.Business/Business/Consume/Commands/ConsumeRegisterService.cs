using BrekkenScan.Domain;
using System;
using System.Threading.Tasks;

namespace BrekkenScan.Business.Business.Consume.Commands
{
    public class ConsumeRegisterService
    {
        private readonly ApplicationDbContext _context;

        public ConsumeRegisterService(ApplicationDbContext context) => _context = context;

        public async Task Register(ConsumeModel consume)
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
