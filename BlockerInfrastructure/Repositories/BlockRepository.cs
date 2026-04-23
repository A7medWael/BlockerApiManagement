using BlockerCore.InterFaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockerInfrastructure.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        private readonly ConcurrentDictionary<string, string> _Dictionary=new ConcurrentDictionary<string, string>();
       
        public void Add(string countryCode)=>_Dictionary.TryAdd(countryCode, countryCode);
        
        public List<string> GetAll()=>_Dictionary.Keys.ToList();
       
        public bool IsBlocked(string countryCode) => _Dictionary.ContainsKey(countryCode);
        

        public void Remove(string countryCode)=>_Dictionary.TryRemove(countryCode,out _);
        
    }
}
