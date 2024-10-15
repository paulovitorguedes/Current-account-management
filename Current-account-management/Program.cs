using ContaCorrente.Model;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{


    private static void Main(string[] args)
    {
        Dictionary<int, List<ContaBancaria>> contas = new();
        ExibirOpcoesDoMenu();

        void ExibirOpcoesDoMenu()
        {
            Console.WriteLine("\nDigite 1 para registrar uma Conta");
            Console.WriteLine("Digite 2 para verificar Dados da Conta");
            Console.WriteLine("Digite 3 para verificar saldo");
            Console.WriteLine("Digite 4 para verificar Extrato");
            Console.WriteLine("Digite 5 para Realizar um SAQUE");
            Console.WriteLine("Digite 6 para Realizar um DEPÓSITO");
            Console.WriteLine("Digite 7 para Realizar um PIX");
            Console.WriteLine("Digite -1 para sair");


            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    RegistrarConta();
                    break;
                default:
                    break;
            }
        }

        void RegistrarConta()
        {
            ExibirTituloDaOpcao("Cadastro de Conta Bancária");

            Console.WriteLine("\nCadatro de Titular da Conta.");
            Console.Write("Nome: ");
            string nome = Console.ReadLine()!;

            Console.Write("CPF: ");
            string cpf = Console.ReadLine()!;

            Console.WriteLine("\nCadatro de Endereço.");
            Console.Write("Rua: ");
            string rua = Console.ReadLine()!;

            Console.Write("Rairro: ");
            string bairro = Console.ReadLine()!;

            Console.Write("Cidade: ");
            string Cidade = Console.ReadLine()!;

            Titular titular = new(nome, cpf)
            {
                Rua = rua,
                Bairro = bairro,
                Cidade = Cidade
            };

            int numeroDaConta = contas.Count() + 1;
            ContaBancaria contaBancaria = new(numeroDaConta, titular);

             
            if (!contas.ContainsKey(numeroDaConta)) contas[numeroDaConta] = [contaBancaria];
            contas[numeroDaConta].Add(contaBancaria);

            Console.WriteLine($"Voce possui { contas.Count} conta cadastrada");

            //if (Data.DataEhValida("31/02/2005"))
            //    Console.WriteLine("Data válida");

            //else
            //    Console.WriteLine("Data inválida");
        }


        void ExibirTituloDaOpcao(string titulo)
        {
            int quantidadeDeLetras = titulo.Length;
            string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
            Console.WriteLine(asteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(asteriscos + "\n");
        }

    }
}