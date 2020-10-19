using B2BAgent.Server.Biz.Dtos;
using EV;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace B2BAgent.Server
{
    public interface IERPBrandAppService : ICrudAppService<ERPBrandDto, Guid, EVPagedAndSortedResultRequestDto, ERPBrandCreateDto,
        ERPBrandDto>
    {
    }
}
