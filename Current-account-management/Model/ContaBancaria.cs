namespace ContaCorrente.Model
{
    internal class ContaBancaria
    {
        private List<Movimentacao> movimentacoes = new();

        public ContaBancaria(int numeroConta, Titular titular)
        {
            NumeroConta = numeroConta;
            Titular = titular;
        }

        public int NumeroConta { get; }
        public double Saldo { get; set;  }
        public bool Especial { get; set; }
        public Titular Titular { get; }
        public Movimentacao Movimentacao { get; }


        public virtual void RegistrarMovimentacao( Movimentacao movimentacao)
        {
            movimentacoes.Add(movimentacao);
        }
    }
}
