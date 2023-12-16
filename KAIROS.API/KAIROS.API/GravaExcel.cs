using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API
{
    //public static void GravarHorario(string caminhoExcel)
    //{
    //    var wb = new XLWorkbook();
    //    var ws = wb.Worksheets.Add("HORARIOS");
    //    ws.Columns().Style.Font.Italic = true;
    //    ws.Range("A1:F1").AddConditionalFormat().WhenGreaterThan(20000).Fill.SetBackgroundColor(XLColor.GreenPigment);
    //    int Celula = 2;
    //    ws.Cell("A1").Style.Font.SetBold().Font.FontSize = 14;
    //    ws.Cell("A1").Value = "  CODIGO  ";
    //    ws.Cell("B1").Style.Font.SetBold().Font.FontSize = 14;
    //    ws.Cell("B1").Value = " DESCRIÇÃO  ";
    //    foreach (var item in Lista.HorariosOR)
    //    {
    //        ws.Cell("A" + Celula).Value = item.Codigo;
    //        ws.Cell("B" + Celula).Value = item.Descricao;
    //        Celula++;
    //    }


    //    ws.Columns().AdjustToContents();


    //    wb.SaveAs(caminhoExcel + "\\Horarios.xlsx");


    //    wb.Dispose();
    //}
}
