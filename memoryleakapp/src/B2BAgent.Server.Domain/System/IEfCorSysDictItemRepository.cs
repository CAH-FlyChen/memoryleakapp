using EV.Domain.System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EV
{
    public interface IEfCorSysDictItemRepository : IRepository<SysDictItem, Guid>
    {
        Task<List<SysDictItem>> GetListByTypeCodeAsync(string code);
        Task<SysDictItem> GetByCodeAsync(string code);
    }
}