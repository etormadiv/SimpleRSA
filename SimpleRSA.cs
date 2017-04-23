using System;
using System.Numerics;
					
public class Program
{
	public static void Main()
	{
		BigInteger p = BigInteger.Parse("58EA1F072BF7A8A8216B73A037EB807162498F6DE13502FE4D908E9D12E5FEFC05D4E76A493CD909DC9C6C6CF9066EA194F24D218DB253C8B2A53D2870DD9B97", System.Globalization.NumberStyles.HexNumber);
		
		BigInteger q = BigInteger.Parse("1E523F5992C10A2D559217299E044951CF7DE8A9857E53EE7DD254B517547333C6D964D7306CB66239F1F6DFF0A415EF52487BB1B9334AB68A7F0876649CE45B", System.Globalization.NumberStyles.HexNumber);
		
		BigInteger n = BigInteger.Multiply(p, q);
		
		BigInteger e = BigInteger.Parse("10001", System.Globalization.NumberStyles.HexNumber);
		
		BigInteger phi = (p - 1) * (q - 1);
		
		if(BigInteger.GreatestCommonDivisor(e, phi) != BigInteger.One)
		{
			Console.WriteLine("Invalid e value");
			return;
		}
		
		
		BigInteger d = ModInverse(e, phi);
		
		//Encryption
		//msg="Hello Crypto RSA"
		BigInteger plainText = BigInteger.Parse("48656C6C6F2043727970746F20525341", System.Globalization.NumberStyles.HexNumber);
		BigInteger cipherText = BigInteger.ModPow(plainText, e, n);
		
		Console.WriteLine("cipherText:");
		Console.WriteLine(cipherText);
		
		
		//Decryption
		
		plainText = BigInteger.Zero;
		plainText = BigInteger.ModPow(cipherText, d, n);
		
		Console.WriteLine("plainText:");
		Console.WriteLine(plainText);
		
		Console.ReadLine();	
	}
	
	public static BigInteger ModInverse(BigInteger a, BigInteger n) 
	{
		BigInteger i = n, v = 0, d = 1;
		
		while (a>0) {
			BigInteger t = i/a, x = a;
			a = i % x;
			i = x;
			x = d;
			d = v - t*x;
			v = x;
		}
		
		v %= n;
		if (v<0) v = (v+n)%n;
		return v;
	}
}