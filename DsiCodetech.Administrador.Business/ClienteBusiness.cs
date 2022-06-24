using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class ClienteBusiness 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ClienteRepository repository;
        public ClienteBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new ClienteRepository(unitOfWork);
        }

        public ClienteDM GetClientePorId(string id)
        {

            var clienteModel = repository.SingleOrDefault(p => p.id_cliente.Equals(id));
            ClienteDM metodoPagoModel = new ClienteDM
            {
                IdCliente = clienteModel.id_cliente,
                Rfc = clienteModel.rfc,
                Razon_Social = clienteModel.razon_social,
                Contacto = clienteModel.contacto,
                Email = clienteModel.e_mail,
                Email2 = clienteModel.e_mail2,
                IdMunicipio = clienteModel.id_municipio,
                IdEntidad = clienteModel.id_entidad


            };
            return metodoPagoModel;
        }
    }
}
