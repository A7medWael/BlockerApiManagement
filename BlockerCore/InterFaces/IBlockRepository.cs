using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockerCore.InterFaces
{
    public interface IBlockRepository
    {
        bool IsBlocked(string countryCode);
        void Add(string countryCode);
        void Remove(string countryCode);
        List<string> GetAll();
    }
}
