using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrekkenScan.Domain.Consume.Read
{
    public class ReadConsumeService
    {
        private readonly IConsumeStorage _storage;

        public ReadConsumeService(IConsumeStorage storage)
        {
            _storage = storage;
        }

        public async Task<Paginated<Models.ConsumeReading>> Read()
        {
            var a = await _storage.Get(new ConsumeFilter
            {
                From = DateTime.Now.AddHours(-13),
            });

            return a;
        }
    }
}
