using EV;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using B2BAgent.Server.Domains;
using System.Threading.Tasks;
using B2BAgent.Server.Biz.Dtos;

namespace B2BAgent.Server
{
    /// <summary>
    /// ERP品牌服务
    /// </summary>
    public class ERPBrandAppService : CrudAppService<Domains.ERPBrand, ERPBrandDto, Guid, EVPagedAndSortedResultRequestDto,
        ERPBrandCreateDto, ERPBrandDto>, IERPBrandAppService
    {
        public ERPBrandAppService(IRepository<Domains.ERPBrand, Guid> repository)
    : base(repository)
        {

        }


        /// <summary>
        /// 创建ERP品牌
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override Task<ERPBrandDto> CreateAsync(ERPBrandCreateDto input)
        {

            return base.CreateAsync(input);
        }
        /// <summary>
        /// 删除ERP品牌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
        /// <summary>
        /// 获取ERP品牌
        /// </summary>
        /// <param name="id">对象id</param>
        /// <returns></returns>
        public override Task<ERPBrandDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }
        /// <summary>
        /// 更新ERP品牌
        /// </summary>
        /// <param name="id">对象id</param>
        /// <param name="input">erp品牌信息</param>
        /// <returns></returns>
        public override Task<ERPBrandDto> UpdateAsync(Guid id, ERPBrandDto input)
        {
            return base.UpdateAsync(id, input);
        }
    }
}
