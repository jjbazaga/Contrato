using Contrato.Entidades.Enumerador;
using System.Collections.Generic;

namespace Contrato.Entidades
{
    class Trabalho
    {
        public string Nome { get; set; }
        public double SalarioBase { get; set; }
        public NivelTrabalho Nivel { get; set; }
        public Departamento Departamento { get; set; }
        public List<ContratoHoras> Contrato { get; set; } = new List<ContratoHoras>();

        public Trabalho()
        {
        }

        public Trabalho(string nome, double salarioBase, NivelTrabalho nivel, Departamento departamento)
        {
            Nome = nome;
            SalarioBase = salarioBase;
            Nivel = nivel;
            Departamento = departamento;
        }

        public void AddContrato(ContratoHoras contrato)
        {
            Contrato.Add(contrato);
        }
        public void RemoveContrato(ContratoHoras contrato)
        {
            Contrato.Remove(contrato);
        }
        public double Renda (int ano, int mes)
        {
            double soma = SalarioBase;
            foreach(ContratoHoras obj in Contrato)
            {
                if (obj.Data.Year == ano && obj.Data.Month == mes)
                {
                    soma += obj.ValorTotal();

                }
             }
            return soma;
        }
    }    
}