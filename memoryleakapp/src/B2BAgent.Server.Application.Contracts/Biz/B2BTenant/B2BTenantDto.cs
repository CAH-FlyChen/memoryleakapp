using System;
using System.Collections.Generic;
using System.Text;

namespace B2BAgent.Server.Biz.Dtos
{
    /// <summary>
    /// 租户
    /// </summary>
    public class B2BTenantDto
    {
        /// <summary>
        /// 租户Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 租户名称
        /// </summary>
        public string Name { get; set; }
    }
}
