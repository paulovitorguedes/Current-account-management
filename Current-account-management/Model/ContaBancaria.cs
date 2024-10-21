namespace ContaCorrente.Model
{
    internal class ContaBancaria
    {
        private List<Movimentacao> movimentacoes = new();

        public ContaBancaria(int numeroConta, Titular titular)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Saldo = 0;
            Ativa = true;
        }

        public int NumeroConta { get; }
        public double Saldo { get; set;  }
        public bool Ativa { get; set; }
        public Titular Titular { get; }
        public List<Movimentacao> Movimentacoes => movimentacoes;


        public virtual void RegistrarMovimentacao( Movimentacao movimentacao)
        {
            movimentacoes.Add(movimentacao);
        }
    }
}
