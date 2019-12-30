using BrekkenScan.Domain.Models;
using System.Threading.Tasks;

namespace BrekkenScan.Domain
{
    public interface IConsumeStorage
    {
        Task Add(Models.Consume consume);

        Task<Paginated<ConsumeReading>> Get(ConsumeFilter filter);
    }
}
