namespace ContaCorrente.Model
{
    internal class Titular : Endereco
    {
        public Titular(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public string Nome { get; }
        public string Cpf { get; }

        internal override void GerarEndereço()
        {
            Console.Write("Endereço: ");
            base.GerarEndereço();
        }
    }
}
