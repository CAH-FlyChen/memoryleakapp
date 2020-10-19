using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace B2BAgent.Server.Domains
{

    /// <summary>
    /// erp品牌
    /// </summary>
    public class ERPBrand: Entity<Guid>
    {
        /// <summary>
        /// erp名称
        /// </summary>
        public string Name { get; set; }
    }
}
