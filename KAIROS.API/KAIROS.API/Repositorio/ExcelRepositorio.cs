using KAIROS.API.Model;
using KAIROS.API.Repositorio.Interface;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Repositorio
{
    public class ExcelRepositorio : IExcelRepositorio
    {

        public ExcelRepositorio()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        }

        public async Task<List<Cargo>> LerCargos(string caminho)
        {
            var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));
            ExcelWorksheet PlanilhaCargos = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "CARGOS");
            ExcelWorksheet PlanilhaFuncionario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "FUNCIONÁRIOS");
            var cargos = new List<Cargo>();
            int Linha = 4;
            int Codigo = 1;

            while (true)
            {
                string DescricaoPlCargo = RemoveAcentos.Remove(Convert.ToString(PlanilhaCargos.Cells[Linha, 2].Value)).Replace(" ", "");
                if (!string.IsNullOrEmpty(DescricaoPlCargo))
                {
                    if (!cargos.Any(a => a.Descricao.Contains(DescricaoPlCargo)))
                    {
                        cargos.Add(new Cargo
                        {
                            Codigo = Codigo,
                            Descricao = DescricaoPlCargo
                        }); ;
                        Codigo++;
                    }
                    Linha++;
                }
                else
                {
                    break;
                }
            }
            Linha = 4;
            while (true)
            {
                string DescricaoPlFuncionario = RemoveAcentos.Remove(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 17].Value)).Replace(" ", "");
                if (!string.IsNullOrEmpty(DescricaoPlFuncionario))
                {
                    
                    if (!cargos.Any(a => a.Descricao.Contains(DescricaoPlFuncionario)))
                    {
                        cargos.Add(new Cargo
                        {
                            Codigo = Codigo,
                            Descricao = DescricaoPlFuncionario
                        });
                        Codigo++;
                    }

                    Linha++;
                }
                else
                { 
                    break;
                }
            }

            return cargos.OrderBy(x => x.Descricao).ToList(); ;

        }

        public async Task<List<Estrutura>> LerEstrutura(string caminho)
        {

            var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));

            ExcelWorksheet PlanilhaDepartamentos = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "DEPARTAMENTOS");
            ExcelWorksheet PlanilhaFuncionario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "FUNCIONÁRIOS");
            var estrutura = new List<Estrutura>();
            int Linha = 4;
            int Codigo = 1;

            while (true)
            {
                string DescricaoPlDepartamento = RemoveAcentos.Remove(Convert.ToString(PlanilhaDepartamentos.Cells[Linha, 2].Value)).Replace(" ", ""); 
                if (!string.IsNullOrEmpty(DescricaoPlDepartamento))
                {
                    if (!estrutura.Any(a => a.Descricao.Contains(DescricaoPlDepartamento)))
                    {
                        estrutura.Add(new Estrutura
                        {
                            Codigo = Codigo,
                            Descricao = DescricaoPlDepartamento
                        });
                        Codigo++;
                    }

                    Linha++;
                }
                else
                { 
                    break;
                }
            }
            Linha = 4;
            while (true)
            {
                string DescricaoPlFuncionario = RemoveAcentos.Remove(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 2].Value)).Replace(" ", "");

                if (!string.IsNullOrEmpty(DescricaoPlFuncionario))
                {
                    if (!estrutura.Any(a => a.Descricao.Contains(DescricaoPlFuncionario)))
                    {
                        estrutura.Add(new Estrutura
                        {
                            Codigo = Codigo,
                            Descricao = DescricaoPlFuncionario
                        });
                        Codigo++;
                    }

                    Linha++;
                }
                else
                {
                    break;
                }
            }

            return estrutura.OrderBy(x => x.Descricao).ToList();


        }

        public Task LerHoarios(string Caminho)
        {
            throw new NotImplementedException();
        }

        public Task LerPessoas(string Caminho)
        {
            throw new NotImplementedException();
        }

        public async Task ListaHorarios(string caminho)
        {





        }
    }
}
