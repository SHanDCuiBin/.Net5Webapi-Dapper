using Model.Modify;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.IBll;

namespace WebApplication1.Bll
{
    public class ModifyService : IModifyService
    {
        public readonly DapperHelper _repository = new DapperHelper();

        public ModifyService()
        {

        }

        public async Task<bool> WriteOperationLog(mh_modify_log Log, List<mh_modify_info> Infos)
        {
            try
            {
                await Task.Run(() =>
                 {
                     _repository.Insert<mh_modify_log>(Log);
                     _repository.Insert<mh_modify_info>(Infos);
                 });


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

