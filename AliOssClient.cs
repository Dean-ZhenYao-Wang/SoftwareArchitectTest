using Aliyun.OSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services
{
    public class AliOssClient
    {
        private static OssClient ossClient;
        private static Aliyun.OSS.Common.ClientConfiguration clientConfiguration;
        private static object locker = new object();
        const string accessKeyId = "";
        const string accessKeySecret = "";
        public const string endpoint = "";

        private AliOssClient() { }
        public static OssClient GetAliOssClient
        {
            get
            {
                if (ossClient == null)
                {
                    lock (locker)
                    {
                        if (ossClient == null)
                        {
                            clientConfiguration = new Aliyun.OSS.Common.ClientConfiguration();
                            clientConfiguration.IsCname = true;
                            ossClient = new OssClient(endpoint, accessKeyId, accessKeySecret, clientConfiguration);
                        }
                    }
                }
                return ossClient;
            }
        }
    }
}
