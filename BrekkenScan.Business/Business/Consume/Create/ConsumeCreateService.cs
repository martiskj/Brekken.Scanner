using BrekkenScan.Domain;
using System;
using System.Threading.Tasks;

namespace BrekkenScan.Business.Business.Consume.Create
{
    public class ConsumeCreateService
    {
        private readonly ApplicationDbContext _context;

        public ConsumeCreateService(ApplicationDbContext context) => _context = context;

        public async Task Register(ConsumeCreateModel consume)
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
