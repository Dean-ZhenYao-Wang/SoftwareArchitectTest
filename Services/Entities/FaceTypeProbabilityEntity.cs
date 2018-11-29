using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services.Entities
{
    /// <summary>
    /// 人脸的各种类型及其置信度
    /// </summary>
    public class FaceTypeProbabilityEntity : BaseEntity
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
}
