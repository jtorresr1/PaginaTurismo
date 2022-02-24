using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificaciones;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<T> ObtenerAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }


        public async Task<IReadOnlyList<T>> ObtenerTodosAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> ObtenerEspecificacion(IEspecificacion<T> espec)
        {
            return await AplicarEspecificacion(espec).FirstOrDefaultAsync();
        }


        public async Task<IReadOnlyList<T>> ObtenerTodosEspecficacion(IEspecificacion<T> espec)
        {
            return await AplicarEspecificacion(espec).ToListAsync();
        }

        private IQueryable<T> AplicarEspecificacion(IEspecificacion<T> espec)
        {
            return EvaluadorEspecificaciones<T>.GetQuery(_db.Set<T>().AsQueryable(), espec);
        }
    }
}