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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();

        void FirmaListele()
        {
            var degerler = (from x in db.TblFirmalar
                            select new
                            {
                                x.ID,
                                x.Ad,
                                x.Yetkili,
                                x.Mail,
                                x.İl
                            });
            gridControl1.DataSource = degerler.ToList();
        }

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            FirmaListele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblFirmalar a = new TblFirmalar();
            a.Ad = TxtAd.Text;
            a.Yetkili = TxtYetkili.Text;
            a.Mail = TxtMail.Text;
            a.İl = Txtİl.Text;
            db.TblFirmalar.Add(a);
            db.SaveChanges();
            XtraMessageBox.Show("Yeni firma kaydı başarılı bir şekilde " +
                "gerçekleşti", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            FirmaListele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            FirmaListele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblFirmalar.Find(x);
            db.TblFirmalar.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Firma silme işlemi başarılı bir şekilde gerçekleşti",
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            FirmaListele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblFirmalar.Find(x);
            deger.Ad = TxtAd.Text;
            deger.Yetkili = TxtYetkili.Text;
            deger.Mail = TxtMail.Text;
            deger.İl = Txtİl.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Firma bilgileri başarılı bir şekilde güncellendi.", "Bilgi",
               MessageBoxButtons.OK, MessageBoxIcon.Question);
            FirmaListele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtYetkili.Text = gridView1.GetFocusedRowCellValue("Yetkili").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            Txtİl.Text = gridView1.GetFocusedRowCellValue("İl").ToString();
        }
    }
}
