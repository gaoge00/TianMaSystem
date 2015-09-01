namespace Function
{
    using System;

    public class Conversion
    {
        public static string BinToHex(string binData)
        {
            return new Hex(new Bits(binData).ToBytes()).ToString();
        }

        public static int BinToInt(string binData)
        {
            return new Bits(binData).ToInt();
        }

        public static uint BinToUInt(string binData)
        {
            return new Bits(binData).ToUInt();
        }

        public static string HexToBin(string hexData)
        {
            return new Bits(new Hex(hexData).ToBytes()).ToString();
        }

        public static int HexToInt(string hexData)
        {
            return new Hex(hexData).ToInt();
        }

        public static uint HexToUInt(string hexData)
        {
            return new Hex(hexData).ToUInt();
        }

        public static string IntToBin(int number, int numBits)
        {
            return new Bits(number, numBits).ToString();
        }

        public static string IntToHex(int data, int numBytes)
        {
            return new Hex(data, numBytes).ToString();
        }

        public static uint IntToUInt(int data, int numBits)
        {
            uint num2 = Convert.ToUInt32((double) (Math.Pow(2.0, (double) numBits) - 1.0));
            if (data < 0)
            {
                return Convert.ToUInt32((long) ((data + num2) + 1L));
            }
            return Convert.ToUInt32(data);
        }

        public static string UIntToBin(uint number, int numBits)
        {
            return new Bits(number, numBits).ToString();
        }

        public static string UIntToHex(uint data, int numBytes)
        {
            return new Hex(data, numBytes).ToString();
        }

        public static int UIntToInt(uint data, int numBits)
        {
            long num = data;
            long num2 = Convert.ToInt32((double) (Math.Pow(2.0, (double) (numBits - 1)) - 1.0));
            if (data > num2)
            {
                num -= Convert.ToInt64(Math.Pow(2.0, (double) numBits));
            }
            return Convert.ToInt32(num);
        }
    }
}

