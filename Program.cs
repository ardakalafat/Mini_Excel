using Microsoft.VisualBasic;
using System;
using System.IO;

internal class Program
{
    // Global deðiþkenler: Fonksiyonlarýn eriþebilmesi için burada tanýmlandý
    static int rows = 15;
    static int cols = 10;
    static int currentrows = 8;
    static int currentcols = 5;

    static string[,] tablo = new string[rows, cols];
    static string[,] hucretipi = new string[rows, cols];

    private static void Main(string[] args)
    {
        char karakter = 'A';
        Console.Write("  ");
        for (int i = 0; i < currentcols; i++)
        {
            char harf0 = (char)(karakter + i);
            Console.Write("  " + harf0 + "  ");
        }
        Console.WriteLine();
        for (int r = 0; r < currentrows; r++)
        {
            // Satýr numarasý formatlamasý
            string sNo = Convert.ToString(r + 1);

            // Satýr numarasýný yaz
            Console.Write(sNo.PadLeft(5) + "|");

            // Hücreleri yaz
            for (int c = 0; c < currentcols; c++)
            {
                string hucre = tablo[r, c];

                if (hucre == null) // Boþsa nokta koy
                {
                    hucre = ".";
                }
                Console.Write("  " + hucre.PadRight(5));
            }

            Console.WriteLine();
        }

        while (true)
        {
            Console.WriteLine("Bir komut giriniz");
            string komut = Console.ReadLine();

            // 1) Fonksiyon adýný bul
            int parantezIndex = komut.IndexOf('(');
            string fonksiyonadi = komut.Substring(0, parantezIndex);

            // 2) Parantez içindeki parametreleri al
            int parantezBas = komut.IndexOf('(');
            int parantezBit = komut.IndexOf(')');
            string parametreBolumu = komut.Substring(parantezBas + 1, parantezBit - parantezBas - 1);

            // 3) Parametreleri böl
            string[] parametreler = parametreBolumu.Split(',');

            // 4) Boþluklarý temizle (Trim)
            for (int i = 0; i < parametreler.Length; i++)
            {
                parametreler[i] = parametreler[i].Trim();
            }

            // 5) Fonksiyona göre yönlendirme
            if (fonksiyonadi == "AssignValue")
            {
                AssignValue(parametreler[0], parametreler[1], parametreler[2]);
                PrintTable();
            }
            else if (fonksiyonadi == "ClearCell")
            {
                ClearCell(parametreler[0]);
                PrintTable();
            }
            else if (fonksiyonadi == "ClearAll")
            {
                ClearAll();
                PrintTable();
            }
            else if (fonksiyonadi == "AddRow")
            {
                int x = Convert.ToInt32(parametreler[0]);
                AddRow(x, parametreler[1]);
                PrintTable();
            }
            else if (fonksiyonadi == "AddColumn")
            {
                AddColumn(parametreler[0], parametreler[1]);
                PrintTable();
            }
            else if (fonksiyonadi == "Copy")
            {
                Copy(parametreler[0], parametreler[1]);
                PrintTable();
            }
            else if (fonksiyonadi == "CopyRow")
            {
                CopyRow(parametreler[0], parametreler[1]);
                PrintTable();
            }
            else if (fonksiyonadi == "CopyColumn")
            {
                CopyColumn(parametreler[0], parametreler[1]);
                PrintTable();
            }
            else if (fonksiyonadi == "X")
            {
                X(parametreler[0], parametreler[1]);
                PrintTable();
            }
            else if (fonksiyonadi == "XRow")
            {
                XRow(parametreler[0], parametreler[1]);
                PrintTable();
            }
            else if (fonksiyonadi == "XColumn")
            {
                XColumn(parametreler[0], parametreler[1]);
                PrintTable();
            }
            else if (fonksiyonadi == "*")
            {
                operator1(parametreler[0], parametreler[1], parametreler[2]);
                PrintTable();
            }
            else if (fonksiyonadi == "+")
            {
                // 4 parametre: 3 sayý toplama
                if (parametreler.Length == 4)
                {
                    operator2(parametreler[0], parametreler[1], parametreler[2], parametreler[3]);
                }
                // 3 parametre: 2 sayý toplama
                else if (parametreler.Length == 3)
                {
                    operator2(parametreler[0], parametreler[1], null, parametreler[2]);
                }
                PrintTable();
            }
            else if (fonksiyonadi == "/")
            {
                operator3(parametreler[0], parametreler[1], parametreler[2]);
                PrintTable();
            }
            else if (fonksiyonadi == "-")
            {
                operator4(parametreler[0], parametreler[1], parametreler[2]);
                PrintTable();
            }
            else if (fonksiyonadi == "#")
            {
                operator5(parametreler[0], parametreler[1], parametreler[2]);
                PrintTable();
            }
            else if (fonksiyonadi == "exit")
            {
                Save("spreadsheet.txt");
                Console.WriteLine("Program sonlandýrýlýyor");
                break;
            }
        }
    }

