using B2BAgent.Server.Biz.Dtos;
using B2BAgent.Server.System.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EV.Application.System.SysDictItems
{
    public interface ISysDictItemAppService: ICrudAppService<SysDictItemDto,Guid, EVPagedAndSortedResultRequestDto,SysDictItemCreateOrUpdateDto, SysDictItemCreateOrUpdateDto>
    {
        /// <summary>
        /// 根据字典类型代码查询字典条目
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<SysDictItemDto>> GetListByTypeCodeAsync(GetListByTypeCodeInput input);
    }
}