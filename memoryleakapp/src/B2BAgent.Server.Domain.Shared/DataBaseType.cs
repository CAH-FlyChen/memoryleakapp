using System;
using System.Collections.Generic;
using System.Text;

namespace B2BAgent.Server
{
    /// <summary>
    /// 数据库类型。
    ///    SqlServer=0,  //SQLServer数据库
    ///    MySql=1,      //Mysql数据库
    ///    Npgsql=2,     //PostgreSQL数据库
    ///    Oracle=3,     //Oracle数据库
    ///    Sqlite=4,     //SQLite数据库
    ///    ODBC=5
    /// </summary>
    public enum DatabaseType
    {
        SqlServer=0,  //SQLServer数据库
        MySql=1,      //Mysql数据库
        Npgsql=2,     //PostgreSQL数据库
        Oracle=3,     //Oracle数据库
        Sqlite=4,     //SQLite数据库
        ODBC=5
        //DB2         //IBM DB2数据库
    }
}
