
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace B2BAgent.Server.System.Dtos
{

    public class SysDictItemDto : EntityDto<Guid>
    {
        /// <summary>
        /// 所属字典Id
        /// </summary>
        public Guid? SysDictId { get; set; }
        /// <summary>
        /// 所属字典对象
        /// </summary>
        //public SysDict SysDict { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(20)]
        public string Value { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        public string SysDictName { get; set; }
    }
}
