﻿using KAIROS.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Repositorio.Interface
{
    interface IAPIRepositorio
    {
       Task InsereCargosAPI(string Key, string CNPJ, Cargo cargo);
       Task<List<Cargo>> ListaCargosAPI(string Key, string CNPJ);
       Task InsereEstruturasAPI(string Key, string CNPJ, Estrutura estrutura);
       Task<List<Estrutura>> ListaEstruturasAPI(string Key, string CNPJ);
       Task<List<Horarios>> ListaHorariosAPI(string Key, string CNPJ);


    }
}