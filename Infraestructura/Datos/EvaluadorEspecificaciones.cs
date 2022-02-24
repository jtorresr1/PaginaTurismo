using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificaciones;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class EvaluadorEspecificaciones<T> where T: class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IEspecificacion<T> espeficacion)
        {
            var query = inputQuery;

            if (espeficacion.Filtro != null)
            {
                query = query.Where(espeficacion.Filtro);
            }

            query = espeficacion.Includes.Aggregate(query, (current, include) => current.Include(include));
            
            return query;
        }
    }
}