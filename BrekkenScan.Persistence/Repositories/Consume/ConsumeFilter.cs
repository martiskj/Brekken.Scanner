using System.Linq;

namespace BrekkenScan.Persistence.Repositories.Consume
{
    public static class ConsumeFilter
    {
        public static IQueryable<Domain.Models.Consume> Filter(this IQueryable<Domain.Models.Consume> q, Domain.ConsumeFilter filter)
        {
            if (filter.From.HasValue)
            {
                q = q.Where(c => c.TimeStamp >= filter.From.Value);
            }

            return q;
        }
    }
}
