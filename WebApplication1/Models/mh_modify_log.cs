using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Modify
{
    public class mh_modify_log : mh_modify_base
    {
        /// <summary>
        /// org_id
        /// </summary>		
        private string _org_id;
        public string org_id
        {
            get { return _org_id; }
            set { _org_id = value; }
        }
        /// <summary>
        /// org_name
        /// </summary>		
        private string _org_name;
        public string org_name
        {
            get { return _org_name; }
            set { _org_name = value; }
        }
        /// <summary>
        /// mk_type
        /// </summary>		
        private string _mk_type;
        public string mk_type
        {
            get { return _mk_type; }
            set { _mk_type = value; }
        }
        /// <summary>
        /// fields
        /// </summary>		
        private string _fields;
        public string fields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        /// <summary>
        /// gc_user_id
        /// </summary>		
        private string _gc_user_id;
        public string gc_user_id
        {
            get { return _gc_user_id; }
            set { _gc_user_id = value; }
        }
        /// <summary>
        /// update_user_id
        /// </summary>		
        private string _update_user_id;
        public string update_user_id
        {
            get { return _update_user_id; }
            set { _update_user_id = value; }
        }
        /// <summary>
        /// update_user_name
        /// </summary>		
        private string _update_user_name;
        public string update_user_name
        {
            get { return _update_user_name; }
            set { _update_user_name = value; }
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
        /// <summary>
        /// reason
        /// </summary>		
        private string _reason;
        public string reason
        {
            get { return _reason; }
            set { _reason = value; }
        }
        /// <summary>
        /// is_batck
        /// </summary>		
        private string _is_batck;
        public string is_batck
        {
            get { return _is_batck; }
            set { _is_batck = value; }
        }
    }
}

