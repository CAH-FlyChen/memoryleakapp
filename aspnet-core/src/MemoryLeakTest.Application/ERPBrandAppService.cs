using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using B2BAgent.Server.Domains;
using System.Threading.Tasks;
using B2BAgent.Server.Biz.Dtos;
using Volo.Abp.Application.Dtos;

namespace B2BAgent.Server
{
    /// <summary>
    /// ERP品牌服务
    /// </summary>
    public class ERPBrandAppService : CrudAppService<Domains.ERPBrand, ERPBrandDto, Guid, PagedAndSortedResultRequestDto,
        ERPBrandCreateDto, ERPBrandDto>, IERPBrandAppService
    {
        public ERPBrandAppService(IRepository<Domains.ERPBrand, Guid> repository)
    : base(repository)
        {

        }
    }
}
