using EV.Domain.System;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;
using B2BAgent.Server.Biz.Dtos;
using B2BAgent.Server.System.Dtos;

namespace EV.Application.System.SysDicts
{
    /// <summary>
    /// 系统字典
    /// </summary>
    public class SysDictAppService : CrudAppService<SysDict,SysDictDto,Guid, EVPagedAndSortedResultRequestDto,SysDictCreateOrUpdateDto,SysDictCreateOrUpdateDto>, ISysDictAppService
    {
        IRepository<SysDictItem, Guid> repositoryItem;
        public SysDictAppService(IRepository<SysDict, Guid> repository, IRepository<SysDictItem, Guid> repositoryItem)
    : base(repository)
        {
            this.repositoryItem = repositoryItem;
        }
        /// <summary>
        /// 通过Id获取字典
        /// </summary>
        /// <param name="id">字典Id</param>
        /// <returns></returns>
        public override Task<SysDictDto> GetAsync(Guid id)
        {
            var r = Repository.WithDetails(t => t.SysDictItems).Single(t => t.Id == id);
            return Task.FromResult(MapToGetOutputDto(r));
        }

        #region 自有方法
        /// <summary>
        /// 创建字典
        /// </summary>
        /// <param name="input">字典创建对象</param>
        /// <returns></returns>
        public override Task<SysDictDto> CreateAsync(SysDictCreateOrUpdateDto input)
        {
            return base.CreateAsync(input);
        }
        /// <summary>
        /// 获取字典列表
        /// </summary>
        /// <param name="input">字典列表获取输入对象</param>
        /// <returns></returns>
        public override Task<PagedResultDto<SysDictDto>> GetListAsync(EVPagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }
        /// <summary>
        /// 更新字典信息
        /// </summary>
        /// <param name="id">字典id</param>
        /// <param name="input">字典更新输入对象</param>
        /// <returns></returns>
        public override Task<SysDictDto> UpdateAsync(Guid id, SysDictCreateOrUpdateDto input)
        {
            return base.UpdateAsync(id, input);
        }
        /// <summary>
        /// 删除字典
        /// </summary>
        /// <param name="id">字典id</param>
        /// <returns></returns>
        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        #endregion
    }
}
