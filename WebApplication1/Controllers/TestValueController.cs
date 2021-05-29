using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Modify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.IBll;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestValueController : ControllerBase
    {
        private readonly IModifyService _iModifyService;
        /// <summary>
        /// 数据修改日志
        /// </summary>
        /// <param name="iModifyService"></param>
        public TestValueController(IModifyService iModifyService)
        {
            this._iModifyService = iModifyService;
        }

        /// <summary>
        /// 测试插入日志
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public bool Test(int sum, string name, string mk_type)
        {
            mh_modify_log log = new mh_modify_log();
            log.id = Guid.NewGuid().ToString();
            log.org_id = name;
            log.org_name = "体检采集";
            log.mk_type = mk_type;
            log.fields = "mh_jy_xqparson.inspectiontime,mh_jy_parson.inspectiontime";
            log.gc_user_id = "xxx";
            log.update_user_id = "nnnn";
            log.update_user_name = "mmmm";
            log.update_time = DateTime.Now;

            List<mh_modify_info> lisInfo = new List<mh_modify_info>();
            for (int i = 0; i < sum; i++)
            {
                mh_modify_info Info = new mh_modify_info();
                Info.id = Guid.NewGuid().ToString();
                Info.modify_id = log.id;
                Info.tmh = DateTime.Now.ToString("yyMMddhhmm") + i.ToString().PadLeft(5, '0');
                Info.original_data = "[老数据1][老数据2]";
                Info.new_data = "[新数据1][新数据2]";
                Info.update_time = DateTime.Now;

                lisInfo.Add(Info);
            }
            return _iModifyService.WriteOperationLog(log, lisInfo);
        }

    }
}
