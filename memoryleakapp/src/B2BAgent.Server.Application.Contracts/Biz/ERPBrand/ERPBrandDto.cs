using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace B2BAgent.Server.Biz.Dtos
{
    /// <summary>
    /// ERP品牌
    /// </summary>
    public class ERPBrandDto:EntityDto<Guid>
    {
        /// <summary>
        /// erp名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
    /// <summary>
    /// ERP品牌
    /// </summary>
    public class ERPBrandCreateDto
    {
        /// <summary>
        /// erp名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
