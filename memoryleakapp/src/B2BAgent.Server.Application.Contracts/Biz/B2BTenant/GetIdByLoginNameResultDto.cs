using System;
using System.Collections.Generic;
using System.Text;

namespace B2BAgent.Server.Biz
{
    /// <summary>
    /// 获取租户id返回值
    /// </summary>
    public class GetIdByLoginNameResultDto
    {
        /// <summary>
        /// 租户Id
        /// </summary>
        public Guid? Tid { get; set; }
    }
}
