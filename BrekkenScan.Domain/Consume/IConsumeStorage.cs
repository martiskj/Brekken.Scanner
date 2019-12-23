using BrekkenScan.Domain.Models;
using System.Threading.Tasks;

namespace BrekkenScan.Domain
{
    public interface IConsumeStorage
    {
        Task Add(Consume consume);

        Task<ConsumeReadModel> Get(ConsumeFilter filter);
    }
}
