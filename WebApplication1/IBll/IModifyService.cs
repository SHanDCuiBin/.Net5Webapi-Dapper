using Model.Modify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.IBll
{
    /// <summary>
    /// 数据修改日志接口
    /// </summary>
    public interface IModifyService
    {
        /// <summary>
        /// 添加日志操作方法
        /// </summary>
        /// <param name="Log"></param>
        /// <param name="Infos"></param>
        /// <returns></returns>
      bool WriteOperationLog(mh_modify_log Log, List<mh_modify_info> Infos);
    }
}
