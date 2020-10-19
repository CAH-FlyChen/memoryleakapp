
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace B2BAgent.Server.System.Dtos
{

    public class SysDictItemCreateOrUpdateDto
    {
        /// <summary>
        /// 所属字典Id
        /// </summary>
        public Guid? SysDictId { get; set; }
        /// <summary>
        /// 条目名称
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// 条目代码
        /// </summary>
        [MaxLength(20)]
        public string Code { get; set; }
        /// <summary>
        /// 条目值，用于翻译文件名称
        /// </summary>
        [MaxLength(20)]
        public string Value { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
