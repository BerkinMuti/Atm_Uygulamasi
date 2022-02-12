using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Projesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sifre = "0101";
            double bakiye = 1000;
            MENU:
            Console.WriteLine("\t Kartlı İşlemler \t 1 \n \t Kartsız işlemler \t 2  \n \t Çıkış için \t \t 3");

            string giris = Console.ReadLine();
            switch (giris)
            {
                case "1":
                    string kartSifre = "";
                    int hak = 0;

                    while (kartSifre != sifre && hak < 3)
            {
                         hak++;
                         Console.WriteLine("Kart şifresini giriniz");
                         kartSifre = Console.ReadLine();
                         if (kartSifre != sifre)
                         {
                            Console.WriteLine(hak + ". hakkınızda şifre hatalıdır.");
                         }
            }

            if (kartSifre == sifre)
                    {
                    ANAMENU:
                        Console.WriteLine("********Ana Menü \n \t Para Çekmek için 1 \n\t Para Yatırmak İçin 2 \n\t Para Transferleri için 3 \n\t Eğitim Ödemeleri 4 \n\t Ödemeler  5 \n\t Bilgi Güncelleme 6\n\t Çıkış  7");

                        string menuSecim = Console.ReadLine();

                        switch (menuSecim)
                        {
                            #region Para Çekme Alanı
                            case "1":
                            CEK:
                                Console.WriteLine("Çekmek istediğiniz tutarı giriniz");

                                double cekilecekMiktar = Convert.ToDouble(Console.ReadLine());

                                if (bakiye >= cekilecekMiktar)
                                {
                                    bakiye = bakiye - cekilecekMiktar;

                                    Console.WriteLine("İşlem Gerçekleştiriliyor...");
                                    System.Threading.Thread.Sleep(3000);

                                    Console.WriteLine("Çekilen tutar: {0} TL\n Yeni Bakiyeniz {1} TL", cekilecekMiktar, bakiye);


                                }
                                else
                                {
                                    Console.WriteLine("Yetersiz Bakiye");
                                    Console.WriteLine("Yeni Giriş İçin 1");
                                    Console.WriteLine("Ana Menü için 9");
                                    string secimBakiye = Console.ReadLine();

                                    if (secimBakiye == "9")
                                    {
                                        goto ANAMENU;
                                    }
                                    else if (secimBakiye == "1")
                                    {
                                        goto CEK;
                                    }
                                }

                                break;


                            #endregion
                            #region Para Yatırma Alanı

                            case "2":

                                Console.WriteLine("\t Kredi Kartına 1 \n \t Kendi Hesabınıza Para Yatırmak için 2 \n\t Ana Menü 9");
                                string secimParaYatirma = Console.ReadLine();
                                if (secimParaYatirma == "1")
                                {
                                KARTALANI:
                                    Console.WriteLine("Kredi kartı için en az 12 haneli kart numaranızı giriniz");
                                    string kartNo = Console.ReadLine();

                                    if (kartNo.Length >= 12)
                                    {
                                        Console.WriteLine("Kredi kartına yatırmak istediğiniz tutarı yazınız.");
                                        double kartYatiralacakTutar = Convert.ToDouble(Console.ReadLine());
                                        if (bakiye >= kartYatiralacakTutar)
                                        {
                                            bakiye = bakiye - kartYatiralacakTutar;
                                            Console.WriteLine("İşlem Gerçekleştiriliyor...");
                                            System.Threading.Thread.Sleep(3000);
                                            Console.WriteLine("Kredi Kartına Yatırılan Tutar :{0}\n Yeni Bakiyeniz {1}", kartYatiralacakTutar, bakiye);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Kart numarasını hatalı girdiniz");
                                        Console.WriteLine("\nKredi kartı numarasını tekrar girmek için   1");
                                        Console.WriteLine("\nAna Menu için 9 ");

                                        string ikinciSecimKart = Console.ReadLine();

                                        if (ikinciSecimKart == "9")
                                        {
                                            goto ANAMENU;
                                        }
                                        else if (ikinciSecimKart == "1")
                                        {
                                            goto KARTALANI;
                                        }
                                    }

                                }
                                else if (secimParaYatirma == "2")
                                {
                                    Console.WriteLine("Yatırılacak Miktarı Giriniz.");
                                    bakiye = bakiye + Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("İşlem Gerçekleştiriliyor...");
                                    System.Threading.Thread.Sleep(3000);
                                    Console.WriteLine("\t Yeni Bakiyeniz :" + bakiye + " TL");
                                }

                                break;

                            #endregion
                            #region Para Transfer Alanı

                            case "3":
                            TRANSFER:
                                Console.WriteLine("\t EFT İşlemi için 1 \n\t Havale İşlemi için 2");

                                string secimTransfer = Console.ReadLine();

                                if (secimTransfer == "1")
                                {
                                EFT:
                                    Console.WriteLine("Yatırmak istediğiniz IBAN numarasını başında TR olacak şekilde giriniz.");
                                    string iban = Console.ReadLine();
                                    long trIban = long.Parse(iban.Substring(2));
                                    string tr = iban.Substring(0, 2).ToLower();

                                    if (tr == "tr")
                                    {
                                        if (trIban >= 100000000000 && trIban <= 999999999999)
                                        {
                                        trMiktar:
                                            Console.WriteLine("Yatıralacak Tutarı Giriniz");
                                            double trMiktar = Convert.ToDouble(Console.ReadLine());
                                            if (bakiye >= trMiktar)
                                            {
                                                bakiye = bakiye - trMiktar;
                                                Console.WriteLine("İşlem Gerçekleştiriliyor...");
                                                System.Threading.Thread.Sleep(3000);
                                                Console.WriteLine(trIban + " hesabına " + trMiktar + " TL tutarında gönderim yapılmıştır.");
                                                Console.WriteLine("Yeni Bakiyeniz: " + bakiye);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Bakiyeniz Yetersiz. Tekrar Deneyiniz");
                                                goto trMiktar;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("IBAN numarasını hatalı girdiniz");
                                        Console.WriteLine("\n IBAN numarasını tekrar girmek için 1");
                                        Console.WriteLine("\t Ana Menu için 9");

                                        string tekrarSecimEft = Console.ReadLine();

                                        if (tekrarSecimEft == "9")
                                        {
                                            goto ANAMENU;
                                        }
                                        else if (tekrarSecimEft == "1")
                                        {
                                            goto EFT;
                                        }

                                    }



                                }
                                else if (secimTransfer == "2")
                                {
                                HAVALE:
                                    Console.WriteLine("Yatırmak istediğiniz hesap numarasını giriniz '11 Hane'");
                                    long hesapNo = long.Parse(Console.ReadLine());

                                    if (hesapNo >= 10000000000 && hesapNo <= 99999999999)
                                    {
                                    HesapMiktar:
                                        Console.WriteLine("Yatırılacak Tutarı Girniz.");
                                        double havaleMiktar = Convert.ToDouble(Console.ReadLine());
                                        if (bakiye >= havaleMiktar)
                                        {
                                            bakiye = bakiye - havaleMiktar;
                                            Console.WriteLine("İşlem Gerçekleştiriliyor...");
                                            System.Threading.Thread.Sleep(3000);
                                            Console.WriteLine("Belirtilen " + hesapNo + " numarasına  " + havaleMiktar + " TL tutarında gönderim yapılmıştır.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\t Bakiyeniz yetersiz. Tekrar giriş yapınız. Bakiyeniz " + bakiye + " TL");
                                            goto HesapMiktar;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hatalı Hesap Numarası");
                                        System.Threading.Thread.Sleep(1000);
                                        Console.WriteLine("Hesap Numarasını tekrar girmek için 1");
                                        Console.WriteLine("Ana Menüye Dönmek için 9");

                                        string havaleSecim = Console.ReadLine();

                                        if (havaleSecim == "1")
                                        {
                                            goto HAVALE;
                                        }
                                        else if (havaleSecim == "9")
                                        {
                                            goto ANAMENU;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı bir seçim yaptınız");
                                    Console.WriteLine("Para Transfer Ekranına Dönem için 1");
                                    Console.WriteLine("Ana Menüye dönmek için 9'a basınız");
                                    if (Console.ReadLine() == "9")
                                    {

                                        goto ANAMENU;
                                    }
                                    else if (Console.ReadLine() == "1")
                                    {
                                        goto TRANSFER;
                                    }
                                }

                                break;

                            #endregion
                            #region Egitim Bolumu

                            case "4":
                                Console.WriteLine("Eğitim Ödemeleri Sayfasına şu an erişilemiyor. Daha sonra tekrar deneyiniz");
                                Console.WriteLine("Ana Menüye Dönmek İsterseniz 9'a basın.");
                                string egitimSecim = Console.ReadLine();
                                if (egitimSecim == "9")
                                {
                                    goto ANAMENU;
                                }
                                else
                                {
                                    Console.WriteLine("Çıkış Yapılıyor...");
                                    System.Threading.Thread.Sleep(3000);
                                    break;
                                }


                            #endregion
                            #region Ödeme Bölümü
                            case "5":
                            FATURAODEME:
                                Console.WriteLine("***********Fatura Ödemeleri");
                                Console.WriteLine("Elektrik Faturası 1");
                                Console.WriteLine("Telefon Faturası 2");
                                Console.WriteLine("İnternet Faturası 3");
                                Console.WriteLine("Su Faturası 4");
                                Console.WriteLine("Ana Menüye Dönmek İçin 9");

                                string secimFatura = Console.ReadLine();
                                double faturaTutar = 40;
                                if (secimFatura == "1")
                                {
                                ELEKTRIKFATURA:
                                    Console.WriteLine("Elektrik Sözleşme Numarasını Giriniz(15 Haneli):");
                                    string eSozlesmeNo = Console.ReadLine();

                                    if (eSozlesmeNo.Length == 15)
                                    {
                                        Console.WriteLine("Fatura tutarınız : " + faturaTutar + " TL");
                                        Console.WriteLine("Ödeme yapmak istiyor musunuz ? (E/H)");
                                        string eFaturaOdeme = Console.ReadLine().ToUpper();
                                        if (eFaturaOdeme == "E")
                                        {
                                            if (bakiye >= faturaTutar)
                                            {
                                                bakiye = bakiye - faturaTutar;

                                                Console.WriteLine(faturaTutar + " TL tutarındaki faturanız ödendi. Yeni Bakiyeniz : " + bakiye + " TL");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Bakiyeniz yetersiz");

                                            }

                                            Console.WriteLine("Ana Menu için 9");
                                            Console.WriteLine("Yeni fatura ödemesi için 1");


                                            string secimEFatura = Console.ReadLine();
                                            if (secimEFatura == "9")
                                            {
                                                goto ANAMENU;
                                            }
                                            else if (secimEFatura == "1")
                                            {
                                                goto FATURAODEME;
                                            }



                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçerli bir sözleşme numarası giriniz");
                                        goto ELEKTRIKFATURA;
                                    }
                                }
                                else if (secimFatura == "2")
                                {
                                TELEFONFATURA:

                                    Console.WriteLine("Telefon numaranızı 0 olmadan giriniz");

                                    string telNo = Console.ReadLine();

                                    if (telNo.Length == 10)
                                    {
                                        Console.WriteLine("Fatura tutarınız : " + faturaTutar + " TL ");
                                        Console.WriteLine("Ödeme yapmak istiyor musunuz?( E/H)");
                                        string telOdemeS = Console.ReadLine().ToUpper();
                                        if (telOdemeS == "E")
                                        {
                                            bakiye = bakiye - faturaTutar;

                                            Console.WriteLine(faturaTutar + " TL fatura ödemesi yapıldı. Yeni Bakiyeniz : " + bakiye + " TL");
                                        }

                                        Console.WriteLine("Ana Menü için 9");
                                        Console.WriteLine("Yeni Fatura Girişi İçin 1");


                                        if (Console.ReadLine() == "9")
                                        {
                                            goto ANAMENU;
                                        }
                                        else if (Console.ReadLine() == "1")
                                        {
                                            goto FATURAODEME;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hatalı Telefon Numarası");
                                        Console.WriteLine("Ana Menu için 9");
                                        Console.WriteLine("Tekrar telefon girişi için 1");
                                        string telfSecim = Console.ReadLine();

                                        if (telfSecim == "9")
                                        {
                                            goto ANAMENU;
                                        }
                                        else if (telfSecim == "1")
                                        {
                                            goto TELEFONFATURA;
                                        }
                                    }
                                }
                                else if (secimFatura == "3")
                                {
                                    Console.WriteLine("İnternet Sözleşme numaranızı giriniz");
                                    string netSozlesmeNo = Console.ReadLine();

                                    if (netSozlesmeNo.Length == 10)
                                    {
                                        Console.WriteLine("Fatura Tutarınız : " + faturaTutar + " TL");
                                        Console.WriteLine("Ödeme yapmak istiyor musunuz? (E/H)");
                                        string netOdemeOnay = Console.ReadLine().ToLower();

                                        if (netOdemeOnay == "e")
                                        {
                                            bakiye = bakiye - faturaTutar;

                                            Console.WriteLine(faturaTutar + " TL fatura ödemesi yapıldı. Yeni Bakiyeniz :" + bakiye + " TL");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hatalı Giriş");
                                    }
                                }
                                else if (secimFatura == "4")
                                {
                                SUFATURA:
                                    Console.WriteLine("8 Haneli Su Fatura sözleşme numaranızı giriniz");
                                    string suSozlesmeNo = Console.ReadLine();
                                    if (suSozlesmeNo.Length == 8)
                                    {
                                        Console.WriteLine("Su Faturanız:" + faturaTutar + "TL");
                                        Console.WriteLine("Ödemeyi Onaylıyor musunuz?(E/H):");
                                        string efatura = Console.ReadLine().ToUpper();
                                        if (efatura == "E")
                                        {
                                            if (bakiye >= faturaTutar)
                                            {
                                                bakiye = bakiye - faturaTutar;
                                                Console.WriteLine(faturaTutar + " TL tutarındaki faturanız ödendi. Yeni Bakiyeniz : " + bakiye + " TL");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Bakiyeniz yetersiz");
                                            }
                                        }
                                        else if (efatura == "H")
                                        {
                                            Console.WriteLine("Ödeme Yapılmadı");
                                        }
                                        Console.WriteLine("Ana Menu için 9");
                                        Console.WriteLine("Yeni fatura ödemesi için 1");
                                        string secimEFatura = Console.ReadLine();
                                        if (secimEFatura == "9")
                                        {
                                            goto ANAMENU;
                                        }
                                        else if (secimEFatura == "1")
                                        {
                                            goto FATURAODEME;
                                        }

                                        else
                                        {
                                            Console.WriteLine("Geçerli Numara Giriniz...");
                                            goto SUFATURA;

                                        }
                                    }
                                    else if (secimFatura == "9")
                                    {
                                        Console.WriteLine("Ana Menüye Yönlendiriliyorsunuz...");
                                        goto ANAMENU;
                                    }
                                    break;
                                    #endregion

                                }
                                break;
                            #region Şifre İşlemleri
                            case "6":
                                Console.WriteLine("Şifre Değiştirme Ekranı");

                                Console.WriteLine("Eski Şifrenizi Giriniz");
                                string eskiSifre = Console.ReadLine();

                                if (eskiSifre == sifre)
                                {
                                    Console.WriteLine("Yeni Şifre Girniz");

                                    string sifre1 = Console.ReadLine();

                                    Console.WriteLine("Yeni Şifrenizi Tekrar Giriniz.");

                                    string sifre2 = Console.ReadLine();

                                    if (sifre1 == sifre2)
                                    {
                                        sifre = sifre1;
                                        Console.WriteLine("Şifreniz Değiştirilmiştir.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Şifreleriniz eşleşmiyor.");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Şifreniz Hatalı");
                                }

                                break;
                            case "7":
                                Console.WriteLine("Çıkış Yapılıyor...");
                                System.Threading.Thread.Sleep(3000);
                                break;

                            #endregion

                            default:
                                Console.WriteLine("Hatalı bir seçim yaptınız");
                                Console.WriteLine("Ana Menüye dönmek için 9'a basınız");
                                if (Console.ReadLine() == "9")
                                {
                                    goto ANAMENU;
                                }
                                break;
                        }
                    }

                    break;
                case "2":
                    Console.WriteLine("Kartsız işlemler menümüz aktif değildir");
                    Console.WriteLine("Çıkış için \t 0 \nAnamenü için \t 9");
                    string kontrol = Console.ReadLine();
                    if (kontrol == "0") 
                    {
                        Console.WriteLine("Çıkış Yapılıyor...");
                        System.Threading.Thread.Sleep(3000);
                        break;
                    }
                    else if (kontrol =="9")
                    {
                        Console.WriteLine("Menüye dönülüyor...");
                        System.Threading.Thread.Sleep(3000);
                        goto MENU;
                    }
                    else
                    {
                        Console.WriteLine("Hatalı Seçim Yaptınız");
                        break;
                    }
                case "3":
                    Console.WriteLine("Çıkış Yapılıyor...");
                    System.Threading.Thread.Sleep(3000);
                    break;
                default:
                    Console.WriteLine("Hatalı Seçim Yaptınız");
                    break;
            }

            Console.ReadKey();

        }
    }
}