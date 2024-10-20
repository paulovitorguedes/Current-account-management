﻿using ContaCorrente.Model;
using System.Drawing;

internal class Program
{


    private static void Main(string[] args)
    {
        Dictionary<int, ContaBancaria> contas = new();
        string data = "20/10/2024";


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

            Console.Write("\nEntre com a opção: ");
            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    RegistrarConta();
                    break;
                case "2":
                    Console.Clear();
                    VerificarDadosDaConta();
                    break;
                case "3":
                    Console.Clear();
                    VerificarSaldo();
                    break;
                case "4":
                    Console.Clear();
                    VerificarExtrato();
                    break;
                case "5":
                    Console.Clear();
                    RealizarSaque();
                    break;
                case "6":
                    Console.Clear();
                    Depositar();
                    break;
                case "7":
                    Console.Clear();
                    RealizarPix();
                    break;
                default:
                    Console.WriteLine("Até mais!!");
                    break;
            }
        }




        //Opção 1 - Classe para cadastro de novas contas
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


            if (!contas.ContainsKey(numeroDaConta)) contas.Add(numeroDaConta, contaBancaria);

            Console.WriteLine("Conta Corrente cadastrada com sucesso . . .");


            bool valid = true;
            do
            {
                Console.Write("\nVerificar os dados cadastrados ( 1-SIM / 2-SAIR ): ");
                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        VerificarDadosDaConta(numeroDaConta);
                        valid = false;
                        break;
                    case "2":
                        Sair();
                        valid = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida\nTente novamente . . .");
                        valid = true;
                        break;
                }

            } while (valid);
        }



        //Opção 2 - Classe para informar os dados cadastrais das contas informadas
        void VerificarDadosDaConta(int numeroConta = 0)
        {
            ExibirTituloDaOpcao("Dados Da Conta Bancária");

            if (numeroConta == 0)
            {
                Console.Write("\nEntre com o numero da Conta Corrente: ");
                numeroConta = int.Parse(Console.ReadLine()!);
            }

            ContaBancaria cb;

            if (contas.Count() > 0 && contas.ContainsKey(numeroConta))
            {
                cb = contas[numeroConta];

                Console.WriteLine($"\nConta Commente: {numeroConta}");
                Console.WriteLine($"Titular da conta: {cb.Titular.Nome}");
                Console.WriteLine($"CPF: {cb.Titular.Cpf}");
                cb.Titular.GerarEndereço();

            }
            else
            {
                Console.WriteLine("Conta Coorente não encontrada !");
            }

            Sair();
        }



        //Opção 3 - Classe para impressao do Saldo
        void VerificarSaldo()
        {
            ExibirTituloDaOpcao("SALDO");

            Console.Write("\nEntre com o número da conta: ");
            int conta = int.Parse(Console.ReadLine()!);

            Console.Write("Entre com o número do CPF: ");
            string doc = Console.ReadLine()!;


            if (contas.ContainsKey(conta))
            {
                if (contas[conta].Titular.Cpf.Equals(doc))
                {
                    Console.WriteLine($"SALDO: R${contas[conta].Saldo}");
                }
                else Console.WriteLine("Documento Inválido");
            }
            else Console.WriteLine("Conta Corrente não encontrada");

            Sair();
        }



        //Opção 4 - Classe para impressao do Extrato
        void VerificarExtrato()
        {
            ExibirTituloDaOpcao("Extrato");

            Console.Write("\nEntre com o número da conta: ");
            int conta = int.Parse(Console.ReadLine()!);

            Console.Write("Entre com o número do CPF: ");
            string doc = Console.ReadLine()!;

            if (contas.ContainsKey(conta))
            {
                if (contas[conta].Titular.Cpf.Equals(doc))
                {

                    List<Movimentacao> extrato = contas[conta].Movimentacoes;
                    if (extrato.Count > 0)
                    {
                        Console.WriteLine("\n\n");
                        foreach (Movimentacao mov in extrato)
                        {
                            Console.WriteLine($"Data: {mov.Data} | {mov.Mov} | R${mov.Valor}");
                        }
                    }
                    else Console.WriteLine("A conta corrente selecionada não possui movimentações!");

                    Console.WriteLine($"Saldo: {contas[conta].Saldo}");
                }
                else Console.WriteLine("Documento Inválido");
            }
            else Console.WriteLine("Conta Corrente não encontrada");

            Sair();

        }



        ////Opção 5 - Classe para realizar saques
        void RealizarSaque()
        {
            ExibirTituloDaOpcao("Saque");

            Console.Write("\nEntre com o número da conta: ");
            int conta = int.Parse(Console.ReadLine()!);

            Console.Write("Entre com o número do CPF: ");
            string doc = Console.ReadLine()!;

            double valor = 0;

            if (contas.ContainsKey(conta))
            {
                if (contas[conta].Titular.Cpf.Equals(doc))
                {
                    Console.Write("\nEntre com o Valor para o saque: ");
                    valor = double.Parse(Console.ReadLine()!);

                    if (contas[conta].Saldo > valor)
                    {
                        contas[conta].Saldo -= valor;
                        Console.WriteLine($"\nA importância de R${valor} foi retirada com sucesso");
                        Console.WriteLine($"SALDO: R${contas[conta].Saldo}");
                        
                        if (Data.DataEhValida(data))
                        {
                            Movimentacao movimentacao = new(data, valor, Movimentacao.TipoMovimentacao.Saque);
                            contas[conta].RegistrarMovimentacao(movimentacao);
                        }
                    }
                    else Console.WriteLine("A conta não possui saldo suficiente para retirada do valor solicitado");

                }
                else Console.WriteLine("Documento Inválido");
            }
            else Console.WriteLine("Conta Corrente não encontrada");

            Sair();
        }



        //Opção 6 - Classe para realizar depósitos 
        void Depositar()
        {
            ExibirTituloDaOpcao("Depositar");

            Console.Write("\nEntre com o número da conta: ");
            int conta = int.Parse(Console.ReadLine()!);

            Console.Write("Entre com o número do CPF: ");
            string doc = Console.ReadLine()!;

            double valor = 0;

            if (contas.ContainsKey(conta))
            {
                if (contas[conta].Titular.Cpf.Equals(doc))
                {
                    Console.Write("\nEntre com o Valor do depósito: ");
                    valor = double.Parse(Console.ReadLine()!);
                    contas[conta].Saldo += valor;
                    Console.WriteLine($"\nA importância de R${valor} foi depositada com sucesso");
                    Console.WriteLine($"SALDO: R${contas[conta].Saldo}");

                    if (Data.DataEhValida(data))
                    {
                        Movimentacao movimentacao = new(data, valor, Movimentacao.TipoMovimentacao.Credito);
                        contas[conta].RegistrarMovimentacao(movimentacao);
                    }
                }
                else Console.WriteLine("Documento Inválido");
            }
            else Console.WriteLine("Conta Corrente não encontrada");

            Sair();
        }



        //Opção 7 - Classe para realizar transferencias
        void RealizarPix()
        {
            ExibirTituloDaOpcao("PIX");

            Console.Write("\nEntre com o número da conta: ");
            int conta = int.Parse(Console.ReadLine()!);

            Console.Write("Entre com o número do CPF: ");
            string doc = Console.ReadLine()!;


            if (contas.ContainsKey(conta))
            {
                if (contas[conta].Titular.Cpf.Equals(doc))
                {

                    Console.Write("\nEntre com a Conta para transferência: ");
                    int contaDestino = int.Parse(Console.ReadLine()!);

                    if (contas.ContainsKey(contaDestino))
                    {
                        Console.Write("\nEntre com o Valor para transferência: ");
                        double valorDestino = double.Parse(Console.ReadLine()!);

                        if (contas[conta].Saldo > valorDestino)
                        {
                            contas[conta].Saldo -= valorDestino;
                            Console.WriteLine($"\nA importância de R${valorDestino} foi Transferida com sucesso");

                            if (Data.DataEhValida(data))
                            {
                                Movimentacao movimentacao = new(data, valorDestino, Movimentacao.TipoMovimentacao.Transferencia);
                                contas[conta].RegistrarMovimentacao(movimentacao);
                            }

                            contas[contaDestino].Saldo += valorDestino;

                            if (Data.DataEhValida(data))
                            {
                                Movimentacao movimentacao = new(data, valorDestino, Movimentacao.TipoMovimentacao.Credito);
                                contas[contaDestino].RegistrarMovimentacao(movimentacao);
                            }
                        }
                        else Console.WriteLine("A conta não possui saldo suficiente para Transferência do valor solicitado");


                    }
                    else Console.WriteLine("Conta Corrente para a transferência não foi encontrada!");


                }
                else Console.WriteLine("Documento Inválido");
            }
            else Console.WriteLine("Conta Corrente não encontrada");

            Sair();
        }



        void ExibirTituloDaOpcao(string titulo)
        {
            int quantidadeDeLetras = titulo.Length;
            string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
            Console.WriteLine(asteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(asteriscos + "\n");
        }


        void Sair()
        {
            Console.Write("\n\nDigite qualquer tecla para sair . . .");
            Console.ReadLine();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }

    }
}