    static void AssignValue(string cell, string type, string value)
    {
        char harf = cell[0];
        int col = harf - 'A';

        string sayikismi = cell.Substring(1);
        int row = Convert.ToInt32(sayikismi) - 1;

        // Uzunluk kontrolü ve formatlama
        if (value.Length > 5)
        {
            value = value.Substring(0, 5) + "_";
            tablo[row, col] = value;
        }
        else
        {
            tablo[row, col] = value;
        }

        // Hücre tipi atamasý
        hucretipi[row, col] = type;
        Console.WriteLine("Deðer baþarýyla atandý.");
    }

    static void PrintTable() // Tablo yazdýrma fonksiyonu
    {
        char karakter = 'A';
        Console.Write("      ");
        for (int i = 0; i < currentcols; i++)
        {
            char harf0 = (char)(karakter + i);
            Console.Write("  " + harf0 + " ".PadRight(5));
        }
        Console.WriteLine();

        for (int r = 0; r < currentrows; r++)
        {
            string sNo = Convert.ToString(r + 1);
            Console.Write(sNo.PadLeft(6) + "|");

            for (int c = 0; c < currentcols; c++)
            {
                string hucre = tablo[r, c];

                if (hucre == null)
                {
                    hucre = ".";
                }
                Console.Write("  " + hucre.PadRight(6));
            }
            Console.WriteLine();
        }
    }

    static void ClearCell(string cell)
    {
        char harf = cell[0];
        int col = harf - 'A';

        string sayikismi = cell.Substring(1);
        int row = Convert.ToInt32(sayikismi) - 1;

        if (tablo[row, col] != null) // Hücre boþ deðilse temizle
        {
            tablo[row, col] = null;
            Console.WriteLine("Hücreniz temizlenmiþtir");
        }
        else
        {
            Console.WriteLine("Seçtiðiniz hücre zaten boþ");
        }
    }

    static void ClearAll()
    {
        // Tüm tabloyu tara ve sil
        for (int i = 0; i < currentrows; i++)
        {
            for (int j = 0; j < currentcols; j++)
            {
                tablo[i, j] = null;
                hucretipi[i, j] = null;
            }
        }
    }

    static void AddRow(int satir, string yon)
    {
        if (currentrows >= rows)
        {
            Console.WriteLine("Out of bounds exception");
            return;
        }

        yon = yon.ToLower().Trim();

        // Satýr numarasý kontrolü
        if (satir < 1 || satir > currentrows)
        {
            Console.WriteLine("Illegal position assignment");
            return;
        }

        // Eklenecek satýrýn indexini belirle
        int rowguncel;
        if (yon == "down")
        {
            rowguncel = satir;
        }
        else if (yon == "up")
        {
            rowguncel = satir - 1;
        }
        else
        {
            Console.WriteLine("Illegal yon parameter");
            return;
        }

        // Sondan baþlayarak satýrlarý kaydýr
        for (int i = currentrows - 1; i >= rowguncel; i--)
        {
            for (int j = 0; j < currentcols; j++)
            {
                tablo[i + 1, j] = tablo[i, j];
                hucretipi[i + 1, j] = hucretipi[i, j];
            }
        }

        // Yeni satýrý boþalt
        for (int j = 0; j < currentcols; j++)
        {
            tablo[rowguncel, j] = null;
            hucretipi[rowguncel, j] = "unassigned";
        }
        currentrows++;
        Console.WriteLine("Operation is done");
    }

