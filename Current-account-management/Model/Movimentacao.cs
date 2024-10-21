using System.Data.Common;

namespace ContaCorrente.Model
{
    internal class Movimentacao
    {
        

        public Movimentacao(string data, double valor, TipoMovimentacao movimentacao)
        {
            Data = data;
            Valor = valor;
            Mov = movimentacao;
        }

        public string Data { get; }
        public double Valor { get; }
        public TipoMovimentacao Mov { get; }


        public enum TipoMovimentacao
        {
            Credito, Debito, Saque, Transferencia
        }
    }
}
