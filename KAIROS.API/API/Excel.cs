using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Excel
    {
        ExcelPackage Planila;
        public Excel(string Caminho)
        {
            Planila = new ExcelPackage(new FileInfo(Caminho));
            ExcelPackage.License.SetNonCommercialPersonal("Jubileu");
        }

        public List<string> ValidaColunasExcel(string Planilha, bool Comunicacao)
        {
            ExcelWorksheet PlanilaSelecionada = Planila.Workbook.Worksheets.First(a => a.Name == Planilha);
            if (PlanilaSelecionada == null)
            {
                throw new Exception("Planilha não encontrada !");
            }
            string DadoLido = string.Empty;
            if (Comunicacao)
            {
                List<string> colunasEsperadasComunica = new()
                {
                    "matricula","nome","pis","crachá",
                    "data de admissão","data de nascimento","cpf",
                    "e-mail","departamento","sexo","cnpj"
                };
                List<string> colunasEncontradasComunica = new();
                List<string> colunasNaoEncontradasComunica = new();

                for (int i = 1; i < 25; i++)
                {
                    DadoLido = Convert.ToString(PlanilaSelecionada.Cells[3, i].Value).ToLower() ?? string.Empty;
                    if (!string.IsNullOrEmpty(DadoLido))
                    {
                        colunasEncontradasComunica.Add(DadoLido.Trim());
                    }
                }

                return colunasEsperadasComunica.Except(colunasEncontradasComunica).ToList();
            }


            List<string> colunasEsperadas = new()
            {
                "matricula","nome","pis","crachá","data de nascimento",
                "data de admissão","rg","cpf","telefone","celular",
                "e-mail","tipo de salário","base de horas","controla ponto","departamento",
                "horario","cargo","escala de folga","sexo","cnpj"
            };
            List<string> colunasEncontradas = new();
            List<string> colunasNaoEncontradas = new();

            for (int i = 1; i < 25; i++)
            {
                DadoLido = Convert.ToString(PlanilaSelecionada.Cells[3, i].Value).ToLower() ?? string.Empty;
                if (!string.IsNullOrEmpty(DadoLido))
                {
                    colunasEncontradas.Add(DadoLido.Trim());
                }
            }

            return colunasEsperadas.Except(colunasEncontradas).ToList();
        }
        public string LeExcel(string Planilha, int Linha, int Celula)
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

        public void EscreveExcel(string Planilha, int Linha, int Celula, string valor)
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
