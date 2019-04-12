using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20181115KullaniciKayitUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // ad soyad, telefon no, TCKN, cinsiyet,doğumtarihi, Kan grubu ve e-posta bilgilerinin girildiği 10 kişilik bir özel rehber uygulaması. Bilgiler validlenmiş olmalı.

            DateTime d1 = new DateTime(2017, 11, 20,10,20,16);
            DateTime d2 = new DateTime(2018, 11, 19,5,15,12);
            TimeSpan fark = (d2 - d1);
            Console.WriteLine(fark.TotalMinutes);

            bool isimKontrol;
            int boslukSayisi;
            do
            {
                #region isimKontrol
                isimKontrol = true;
                boslukSayisi = 0;
                string adSoyad;
                Console.Write("Lütfen adınızı ve soyadınızı girin: ");
                adSoyad = Console.ReadLine();
                if (string.IsNullOrEmpty(adSoyad.Trim()))
                {
                    Console.WriteLine("Lütfen Ad Soyad alanını doldurun.");
                    isimKontrol = false;
                }

                if(adSoyad.Trim().Length<6 || adSoyad.Trim().Length>35)
                {
                    Console.WriteLine("Ad Soyad alanı en az 6, en fazla 35 karakter olmalıdır.");
                    isimKontrol = false;
                }

                for (int i = 0; i < adSoyad.Length; i++)
                {
                    if (char.IsLetter(adSoyad[i]) == false && char.IsWhiteSpace(adSoyad[i])==false)
                    {
                        isimKontrol = false;
                        break;//döngüyü sonlandırır. 
                    }
                }

                for (int i = 0; i < adSoyad.Trim().Length; i++)
                {
                    if (char.IsWhiteSpace(adSoyad[i]))
                        boslukSayisi++;
                }
                if (boslukSayisi > 2)
                {
                    Console.WriteLine("Lütfen düzgün formatta ad soyad girin.");
                    isimKontrol = false;
                }
                #endregion
            } while (!isimKontrol);
            bool telefonKontrol = false;
            string telNo;

            do
            {
                telefonKontrol = true;
                Console.Write("Telefon Numaranızı Girin: ");
                telNo = Console.ReadLine();
                if (string.IsNullOrEmpty(telNo.Trim()))
                {
                    Console.WriteLine("Telefon alanını boş geçemezsiniz.");
                    telefonKontrol = false;
                }
                if (telNo.Length != 10)
                {
                    Console.WriteLine("Telefon numarası başında 0 olmadan 10 haneli olacak şekilde yazılmalıdır.");
                    telefonKontrol = false;
                }

                if (!telNo.StartsWith("55") && !telNo.StartsWith("54") && !telNo.StartsWith("53") && !telNo.StartsWith("50"))
                {
                    Console.WriteLine("Telefon numarası 50xxxxxxxx , 53xxxxxxxx,54xxxxxxxx,55xxxxxxxx ile formatında olmalıdır.");
                    telefonKontrol = false;

                }

                for (int i = 0; i < telNo.Length; i++)
                {
                    if (!char.IsNumber(telNo[i]))
                    {
                        Console.WriteLine("Telefon numarası sadece rakamlardan oluşmalıdır.");
                        telefonKontrol = false;
                        //break; 
                        i = telNo.Length;
                    }
                }
            } while (!telefonKontrol);


            bool dtKontrol = false;

            do
            {

                dtKontrol = true;
                Console.WriteLine("Doğum tarihinizi girin: ");
                string dt = Console.ReadLine();
                DateTime dogumTarihi = new DateTime();
                if(DateTime.TryParse(dt,out dogumTarihi)==false)
                {
                    Console.WriteLine("Lütfen doğru formatta tarih bilgisi girin (GG/AA/YYYY)");
                    dtKontrol = false;
                }


                if((DateTime.Now.Year- dogumTarihi.Year)<18 || 
                   DateTime.Now.Year- dogumTarihi.Year > 65)
                {
                    Console.WriteLine("Yasak");
                    dtKontrol = false;
                }

            } while (!dtKontrol);
            Console.WriteLine("Bravo doğru girdin.");
            Console.ReadKey();
        }
    }
}
