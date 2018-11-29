using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services.Entities
{
    /// <summary>
    /// 人脸在图片中的位置
    /// </summary>
    public class FaceLocationEntity : BaseEntity
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
