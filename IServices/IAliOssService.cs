using System.IO;
using System.Threading.Tasks;

namespace ZYW.IServices
{
    public interface IAliOssService:IServiceSupport
    {
        /// <summary>
        /// 上传至oss
        /// </summary>
        /// <param name="key">文件名称</param>
        /// <param name="memoryStream">文件流</param>
        /// <returns></returns>
       Task<string> PutObjectResultAsync(string key, MemoryStream memoryStream);
        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="key">文件名称</param>
        /// <returns></returns>
        bool DoesObjectExist(string key);
    
    }
}
