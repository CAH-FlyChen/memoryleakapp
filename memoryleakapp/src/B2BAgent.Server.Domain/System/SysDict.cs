using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace EV.Domain.System
{
    /// <summary>
    /// 系统字典类型
    /// </summary>
    [Table("Sys_Dict")]
    public class SysDict : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        [MaxLength(50)]
        public string Code { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// 字典条目
        /// </summary>
        public virtual ICollection<SysDictItem> SysDictItems { get; set; }
        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool AllowEdit { get; set; } = true;

        public SysDict() { }

        public SysDict(Guid id,string name,string code,int displayOrder,bool allowEdit=true)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
            this.DisplayOrder = displayOrder;
            this.AllowEdit = allowEdit;
        }
    }
}
