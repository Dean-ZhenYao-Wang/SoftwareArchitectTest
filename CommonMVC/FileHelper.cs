using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.CommonMVC
{
    public class FileHelper
    {

        /// <summary>
        /// 将bytes数据转换为stream
        /// </summary>
        /// <param name="fileName">要保存成的文件路径</param>
        /// <param name="dataBytes">要保存的数据</param>
        /// <returns></returns>

        public static Stream BytesToStream(string fileName, byte[] dataBytes)
        {
            if (dataBytes == null)
            {
                return null;
            }
            //MemoryStream ms = new MemoryStream(dataBytes);
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                fs.Write(dataBytes, 0, dataBytes.Length);
                return fs;
            }
        }
        /// <summary>
        /// 将bytes数据转换为MemoryStream
        /// </summary>
        /// <param name="dataBytes">要转换的数据</param>
        /// <returns></returns>

        public static MemoryStream BytesToMemoryStream(byte[] dataBytes)
        {
            if (dataBytes == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream(dataBytes);
            return ms;
        }
        /// <summary>
        /// Stream转换为文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileName"></param>
        public static void StreamToFile(Stream stream, string fileName)
        {

            // 把 Stream 转换成 byte[]   
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始   
            stream.Seek(0, SeekOrigin.Begin);
            // 把 byte[] 写入文件   
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }
        public static byte[] Base64ToBytes(string base64Img)
        {
            if (!string.IsNullOrEmpty(base64Img))
            {
                byte[] bytes = Convert.FromBase64String(base64Img);
                return bytes;
            }
            return null;
        }
    }
}