using BrekkenScan.Domain.Models;
using System.Threading.Tasks;

namespace BrekkenScan.Domain
{
    public interface IConsumeStorage
    {
        Task Add(Models.Consume consume);

        Task<ConsumeReadModel> GetConsume(ConsumeFilter filter);

        Task<Paginated<Models.ConsumeReading>> Get(ConsumeFilter filter);
    }
}
