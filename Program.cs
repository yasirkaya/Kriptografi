using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace md5_ödev
{
    class Program
    {
        static string metin;

        public static void oku(string dosya)
        {
            using(StreamReader sr=new StreamReader(dosya))
            {
                metin = sr.ReadToEnd();
                Console.WriteLine(metin);
            }    
        }
        public static string Md5Hash(string veri)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string[] hex;
            byte[] dizi = Encoding.UTF8.GetBytes(veri);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach(byte b in dizi)
            {
                sb.Append(b.ToString("x2"));
            }
            metin = sb.ToString();
            return sb.ToString().Substring(24,1);
        }


        static void Main(string[] args)
        {
            string hex7 = "";
            oku("text.txt");
            Console.Write("tekrar sayısı giriniz:");
            int tekrar = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < tekrar; i++)
            {
                hex7 += Md5Hash(metin);
            }
            Console.WriteLine(hex7);
            Console.WriteLine(Convert.ToInt64(hex7,16));
        }
    }
}
