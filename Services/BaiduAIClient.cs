using System;
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
        private static readonly string APP_ID = "";
        private static readonly string API_KEY = "";
        private static readonly string SECRET_KEY = "";


        private BaiduAIClient() { }
        public static Baidu.Aip.Face.Face GetAliOss
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
