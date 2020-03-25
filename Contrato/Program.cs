using System;
using Contrato.Entidades;
using Contrato.Entidades.Enumerador;
using System.Globalization;

namespace Contrato
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o nome do departamento: ");
            string dep = Console.ReadLine();
            Console.WriteLine("ENTRE COM OS DADOS DE TRABALHO");
            Console.Write("Nome do funcionário: ");
            string nome = Console.ReadLine();
            Console.Write("Nível de atuação (Junior/Medio/Senior): ");
            NivelTrabalho nivel = Enum.Parse<NivelTrabalho>(Console.ReadLine());
            Console.Write("Entre com salário base: ");
            double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();
            //---------------------------------------------------------------------------------
            Departamento departamento = new Departamento(dep);
            Trabalho trabalho = new Trabalho(nome, salario, nivel, departamento);
            //---------------------------------------------------------------------------------
            Console.Write("Quantos contratos de trabalhos? ");
            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre com os dados do contrato #{i}" );
                Console.Write("Data (dd/MM/aaaa): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração do trabalho em horas: ");
                int periodo = int.Parse(Console.ReadLine());
                ContratoHoras contrato = new ContratoHoras(data, valor, periodo);
                trabalho.AddContrato(contrato);
            }
            Console.WriteLine();
            Console.Write("Entre com o ano o mês para cálculo da renda: ");
            string mesAno = Console.ReadLine();
            int mes = int.Parse(mesAno.Substring(0, 2));
            int ano = int.Parse(mesAno.Substring(3));
            Console.WriteLine("Nome: " + trabalho.Nome);
            Console.WriteLine("Departamento: " + trabalho.Departamento.Nome);
            Console.WriteLine("Renda para " + mesAno + " : " + trabalho.Renda(ano, mes).ToString("f2" , CultureInfo.InvariantCulture));
        }
    }
}