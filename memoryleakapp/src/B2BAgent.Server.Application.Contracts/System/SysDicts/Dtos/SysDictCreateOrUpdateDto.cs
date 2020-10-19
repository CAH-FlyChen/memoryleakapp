using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace B2BAgent.Server.System.Dtos
{
    /// <summary>
    /// 系统字典创建修改对象
    /// </summary>
    public class SysDictCreateOrUpdateDto
    {
        /// <summary>
        /// 字典名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 字典代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// 是否已经删除
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
