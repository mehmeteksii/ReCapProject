﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);   // filtresiz sorgularda
        T Get(Expression<Func<T, bool>> filter);    // id ile alırken filtre uygularız
        void Add(T entity);  // ekleme
        void Update(T entity);   // güncelleme 
        void Delete(T entity);  // silme
    }
}