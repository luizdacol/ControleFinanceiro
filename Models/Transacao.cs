using System;

namespace Models
{
    public class Transacao
    {
        public Transacao()
        {
            this.Id = Guid.NewGuid();
        }

        public Transacao(Guid id, DateTime dataCompensacao, string descricao, string categoria, double valor, DateTime? data = null)
        {
            this.Id = id;
            this.DataCompensacao = dataCompensacao;
            this.Descricao = descricao;
            this.Categoria = categoria;
            this.Valor = valor;
            this.Data = data.HasValue ? data.Value : this.DataCompensacao;
        }

        // public Transacao(DateTime dataCompensacao, string descricao, string categoria, double valor, DateTime? data = null)
        // {
        //     this.Id = new Guid();
        //     this.DataCompensacao = dataCompensacao;
        //     this.Descricao = descricao;
        //     this.Categoria = categoria;
        //     this.Valor = valor;
        //     this.Data = data.HasValue ? data.Value : this.DataCompensacao;
        // }
        public Guid Id { get; private set; }
        public DateTime Data { get; set; }
        public DateTime DataCompensacao { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double Valor { get; set; }

        public string MapearLinha()
        {
            return this.DataCompensacao.ToString("yyyy-MM-dd").PadRight(11) +
            this.Data.ToString("yyyy-MM-dd").PadRight(11) +
            this.Descricao.PadRight(51) +
            this.Categoria.PadRight(21) +
            this.Valor.ToString().PadRight(10) +
            this.Id.ToString() +
            "\n";
        }
    }
}