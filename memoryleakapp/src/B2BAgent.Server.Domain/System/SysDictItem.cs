using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace EV.Domain.System
{
    /// <summary>
    /// 系统字典条目
    /// </summary>
    public class SysDictItem : Entity<Guid>
    {
        /// <summary>
        /// 所属字典Id
        /// </summary>
        public Guid? SysDictId { get; set; }
        /// <summary>
        /// 所属字典对象
        /// </summary>
        public SysDict SysDict { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool AllowEdit { get; set; } = true;

        public SysDictItem() { }

        public SysDictItem(Guid id,Guid? sysDictId,string name,string code,string value,int displayOrder,bool allowEdit=true)
        {
            this.Id = id;
            this.SysDictId = sysDictId;
            this.Name = name;
            this.Code = code;
            this.Value = value;
            this.DisplayOrder = displayOrder;
            this.AllowEdit = allowEdit;

        }
    }
}
