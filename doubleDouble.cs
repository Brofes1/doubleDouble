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
            doubleAsString = Convert.ToString(doubleAsLong, 2);
			
			try{signs = doubleAsString[63] >> 1;} catch (IndexOutOfRangeException e){}
			doubleAsLong = doubleAsLong >> 1;
			doubleAsLong = doubleAsLong | 1 << 63;
			doubleAsString = Convert.ToString(doubleAsLong, 2);
			
            if (doubleAsString.Length < 64)
                doubleAsString = "0" + doubleAsString;
            for (int i = 1; i < 2; i++)
                signs = signs | doubleAsString[i];
            for (int i = 2; i < 13; i++)
                try {exponent = exponent + doubleAsString[i];} catch (IndexOutOfRangeException e){break;}
            for (int i = 13; i < 65; i++)
                try {mantissa = mantissa + doubleAsString[i];} catch (IndexOutOfRangeException e){break;}

            Console.WriteLine(doubleAsString);
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
			double test2 = 0;
			test.seperateDouble(test2);
        }
    }
}
