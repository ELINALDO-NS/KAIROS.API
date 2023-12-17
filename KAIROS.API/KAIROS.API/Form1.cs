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
            _excel.ListaHorario("C:\\Users\\Santos\\Desktop\\");
            MessageBox.Show("Ok");
        }
    }
}
