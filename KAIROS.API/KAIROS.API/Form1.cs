using KAIROS.API.Repositorio;
using KAIROS.API.Repositorio.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace KAIROS.API
{
    public partial class Form1 : Form
    {
        private readonly IExcelRepositorio _excel;



        public Form1(ServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _excel = new ExcelRepositorio();
            InitializeComponent();

        }

        public ServiceProvider ServiceProvider { get; }

        private void btn_Lista_Horarios_Click(object sender, EventArgs e)
        {
            _excel.LerCargos(PatchExcel);
            MessageBox.Show("Ok");
        }
        public string PatchExcel;
        public bool PathExcel()
        {
            try
            {

                using (OpenFileDialog OpenFileDialog1 = new OpenFileDialog())
                {
                    OpenFileDialog1.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PatchExcel = OpenFileDialog1.FileName;
                        Txb_Excel.Text = OpenFileDialog1.FileName;
                        //Txb_Excel.Text = OpenFileDialog1.FileName;

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

        private void btn_LocalExcel_Click(object sender, EventArgs e)
        {
            PathExcel();
        }
    }
}
