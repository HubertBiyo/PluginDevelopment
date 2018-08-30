using Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using ThoughtWorks.QRCode.Codec;

namespace QRCode.ZXing.Multiple
{
    class CardImage
    {
        /// <summary>
        /// 生成名片二维码图片
        /// </summary>
        /// <param name="Img"></param>
        /// <param name="Width">宽</param>
        /// <param name="Height">高</param>
        /// <returns></returns>
        public static string SaveVCardCodeImages(Image Img, int Width, int Height, string maxnum, string bm)
        {
            try
            {
                string guidcode = System.Guid.NewGuid().ToString();
                string CardSrc = "E://二维码/生成结果/" + bm + ".png";

                Image SmallPic1 = ImageProvider.DrawImageByProportion(Img, new Size(Width, Height), Color.White);
                SmallPic1.Save(CardSrc);
                return "/二维码/生成结果/" + bm + ".png";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
        public static void WriteLogInfo(string action, string strMessage)
        {
            DateTime time = DateTime.Now;
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Log\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileFullPath = path + time.ToString("yyyy-MM-dd") + ".System.txt";
            StringBuilder str = new StringBuilder();
            str.Append("Time:    " + time.ToString() + "\r\n");
            str.Append("Action:  " + action + "\r\n");
            str.Append("Message: " + strMessage + "\r\n");
            str.Append("-----------------------------------------------------------\r\n\r\n");
            StreamWriter sw;
            if (!File.Exists(fileFullPath))
            {
                sw = File.CreateText(fileFullPath);
            }
            else
            {
                sw = File.AppendText(fileFullPath);
            }
            sw.WriteLine(str.ToString());
            sw.Close();
        }
        public static Image GetVCardCodeImage(QRCodeEncoder qrCodeEncoder, string VCardStr)
        {
            System.Drawing.Image myimg = qrCodeEncoder.Encode(VCardStr.ToString(), Encoding.UTF8);
            return myimg;
        }

    }
}
