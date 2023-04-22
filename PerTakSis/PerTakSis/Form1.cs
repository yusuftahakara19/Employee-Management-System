using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PerTakSis
{
   
    public partial class Form1 : Form
    {
        void temizle()
        {
            textBoxID.Text = "";
            textBoxAD.Text = "";
            textBoxSOYAD.Text = "";
            textBoxMESLEK.Text = "";
            comboBoxSEHİR.Text = "";
            maskedTextBoxMAAS.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;

        }
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        SqlConnection baglanti = new SqlConnection("Data Source=YTK\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string metin="";
            if (radioButton1.Checked == true)
            {
                metin = "true";
            } if (radioButton2.Checked == true)
            {
                metin = "false";

            }
        
            baglanti.Open();
            if (textBoxAD.Text == "" || textBoxSOYAD.Text=="" ||textBoxMESLEK.Text=="" || comboBoxSEHİR.Text=="" || maskedTextBoxMAAS.Text=="")
            {
                MessageBox.Show("Lütfen Tüm Değerleri Giriniz");
                baglanti.Close();
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerMeslek,PerSehir,PerMaas,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBoxAD.Text);
                komut.Parameters.AddWithValue("@p2", textBoxSOYAD.Text);
                komut.Parameters.AddWithValue("@p3", textBoxMESLEK.Text);
                komut.Parameters.AddWithValue("@p4", comboBoxSEHİR.Text);
                komut.Parameters.AddWithValue("@p5", maskedTextBoxMAAS.Text);
                komut.Parameters.AddWithValue("@p6", metin);
                komut.ExecuteNonQuery();
                baglanti.Close();
                this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
                MessageBox.Show("Personel Başarılı Bir Şekilde Kaydedildi");
                temizle();
            }
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBoxID.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBoxAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBoxSOYAD.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBoxMESLEK.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            comboBoxSEHİR.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBoxMAAS.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            if (dataGridView1.Rows[secilen].Cells[5].Value.ToString()=="True")
            {
                radioButton1.Checked = true;
            }
            if(dataGridView1.Rows[secilen].Cells[5].Value.ToString()=="False")
            {
                radioButton2.Checked = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("delete from Tbl_Personel where Perid = @k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1",textBoxID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
            if (textBoxID.Text == "")
            {
                MessageBox.Show("Lütfen Seçim Yapınız");
            }
            else
            {
                MessageBox.Show("Personel Başarılı Bir Şekilde Silindi");

            }
            temizle();
          


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string durum="";
            if (radioButton1.Checked = true)
            {
                durum = "True";
            }
            else if(radioButton2.Checked=true){
                durum = "False";
            }
            SqlCommand komutguncelle = new SqlCommand("update Tbl_Personel set PerAd=@a1,PerSoyad=@a2,PerMeslek=@a3,PerSehir=@a4,PerMaas=@a5,PerDurum=@a6 where Perid=@a7",baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", textBoxAD.Text);
            komutguncelle.Parameters.AddWithValue("@a2", textBoxSOYAD.Text);
            komutguncelle.Parameters.AddWithValue("@a3", textBoxMESLEK.Text);
            komutguncelle.Parameters.AddWithValue("@a4", comboBoxSEHİR.Text);
            komutguncelle.Parameters.AddWithValue("@a5", maskedTextBoxMAAS.Text);
            komutguncelle.Parameters.AddWithValue("@a6", durum);
            komutguncelle.Parameters.AddWithValue("@a7", textBoxID.Text);
            komutguncelle.ExecuteNonQuery();

            baglanti.Close();
            if (textBoxID.Text == "") {
                MessageBox.Show("Lütfen Seçim Yapınız");
            }
            else
            {
                MessageBox.Show("Güncelleme Başarılı Bir Şekilde Yapıldı");

            }
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

            temizle();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnIstatistik_Click(object sender, EventArgs e)
        {
            Frmİstatistik frm = new Frmİstatistik();
            frm.Show();
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafik frm = new FrmGrafik();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRapor frm = new FrmRapor();
            frm.Show();
        }
    }
}
