﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services
{
    public class BaiduAIClient
    {
        private static Baidu.Aip.Face.Face face;
        private static object locker = new object();
        const string APP_ID = "";
        const string API_KEY = "";
        const string SECRET_KEY = " ";


        private BaiduAIClient() { }
        public static Baidu.Aip.Face.Face GetBaiduFaceClient
        {
            get
            {
                if (face == null)
                {
                    lock (locker)
                    {
                        if (face == null)
                        {
                            face = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
                            face.Timeout = 60000;  // 修改超时时间
                        }
                    }
                }
                return face;
            }
        }
    }
}
