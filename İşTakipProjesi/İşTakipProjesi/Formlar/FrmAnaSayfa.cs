using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using İşTakipProjesi.Entity;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace İşTakipProjesi.Formlar
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            
            InitializeComponent();
        }
        
        SqlConnection baglanti = new SqlConnection(@"Data Source=E-CORP;Initial Catalog=DbisTakip;Integrated Security=True");

        private void BtnGiriş_Click(object sender, EventArgs e)
        {
           
            try
            {
                baglanti.Open();
                string sql = "SELECT * FROM TblAdmin WHERE Kullanici= @adi AND Sifre = @sifresi";
                SqlParameter prm1 = new SqlParameter("adi", TxtAd.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", TxtSifre.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    Form1 fr = new Form1();
                    fr.rDepartman.Visible = true;
                    fr.ribbonPage3.Visible = true;
                    fr.ribbonPage4.Visible = true;
                    fr.ribbonPage5.Visible = true;
                    fr.ribbonPage6.Visible = true;
                    fr.Show();

                    fr.ribbonPage1.Visible = false;

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Giriş");

            }

        }
    }
}
