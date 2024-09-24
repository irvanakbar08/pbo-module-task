using System;
using System.Collections.Generic;

public class Hewan
{
    public string nama;
    public int umur;

    public Hewan(string nama, int umur)
    {
        this.nama = nama;
        this.umur = umur;
    }

    public virtual string Suara()
    {
        return "Hewan ini bersuara";
    }

    public string InfoHewan()
    {
        return "Nama: " + nama + ", Umur: " + umur;
    }
}

public class Mamalia : Hewan
{
    public int jumlahKaki;

    public Mamalia(string nama, int umur, int jumlahKaki) : base(nama, umur)
    {
        this.jumlahKaki = jumlahKaki;
    }

    public override string Suara()
    {
        return "Mamalia ini bersuara";
    }
}

public class Reptil : Hewan
{
    public double panjangTubuh;

    public Reptil(string nama, int umur, double panjangTubuh) : base(nama, umur)
    {
        this.panjangTubuh = panjangTubuh;
    }

    public override string Suara()
    {
        return "Reptil ini bersuara";
    }
}

public class Singa : Mamalia
{
    public Singa(string nama, int umur) : base(nama, umur, 4) { }

    public override string Suara()
    {
        return "Singa bersuara AINGG MAUNGGG";
    }

    public void Mengaum()
    {
        Console.WriteLine("AINGG MAUNGGG");
    }

    public string Infolengkap()
    {
        return InfoHewan() + ",Jumlah Kaki: " + jumlahKaki;
    }
}

public class Gajah : Mamalia
{
    public Gajah(string nama, int umur) : base(nama, umur, 4) { }

    public override string Suara()
    {
        return "MPREEETTT";
    }
}

public class Ular : Reptil
{
    public Ular(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh) { }

    public override string Suara()
    {
        return "Mendesis";
    }

    public void Merayap()
    {
        Console.WriteLine("Ular sedang merayap");
    }
}

public class Buaya : Reptil
{
    public Buaya(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh) { }
    public override string Suara()
    {
        return "Buaya: cuma temen kok :)";
    }
}

public class KebunBinatang
{
    private List<Hewan> koleksiHewan = new List<Hewan>();

    public void TambahHewan(Hewan hewan)
    {
        koleksiHewan.Add(hewan);
    }

    public void DaftarHewan()
    {
        foreach (var hewan in koleksiHewan)
        {
            Console.WriteLine(hewan.InfoHewan());
            Console.WriteLine(hewan.Suara());
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        KebunBinatang kebunBinatang = new KebunBinatang();

        Singa singa = new Singa("Singa", 5) { jumlahKaki = 4 };
        Gajah gajah = new Gajah("Gajah", 10) { jumlahKaki = 4 };
        Ular ular = new Ular("Ular", 3, 2.5);
        Buaya buaya = new Buaya("Buaya", 6, 4.0);

        kebunBinatang.TambahHewan(singa);
        kebunBinatang.TambahHewan(gajah);
        kebunBinatang.TambahHewan(ular);
        kebunBinatang.TambahHewan(buaya);

        kebunBinatang.DaftarHewan();

        Hewan hewan1 = singa;
        Hewan hewan2 = ular;
        Console.WriteLine(hewan1.Suara());
        Console.WriteLine(hewan2.Suara());

        //Soal 1
        Console.WriteLine(gajah.Suara());
        Console.WriteLine(ular.Suara());

        ////Soal 2
        singa.Mengaum();

        ////Soal 3
        Console.WriteLine(singa.Infolengkap());

        //Soal 4
        ular.Merayap();

        ////Soal 5
        Reptil reptil = buaya;
        Console.WriteLine(reptil.Suara());

        Console.ReadLine();
    }
}
