using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IClienteBusiness
    {

        /// <summary>
        /// Este metodo se encarga de consultar todas las entidades del tipo clientes
        /// </summary>
        /// <returns>regresa una coleccion de clientes</returns>
        List<ClienteDM> GetAllClientes();

        /// <summary>
        /// Este metodo se encarga de consultar un cliente por Identificador
        /// </summary>
        /// <param name="id">identificador de la entidad</param>
        /// <returns>la entidad del tipo clienteDM</returns>
        ClienteDM GetClienteById(string id);
        /// <summary>
        /// Este metodo se encarga de insertar una entidad cliente
        /// </summary>
        /// <param name="cliente">la entidad cliente</param>
        /// <returns>regresa un valor boolean</returns>
        bool Insert(ClienteDM cliente);
    }
}
