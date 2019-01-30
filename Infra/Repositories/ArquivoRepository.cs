using System.Collections.Generic;
using Models;
using Models.Repositories;
using System.Linq;
using System;

namespace Infra.Repositories
{
    public class ArquivoRepository : ITransacaoRepository
    {
        private string _path = "/home/luiz/Documents/Projetos/ControleFinanceiro/Infra/Transacoes";

        public IEnumerable<Transacao> GetTransacoes()
        {
            List<Transacao> transacoes = new List<Transacao>();
            var linhas = System.IO.File.ReadAllLines(this._path);
            // foreach (var linha in linhas)
            // {
            //     var transacao = MapperTransacao.FromArquivo(linha);
            //     transacoes.Add(transacao);
            // }
            // return transacoes;
            return linhas.Select(l => this.MapearTransacao(l));
        }

        public bool AddTransacao(Transacao transacao)
        {
            var linha = transacao.MapearLinha();

            System.IO.File.AppendAllText(this._path, linha);

            return true;
        }

        private Transacao MapearTransacao(string linha)
        {
            var dataCompensacao = DateTime.Parse(linha.Substring(0, 10));
            var descricao = linha.Substring(22, 50);
            var categoria = linha.Substring(73, 20);
            var valor = Double.Parse(linha.Substring(94, 10));
            var data = DateTime.Parse(linha.Substring(11, 10));

            return new Transacao(dataCompensacao, descricao, categoria, valor, data);
        }
    }
}