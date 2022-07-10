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
    public partial class FrmGörevListesi : Form
    {
        public FrmGörevListesi()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();

        void GörevLisetele()
        {
            var degerler = from x in db.TblGörevler
                           select new
                           {
                               x.ID,
                               GörevVeren = x.TblPersonel.Ad,
                               GörevAlan = x.TblPersonel1.Ad,
                               x.Açıklama,
                               x.Durum
                           };

            gridControl1.DataSource = degerler.ToList();

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            GörevLisetele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblGörevler t = new TblGörevler();
            t.GörevVeren = int.Parse(TxtVeren.EditValue.ToString());
            t.GörevAlan = int.Parse(TxtAlan.EditValue.ToString());
            t.Açıklama = TxtAçıklama.Text;
            t.Durum = TxtDurum.Text;
            db.TblGörevler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Yeni görev kaydı başarılı bir şekilde " +
                "gerçekleşti", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            GörevLisetele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblGörevler.Find(x);
            deger.Açıklama = TxtAçıklama.Text;
            deger.Durum = TxtDurum.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Görev başarılı bir şekilde güncellendi.", "Bilgi",
               MessageBoxButtons.OK, MessageBoxIcon.Question);
            GörevLisetele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtVeren.Text = gridView1.GetFocusedRowCellValue("GörevVeren").ToString();
            TxtAlan.Text = gridView1.GetFocusedRowCellValue("GörevAlan").ToString();
            TxtAçıklama.Text = gridView1.GetFocusedRowCellValue("Açıklama").ToString();
            TxtDurum.Text = gridView1.GetFocusedRowCellValue("Durum").ToString();
        }
    }
}
