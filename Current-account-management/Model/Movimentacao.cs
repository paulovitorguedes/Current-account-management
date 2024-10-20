using System.Data.Common;

namespace ContaCorrente.Model
{
    internal class Movimentacao
    {
        public string data;
        public double valor;
        public TipoMovimentacao movimentacao;

        public Movimentacao(string data, double valor, TipoMovimentacao movimentacao)
        {
            this.data = data;
            this.valor = valor;
            this.movimentacao = movimentacao;
        }

        public enum TipoMovimentacao
        {
            Credito, Debito, Saque, Transferencia
        }
    }
}
