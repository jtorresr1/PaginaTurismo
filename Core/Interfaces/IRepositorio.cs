using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificaciones;

namespace Core.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> ObtenerAsync (int id);

        Task<IReadOnlyList<T>> ObtenerTodosAsync();

        Task<T> ObtenerEspecificacion(IEspecificacion<T> espec);

        Task<IReadOnlyList<T>> ObtenerTodosEspecficacion(IEspecificacion<T> espec); 
    }
} 