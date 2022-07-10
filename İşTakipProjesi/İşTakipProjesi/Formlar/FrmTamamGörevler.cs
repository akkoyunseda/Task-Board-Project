using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using İşTakipProjesi.Entity;
using System.Windows.Forms;

namespace İşTakipProjesi.Formlar
{
    public partial class FrmTamamGörevler : Form
    {
        public FrmTamamGörevler()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=E-CORP;Initial Catalog=DbisTakip;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand cmd = new SqlCommand("Tamamlanmış_Görevler", baglantı);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
    }
}
