using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThoughtWorks.QRCode.Codec;

namespace QRCode.ZXing.Multiple
{
    class Create2Code
    {
        /// <summary>
        /// 设置生成二维码参数
        /// </summary>
        /// <param name="encoding">编码方式</param>
        /// <param name="scale">大小</param>
        /// <param name="version">符号版本</param>
        /// <param name="errorCorrect">纠错能力</param>
        /// <returns></returns>
        public static QRCodeEncoder GetQRCodeEncoder(String encoding, int scale, int version, string errorCorrect)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            if (encoding == "Byte")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            }
            else if (encoding == "AlphaNumeric")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
            }
            else if (encoding == "Numeric")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
            }
            try
            {
                qrCodeEncoder.QRCodeScale = scale;
                try
                {
                    qrCodeEncoder.QRCodeVersion = version;
                }
                catch (Exception ex)
                {
                }
                if (errorCorrect == "L")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                else if (errorCorrect == "M")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                else if (errorCorrect == "Q")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                else if (errorCorrect == "H")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
            }
            catch (Exception ex)
            {

            }
            return qrCodeEncoder;
        }
    }
}
