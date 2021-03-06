﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.CommonMVC
{
    /// <summary>
    /// All Ajax returns objects of this type
    /// </summary>
    public class AjaxResult
    {
        /// <summary>
        /// 000000:normal
        /// 999999:error
        /// </summary>
        public string Status { get; set; }
        
        public string ErrorMsg { get; set; }
        
        public object Data { get; set; }

    }
}
