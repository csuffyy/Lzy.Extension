/*
 * 由SharpDevelop创建。
 * 用户： lizy
 * 日期: 2014/1/15
 * 时间: 17:12
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Lzy.Extension
{
	/// <summary>
	/// Description of ImageExtension.
	/// </summary>
	public static class ImageExtension
	{
		/// <summary>
        /// 将Image转换为byte[]
        /// </summary>
        /// <param name="image">Image</param>
        /// <returns>byte[]</returns>
        public static byte[] ToBytes(this Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                var imageBytes = new byte[ms.Length];
                ms.Read(imageBytes, 0, imageBytes.Length);
                return imageBytes;
            }
        }
	}
}
