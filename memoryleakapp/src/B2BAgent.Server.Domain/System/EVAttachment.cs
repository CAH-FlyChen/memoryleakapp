using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace EV.Domain.System
{
    public class EVFile: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 原始文件名
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string OriginName { get; set; }
        /// <summary>
        /// 扩展名，不带点
        /// </summary>
        [Required]
        [MaxLength(5)]
        public string Ext { get; set; }
        /// <summary>
        /// 保存路径
        /// </summary>
        [MaxLength(5000)]
        [Required]
        public string FilePath { get; set; }
        /// <summary>
        /// 新文件名
        /// </summary>
        [MaxLength(32)]
        [Required]
        public string GuidName { get; set; }

        public byte[] Content { get; set; }

        protected EVFile() { }
        public EVFile(string fileName,string basePath)
        {
            this.OriginName = fileName;
            var s = fileName.Split(".");
            if (s.Length > 1)
                this.Ext = s.Last();
            this.GuidName = Guid.NewGuid().ToString("N");
            this.FilePath = Path.Combine(basePath, GuidName.Substring(0, 2), GuidName.Substring(2, 2),GuidName);

        }
    }
}
