using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerTakSis
{
    public partial class FrmRapor : Form
    {
        public FrmRapor()
        {
            InitializeComponent();
        }

        private void FrmRapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PersonelVeriTabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.Tbl_PersonelTableAdapter.Fill(this.PersonelVeriTabaniDataSet.Tbl_Personel);

            this.reportViewer1.RefreshReport();
        }
    }
}
