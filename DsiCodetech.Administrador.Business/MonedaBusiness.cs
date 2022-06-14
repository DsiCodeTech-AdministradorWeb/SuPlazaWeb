using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class MonedaBusiness: IMonedaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Moneda_Repository repository;
        public MonedaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Moneda_Repository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar las monedas
        /// </summary>
        /// <returns>una coleccion de monedas domain model</returns>
        public List<MonedaDM> GetMonedas()
        {
            List<MonedaDM> monedas = null;
            return monedas = repository.GetAll().Select(p => new MonedaDM
            {
                Id = p.id,
                Decimales = p.decimales,
                Fecha_Fin = p.fecha_fin.Value,
                Fecha_Inicio = p.fecha_inicio.Value,
                Porcentaje =p.porcentaje,
                Descripcion= p.porcentaje
                

            }).ToList();
        }
    }
}
