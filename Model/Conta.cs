using bancoDio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bancoDio.Model
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tpConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tpConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Não foi possivel realzar esta operação. Entre em contato");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("{1}, Saque realizado com sucesso. Seu saldo é R$ {0} ", this.Saldo, this.Nome);
            return true;
        }

        public void Deposito(double val) 
        {
            this.Saldo += val;
            Console.WriteLine("{0}, seu saldo atual é R$ {1}", this.Nome, this.Saldo);
        }

        public  void Transferir(double val, Conta destino) 
        {
            if (this.Sacar(val)) destino.Deposito(val);
           
        }

        public override string ToString() 
        {
            string data = "";
            data += "Tipo de Conta: " + this.TipoConta + " | ";
            data += "Titular : " + this.Nome + " | ";
            data += "Saldo: " + this.Saldo + " | ";
            data += "Crédito: " + this.Credito;
            return data;
        }
    }
}
