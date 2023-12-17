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
    public class ExcelRepositorio: IExcelRepositorio
    {
        
        public ExcelRepositorio()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
        }

        public async Task<List<Cargo>> LerCargos(string caminho)
        {
            var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));
            
                ExcelWorksheet planilha = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "CARGOS");
                var cargos = new List<Cargo>();
                int Linha = 4;
                
                while (Linha <= planilha.Dimension.Rows -3)
                {

                   cargos.Add(new Cargo
                   {
                    Codigo = Convert.ToInt32(planilha.Cells[Linha, 1].Value.ToString()),
                    Descricao = planilha.Cells[Linha, 2].Value.ToString()


                    });
                   Linha++;
                   
                }
                
                return cargos;

               

        }

        public Task LerEstrutura(string Caminho)
        {
            throw new NotImplementedException();
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
