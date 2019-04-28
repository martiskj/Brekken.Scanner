using BrekkenScan.Domain;
using System;
using System.Threading.Tasks;

namespace BrekkenScan.Business.Business.Consume.Create
{
    public class ConsumeCreateService
    {
        private readonly ApplicationDbContext database;

        public ConsumeCreateService(ApplicationDbContext database) => this.database = database;

        public async Task Register(ConsumeCreateModel consume)
        {
            await database.Consume.AddAsync(new Domain.Consume
            {
                TimeStamp = DateTime.Now,
                Barcode = consume.Barcode,
            });
            await database.SaveChangesAsync();
        }
    }
}
