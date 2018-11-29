using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services.Entities
{
    /// <summary>
    /// 人脸的信息
    /// </summary>
    public class FaceEntity:BaseEntity
    {
        /// <summary>
        /// 检测到的图片中的人脸数量
        /// </summary>
        public int face_num { get; set; }
        /// <summary>
        /// 人脸在图片中的位置
        /// </summary>
        public FaceLocationEntity location { get; set; }
        /// <summary>
        /// 人脸置信度，范围【0~1】，代表这是一张人脸的概率，0最小、1最大。
        /// </summary>
        public double face_probability { get; set; }
        /// <summary>
        /// 人脸旋转角度参数
        /// </summary>
        public FaceAngelEntity angel { get; set; }
        /// <summary>
        /// 年龄 ，当face_field包含age时返回
        /// </summary>
        public double age { get; set; }
        /// <summary>
        /// 美丑打分，范围0-100，越大表示越美。当face_fields包含beauty时返回
        /// </summary>
        public Int64 beauty { get; set; }
        /// <summary>
        /// 各种类型及其置信度
        /// </summary>
        public FaceTypeProbabilityEntity typeProbability { get; set; }
        /// <summary>
        /// 4个关键点位置，左眼中心、右眼中心、鼻尖、嘴中心。face_field包含landmark时返回
        /// </summary>
        public string landmark { get; set; }
        /// <summary>
        /// 72个特征点位置 face_field包含landmark时返回
        /// https://ai.bdstatic.com/file/52BC00FFD4754A6298D977EDAD033DA0
        /// </summary>
        public string landmark72 { get; set; }
    }
}