    static void AddColumn(string sutun, string yon)
    {
        char sutunchar = sutun.ToUpper()[0];
        int mevcutSutunIndex = sutunchar - 'A';

        yon = yon.ToLower();
        yon = yon.Trim();

        if (currentcols >= cols)
        {
            Console.WriteLine("Out of bounds exception");
            return;
        }

        if (mevcutSutunIndex < 0 || mevcutSutunIndex >= currentcols)
        {
            Console.WriteLine("Illegal position assignment");
            return;
        }

        int yeniSutunIndexi;
        if (yon == "right")
        {
            yeniSutunIndexi = mevcutSutunIndex + 1;
        }
        else if (yon == "left")
        {
            yeniSutunIndexi = mevcutSutunIndex;
        }
        else
        {
            Console.WriteLine("Illegal yon parameter. Please use 'right' or 'left'.");
            return;
        }

        // Sütunlarý saða kaydýr
        for (int j = currentcols - 1; j >= yeniSutunIndexi; j--)
        {
            for (int i = 0; i < currentrows; i++)
            {
                tablo[i, j + 1] = tablo[i, j];
                hucretipi[i, j + 1] = hucretipi[i, j];
            }
        }

        // Yeni sütunu boþalt
        for (int i = 0; i < currentrows; i++)
        {
            tablo[i, yeniSutunIndexi] = null;
            hucretipi[i, yeniSutunIndexi] = "unassigned";
        }
        currentcols++;
        Console.WriteLine("Operation is done");
    }

    static void Copy(string kopya, string kopya1)
    {
        // Kaynak hücre
        char kaynakharf = kopya[0];
        int kaynakcol = kaynakharf - 'A';
        string kaynaksayi = kopya.Substring(1);
        int kaynakrow = Convert.ToInt32(kaynaksayi) - 1;

        // Hedef hücre
        char hedefharf = kopya1[0];
        int hedefcol = hedefharf - 'A';
        string hedefsayi = kopya1.Substring(1);
        int hedefrow = Convert.ToInt32(hedefsayi) - 1;

        // Sýnýr kontrolü
        if (kaynakrow < 0 || kaynakrow >= currentrows || kaynakcol < 0 || kaynakcol >= currentcols)
        {
            Console.WriteLine("Illegal position assignment");
            return;
        }
        if (hedefrow < 0 || hedefrow >= currentrows || hedefcol < 0 || hedefcol >= currentcols)
        {
            Console.WriteLine("Illegal position assignment");
            return;
        }

        // Kopyalama iþlemi
        tablo[hedefrow, hedefcol] = tablo[kaynakrow, kaynakcol];
        hucretipi[hedefrow, hedefcol] = hucretipi[kaynakrow, kaynakcol];

        Console.WriteLine("Operation is done");
    }

    static void CopyRow(string satir1, string satir2)
    {
        int kaynakSatir = Convert.ToInt32(satir1) - 1;
        int hedefSatir = Convert.ToInt32(satir2) - 1;

        if (kaynakSatir < 0 || kaynakSatir >= currentrows || hedefSatir < 0 || hedefSatir >= currentrows)
        {
            Console.WriteLine("Illegal position assignment");
            return;
        }

        // Satýrý kopyala
        for (int j = 0; j < currentcols; j++)
        {
            tablo[hedefSatir, j] = tablo[kaynakSatir, j];
            hucretipi[hedefSatir, j] = hucretipi[kaynakSatir, j];
        }

        Console.WriteLine("Operation is done");
    }

