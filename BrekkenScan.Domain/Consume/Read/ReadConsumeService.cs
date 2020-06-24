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

        public async Task<Paginated<Models.ConsumeReading>> Read(ConsumeFilter filter)
        {
            return await _storage.Get(filter);
        }
    }
}
