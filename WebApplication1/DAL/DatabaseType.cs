using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DAL
{
    /// <summary>
    /// 数据库类型定义
    /// </summary>
    public enum DatabaseType
    {
        SqlServer,  //SQLServer数据库
        MySql,      //Mysql数据库
        Oracle,     //Oracle数据库
        Sqlite,     //SQLite数据库
    }
}
