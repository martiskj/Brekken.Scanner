using System.Threading.Tasks;
using BrekkenScan.Domain;
using Microsoft.EntityFrameworkCore;

namespace BrekkenScan.Business.Business.Consume.Queries
{
    public class ConsumeViewService
    {
        private readonly ApplicationDbContext _context;

        public ConsumeViewService(ApplicationDbContext context) => _context = context;

        public async Task<ConsumeModel> GetConsume() => new ConsumeModel
        {
            Total = await _context.Consume.CountAsync(),
            Tonight = await _context.Consume.CountAsync(c => c.TimeStamp > System.DateTime.Now.AddHours(-13)),
        };
    }
}