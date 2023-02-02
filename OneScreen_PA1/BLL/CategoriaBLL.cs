using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PantallaOne.Models;
using PantallaOne.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


#nullable disable // Para quitar el aviso de nulls

namespace PantallaOne.BLL // BLL Para la categoria del articulo
{
    public class CategoriaBLL
    {
        private Contexto contexto;

        public CategoriaBLL(Contexto _contexto)
        {
            contexto = _contexto;
        }

        public Categoria Buscar(int id)
        {
            Categoria categoria = new Categoria();

            try
            {
                categoria = contexto.Categoria
                .Where(p => p.CategoriaId == id)
                .AsNoTracking()
                .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return categoria;
        }

        public async Task<List<Categoria>> GetList(Expression<Func<Categoria, bool>> categoria)
        {
            List<Categoria> Lista = new List<Categoria>();
            try
            {
                Lista = await contexto.Categoria
                .Where(categoria)
                .AsNoTracking()
                .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}
