using System;

namespace Borfendosm
{
	public class doubleDouble
	{
        int signs = 0x00000000000000000000000000000000; //yes, declared *this way*
		int primary, e, ee;
        string doubleAsString, mantissa, exponent;
        long doubleAsLong;

		public doubleDouble(int Primary, int E, int Ee)
		{
			primary = Primary;
			e = E;
			ee = Ee;
		}

        public void seperateDouble(double toSeperate)
        {
            doubleAsLong = BitConverter.DoubleToInt64Bits(toSeperate);
			Console.WriteLine(doubleAsLong);
            doubleAsString = Convert.ToString(doubleAsLong, 2);
			
			try	{signs = doubleAsString[63] >> 1;} catch (IndexOutOfRangeException e){Console.Write("a ");}
			Console.WriteLine(signs + " " + doubleAsString);
			doubleAsLong = doubleAsLong >> 1;
			doubleAsLong = doubleAsLong;// | 1L << 62;
			doubleAsString = Convert.ToString(doubleAsLong, 2);
			doubleAsString = doubleAsString + 0;
			
			Console.WriteLine(doubleAsString);
			
            if (doubleAsString.Length < 64)
                doubleAsString = "0" + doubleAsString;
            for (int i = 64; i > 63; i--)
                signs = signs | doubleAsString[i];
            for (int i = 63; i > 52; i--)
                try {exponent = exponent + doubleAsString[i];} catch (IndexOutOfRangeException e){break;}
            for (int i = 52; i > 0; i--)
                try {mantissa = mantissa + doubleAsString[i];} catch (IndexOutOfRangeException e){break;}

            Console.WriteLine(doubleAsString + " " + mantissa + " " + exponent);
        }

        public void bitRight(double amount)
        {
			
        }
	}
	
    public class main
    {
        public static void Main(string[] args)
        {
			doubleDouble test = new doubleDouble(0, 0, 0);
			double test2 = 4;
			test.seperateDouble(test2);
        }
    }
}