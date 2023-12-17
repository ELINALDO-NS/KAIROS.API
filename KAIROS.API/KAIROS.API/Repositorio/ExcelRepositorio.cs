using KAIROS.API.Repositorio.Interface;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Repositorio
{
    public class ExcelRepositorio: IExcelRepositorio
    {
        private readonly ExcelPackage _excel;
        public ExcelRepositorio()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _excel = new ExcelPackage();
        }



        public async Task ListaHorario(string caminho)
        {
            
            var worksheet = _excel.Workbook.Worksheets.Add("Sheet1");
                // Adicionar dados à célula A1
           worksheet.Cells["A1"].Value = "Olá, Excel!";
           // Salvar o arquivo Excel
           var fileInfo = new System.IO.FileInfo($"{caminho}\\Arquivo.xlsx");
           await _excel.SaveAsAsync(fileInfo);
            



        }
    }
}
