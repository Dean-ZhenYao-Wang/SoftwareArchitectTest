using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services.Entities
{

    /// <summary>
    /// 人脸旋转角度参数
    /// </summary>
    public class FaceAngelEntity : BaseEntity
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
}
