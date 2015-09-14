using System.IO;
using System.Linq;
using Domain.Services;
using Newtonsoft.Json;

namespace Domain.Infrastructure.Persistance
{
    public class FakeWorkspace:IWorkspace
    {
        private IdentityMap IdentityMap;
        private readonly string _dataFile;

        public IQueryable<T> GetAll<T>() where T : class
        {
            return IdentityMap.GetAll().Cast<T>().AsQueryable();
        }

        public FakeWorkspace(string dataFile)
        {
            _dataFile = dataFile;
            IdentityMap = LoadMap();
        }

        private IdentityMap LoadMap()
        {
            var map = new IdentityMap();
            foreach (var data in File.ReadLines(this._dataFile))
            {
                var o = JsonConvert.DeserializeObject(data, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                });
                map.Insert(o);
            }
            return map;
        }

        public T GetById<T>(object id) where T : class
        {
            return (T) IdentityMap.Find(id);
        }

        public void Attach<T>(T poco) where T : class
        {
            IdentityMap.Insert(poco);
        }

        public void Commit()
        {
            using (var fs = File.CreateText(_dataFile))
            {
                foreach (var item in IdentityMap.GetAll())
                {
                    var payload = JsonConvert.SerializeObject(item, new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });
                    fs.WriteLine(payload);
                }
            }
            IdentityMap = LoadMap();
        }
    }
}