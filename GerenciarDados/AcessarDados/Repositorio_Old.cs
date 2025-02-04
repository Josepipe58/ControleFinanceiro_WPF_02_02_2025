using AcessarBancoDados.ContextoDeDados;
using Microsoft.EntityFrameworkCore;

namespace GerenciarDados.AcessarDados
{
    public class Repositorio_Old<TEntity> where TEntity : class
    {
        protected readonly Contexto _contexto;
        protected readonly DbSet<TEntity> DbSet;

        public Repositorio_Old(Contexto contexto)
        {
            _contexto = contexto;
            DbSet = _contexto.Set<TEntity>();
        }

        public List<TEntity> ObterTodos()
        {
            var listarTodos = DbSet.ToList();
            return listarTodos;
        }

        public TEntity ObterPorId(int? id)
        {
            var obterId = DbSet.Find(id);
            return obterId;
        }

        public void Cadastrar(TEntity entity)
        {
            DbSet.Add(entity);
            _contexto.SaveChanges();
        }

        public void Alterar(TEntity entity)
        {
            DbSet.Update(entity);
            _contexto.SaveChanges();
        }

        public void Excluir(int? id)
        {
            var excluir = DbSet.Find(id);
            DbSet.Remove(excluir);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto?.Dispose();
        }
    }
}
