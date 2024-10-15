namespace ContaCorrente.Model;

internal class Endereco
{
    public string Rua { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;


    internal virtual void GerarEndereço()
    {
        Console.WriteLine($"Rua: {Rua} - Bairro: {Bairro} - {Cidade}");
    }
}


