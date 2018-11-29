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
        public FaceLocation location { get; set; }
        /// <summary>
        /// 人脸置信度，范围【0~1】，代表这是一张人脸的概率，0最小、1最大。
        /// </summary>
        public double face_probability { get; set; }
        /// <summary>
        /// 人脸旋转角度参数
        /// </summary>
        public FaceAngel angel { get; set; }
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
        public FaceTypeProbability typeProbability { get; set; }
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
    /// <summary>
    /// 人脸的各种类型及其置信度
    /// </summary>
    public class FaceTypeProbability:BaseEntity
    {
        /// <summary>
        /// 人脸图片的唯一标识
        /// </summary>
        public string face_token { get; set; }
        /// <summary>
        /// 某个类型下的某个类型
        /// </summary>
        public double type { get; set; }
        /// <summary>
        /// 置信度，范围【0~1】，代表这是某个类型下的某个类型的判断正确的概率，0最小、1最大。
        /// </summary>
        public double probability { get; set; }
        /// <summary>
        /// 某个类型
        /// </summary>
        public string typeClass { get; set; }
    }

    /// <summary>
    /// 人脸旋转角度参数
    /// </summary>
    public class FaceAngel : BaseEntity
    {
        /// <summary>
        /// 人脸图片的唯一标识
        /// </summary>
        public string face_token { get; set; }
        /// <summary>
        /// 三维旋转之左右旋转角[-90(左), 90(右)]
        /// </summary>
        public double yaw { get; set; }
        /// <summary>
        /// 三维旋转之俯仰角度[-90(上), 90(下)]
        /// </summary>
        public double pitch { get; set; }
        /// <summary>
        /// 平面内旋转角[-180(逆时针), 180(顺时针)]
        /// </summary>
        public double roll { get; set; }
    }
    /// <summary>
    /// 人脸在图片中的位置
    /// </summary>
    public class FaceLocation : BaseEntity
    {
        /// <summary>
        /// 人脸图片的唯一标识
        /// </summary>
        public string face_token { get; set; }
        /// <summary>
        /// 人脸区域离左边界的距离
        /// </summary>
        public double left { get; set; }
        /// <summary>
        /// 人脸区域离上边界的距离
        /// </summary>
        public double top { get; set; }
        /// <summary>
        /// 人脸区域的宽度
        /// </summary>
        public double width { get; set; }
        /// <summary>
        /// 人脸区域的高度
        /// </summary>
        public double height { get; set; }
        /// <summary>
        /// 人脸框相对于竖直方向的顺时针旋转角，[-180,180]
        /// </summary>
        public Int64 rotation { get; set; }
    }
}
