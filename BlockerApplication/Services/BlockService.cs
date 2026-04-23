using BlockerApplication.pagedList;
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
            if (string.IsNullOrWhiteSpace(countryCode))
                throw new ArgumentException("Country code required");

            if (_blockRepository.IsBlocked(countryCode))
                throw new Exception("Already Blocked");
            _blockRepository.Add(countryCode);
        }

        public void UnBlock(string countryCode)
        {
            if (!_blockRepository.IsBlocked(countryCode))
                throw new Exception("Not found");

            if (!_blockRepository.IsBlocked(countryCode))
                throw new Exception("Not Found");

            _blockRepository.Remove(countryCode);
        }

        public PagedResult<string> GetAll(int page, int pageSize, string search)
        {
            var data = _blockRepository.GetAll();

            if (!string.IsNullOrEmpty(search))
                data = data.Where(x => x.Contains(search.ToUpper())).ToList();

            var total = data.Count;

            var items = data
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<string>
            {
                Items = items,
                TotalCount = total
            };
        }

    }
}
