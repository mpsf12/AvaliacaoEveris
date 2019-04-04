using System;
using System.Linq;

namespace Everis
{
    class Program
    {
        static void Main(string[] args)
        {

            var teste = new Controle.Empresa();

            var lol = teste.GetAll().ToList();

            var yea = teste.GetById(3);

            Conta c = new ContaCorrente();
            Cliente titular = new Cliente("victor");
            ContaExtensions.MudaTitular(c, titular);

            Console.WriteLine("Hello World!");
        }
    }

    public class Cliente
    {
        public string Nome { get; set; }

        public Cliente(string nome)
        {
            this.Nome = nome;
        }
    }

    public abstract class Conta
    {
        public Cliente Titular { get; set; }
        //outros métodos e atributos da Conta
    }

    public class ContaCorrente : Conta
    {

    }

    public static class ContaExtensions
    {
        public static void MudaTitular(this Conta c, Cliente titular)
        {
            c.Titular = titular;
        }
    }

}
