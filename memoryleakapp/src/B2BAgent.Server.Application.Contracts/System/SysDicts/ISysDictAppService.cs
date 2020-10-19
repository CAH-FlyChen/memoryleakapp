using B2BAgent.Server.Biz.Dtos;
using B2BAgent.Server.System.Dtos;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EV.Application.System.SysDicts
{
    public interface ISysDictAppService: ICrudAppService<SysDictDto,Guid, EVPagedAndSortedResultRequestDto,SysDictCreateOrUpdateDto,SysDictCreateOrUpdateDto>
    {
    }
}