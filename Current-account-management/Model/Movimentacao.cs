namespace ContaCorrente.Model
{
    internal class Movimentacao
    {
        public double valor;
        public TipoMovimentacao movimentacao;

        public enum TipoMovimentacao
        {
            Credito, Debito, saque, transferencia
        }
    }
}
