using System.Collections.Generic;
using Models;

namespace Models.Repositories
{
    public interface ITransacaoRepository
    {
        IEnumerable<Transacao> GetTransacoes();
        bool AddTransacao(Transacao transacao);
    }
}