using System.Collections.Generic;
using Models;
using Models.Repositories;
using System.Linq;
using System;
using System.IO;

namespace Infra.Repositories
{
    public class ArquivoRepository : ITransacaoRepository
    {
        private string _path = "/home/luiz/Documents/Projetos/ControleFinanceiro/Infra/Transacoes";

        public IEnumerable<Transacao> GetTransacoes()
        {
            if (!File.Exists(this._path))
                return new List<Transacao>();

            var linhas = System.IO.File.ReadAllLines(this._path);
            return linhas.Select(l => this.MapearTransacao(l));
        }

        public void AddTransacao(Transacao transacao)
        {
            var linha = transacao.MapearLinha();
            File.AppendAllText(this._path, linha);
        }

        public bool DeleteTransacao(Guid id)
        {
            var transacoes = this.GetTransacoes().ToList();
            transacoes.RemoveAll(t => t.Id == id);

            // var text = new System.Text.StringBuilder();
            // transacoes.ForEach(t => text.Append(t.MapearLinha()));
            // File.WriteAllText(this._path, text.ToString());

            File.WriteAllLines(this._path, transacoes.Select(t => t.MapearLinha()));

            return true;
        }

        private Transacao MapearTransacao(string linha)
        {
            var id = Guid.Parse(linha.Substring(104));
            var dataCompensacao = DateTime.Parse(linha.Substring(0, 10));
            var descricao = linha.Substring(22, 50);
            var categoria = linha.Substring(73, 20);
            var valor = Double.Parse(linha.Substring(94, 10));
            var data = DateTime.Parse(linha.Substring(11, 10));

            return new Transacao(id, dataCompensacao, descricao, categoria, valor, data);
        }
    }
}