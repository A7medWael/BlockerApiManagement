using BlockerCore.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockerApplication.Services
{
    public class BlockService
    {
        private readonly IBlockRepository _blockRepository;
        public BlockService(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public void Block(string countryCode)
        {
            if (_blockRepository.IsBlocked(countryCode))
                throw new Exception("Already Blocked");
            _blockRepository.Add(countryCode);
        }

        public void UnBlock(string countryCode)
        {
            if (!_blockRepository.IsBlocked(countryCode))
                throw new Exception("Not Found");

            _blockRepository.Remove(countryCode);
        }

        public List<string> GetAll()=>_blockRepository.GetAll();
        
    }
}
