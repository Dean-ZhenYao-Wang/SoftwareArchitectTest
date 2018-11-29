using Aliyun.OSS;
using System;
using System.IO;
using System.Threading.Tasks;
using ZYW.IServices;
using static System.Net.Mime.MediaTypeNames;

namespace ZYW.Services.Service
{
    public class AliOssService : IAliOssService
    {
        const string bucketName = "nizhenchou";
        /// <summary>
        /// 上传文件至oss
        /// </summary>
        /// <param name="key">文件名称</param>
        /// <param name="memoryStream">文件流</param>
        /// <returns></returns>
        public async Task<string> PutObjectResultAsync(string key,MemoryStream memoryStream)
        {
            memoryStream.Seek(0, SeekOrigin.Begin);
            PutObjectResult putObjectResult = AliOssClient.GetAliOssClient.PutObject(bucketName, key, memoryStream);
            return putObjectResult.ETag;
        }
        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="key">文件名称</param>
        /// <returns></returns>
        public bool DoesObjectExist(string key)
        {
            return AliOssClient.GetAliOssClient.DoesObjectExist(bucketName,key);
        }
    }
}
