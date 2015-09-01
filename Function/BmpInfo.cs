using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Function
{
    public class BmpInfo
    {
        #region 扩展
        /// <summary>
        /// buffer
        /// </summary>
        public byte[] buffer
        {
            get;
            set;
        }

        /// <summary>
        /// 获取BMP每行像素的字节数！
        /// 让不是4整数倍的数字,扩展到4的整数倍
        /// </summary>
        public int ByteRead
        {
            get;
            set;
        }

        /// <summary>
        /// CmdWidth
        /// </summary>
        public int CmdWidth
        {
            get;
            set;
        }

        /// <summary>
        /// CmdHeight
        /// </summary>
        public int CmdHeight
        {
            get;
            set;
        }

        public ArrayList _bitData = new ArrayList();
        public ArrayList _pixelData = new ArrayList();
        public ArrayList _rawData = new ArrayList();

        /// <summary>
        /// 位数据
        /// </summary>
        public ArrayList BitData
        {
            get { return _bitData; }
            set { _bitData = value; }
        }

        /// <summary>
        /// 像素数据
        /// </summary>
        public ArrayList PixelData
        {
            get { return _pixelData; }
            set { _pixelData = value; }
        }


        /// <summary>
        /// 原始数据
        /// </summary>
        public ArrayList RawData
        {
            get { return _rawData; }
            set { _rawData = value; }
        }


        #endregion


        /// <summary>
        /// bmp标识
        /// </summary>
        public string BmpMark
        {
            get;
            set;
        }

        /// <summary>
        /// 用字节表示的整个文件的大小
        /// </summary>
        public int FileSize
        {
            get;
            set;
        }

        /// <summary>
        /// 保留，必须设置为0
        /// </summary>
        public int Reserved
        {
            get;
            set;
        }

        /// <summary>
        /// 从文件开始到位图数据开始之间的数据(bitmap data)之间的偏移量
        /// </summary>
        public int BitmapDataOffset
        {
            get;
            set;
        }

        /// <summary>
        /// 位图信息头(Bitmap Info Header)的长度，用来描述位图的颜色、压缩方法等。下面的长度表示： 
        /// 28h - Windows 3.1x, 95, NT, … 0Ch - OS/2 1.x F0h - OS/2 2.x
        /// 注：在Windows95、98、2000等操作系统中，位图信息头的长度并不一定是28h，
        /// 因为微软已经制定出了新的BMP文件格式，其中的信息头结构变化比较大，长度加长。
        /// 所以最好不要直接使用常数28h，而是应该从具体的文件中读取这个值。这样才能确保程序的兼容性.
        /// </summary>
        public int BitmapHeaderSize
        {
            get;
            set;
        }

        /// <summary>
        /// 位图的宽度，以象素为单位
        /// </summary>
        public int Width
        {
            get;
            set;
        }

        /// <summary>
        /// 位图的高度，以象素为单位
        /// </summary>
        public int Height
        {
            get;
            set;
        }

        /// <summary>
        /// 位图的位面数（注：该值将总是1）
        /// </summary>
        public int Planes
        {
            get;
            set;
        }

        /// <summary>
        /// 每个象素的位数 
        /// 1 - 单色位图（实际上可有两种颜色，缺省情况下是黑色和白色。你可以自己定义这两种颜色） 
        /// 4 - 16 色位图 
        /// 8 - 256 色位图 
        /// 16 - 16bit 高彩色位图 
        /// 24 - 24bit 真彩色位图 
        /// 32 - 32bit 增强型真彩色位图
        /// </summary>
        public int BitsPerPixel
        {
            get;
            set;
        }

        /// <summary>
        /// 压缩说明： 
        /// 0 - 不压缩 (使用BI_RGB表示) 
        /// 1 - RLE 8-使用8位RLE压缩方式(用BI_RLE8表示) 
        /// 2 - RLE 4-使用4位RLE压缩方式(用BI_RLE4表示) 
        /// 3 - Bitfields-位域存放方式(用BI_BITFIELDS表示)
        /// </summary>
        public int Compression
        {
            get;
            set;
        }

        /// <summary>
        /// 用字节数表示的位图数据的大小。该数必须是4的倍数
        /// </summary>
        public int BitmapDataSize
        {
            get;
            set;
        }

        /// <summary>
        /// 用象素/米表示的水平分辨率
        /// </summary>
        public int HResolution
        {
            get;
            set;
        }

        /// <summary>
        /// 用象素/米表示的垂直分辨率
        /// </summary>
        public int VResolution
        {
            get;
            set;
        }

        /// <summary>
        /// 位图使用的颜色数。如8-比特/象素表示为100h或者 256.
        /// </summary>
        public int Colors
        {
            get;
            set;
        }

        /// <summary>
        /// 指定重要的颜色数。当该域的值等于颜色数时（或者等于0时），表示所有颜色都一样重要
        /// </summary>
        public int ImportantColors
        {
            get;
            set;
        }

        /// <summary>
        /// 调色板规范。对于调色板中的每个表项，这4个字节用下述方法来描述RGB的值：  
        /// 1字节用于蓝色分量 
        /// 1字节用于绿色分量 
        /// 1字节用于红色分量 
        ///1字节用于填充符(设置为0) 
        /// </summary>
        public List<byte> Palette
        {
            get;
            set;
        }

        /// <summary>
        /// 该域的大小取决于压缩方法及图像的尺寸和图像的位深度，
        /// 它包含所有的位图数据字节，这些数据可能是彩色调色板的索引号，
        /// 也可能是实际的RGB值，这将根据图像信息头中的位深度值来决定。
        /// </summary>
        public List<byte> BitmapData
        {
            get;
            set;
        }
    }
}
