using API;
using API.Repositorio.Interface;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API.Repositorio
{
    public class ValidaDadosRepositorio : IValidaDadosRepositorio
    {
        public async Task<bool> ValidaCPF(string CaminhoExcel)
        {

            bool CPFValido = true;
            int Linha = 4;
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {

                while (true)
                {
                    string CPF = excel.LeExcel("FUNCIONÁRIOS", Linha, 8);
                    if (!string.IsNullOrEmpty(CPF))
                    {
                        if (!ValCPF.IsCpf(CPF))
                        {
                            CPFValido = false;
                            Log.GravaLog($"CPF Invalido - {CPF}");

                        }
                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }
            });
            return CPFValido;
        }
        public async Task<bool> ValidaCPFDuplicado(string CaminhoExcel)
        {
            bool CPFDupplic = true;
            int Linha = 4;
            var CPFs = new List<string>();
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {

                while (true)
                {
                    string CPF = excel.LeExcel("FUNCIONÁRIOS", Linha, 8);
                    if (!string.IsNullOrEmpty(CPF))
                    {
                        CPFs.Add(CPF);
                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }

                var duplicados = CPFs.GroupBy(x => x)
                      .Where(g => g.Count() > 1)
                      .Select(g => g.Key)
                      .ToList();
                if (duplicados.Count > 0)
                {
                    CPFDupplic = false;
                    duplicados.ForEach(cpf => { Log.GravaLog($"CPF Duplicado - {cpf}"); });

                }
            });
            return CPFDupplic;

        }
        public async Task<bool> ValidaDescricaoHorario(string CaminhoExcel)
        {

            bool DescricaoValido = true;
            int Linha = 4;
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {

                while (true)
                {
                    string DescHorario = excel.LeExcel("FUNCIONÁRIOS", Linha, 16);
                    if (!string.IsNullOrEmpty(DescHorario))
                    {
                        if (DescHorario.Length > 49)
                        {
                            DescricaoValido = false;
                            Log.GravaLog($"A Descrição do Horario deve Conter no Maximo 50 Caracteres - {DescHorario}");
                        }
                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }
                Linha = 4;
                while (true)
                {
                    string DescHorario = excel.LeExcel("HORÁRIOS", Linha, 5);
                    if (!string.IsNullOrEmpty(DescHorario))
                    {
                        if (DescHorario.Length > 49)
                        {
                            DescricaoValido = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }

            });
            return DescricaoValido;
        }
        public async Task<bool> ValidaEmailDuplicado(string CaminhoExcel)
        {
            bool EmailDupplic = true;
            int Linha = 4;
            var Emails = new List<string>();
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {

                while (true)
                {
                    string Email = excel.LeExcel("FUNCIONÁRIOS", Linha, 11);
                    if (!string.IsNullOrEmpty(Email))
                    {
                        Emails.Add(Email);
                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }

                var duplicados = Emails.GroupBy(x => x)
                      .Where(g => g.Count() > 1)
                      .Select(g => g.Key)
                      .ToList();
                if (duplicados.Count > 0)
                {
                    EmailDupplic = false;
                    duplicados.ForEach(email => { Log.GravaLog($"E-Mail Duplicado - {email}"); });

                }
            });
            return EmailDupplic;

        }
        public async Task<bool> ValidaMatriculaDuplicada(string CaminhoExcel)
        {
            bool MatriculaDupplic = true;
            int Linha = 4;
            var Matriculas = new List<string>();
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {

                while (true)
                {
                    string CPF = excel.LeExcel("FUNCIONÁRIOS", Linha, 1);
                    if (!string.IsNullOrEmpty(CPF))
                    {
                        Matriculas.Add(CPF);
                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }

                var duplicados = Matriculas.GroupBy(x => x)
                      .Where(g => g.Count() > 1)
                      .Select(g => g.Key)
                      .ToList();
                if (duplicados.Count > 0)
                {
                    MatriculaDupplic = false;
                    duplicados.ForEach(cpf => { Log.GravaLog($"Matricula Duplicada - {cpf}"); });

                }
            });
            return MatriculaDupplic;
        }
        public async Task<bool> ValidaPessoaSemMatricula(string CaminhoExcel)
        {

            int Linha = 4;
            var excel = new Excel(CaminhoExcel);
            bool MatriculaValida = true;
            await Task.Run(() =>
            {

                while (true)
                {
                    string Pessoa = excel.LeExcel("FUNCIONÁRIOS", Linha, 2);
                    string Matricula = excel.LeExcel("FUNCIONÁRIOS", Linha, 1);
                    if (!string.IsNullOrEmpty(Pessoa))
                    {
                        if (string.IsNullOrEmpty(Matricula))
                        {
                            MatriculaValida = false;
                            Log.GravaLog($"Funcionario Sem Matricula Associada -  {Pessoa}");

                        }
                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }

            });
            return MatriculaValida;
        }
        public async Task<bool> ValidaPIS(string CaminhoExcel)
        {

            bool PISValido = true;
            int Linha = 4;
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {

                while (true)
                {
                    string PIS = excel.LeExcel("FUNCIONÁRIOS", Linha, 3);
                    string Matricula = excel.LeExcel("FUNCIONÁRIOS", Linha, 1);

                    if (!string.IsNullOrWhiteSpace(Matricula))
                    {

                        if (!string.IsNullOrEmpty(PIS))
                        {
                            if (!ValPIS.IsPis(PIS))
                            {
                                PISValido = false;
                                Log.GravaLog($"PIS Invalido - {PIS}");
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }
            });

            return PISValido;
        }
        public async Task<bool> ValidaBaseDeHoras(string CaminhoExcel)
        {

            bool BaseDeHoras = true;
            int Linha = 4;
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {

                while (true)
                {
                    string Base = excel.LeExcel("FUNCIONÁRIOS", Linha, 13);
                    string Matricula = excel.LeExcel("FUNCIONÁRIOS", Linha, 1);

                    if (!string.IsNullOrWhiteSpace(Matricula) && !string.IsNullOrEmpty(Base))
                    {                        
                        if (!float.TryParse(Base, out float valor))
                        {                            
                            BaseDeHoras = false;
                            Log.GravaLog($"Base de Horas ({Base}) Invalida Para o Funcionario de Matricula: {Matricula}");
                        }
                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }
            });

            return BaseDeHoras;
        }
        public async Task<bool> ValidaPISDuplicado(string CaminhoExcel)
        {
            bool PISDupplic = true;
            int Linha = 4;
            var PIS = new List<string>();
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {

                while (true)
                {
                    string pis = excel.LeExcel("FUNCIONÁRIOS", Linha, 3);
                    if (!string.IsNullOrEmpty(pis))
                    {
                        PIS.Add(pis);
                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }

                var duplicados = PIS.GroupBy(x => x)
                      .Where(g => g.Count() > 1)
                      .Select(g => g.Key)
                      .ToList();
                if (duplicados.Count > 0)
                {
                    PISDupplic = false;
                    duplicados.ForEach(pis => { Log.GravaLog($"PIS Duplicado - {pis}"); });

                }
            });
            return PISDupplic;
        }
        public async Task<bool> ValidaDatas(string CaminhoExcel)
        {
            int Linha = 4;
            var excel = new Excel(CaminhoExcel);
            bool DataValida = true;
            await Task.Run(() =>
            {
                while (true)
                {
                    string Pessoa = excel.LeExcel("FUNCIONÁRIOS", Linha, 2);
                    string DTAdmissao = excel.LeExcel("FUNCIONÁRIOS", Linha, 6);
                    if (!string.IsNullOrEmpty(Pessoa))
                    {

                        DateTime Admissao;
                        bool AdmissaoValido = DateTime.TryParseExact(DTAdmissao, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out Admissao);
                        bool AdmissaoValido1 = DateTime.TryParseExact(DTAdmissao, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out Admissao);

                        if (!AdmissaoValido && !AdmissaoValido1)
                        {
                            DataValida = false;
                            Log.GravaLog($"Funcionario sem data de Admissão, ou data Invalida para o Funcionario -  {Pessoa}");

                        }

                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }
                //    Linha = 4;
                //    while (true)
                //    {
                //        string Pessoa = excel.LeExcel("FUNCIONÁRIOS", Linha, 2);
                //        string DTnascimento = excel.LeExcel("FUNCIONÁRIOS", Linha, 5);
                //        if (!string.IsNullOrEmpty(Pessoa))
                //        {
                //            DateTime nascimento;
                //            bool nascimentoValido = DateTime.TryParseExact(DTnascimento, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out nascimento);

                //            if (string.IsNullOrEmpty(DTnascimento))
                //            {
                //                Log.GravaLog($"Funcionario sem Data de Nascimento, ou Data Invalida para o Funcionario -   {Pessoa}");

                //            }
                //            else if (!nascimentoValido)
                //            {
                //                DataValida = false;
                //                Log.GravaLog($"Funcionario sem Data de Nascimento, ou Data Invalida para o Funcionario -   {Pessoa}");
                //            }
                //        }
                //        else
                //        {
                //            break;
                //        }
                //        Linha++;
                //    }

            });
            return DataValida;

        }
        public async Task<bool> ValidaPessoaSemCNPJ(string CaminhoExcel)
        {
            int Linha = 4;
            var excel = new Excel(CaminhoExcel);
            bool PessoaSemCNPJ = true;
            await Task.Run(() =>
            {

                while (true)
                {
                    string Pessoa = excel.LeExcel("FUNCIONÁRIOS", Linha, 2);
                    string CNPJ = excel.LeExcel("FUNCIONÁRIOS", Linha, 20);
                    if (!string.IsNullOrEmpty(Pessoa))
                    {
                        if (string.IsNullOrEmpty(CNPJ))
                        {
                            PessoaSemCNPJ = false;
                            Log.GravaLog($"Funcionario Sem CNPJ Associado -  {Pessoa}");

                        }
                    }
                    else
                    {
                        break;
                    }
                    Linha++;
                }

            });
            return PessoaSemCNPJ;
        }
    }
}
