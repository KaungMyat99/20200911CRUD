using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20200911CRUD.Models
{
    public class _MessageModel
    {
        public _MessageModel() 
        {
            String l_value = string.Empty;
            RespCode = l_value;
            RespDesp = l_value;
            RespType = l_value;
        }
        public _MessageModel(string l_RespCode,string l_RespDesp,string l_RespType)
        {
            RespCode = l_RespCode;
            RespDesp = l_RespDesp;
            RespType = l_RespType;
        }
        public string RespCode { get; set; }
        public string RespDesp { get; set; }
        public string RespType { get; set; }
    }
}