using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Mostrar Data");
        Console.WriteLine("2. Calculo do desconto do INSS");
        Console.Write("Escolha uma opção: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                MostrarData();
                break;
            case "2":
                CalculoDescontoINSS();
                break;
            default:
                Console.WriteLine("Opção inválida! Tente novamente.");
                break;
        }
    }

    static void MostrarData()
    {
        Console.Write("Digite uma data (dd/MM/yyyy): ");
            string dataInput = Console.ReadLine();
            
            if (DateTime.TryParse(dataInput, out DateTime data))
            {
                string diaSemana = data.ToString("dddd");
                string mesExtenso = data.ToString("MMMM");

                Console.WriteLine($"Dia da Semana: {diaSemana}");
                Console.WriteLine($"Mês: {mesExtenso}");

                if (diaSemana.Equals("domingo", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Hora atual: {DateTime.Now:HH:mm}");
                }
            }
            else
            {
                Console.WriteLine("Data inválida.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
    }

    static void CalculoDescontoINSS()
    {
        Console.Write("Digite o valor do salário: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal salario))
        {
            decimal inss = CalcularINSS(salario);
            decimal salarioComDesconto = salario - inss;

            Console.WriteLine($"Valor do INSS a ser pago: {inss:C}");
            Console.WriteLine($"Salário com desconto do INSS: {salarioComDesconto:C}");
        }
        else
        {
            Console.WriteLine("Valor do salário inválido!");
        }
    }

    static decimal CalcularINSS(decimal salario)
    {
        decimal inss = 0;

        if (salario <= 1212.00m)
        {
            inss = salario * 0.075m;
        }
        else if (salario <= 2427.35m)
        {
            inss = (1212.00m * 0.075m) + ((salario - 1212.00m) * 0.09m);
        }
        else if (salario <= 3641.03m)
        {
            inss = (1212.00m * 0.075m) + ((2427.35m - 1212.00m) * 0.09m) + ((salario - 2427.35m) * 0.12m);
        }
        else if (salario <= 7087.22m)
        {
            inss = (1212.00m * 0.075m) + ((2427.35m - 1212.00m) * 0.09m) + ((3641.03m - 2427.35m) * 0.12m) + ((salario - 3641.03m) * 0.14m);
        }
        else
        {
            inss = 828.39m; // Teto do INSS
        }

        return inss;
    }
}