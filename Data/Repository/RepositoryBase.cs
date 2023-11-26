using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private ModelContext _context;
        protected DbSet<T> _dbSet;

        public RepositoryBase(ModelContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> GetAllNoTracking()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public T? GetById(int id)
        {
            var result = _dbSet.Find(id);
            return result;
        }

        public T? GetByIdNoTracking(int id)
        {
            var obj = _dbSet.Find(id);
            if (obj != null)
                _context.Entry(obj).State = EntityState.Detached;
            return obj;
        }

        public void Insert(T obj)
        {
            try
            {
                if (obj == null)
                    throw new NullReferenceException("O Objeto a ser cadastrado não pode ser nulo");
                _dbSet.Add(obj);
            }
            catch (SqlException e)
            {
                throw new Exception("Não foi possível realizar a transação na base de dados, contate o administrador do sistema ou tente novamente mais tarde", e);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            try
            {
                if (obj == null)
                    throw new Exception("O Objeto a ser atualizado não pode ser nulo");
                _context.Entry(obj).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw new Exception("Falha ao Atualizar o objeto: Não foi possível realizar a transação na base de dados, contate o administrador do sistema ou tente novamente mais tarde", e);
            }
        }
    }
}
