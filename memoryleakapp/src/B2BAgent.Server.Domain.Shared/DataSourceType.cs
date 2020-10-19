using System;
using System.Collections.Generic;
using System.Text;

namespace B2BAgent.Server
{
    /// <summary>
    /// 数据来源类型
    /// 0队列 , 1文件 , 2数据库 , 3API
    /// </summary>
    public enum DataSourceType
    {
        队列 = 0,
        文件 = 1,
        数据库 = 2,
        API = 3
    }
}
