using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ZYW.CommonMVC;
using ZYW.IServices;

namespace ZYW.Services.Service
{
    public class BaiduAIFanceService : IBaiduAIFanceService
    {
        public IAliOssService aliOssService { get; set; }
        /// <summary>
        /// 人脸检测 
        /// </summary>
        /// <param name="image">图片信息(总数据大小应小于10M)，图片上传方式根据image_type来判断</param>
        /// <param name="imagetype">图片类型 
        /// BASE64:图片的base64值，base64编码后的图片数据，需urlencode，编码后的图片大小不超过2M；
        /// URL:图片的 URL地址( 可能由于网络等原因导致下载图片时间过长)；
        /// FACE_TOKEN: 人脸图片的唯一标识，调用人脸检测接口时，会为每个人脸图片赋予一个唯一的FACE_TOKEN，同一张图片多次检测得到的FACE_TOKEN是同一个</param>
        /// <param name="face_field">包括age,beauty,expression,faceshape,gender,glasses,landmark,race,quality,facetype信息
        /// 逗号分隔.默认只返回face_token、人脸框、概率和旋转角度</param>
        /// <param name="max_face_num">最多处理人脸的数目:
        /// 默认值为1，仅检测图片中面积最大的那个人脸；
        /// 最大值10，检测图片中面积最大的几张人脸。</param>
        /// <param name="face_type">人脸的类型 
        /// LIVE表示生活照：通常为手机、相机拍摄的人像图片、或从网络获取的人像图片等
        /// IDCARD表示身份证芯片照：二代身份证内置芯片中的人像照片 
        /// WATERMARK表示带水印证件照：一般为带水印的小图，如公安网小图 
        /// CERT表示证件照片：如拍摄的身份证、工卡、护照、学生证等证件图片 
        /// 默认LIVE</param>
        /// <returns>图片访问地址</returns>
        public async Task<string> Detect(string image, string imagetype, string face_field = "beauty", int max_face_num = 1, string face_type = "")
        {
            string[] imageArray = image.Split(';');// "data:image/jpeg;base64,/9j/";
            //文件类型
            string fileName = Guid.NewGuid().ToString() + "." + imageArray[0].Split('/')[1];
            //文件的base64编码
            string base64Image = imageArray[1].Split(',')[1];
            MemoryStream memoryStream = FileHelper.BytesToMemoryStream(FileHelper.Base64ToBytes(base64Image));
            //异步上传到阿里云oss
            await aliOssService.PutObjectResultAsync(fileName, memoryStream);
            var options = new Dictionary<string, object>
            {
                {"face_field",face_field }
            };
            if (max_face_num != 1)
                options.Add("max_face_num", max_face_num);
            if (!string.IsNullOrEmpty(face_type))
                options.Add("face_type", face_type);
            //上传至百度人脸检测AI
            var result = BaiduAIClient.GetBaiduFaceClient.Detect(base64Image, imagetype, options);

            string imageUrl = AliOssClient.endpoint + "/" + fileName;
            return imageUrl;
        }
    }
}
