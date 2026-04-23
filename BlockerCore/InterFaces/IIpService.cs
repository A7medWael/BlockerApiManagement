using BlockerCore.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockerCore.InterFaces
{
    public interface IIpService
    {
        Task<IpResponse> GetCountryAsync(string ip);
    }
}