    static void CopyColumn(string sutun1, string sutun2)
    {
        char kHarf = sutun1.ToUpper()[0];
        int kaynakSutun = kHarf - 'A';

        char hHarf = sutun2.ToUpper()[0];
        int hedefSutun = hHarf - 'A';

        if (kaynakSutun < 0 || kaynakSutun >= currentcols || hedefSutun < 0 || hedefSutun >= currentcols)
        {
            Console.WriteLine("Illegal position assignment");
            return;
        }

        // Sütunu kopyala
        for (int i = 0; i < currentrows; i++)
        {
            tablo[i, hedefSutun] = tablo[i, kaynakSutun];
            hucretipi[i, hedefSutun] = hucretipi[i, kaynakSutun];
        }

        Console.WriteLine("Operation is done");
    }

    static void X(string kopya2, string kopya4) // Kesme (Cut) iþlemi
    {
        char kaynakharf = kopya2[0];
        int kaynakcol = kaynakharf - 'A';
        string kaynaksayi = kopya2.Substring(1);
        int kaynakrow = Convert.ToInt32(kaynaksayi) - 1;

        char hedefharf = kopya4[0];
        int hedefcol = hedefharf - 'A';
        string hedefsayi = kopya4.Substring(1);
        int hedefrow = Convert.ToInt32(hedefsayi) - 1;

        if (kaynakrow < 0 || kaynakrow >= currentrows || kaynakcol < 0 || kaynakcol >= currentcols)
        {
            Console.WriteLine("Illegal position assignment");
            return;
        }
        if (hedefrow < 0 || hedefrow >= currentrows || hedefcol < 0 || hedefcol >= currentcols)
        {
            Console.WriteLine("Illegal position assignment");
            return;
        }

        // Kopyala
        tablo[hedefrow, hedefcol] = tablo[kaynakrow, kaynakcol];
        hucretipi[hedefrow, hedefcol] = hucretipi[kaynakrow, kaynakcol];

        // Kaynaðý temizle
        tablo[kaynakrow, kaynakcol] = null;
        hucretipi[kaynakrow, kaynakcol] = "unassigned";

        Console.WriteLine("Operation is done");
    }

    static void XColumn(string sutun1, string sutun2)
    {
        char kHarf = sutun1.ToUpper()[0];
        int kaynakSutun = kHarf - 'A';

        char hHarf = sutun2.ToUpper()[0];
        int hedefSutun = hHarf - 'A';

        if (kaynakSutun < 0 || kaynakSutun >= currentcols || hedefSutun < 0 || hedefSutun >= currentcols)
        {
            Console.WriteLine("Illegal position assignment");
            return;
        }

        for (int i = 0; i < currentrows; i++)
        {
            // Kopyala
            tablo[i, hedefSutun] = tablo[i, kaynakSutun];
            hucretipi[i, hedefSutun] = hucretipi[i, kaynakSutun];

            // Kes (Sil)
            tablo[i, kaynakSutun] = null;
            hucretipi[i, kaynakSutun] = "unassigned";
        }

        Console.WriteLine("Operation is done");
    }

    static void XRow(string satir1, string satir2)
    {
        int kaynakSatir = Convert.ToInt32(satir1) - 1;
        int hedefSatir = Convert.ToInt32(satir2) - 1;

        if (kaynakSatir < 0 || kaynakSatir >= currentrows || hedefSatir < 0 || hedefSatir >= currentrows)
        {
            Console.WriteLine("Illegal position assignment");
            return;
        }

        for (int j = 0; j < currentcols; j++)
        {
            // Kopyala
            tablo[hedefSatir, j] = tablo[kaynakSatir, j];
            hucretipi[hedefSatir, j] = hucretipi[kaynakSatir, j];

            // Kes (Sil)
            tablo[kaynakSatir, j] = null;
            hucretipi[kaynakSatir, j] = "unassigned";
        }

        Console.WriteLine("Operation is done");
    }

