namespace Function
{
    using System;
    using System.IO;

    public class Controller
    {
        public static string convertHexToBit(string str)
        {
            if (str.Equals("FF"))
            {
                return "0";
            }
            if (!str.Equals("00") && (str.CompareTo("80") > 0))
            {
                return "0";
            }
            return "1";
        }

        public static string formatHexString(string str)
        {
            if (str.Length == 1)
            {
                str = "00" + str;
                return str;
            }
            if (str.Length == 2)
            {
                str = "0" + str;
            }
            return str;
        }

        public static string formatLast1BitData(string str, int imageWidth)
        {
            string str2 = str;
            int length = imageWidth % 8;
            if (length == 0)
            {
                return str2;
            }
            string str3 = "";
            for (int i = length; i < 8; i++)
            {
                str3 = str3 + "0";
            }
            return (str.Substring(0, length) + str3);
        }

        public static int getBytePerRow(int depth, int imageWidth)
        {
            int num = 0;
            if (depth == 0x18)
            {
                num = 3 * imageWidth;
                if ((num % 4) != 0)
                {
                    num = ((num / 4) + 1) * 4;
                }
                return num;
            }
            if (depth == 8)
            {
                num = imageWidth;
                if (num < 4)
                {
                    return 4;
                }
                if ((num % 4) != 0)
                {
                    num = ((num / 4) + 1) * 4;
                }
                return num;
            }
            if (depth == 4)
            {
                num = imageWidth / 2;
                if ((num % 4) != 0)
                {
                    num = ((num / 4) + 1) * 4;
                }
                return num;
            }
            if (depth == 1)
            {
                num = getCeilingByte(imageWidth);
                if (num < 4)
                {
                    return 4;
                }
                if ((num % 4) != 0)
                {
                    num = ((num / 4) + 1) * 4;
                }
            }
            return num;
        }

        public static int getCeilingByte(int n)
        {
            if ((n % 8) == 0)
            {
                return (n / 8);
            }
            if (n < 8)
            {
                return 1;
            }
            return ((n / 8) + 1);
        }

        public static byte[] getFileContent(string filename)
        {
            byte[] buffer = null;
            try
            {
                FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryReader reader = new BinaryReader(input);
                buffer = new byte[(int) input.Length];
                reader.Read(buffer, 0, buffer.Length);
                reader.Close();
                input.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("GetFileContent Exception : " + exception);
            }
            return buffer;
        }

        public static string getHexToBit(string str)
        {
            string str2 = Conversion.HexToBin(str);
            if (str2.Length < 8)
            {
                for (int i = 0; i < (8 - str2.Length); i++)
                {
                    str2 = "0" + str2;
                }
            }
            return str2.Replace("0", "2").Replace("1", "0").Replace("2", "1");
        }

        public static string process24BitPixel(string str)
        {
            if (str.Equals("FFFFFF"))
            {
                return "0";
            }
            if (!str.Equals("000000") && (((str.Substring(0, 2).CompareTo("88") > 0) && (str.Substring(2, 2).CompareTo("88") > 0)) && (str.Substring(4, 2).CompareTo("88") > 0)))
            {
                return "0";
            }
            return "1";
        }

        public static string process4BitData(string str, int widthCnt, int width)
        {
            if (((width % 2) == 1) && (widthCnt == width))
            {
                if (str.Substring(0, 1).CompareTo("8") > 0)
                {
                    return "00";
                }
                return "10";
            }
            string str2 = "";
            string str3 = "";
            if (str.Equals("FF"))
            {
                return "00";
            }
            if (str.Equals("00"))
            {
                return "11";
            }
            if (str.Substring(0, 1).CompareTo("8") < 0)
            {
                str2 = "1";
            }
            else
            {
                str2 = "0";
            }
            if (str.Substring(1, 1).CompareTo("8") < 0)
            {
                str3 = "1";
            }
            else
            {
                str3 = "0";
            }
            return (str2 + str3);
        }
    }
}

