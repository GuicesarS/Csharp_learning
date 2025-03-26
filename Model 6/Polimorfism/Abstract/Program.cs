using System;
using System.Collections.Generic;
using System.Globalization;

abstract class Taxas
{
    public string Nome { get; set; }
    public double FaturamentoAnual { get; set; }

    public Taxas(string nome, double faturamentoanual)
    {
        Nome = nome;
        FaturamentoAnual = faturamentoanual;
    }

    public abstract double calcularimposto();
}

class PessoaFisica : Taxas
{
    public double DespezaSaude { get; set; }

    public PessoaFisica(string nome, double faturamentoanual, double despezasaude)
    : base(nome, faturamentoanual)
    {
        DespezaSaude = despezasaude;
    }

    public override double calcularimposto()
    {
        if (FaturamentoAnual <= 20000.00)
        {
            return (FaturamentoAnual * 0.15);
        }
        else if (FaturamentoAnual > 20000.00 && DespezaSaude > 0)
        {
            return (FaturamentoAnual * 0.25) - (DespezaSaude * 0.5);
        }
        else
        {
            return (FaturamentoAnual * 0.25);
        }
    }
}

class PessoaJuridica : Taxas
{
    public int QuantidadeFuncionario { get; set; }

    public PessoaJuridica(string nome, double faturamentoanual, int quantidadefuncionario)
    : base(nome, faturamentoanual)
    {
        QuantidadeFuncionario = quantidadefuncionario;
    }

    public override double calcularimposto()
    {
        if (QuantidadeFuncionario <= 10)
        {
            return (FaturamentoAnual * 0.16);
        }
        else
        {
            return (FaturamentoAnual * 0.14);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Taxas> listatudo = new List<Taxas>();
        Console.WriteLine("Enter the number of tax payers");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Individual or Company (i/c)");
            char tipo = char.Parse(Console.ReadLine());
            tipo = char.ToUpper(tipo);

            Console.WriteLine("Name: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Faturamento Anual: ");
            double faturamentoanual = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (tipo == 'I')
            {
                Console.Write("Gasto com Saúde:  ");
                double gastosSaude = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                listatudo.Add(new PessoaFisica(nome, faturamentoanual, tipo));
            }
            else if (tipo == 'C')
            {
                Console.Write("Quantidade de Funcionarios: ");
                int quantidadefuncionario = int.Parse(Console.ReadLine());
                listatudo.Add(new PessoaJuridica(nome, faturamentoanual, quantidadefuncionario));
            }
            else
            {
                Console.WriteLine("Dados incorretos.");
            }
        }
        double soma =0;
        Console.WriteLine();
        Console.WriteLine("Pagamentos Atualizados: ");

        foreach (Taxas mostrarlista in listatudo)
        {
            double taxas = mostrarlista.calcularimposto();
            Console.WriteLine($"{mostrarlista.Nome}: $ {mostrarlista.calcularimposto().ToString("F2", CultureInfo.InvariantCulture)}");
            soma += taxas;
        }
                    Console.WriteLine($"TAXAS TOTAIS: {soma.ToString("F2", CultureInfo.InvariantCulture)}");


    }
}