    static void operator1(string hucre1, string hucre2, string hucre3) // * operatörü
    {
        // Hücre 1
        char hucre1harf = hucre1[0];
        int col1 = hucre1harf - 'A';
        string hucre1sayi = hucre1.Substring(1);
        int row1 = Convert.ToInt32(hucre1sayi) - 1;

        // Hücre 2
        char hucre2harf = hucre2[0];
        int col2 = hucre2harf - 'A';
        string hucre2sayi = hucre2.Substring(1);
        int row2 = Convert.ToInt32(hucre2sayi) - 1;

        // Hücre 3 (Sonuç)
        char hucre3harf = hucre3[0];
        int col3 = hucre3harf - 'A';
        string hucre3sayi = hucre3.Substring(1);
        int row3 = Convert.ToInt32(hucre3sayi) - 1;

        // Sýnýr kontrolü
        if (row1 < 0 || row1 >= currentrows || col1 < 0 || col1 >= currentcols || row2 < 0 || row2 >= currentrows || col2 < 0 || col2 >= currentcols || row3 < 0 || row3 >= currentrows || col3 < 0 || col3 >= currentcols)
        {
            Console.WriteLine("Illegal operation");
            return;
        }

        string tip1 = hucretipi[row1, col1];
        string tip2 = hucretipi[row2, col2];

        if (tip1 == null || tip1 == "unassigned" || tip2 == null || tip2 == "unassigned")
        {
            Console.WriteLine("Illegal operation");
            return;
        }

        string deger1 = tablo[row1, col1];
        string deger2 = tablo[row2, col2];

        // Integer * Integer
        if (tip1 == "integer" && tip2 == "integer")
        {
            int sayi1 = Convert.ToInt32(deger1);
            int sayi2 = Convert.ToInt32(deger2);
            int sonuc = sayi1 * sayi2;

            tablo[row3, col3] = sonuc.ToString();
            hucretipi[row3, col3] = "integer";
            Console.WriteLine("Operation is done");
            return;
        }

        // String * Integer (Tekrar)
        if (tip1 == "string" && tip2 == "integer")
        {
            int k = Convert.ToInt32(deger2);
            string kelime = deger1;
            string sonuc2 = "";

            if (k >= 0)
            {
                for (int i = 0; i < k; i++)
                {
                    sonuc2 += kelime;
                }
            }
            else // Sayý negatifse kelimeyi ters çevir ve tekrarla
            {
                char[] dizi = kelime.ToCharArray();
                Array.Reverse(dizi);
                string ters = new string(dizi);

                for (int i = 0; i < Math.Abs(k); i++)
                {
                    sonuc2 += ters;
                }
            }

            tablo[row3, col3] = sonuc2;
            hucretipi[row3, col3] = "string";
            Console.WriteLine("Operation is done");
            return;
        }

        // Integer * String (Parametreler ters ise)
        if (tip1 == "integer" && tip2 == "string")
        {
            int k = Convert.ToInt32(deger1);
            string kelime = deger2;
            string sonuc2 = "";

            if (k >= 0)
            {
                for (int i = 0; i < k; i++)
                {
                    sonuc2 += kelime;
                }
            }
            else
            {
                char[] dizi = kelime.ToCharArray();
                Array.Reverse(dizi);
                string ters = new string(dizi);

                for (int i = 0; i < Math.Abs(k); i++)
                {
                    sonuc2 += ters;
                }
            }

            tablo[row3, col3] = sonuc2;
            hucretipi[row3, col3] = "string";
            Console.WriteLine("Operation is done");
            return;
        }

        // String * String
        if (tip1 == "string" && tip2 == "string")
        {
            Console.WriteLine("Illegal operation String – String operation is not allowed");
            return;
        }
    }

