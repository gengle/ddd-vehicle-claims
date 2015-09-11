using System.Collections.Generic;
using System.Linq;

namespace Domain.Infrastructure.Persistance
{
    public class IdentityMap
    {
        private readonly Dictionary<object, object> Map = new Dictionary<object, object>();

        public void Delete(object id)
        {
            Map.Remove(id);
        }

        public void Insert(dynamic poco)
        {
            Map[poco.Id] = poco;
        }

        public object Find(object id)
        {
            if (Map.ContainsKey(id))
                return Map[id];
            return null;
        }

        public IReadOnlyCollection<object> GetAll()
        {
            return this.Map.Select(x => x.Value).ToList();
        } 
    }
}