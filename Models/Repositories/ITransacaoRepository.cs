using System;
using System.Collections.Generic;
using Models;

namespace Models.Repositories
{
    public interface ITransacaoRepository
    {
        IEnumerable<Transacao> GetTransacoes();
        void AddTransacao(Transacao transacao);
        bool DeleteTransacao(Guid id);
    }
}