    static void operator2(string h1, string h2, string h3, string h4) // + operatörü
    {
        // Hücre 1
        char c1 = h1[0];
        int col1 = c1 - 'A';
        int row1 = Convert.ToInt32(h1.Substring(1)) - 1;

        // Hücre 2
        char c2 = h2[0];
        int col2 = c2 - 'A';
        int row2 = Convert.ToInt32(h2.Substring(1)) - 1;

        // Hücre 3 (Opsiyonel)
        char c3 = h3[0];
        int col3 = c3 - 'A';
        int row3 = Convert.ToInt32(h3.Substring(1)) - 1;

        // Hedef hücre
        char c4 = h4[0];
        int col4 = c4 - 'A';
        int row4 = Convert.ToInt32(h4.Substring(1)) - 1;

        // Sýnýr kontrolü
        if (row1 < 0 || row1 >= currentrows || col1 < 0 || col1 >= currentcols || row2 < 0 || row2 >= currentrows || col2 < 0 || col2 >= currentcols || row3 < 0 || row3 >= currentrows || col3 < 0 || col3 >= currentcols || row4 < 0 || row4 >= currentrows || col4 < 0 || col4 >= currentcols)
        {
            Console.WriteLine("Illegal operation");
            return;
        }

        string t1 = hucretipi[row1, col1];
        string t2 = hucretipi[row2, col2];
        string t3 = hucretipi[row3, col3];

        if (t1 == null || t2 == null || t3 == null || t1 == "unassigned" || t2 == "unassigned" || t3 == "unassigned")
        {
            Console.WriteLine("Illegal operation");
            return;
        }

        string v1 = tablo[row1, col1];
        string v2 = tablo[row2, col2];
        string v3 = tablo[row3, col3];

        // Integer + Integer + Integer
        if (t1 == "integer" && t2 == "integer" && t3 == "integer")
        {
            int a = Convert.ToInt32(v1);
            int b = Convert.ToInt32(v2);
            int c = Convert.ToInt32(v3);

            int sonuc = a + b + c;
            tablo[row4, col4] = sonuc.ToString();
            hucretipi[row4, col4] = "integer";
            Console.WriteLine("Operation is done");
            return;
        }

        // String birleþtirme
        Console.WriteLine("Harfleriniz küçük mü olsun büyük mü olsun? low ya da up diye cevaplayýnýz");
        string secim = Console.ReadLine();
        secim = secim.ToLower().Trim();

        string birlesik = v1 + v2 + v3;

        if (secim == "low")
        {
            birlesik = birlesik.ToLower();
        }
        else if (secim == "up")
        {
            birlesik = birlesik.ToUpper();
        }
        else
        {
            Console.WriteLine("Illegal operation");
            return;
        }

        tablo[row4, col4] = birlesik;
        hucretipi[row4, col4] = "string";
        Console.WriteLine("Operation is done");
    }

