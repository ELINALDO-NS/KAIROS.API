using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API
{
    public  class Excel
    {
        ExcelPackage Planila;
        public Excel(string Caminho)
        {
            Planila = new ExcelPackage(new FileInfo(Caminho));
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public string LeExcel( string Planilha, int Linha, int Celula)
        {
            
            ExcelWorksheet PlanilaSelecionada = Planila.Workbook.Worksheets.First(a => a.Name == Planilha);
            if (PlanilaSelecionada == null)
            {
                throw new Exception("Planilha não encontrada !");
            }
            string DadoLido = string.Empty;
            int linha = Linha;
            DadoLido = Convert.ToString(PlanilaSelecionada.Cells[Linha, Celula].Value);
            return DadoLido;
        }

        public void EscreveExcel(string Planilha, int Linha, int Celula,string valor)
        {

            ExcelWorksheet PlanilaSelecionada = Planila.Workbook.Worksheets.First(a => a.Name == Planilha);
            if (PlanilaSelecionada == null)
            {
                throw new Exception("Planilha não encontrada !");
            }
            
            
            PlanilaSelecionada.Cells[Linha, Celula].Value = valor;
            Planila.Save();
           
            
        }

    }
}
