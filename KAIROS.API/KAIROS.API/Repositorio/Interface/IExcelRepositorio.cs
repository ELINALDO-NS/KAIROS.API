﻿using KAIROS.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Repositorio.Interface
{
    public interface IExcelRepositorio
    {
        Task< List<Cargo>> ListaCargos(string Caminho);
        Task<List<Estrutura>> ListaEstrutura(string Caminho);
        Task<List<Horarios>> ListaHorarios(string Caminho);
        Task ListaPessoas(string Caminho);
        Task SalvaHorarios(string caminho);

    }
}