    static void operator3(string h1, string h2, string h3) // "/" operatörü
    {
        // Hücre 1
        char c1 = h1[0];
        int col1 = c1 - 'A';
        int row1 = Convert.ToInt32(h1.Substring(1)) - 1;

        // Hücre 2
        char c2 = h2[0];
        int col2 = c2 - 'A';
        int row2 = Convert.ToInt32(h2.Substring(1)) - 1;

        // Hedef hücre
        char c3 = h3[0];
        int col3 = c3 - 'A';
        int row3 = Convert.ToInt32(h3.Substring(1)) - 1;

        if (row1 < 0 || row1 >= currentrows || col1 < 0 || col1 >= currentcols || row2 < 0 || row2 >= currentrows || col2 < 0 || col2 >= currentcols || row3 < 0 || row3 >= currentrows || col3 < 0 || col3 >= currentcols)
        {
            Console.WriteLine("Illegal operation");
            return;
        }

        string t1 = hucretipi[row1, col1];
        string t2 = hucretipi[row2, col2];

        if (t1 == null || t2 == null || t1 == "unassigned" || t2 == "unassigned")
        {
            Console.WriteLine("Illegal operation");
            return;
        }

        string v1 = tablo[row1, col1];
        string v2 = tablo[row2, col2];

        // Integer / Integer
        if (t1 == "integer" && t2 == "integer")
        {
            int a = Convert.ToInt32(v1);
            int b = Convert.ToInt32(v2);

            if (b == 0) // Sýfýra bölme hatasý
            {
                Console.WriteLine("Illegal operation");
                return;
            }

            int sonuc = a / b;
            tablo[row3, col3] = sonuc.ToString();
            hucretipi[row3, col3] = "integer";
            Console.WriteLine("Operation is done");
            return;
        }

        // String / Integer (Parçalama)
        if ((t1 == "string" && t2 == "integer") || (t1 == "integer" && t2 == "string"))
        {
            string kelime;
            int sayi;

            if (t1 == "string")
            {
                kelime = v1;
                sayi = Convert.ToInt32(v2);
            }
            else
            {
                kelime = v2;
                sayi = Convert.ToInt32(v1);
            }

            if (sayi == 0)
            {
                Console.WriteLine("Illegal operation");
                return;
            }

            int L = kelime.Length;
            int parca = L / Math.Abs(sayi); // Aþaðý yuvarlama

            string sonuc;

            if (sayi > 0)
            {
                if (parca <= 0) sonuc = "";
                else sonuc = kelime.Substring(0, parca);
            }
            else // Negatifse sondan al
            {
                if (parca <= 0) sonuc = "";
                else sonuc = kelime.Substring(L - parca);
            }

            tablo[row3, col3] = sonuc;
            hucretipi[row3, col3] = "string";
            Console.WriteLine("Operation is done");
            return;
        }

        if (t1 == "string" && t2 == "string")
        {
            Console.WriteLine("Illegal operation String – String operation is not allowed");
            return;
        }
    }

    static void operator4(string h1, string h2, string h3) // "-" operatörü
    {
        char c1 = h1[0];
        int col1 = c1 - 'A';
        int row1 = Convert.ToInt32(h1.Substring(1)) - 1;

        char c2 = h2[0];
        int col2 = c2 - 'A';
        int row2 = Convert.ToInt32(h2.Substring(1)) - 1;

        char c3 = h3[0];
        int col3 = c3 - 'A';
        int row3 = Convert.ToInt32(h3.Substring(1)) - 1;

        if (row1 < 0 || row1 >= currentrows || col1 < 0 || col1 >= currentcols || row2 < 0 || row2 >= currentrows || col2 < 0 || col2 >= currentcols || row3 < 0 || row3 >= currentrows || col3 < 0 || col3 >= currentcols)
        {
            Console.WriteLine("Illegal operation");
            return;
        }

        string t1 = hucretipi[row1, col1];
        string t2 = hucretipi[row2, col2];

        if (t1 == null || t2 == null || t1 == "unassigned" || t2 == "unassigned")
        {
            Console.WriteLine("Illegal operation");
            return;
        }

        string v1 = tablo[row1, col1];
        string v2 = tablo[row2, col2];

        // Integer - Integer
        if (t1 == "integer" && t2 == "integer")
        {
            int a = Convert.ToInt32(v1);
            int b = Convert.ToInt32(v2);
            int sonuc = a - b;

            tablo[row3, col3] = sonuc.ToString();
            hucretipi[row3, col3] = "integer";
            Console.WriteLine("Operation is done");
            return;
        }

        // String - Integer (ASCII ile karakter silme)
        if ((t1 == "string" && t2 == "integer") || (t1 == "integer" && t2 == "string"))
        {
            string kelime;
            int ascii;

            if (t1 == "string")
            {
                kelime = v1;
                ascii = Convert.ToInt32(v2);
            }
            else
            {
                kelime = v2;
                ascii = Convert.ToInt32(v1);
            }

            // ASCII aralýðý kontrolü
            if (ascii < 33 || ascii > 126)
            {
                Console.WriteLine("Illegal operation");
                return;
            }

            char silinecek = (char)ascii;
            string yeni = "";

            for (int i = 0; i < kelime.Length; i++)
            {
                if (kelime[i] != silinecek)
                {
                    yeni = yeni + kelime[i];
                }
            }

            tablo[row3, col3] = yeni;
            hucretipi[row3, col3] = "string";
            Console.WriteLine("Operation is done");
            return;
        }

        // String - String (Alt metin silme)
        if (t1 == "string" && t2 == "string")
        {
            string uzun;
            string kisa;

            if (v1.Length >= v2.Length)
            {
                uzun = v1;
                kisa = v2;
            }
            else
            {
                uzun = v2;
                kisa = v1;
            }

            string sonuc = "";
            int i = 0;

            while (i < uzun.Length)
            {
                bool ayni = true;

                for (int j = 0; j < kisa.Length && i + j < uzun.Length; j++)
                {
                    if (uzun[i + j] != kisa[j])
                    {
                        ayni = false;
                        break;
                    }
                }

                if (ayni && i + kisa.Length <= uzun.Length)
                {
                    i += kisa.Length;
                }
                else
                {
                    sonuc += uzun[i];
                    i++;
                }
            }

            tablo[row3, col3] = sonuc;
            hucretipi[row3, col3] = "string";
            Console.WriteLine("Operation is done");
            return;
        }
        else
        {
            Console.WriteLine("Illegal operation");
        }
    }

