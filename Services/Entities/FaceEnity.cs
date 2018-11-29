using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services.Entities
{
    /// <summary>
    /// 人脸检测返回数据
    /// </summary>
    public class ResultFaceDTO
    {
        /// <summary>
        /// 检测到的图片中的人脸数量
        /// </summary>
        public int face_num { get; set; }
        /// <summary>
        /// 人脸信息列表
        /// </summary>
        public List<Face> face_list { get; set; }
    }
    /// <summary>
    /// 人脸信息
    /// </summary>
    public class Face
    {
        /// <summary>
        /// 人脸图片的唯一标识
        /// </summary>
        public string face_token { get; set; }
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
        /// 表情，当 face_field包含expression时返回
        /// </summary>
        public FaceExpression expression { get; set; }
        /// <summary>
        /// 脸型，当face_field包含faceshape时返回
        /// </summary>
        public FaceShape face_shape { get; set; }
        /// <summary>
        /// 性别，face_field包含gender时返回
        /// </summary>
        public FaceGender gender { get; set; }
        /// <summary>
        /// 是否带眼镜，face_field包含glasses时返回
        /// </summary>
        public FaceGlasses glasses { get; set; }
        /// <summary>
        /// 人种 face_field包含race时返回
        /// </summary>
        public FaceRace race { get; set; }
        /// <summary>
        /// 真实人脸/卡通人脸 face_field包含face_type时返回
        /// </summary>
        public FaceType face_type { get; set; }
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

    public class FaceType
    {
        /// <summary>
        /// human: 真实人脸 cartoon: 卡通人脸
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 人脸类型判断正确的置信度，范围【0~1】，0代表概率最小、1代表最大。
        /// </summary>
        public double probability { get; set; }
    }
    public class FaceRace
    {
        /// <summary>
        /// yellow: 黄种人 white: 白种人 black:黑种人 arabs: 阿拉伯人
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 人种置信度，范围【0~1】，0代表概率最小、1代表最大。
        /// </summary>
        public double probability { get; set; }
    }
    /// <summary>
    /// 是否带眼镜，face_field包含glasses时返回
    /// </summary>
    public class FaceGlasses
    {
        /// <summary>
        /// none:无眼镜，common:普通眼镜，sun:墨镜
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 眼镜置信度，范围【0~1】，0代表概率最小、1代表最大。
        /// </summary>
        public double probability { get; set; }
    }
    /// <summary>
    /// 性别，face_field包含gender时返回
    /// </summary>
    public class FaceGender
    {
        /// <summary>
        /// male:男性 female:女性
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 性别置信度，范围【0~1】，0代表概率最小、1代表最大。
        /// </summary>
        public double probability { get; set; }
    }

    /// <summary>
    /// 脸型，当face_field包含faceshape时返回
    /// </summary>
    public class FaceShape
    {
        /// <summary>
        /// square: 正方形 triangle:三角形 oval: 椭圆 heart: 心形 round: 圆形
        /// </summary>
        public double type { get; set; }
        /// <summary>
        /// 置信度，范围【0~1】，代表这是人脸形状判断正确的概率，0最小、1最大。
        /// </summary>
        public double probability { get; set; }
    }
    /// <summary>
    /// 表情，当 face_field包含expression时返回
    /// </summary>
    public class FaceExpression
    {
        /// <summary>
        /// none:不笑；smile:微笑；laugh:大笑
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 表情置信度，范围【0~1】，0最小、1最大。
        /// </summary>
        public double probability { get; set; }
    }
    /// <summary>
    /// 人脸旋转角度参数
    /// </summary>
    public class FaceAngel
    {
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
    public class FaceLocation
    {
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
