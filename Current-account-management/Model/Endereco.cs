namespace ContaCorrente.Model;

internal class Endereco
{
    public string Rua { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;


    string GerarEndereço()
    {
        return $"Rua: {Rua} - Bairro: {Bairro} - {Cidade}";
    }
}


