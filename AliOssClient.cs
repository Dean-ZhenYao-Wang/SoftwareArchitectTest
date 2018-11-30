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
        const string accessKeyId = "LTAIQ0fFnaRmVgwa";
        const string accessKeySecret = "8Jgre3av37QThyw4K5xgrzcPRnQuKi";
        public const string endpoint = "http://nizhenchou.oss-cn-shanghai.aliyuncs.com";

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
