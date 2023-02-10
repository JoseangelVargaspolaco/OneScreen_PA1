using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PantallaOne.Models;
using PantallaOne.DAL;
using System.Linq.Expressions;
  
#nullable disable // Para quitar el aviso de nulls

namespace PantallaOne.BLL
{
    public class SuplidorBLL  // BLL Para Suplidor
    {
        private Contexto contexto;

        public SuplidorBLL(Contexto _contexto)
        {
            contexto = _contexto;
        }

          private bool Existe(int id)
        {
            bool existe = false;

            try
            {
                existe = contexto.Suplidor.Any(s => s.SuplidorId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }
        public bool Guardar(Suplidor suplidor)
        {
            if (!Existe(suplidor.SuplidorId))
                return Insertar(suplidor);
            else
                return Modificar(suplidor);
        }
        private bool Insertar(Suplidor suplidor)
        {
            bool Insertado = false;

            try
            {
                contexto.Suplidor.Add(suplidor);
                Insertado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        private bool Modificar(Suplidor suplidor)
        {
            bool Insertado = false;

            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
                Insertado =  contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        public Suplidor ExisteNombre(string Nombre)
        {
            Suplidor existe;

            try
            {
                existe = contexto.Suplidor               
                .Where( p => p.Nombre
                .ToLower() == Nombre.ToLower())
                .AsNoTracking()
                .SingleOrDefault();

            }catch
            {
                throw;
            }
            return existe;
        }

        public Suplidor Buscar(int id)
        {
            Suplidor suplidor = new Suplidor();

            try
            {
               suplidor = contexto.Suplidor.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return suplidor;
        }
 
        public async Task<bool> Eliminar(int id)
        {
            bool Eliminado = false;

            try
            {
                var suplidor = await contexto.Suplidor.FindAsync(id);

                if (suplidor != null)
                {
                    contexto.Suplidor.Remove(suplidor);
                    Eliminado = (await contexto.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Eliminado;
        }

        public List<Suplidor> GetList(Expression<Func<Suplidor, bool>> suplidor)
        {
            List<Suplidor> Lista = new List<Suplidor>();
            try
            {
                Lista = contexto.Suplidor
                .Where(suplidor)
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
