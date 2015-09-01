using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Function
{
    public class BmpParser
    {
        public static BmpInfo Parse(string path)
        {
            BmpInfo bmpInfo = new BmpInfo();
            byte[] bmpBytes = File.ReadAllBytes(path);

            bmpInfo = Parse(bmpBytes);

            return bmpInfo;
        }

        public static BmpInfo Parse(byte[] bmpBytes)
        {
            BmpInfo bmpInfo = new BmpInfo();
       

            // 获取bmp标识
            bmpInfo.BmpMark = bmpBytes.ToStringEx(0, 2);
            // 获取整个文件的大小
            bmpInfo.FileSize = bmpBytes.ToInt32(2, 4);
            // 获取保留
            bmpInfo.Reserved = bmpBytes.ToInt32(6, 4);
            // 获取从文件开始到位图数据开始之间的数据之间的偏移量
            bmpInfo.BitmapDataOffset = bmpBytes.ToInt32(10, 4);
            // 位图信息头(Bitmap Info Header)的长度
            bmpInfo.BitmapHeaderSize = bmpBytes.ToInt32(14, 4);
            // 位图的宽度，以象素为单位
            bmpInfo.Width = bmpBytes.ToInt32(18, 4);
            // 位图的高度，以象素为单位
            bmpInfo.Height = bmpBytes.ToInt32(22, 4);
            // 位图的位面数（注：该值将总是1）
            bmpInfo.Planes = bmpBytes.ToInt32(26, 2);
            // 每个象素的位数
            bmpInfo.BitsPerPixel = bmpBytes.ToInt32(28, 2);
            // 压缩
            bmpInfo.Compression = bmpBytes.ToInt32(30, 4);
            // 位图数据的大小
            bmpInfo.BitmapDataSize = bmpBytes.ToInt32(34, 4);
            // 象素/米表示的水平分辨率
            bmpInfo.HResolution = bmpBytes.ToInt32(38, 4);
            // 用象素/米表示的垂直分辨率
            bmpInfo.VResolution = bmpBytes.ToInt32(42, 4);
            // 位图使用的颜色数
            bmpInfo.Colors = bmpBytes.ToInt32(46, 4);
            // 指定重要的颜色数
            bmpInfo.ImportantColors = bmpBytes.ToInt32(50, 4);
            // 图象数据
            bmpInfo.BitmapData = bmpBytes.ToBytesList(bmpInfo.BitmapDataOffset, bmpInfo.FileSize - bmpInfo.BitmapDataOffset);
            // 获取调色板
            bmpInfo.Palette = bmpBytes.ToBytesList(54, bmpInfo.BitmapDataOffset - 54);

            //其他

            //(1+3) / 4 = 1
            //(2+3) / 4 = 1;
            //(3+3) / 4 = 1;
            //从上可看出, +3就是为了让不是4整数倍的数字,扩展到4的整数倍.
            bmpInfo.ByteRead = (bmpInfo.Width * bmpInfo.BitsPerPixel / 8 + 3) / 4 * 4;  //获取BMP每行像素的字节数！
            //bmpInfo.ByteRead = Controller.getBytePerRow(bmpInfo.BitsPerPixel, bmpInfo.Width);


            bmpInfo.CmdWidth = Controller.getCeilingByte(bmpInfo.Width);    //得到打印图像的宽度
            bmpInfo.CmdHeight = Controller.getCeilingByte(bmpInfo.Height);  //得到打印图像的高度
            bmpInfo.buffer = bmpBytes;

            return bmpInfo;
        }
    }

    public static class BytesEntend
    {   

        public static int ToInt32(this byte[] bytes, int index, int count)
        {
            int result = 0;
            for (int i = count - 1; i >= 0; i--)
            {
                if (bytes[index + i] != 0)
                {
                    result += (int)Math.Pow(256, i) * bytes[index + i];
                }
            }

            return result;
        }

        public static string ToStringEx(this byte[] bytes, int index, int count)
        {
            return Encoding.Default.GetString(bytes, index, count);
        }

        public static List<byte> ToBytesList(this byte[] bytes, int index, int count)
        {
            return bytes.Skip(index).Take(count).ToList();
        }
    }


}
