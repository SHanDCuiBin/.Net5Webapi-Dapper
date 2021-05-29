using Model.Modify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Modify
{
    public class mh_modify_info:mh_modify_base
    {     
        /// <summary>
        /// modify_id
        /// </summary>		
        private string _modify_id;
        public string modify_id
        {
            get { return _modify_id; }
            set { _modify_id = value; }
        }
        /// <summary>
        /// tmh
        /// </summary>		
        private string _tmh;
        public string tmh
        {
            get { return _tmh; }
            set { _tmh = value; }
        }
        /// <summary>
        /// original_data
        /// </summary>		
        private string _original_data;
        public string original_data
        {
            get { return _original_data; }
            set { _original_data = value; }
        }
        /// <summary>
        /// new_data
        /// </summary>		
        private string _new_data;
        public string new_data
        {
            get { return _new_data; }
            set { _new_data = value; }
        }
        /// <summary>
        /// update_time
        /// </summary>		
        private DateTime _update_time;
        public DateTime update_time
        {
            get { return _update_time; }
            set { _update_time = value; }
        }
    }
}