    static void operator5(string h1, string h2, string h3) // "#" operatörü (Þifreleme)
    {
        char c1 = h1[0];
        int col1 = c1 - 'A';
        int row1 = Convert.ToInt32(h1.Substring(1)) - 1;

        char c2 = h2[0];
        int col2 = c2 - 'A';
        int row2 = Convert.ToInt32(h2.Substring(1)) - 1;

        char c3 = h3[0];
        int col3 = c3 - 'A';
        int row3 = Convert.ToInt32(h3.Substring(1)) - 1;

        if (row1 < 0 || row1 >= currentrows || col1 < 0 || col1 >= currentcols || row2 < 0 || row2 >= currentrows || col2 < 0 || col2 >= currentcols || row3 < 0 || row3 >= currentrows || col3 < 0 || col3 >= currentcols)
        {
            Console.WriteLine("Illegal operation");
            return;
        }

        string t1 = hucretipi[row1, col1];
        string t2 = hucretipi[row2, col2];

        if (t1 == null || t2 == null || t1 == "unassigned" || t2 == "unassigned")
        {
            Console.WriteLine("Illegal operation");
            return;
        }

        if ((t1 == "string" && t2 == "integer") || (t1 == "integer" && t2 == "string"))
        {
            string kelime;
            int sayi;

            if (t1 == "string")
            {
                kelime = tablo[row1, col1];
                sayi = Convert.ToInt32(tablo[row2, col2]);
            }
            else
            {
                kelime = tablo[row2, col2];
                sayi = Convert.ToInt32(tablo[row1, col1]);
            }

            if (sayi < -20 || sayi > 30)
            {
                Console.WriteLine("Illegal operation");
                return;
            }

            // ASCII kaydýrma (Þifreleme)
            string yeni = "";
            for (int i = 0; i < kelime.Length; i++)
            {
                char ch = kelime[i];
                int ascii = (int)ch;
                ascii = ascii + sayi;
                char yeniHarf = (char)ascii;

                yeni = yeni + yeniHarf;
            }

            tablo[row3, col3] = yeni;
            hucretipi[row3, col3] = "string";
            Console.WriteLine("Operation is done");
            return;
        }

        Console.WriteLine("Illegal operation");
    }

    static void Save(string dosya)
    {
        if (!dosya.EndsWith(".txt"))
        {
            dosya = dosya + ".txt";
        }

        StreamWriter f = File.CreateText(dosya);

        for (int r = 0; r < currentrows; r++)
        {
            for (int c = 0; c < currentcols; c++)
            {
                string deger = tablo[r, c];

                if (deger == null)
                    deger = ".";

                f.Write(deger);

                // Son sütun deðilse tab koy
                if (c < currentcols - 1)
                    f.Write("\t");
            }
            f.WriteLine();
        }

        f.Close();
        Console.WriteLine("Saving operation is done");
    }
}