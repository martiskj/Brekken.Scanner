using System;
using System.Threading.Tasks;

namespace BrekkenScan.Domain.Consume.Create
{
    public class CreateConsumeService
    {
        private readonly IConsumeStorage _storage;

        public CreateConsumeService(IConsumeStorage storage)
        {
            _storage = storage;
        }

        public async Task CreateConsume(Models.Consume consume)
        {
            consume.TimeStamp = DateTime.Now;
            await _storage.Add(consume);
        }
    }
}