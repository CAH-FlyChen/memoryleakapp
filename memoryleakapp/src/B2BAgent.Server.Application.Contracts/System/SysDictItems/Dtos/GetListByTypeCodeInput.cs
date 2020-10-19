using System;
using System.Collections.Generic;
using System.Text;

namespace B2BAgent.Server.System.Dtos
{
    /// <summary>
    /// 过滤条件
    /// </summary>
    public class GetListByTypeCodeInput
    {
        /// <summary>
        /// 字典类型代码
        /// </summary>
        public string DicTypeCode { get; set; }
    }
}
