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
using System.Windows.Forms;

namespace İşTakipProjesi.Formlar
{
    public partial class FrmAdminler : Form
    {
        public FrmAdminler()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();

        void Adminler()
        {
            var degerler = from x in db.TblAdmin
                           select new
                           {
                               x.ID,
                               x.Kullanici,
                               x.Sifre
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Adminler();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblAdmin t = new TblAdmin();
            t.ID = int.Parse(TxtID.Text);
            t.Kullanici = TxtAd.Text;
            t.Sifre = TxtSifre.Text;
           
            db.TblAdmin.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Yeni admin kaydı başarılı bir şekilde " +
                "gerçekleşti", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Adminler();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblAdmin.Find(x);
            db.TblAdmin.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Admin silme işlemi başarılı bir şekilde gerçekleşti",
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Adminler();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            var x = int.Parse(TxtID.Text);
            var deger = db.TblAdmin.Find(x);
            deger.Kullanici = TxtAd.Text;
            deger.Sifre = TxtSifre.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Admin bilgisi başarılı bir şekilde " +
                "güncellendi", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Adminler();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Kullanici").ToString();
            TxtSifre.Text = gridView1.GetFocusedRowCellValue("Sifre").ToString();
        }

       
    }
}
