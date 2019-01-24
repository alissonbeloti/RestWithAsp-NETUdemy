using Microsoft.EntityFrameworkCore;
using RestWithAsp_NETUdemy.Model.Base;
using RestWithAsp_NETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext context;
        private DbSet<T> dataSet;
        public GenericRepository(MySqlContext context)
        {
            this.context = context;
            dataSet = context.Set<T>();
        }

        public T Create(T item)
        {
            this.dataSet.Add(item);
            this.context.SaveChanges();
            return item;
        }

        public void Delete(long id)
        {
            this.dataSet.Remove(dataSet.SingleOrDefault(x => x.Id == id));
            this.context.SaveChanges();
        }

        public bool Exists(long? id)
        {
            return dataSet.Any(x => x.Id == id);
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindById(long id)
        {
            return dataSet.SingleOrDefault(x => x.Id == id);
        }

        public T Update(T item)
        {
            context.Entry<T>(item).State = EntityState.Modified;
            context.SaveChanges();
            return item;
        }
    }
}
