using System;

public class Rekening
{
    public string namaPemilik;
    public string nomorRekening;
    public double saldo;

    public Rekening(string nama, string rekening, double saldoAwal)
    {
        namaPemilik = nama;
        nomorRekening = rekening;
        saldo = saldoAwal;
    }

    public void CekSaldo()
    {
        Console.WriteLine($"Saldo rekening {nomorRekening} adalah: {saldo}");
    }

    public void Setor(double jumlah)
    {
        saldo += jumlah;
        Console.WriteLine($"Berhasil menyetor {jumlah}. Saldo sekarang: {saldo}");
    }

    public virtual void Tarik(double jumlah)
    {
        if (jumlah > saldo)
        {
            Console.WriteLine("Saldo tidak cukup untuk penarikan.");
        }
        else
        {
            saldo -= jumlah;
            Console.WriteLine($"Berhasil menarik {jumlah}. Saldo sekarang: {saldo}");
        }
    }
}

public class RekeningTabungan : Rekening
{
    public double bunga;

    public RekeningTabungan(string nama, string rekening, double saldoAwal, double bungaBulanan)
        : base(nama, rekening, saldoAwal)
    {
        bunga = bungaBulanan;
    }

    // Overriding 
    public void CekSaldoDenganBunga()
    {
        saldo += bunga;
        Console.WriteLine($"Bunga sebesar {bunga} ditambahkan.");
        CekSaldo(); 
    }
}


public class RekeningGiro : Rekening
{
    public double batasPenarikan; 

    public RekeningGiro(string nama, string rekening, double saldoAwal, double batasPenarikan)
        : base(nama, rekening, saldoAwal)
    {
        this.batasPenarikan = batasPenarikan; 
    }

    // Overriding 
    public override void Tarik(double jumlah)
    {
        if (jumlah > saldo - batasPenarikan)
        {
            Console.WriteLine($"Penarikan melebihi batas penarikan. Saldo tersedia: {saldo}, Batas Penarikan: {batasPenarikan}");
        }
        else
        {
            saldo -= jumlah;
            Console.WriteLine($"Berhasil menarik {jumlah}. Saldo sekarang: {saldo}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        RekeningTabungan tabungan = new RekeningTabungan("Irvan", "088", 50000, 10);
        Console.WriteLine($"Nama Pemilik Rekening Tabungan: {tabungan.namaPemilik}");
        tabungan.CekSaldoDenganBunga();  
        tabungan.Setor(50000); 
        tabungan.Tarik(100000); 
        Console.WriteLine();

        RekeningGiro giro = new RekeningGiro("Irvan", "099", 100000, 50000);
        Console.WriteLine($"Nama Pemilik Rekening Giro: {giro.namaPemilik}");
        giro.CekSaldo();      
        giro.Setor(50000);     
        giro.Tarik(1000000);
        
    }
}
