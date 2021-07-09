using Dominio.Enums;

namespace Dominio.Entidades
{
    public class Imovel
    {
        public Imovel(string cidade, string bairro, int qtdDeQuartos, ETipoCasa tipo, decimal valorDoAluguel)
        {
            Cidade = cidade;
            Bairro = bairro;
            QtdDeQuartos = qtdDeQuartos;
            Tipo = tipo;
            ValorDoAluguel = valorDoAluguel;
        }

        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public int QtdDeQuartos { get; set; }
        public ETipoCasa Tipo { get; set; }
        public decimal ValorDoAluguel { get; set; }

        public void AtualizarImovel (string cidade, string bairro, int qtdQuartos, ETipoCasa tipo, decimal valorDoAluguel)
        {
            this.Cidade = cidade;
            this.Bairro = bairro;
            this.QtdDeQuartos = qtdQuartos;
            this.Tipo = tipo;
            this.ValorDoAluguel = valorDoAluguel;
        }
    }
}
