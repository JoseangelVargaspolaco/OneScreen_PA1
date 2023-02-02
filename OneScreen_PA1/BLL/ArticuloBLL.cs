using Microsoft.EntityFrameworkCore;
using PantallaOne.Models;
using PantallaOne.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

#nullable disable // Para quitar el aviso de nulls

namespace PantallaOne.BLL
{
    public class ArticuloBLL // BLL Para Articulo
    {
        private Contexto contexto;

        public ArticuloBLL(Contexto _contexto)
        {
            contexto = _contexto;
        }

        private bool Existe(int id)
        {
            bool existe = false;

            try
            {
                existe = contexto.Articulo.Any(c => c.ArticuloId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        public Articulos ExisteNombre(string Nombre)
        {
            Articulos existe;

            try
            {
                existe = contexto.Articulo
                .Where(p => p.Nombre
                .ToLower() == Nombre.ToLower())
                .AsNoTracking()
                .SingleOrDefault();

            }
            catch
            {
                throw;
            }
            return existe;
        }



        public bool Guardar(Articulos articulo)
        {

            if (!Existe(articulo.ArticuloId))
                return Insertar(articulo);
            else
                return Modificar(articulo);
        }



        private bool Insertar(Articulos articulo)
        {
            bool Insertado = false;

            try
            {
                if (contexto.Articulo.Add(articulo) != null)
                {
                    Insertado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        private bool Modificar(Articulos articulo)
        {
            bool Insertado = false;

            try
            {
                contexto.Entry(articulo).State = EntityState.Modified;
                Insertado = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        public Articulos Buscar(int id)
        {
            Articulos articulo = new Articulos();

            try
            {
                articulo = contexto.Articulo.Find(id);


            }
            catch (Exception)
            {
                throw;
            }
            return articulo;
        }


        public async Task<bool> Eliminar(int id)
        {
            bool Eliminado = false;

            try
            {
                var articulo = await contexto.Articulo.FindAsync(id);

                if (articulo != null)
                {
                    contexto.Articulo.Remove(articulo);
                    Eliminado = (await contexto.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Eliminado;
        }

        public List<Articulos> GetList(Expression<Func<Articulos, bool>> articulo)
        {
            List<Articulos> Lista = new List<Articulos>();
            try
            {
                Lista = contexto.Articulo
                .Where(articulo)
                .AsNoTracking()
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}
