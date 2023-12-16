using KAIROS.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Repositorio.Interface
{
    interface IcargoRepositorio
    {
       Task InsereCargo(Cargo cargo);
       Task ListaCargo(Cargo cargo);
    }
}
