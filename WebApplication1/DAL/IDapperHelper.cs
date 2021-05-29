using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DAL
{
    public interface IDapperHelper
    {
        Database GetConnection();

        #region Dapper同步操作方法
        T Get<T>(string id, IDbTransaction tran = null, int? commandTimeout = null) where T : class;
        IEnumerable<T> GetAll<T>(object predicate = null, IList<ISort> sort = null, IDbTransaction tran = null, int? commandTimeout = null, bool buffered = true) where T : class;
        IEnumerable<T> GetPage<T>(object predicate, IList<ISort> sort, int page, int pagesize, IDbTransaction tran = null, int? commandTimeout = null, bool buffered = true) where T : class;
        dynamic Insert<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null) where T : class;
        void Insert<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null) where T : class;
        bool Update<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        bool Update<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        bool Delete<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null) where T : class;
        bool Delete<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null) where T : class;
        IDbTransaction TranStart();
        void TranRollBack(IDbTransaction tran);
        void TranCommit(IDbTransaction tran);
        List<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        int Execute<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        #endregion

        #region 异步操作方法
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null) where T : class;

        /// <summary>
        /// 删除实体列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null) where T : class;

        /// <summary>
        /// 获取单个对象 id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string id, IDbTransaction tran = null, int? commandTimeout = null) where T : class;

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
        Task<IEnumerable<T>> GetAllAsync<T>(object predicate = null, IList<ISort> sort = null, IDbTransaction tran = null, int? commandTimeout = null) where T : class;

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
        Task<IEnumerable<T>> GetPageAsync<T>(object predicate, IList<ISort> sort, int page, int pagesize, IDbTransaction tran = null, int? commandTimeout = null) where T : class;

        /// <summary>
        /// 单实体插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<dynamic> InsertAsync<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null) where T : class;

        /// <summary>
        /// 列表插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        void InsertAsync<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null) where T : class;

        /// <summary>
        /// 实体更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="ignoreAllKeyProperties"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null, bool ignoreAllKeyProperties = true) where T : class;

        /// <summary>
        /// 实体集合更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="ignoreAllKeyProperties"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null, bool ignoreAllKeyProperties = true) where T : class;

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
        public Task<List<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行SQL 实现“增”“删”“改”
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<int> ExecuteAsync<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        #endregion
    }
}
 