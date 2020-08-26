using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAll();
        Cliente Get(int id);
        bool Add(Cliente model);
        bool Update(Cliente model);
        bool Delete(int id);
    }
   public class ClienteService : IClienteService
    {
        private readonly ClienteDbContext _clienteDbContext;
        public ClienteService(
            ClienteDbContext clienteDbContext
            )
        {
            _clienteDbContext = clienteDbContext;
        }
     
        public IEnumerable<Cliente> GetAll()
        {
            var result = new List<Cliente>();
            try
            {
                result = _clienteDbContext.Cliente.ToList();
            }
            catch (System.Exception)
            {

            }
            return result;
        }
        public Cliente Get(int id)
        {
            var result = new Cliente();
            try
            {
                result = _clienteDbContext.Cliente.Single(x => x.ClienteId == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }
        public bool Add(Cliente model)
        {
            try
            {
                 _clienteDbContext.Add(model);
                _clienteDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
        public bool Update(Cliente model)
        {
            try
            {
                var originalModel = _clienteDbContext.Cliente.Single(x =>
                x.ClienteId == model.ClienteId
                );

                originalModel.Nombre = model.Nombre;
                originalModel.Apellido = model.Apellido;
                originalModel.Telefono = model.Telefono;

                _clienteDbContext.Update(originalModel);
                _clienteDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                _clienteDbContext.Entry(new Cliente { ClienteId = id }).State = EntityState.Deleted;
                _clienteDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}
