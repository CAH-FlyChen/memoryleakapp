using EV.Domain.System;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using System.Linq;
using EV;
using B2BAgent.Server.Biz.Dtos;
using B2BAgent.Server.System.Dtos;
using Volo.Abp.Linq;

namespace EV.Application.System.SysDictItems
{
    /// <summary>
    /// 系统字典条目
    /// </summary>
    public class SysDictItemAppService : CrudAppService<SysDictItem, SysDictItemDto,Guid, EVPagedAndSortedResultRequestDto, SysDictItemCreateOrUpdateDto, SysDictItemCreateOrUpdateDto>, ISysDictItemAppService
    {
        public SysDictItemAppService(IRepository<SysDictItem, Guid> repository)
    : base(repository)
        {
        }
        /// <summary>
        /// 根据类型代码查询
        /// </summary>
        /// <param name="input">过滤条件</param>
        /// <returns></returns>
        public async Task<List<SysDictItemDto>> GetListByTypeCodeAsync(GetListByTypeCodeInput input)
        {
            await CheckGetListPolicyAsync();

            var entities = Repository.WithDetails(t=>t.SysDict).Where(t=>t.SysDict.Code== input.DicTypeCode);

            return entities.Select(MapToGetListOutputDto).ToList();
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="input">分页条件</param>
        /// <returns></returns>
        public async override Task<PagedResultDto<SysDictItemDto>> GetListAsync(EVPagedAndSortedResultRequestDto input)
        {
            //await CheckGetListPolicyAsync();

            //var query = CreateFilteredQuery(input);

            //var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            //query = ApplySorting(query, input);
            //query = ApplyPaging(query, input);

            //var entities = Repository.WithDetails(t => t.SysDict).PageBy(input).ToList();

            //return new PagedResultDto<SysDictItemDto>(
            //    totalCount,
            //    entities.Select(MapToGetListOutputDto).ToList()
            //);
            return null;
        }
        /// <summary>
        /// 删除字典条目
        /// </summary>
        /// <param name="id">字典条目Id</param>
        /// <returns></returns>
        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
        /// <summary>
        /// 更新字典条目
        /// </summary>
        /// <param name="id">字典条目id</param>
        /// <param name="input">字典条目内容</param>
        /// <returns></returns>
        public override Task<SysDictItemDto> UpdateAsync(Guid id, SysDictItemCreateOrUpdateDto input)
        {
            return base.UpdateAsync(id, input);
        }
        /// <summary>
        /// 创建字典条目
        /// </summary>
        /// <param name="input">字典条目对象</param>
        /// <returns></returns>
        public override Task<SysDictItemDto> CreateAsync(SysDictItemCreateOrUpdateDto input)
        {
            return base.CreateAsync(input);
        }
        /// <summary>
        /// 获取字典条目
        /// </summary>
        /// <param name="id">字典条目Id</param>
        /// <returns></returns>
        public override Task<SysDictItemDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }
    }
}
