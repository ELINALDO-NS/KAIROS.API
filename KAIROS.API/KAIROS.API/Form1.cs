using KAIROS.API.Repositorio;
using KAIROS.API.Repositorio.Interface;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml.FormulaParsing.Exceptions;
using System.Runtime.CompilerServices;

namespace KAIROS.API
{
    public partial class Form1 : Form
    {
        private readonly IExcelRepositorio _excel;
        private readonly IAPIRepositorio _API;

        public Form1(ServiceProvider serviceProvider)
        {
            InitializeComponent();
            _excel = serviceProvider.GetRequiredService<IExcelRepositorio>();
            _API = serviceProvider.GetRequiredService<IAPIRepositorio>();    
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btn_Lista_Horarios_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(Txb_Excel.Text))
                {
                    MessageBox.Show("Informe o Local da Planilha de Implantação !", "Listar Horario");
                    return;
                }
                string LocalGravacao = PathGravacao();
                if (!string.IsNullOrEmpty(LocalGravacao))
                {
                    _excel.SalvaHorarios(Txb_Excel.Text, LocalGravacao);                   
                    MessageBox.Show("Ok");
                }
                else
                {

                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public bool PathLeitura()
        {
            try
            {

                using (OpenFileDialog OpenFileDialog1 = new OpenFileDialog())
                {
                    OpenFileDialog1.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        Txb_Excel.Text = OpenFileDialog1.FileName;

                        return true;
                    }
                    else
                    {

                        return false;

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Modelo Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public string PathGravacao()
        {
            try
            {

                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        return folderBrowserDialog.SelectedPath;
                    }

                }
                return "";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Local de Gravação Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

        }


        private void btn_LocalExcel_Click(object sender, EventArgs e)
        {
            PathLeitura();
        }

        private void btn_Iniciar_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("OK");
        }
    }
}
