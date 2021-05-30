using Dapper;
using DapperExtensions;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DAL
{
    public class DapperHelper : IDapperHelper, IDisposable
    {
        private string ConnectionString = string.Empty;
        private Database Connection = null;
        /// <summary>
        /// 初始化 若不传则默认从appsettings.json读取Connections:DefaultConnect节点
        /// 传入setting:xxx:xxx形式 则会从指定的配置文件中读取内容
        /// 直接传入连接串则
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="jsonConfigFileName"> 配置文件名称</param>
        public DapperHelper(string conn = "", string jsonConfigFileName = "appsettings.json", DatabaseType databaseType = DatabaseType.MySql)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile(jsonConfigFileName, optional: true)
                                                   .Build();
            if (string.IsNullOrEmpty(conn))
            {
                conn = config.GetSection("Connections:DefaultConnect").Value;
            }
            else if (conn.StartsWith("setting:"))
            {
                conn = config.GetSection(conn.Substring(8)).Value;
            }
            ConnectionString = conn;
            Connection = ConnectionFactory.CreateConnection(ConnectionString, databaseType);
        }
        public Database GetConnection()
        {
            return Connection;
        }


        #region 同步操作方法
        public IDbTransaction TranStart()
        {
            if (Connection.Connection.State == ConnectionState.Closed)
                Connection.Connection.Open();
            return Connection.Connection.BeginTransaction();
        }
        public void TranRollBack(IDbTransaction tran)
        {
            tran.Rollback();
            if (Connection.Connection.State == ConnectionState.Open)
                tran.Connection.Close();
        }
        public void TranCommit(IDbTransaction tran)
        {
            tran.Commit();
            if (Connection.Connection.State == ConnectionState.Open)
                tran.Connection.Close();
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public bool Delete<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            return Connection.Delete(obj, tran, commandTimeout);
        }

        /// <summary>
        /// 删除实体列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public bool Delete<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            return Connection.Delete(list, tran, commandTimeout);
        }

        /// <summary>
        /// 获取单个对象 id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public T Get<T>(string id, IDbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            return Connection.Get<T>(id, tran, commandTimeout);
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>(object predicate = null, IList<ISort> sort = null, IDbTransaction tran = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            return Connection.GetList<T>(predicate, sort, tran, commandTimeout, buffered);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetPage<T>(object predicate, IList<ISort> sort, int page, int pagesize, IDbTransaction tran = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            return Connection.GetPage<T>(predicate, sort, page, pagesize, tran, commandTimeout, buffered);
        }

        /// <summary>
        /// 单实体插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public dynamic Insert<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null) where T : class
        {

            LogHelper.Write("Insert",LogLev.Debug);
            return Connection.Insert(obj, tran, commandTimeout);
        }

        /// <summary>
        /// 列表插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        public void Insert<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            LogHelper.Write("Insert<T>",LogLev.Debug);
            Connection.Insert(list, tran, commandTimeout);
        }

        /// <summary>
        /// 实体更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="ignoreAllKeyProperties"></param>
        /// <returns></returns>
        public bool Update<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null, bool ignoreAllKeyProperties = true) where T : class
        {
            return Connection.Update(obj, tran, commandTimeout, ignoreAllKeyProperties);
        }

        /// <summary>
        /// 实体集合更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="ignoreAllKeyProperties"></param>
        /// <returns></returns>
        public bool Update<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null, bool ignoreAllKeyProperties = true) where T : class
        {
            return Connection.Update(list, tran, commandTimeout, ignoreAllKeyProperties);
        }

        /// <summary>
        /// 自定义SQL语句查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public List<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType).ToList();
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public int Execute<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Connection.Execute(sql, param, transaction, commandTimeout, commandType);
        }
        #endregion

       

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
            }
        }
    }
}

