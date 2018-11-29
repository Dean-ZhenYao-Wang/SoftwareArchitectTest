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
        const string APP_ID = "11038206";
        const string API_KEY = "eWHHExU8qB2VWTtGKO9WlfuA";
        const string SECRET_KEY = "Lt9tCouI2OOgoCl57NwGNadtfKLzmwRI ";


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
