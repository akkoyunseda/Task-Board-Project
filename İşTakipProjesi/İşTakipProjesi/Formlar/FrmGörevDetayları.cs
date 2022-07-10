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
    public partial class FrmGörevDetayları : Form
    {
        public FrmGörevDetayları()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();

        void DetayListe()
        {
            var degerler = (from x in db.TblGörevDetaylar
                            select new
                            {
                                x.ID,
                                Görev = x.TblGörevler.Açıklama,
                                x.GörevAçıklama,
                                x.Saat,
                                x.Tarihi
                            });
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            DetayListe();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblGörevDetaylar.Find(x);
            deger.Görev = int.Parse(TxtGörev.EditValue.ToString());
            deger.GörevAçıklama = TxtAçıklama.Text;
            deger.Saat = Saat.Text;
            deger.Tarihi = TxtTarih.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Görev başarılı bir şekilde güncellendi.", "Bilgi",
               MessageBoxButtons.OK, MessageBoxIcon.Question);
            DetayListe();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtGörev.Text = gridView1.GetFocusedRowCellValue("Görev").ToString();
            TxtAçıklama.Text = gridView1.GetFocusedRowCellValue("GörevAçıklama").ToString();
            TxtSaat.Text = gridView1.GetFocusedRowCellValue("Saat").ToString();
            TxtTarih.Text = gridView1.GetFocusedRowCellValue("Tarihi").ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TblGörevDetaylar det = new TblGörevDetaylar();
            det.GörevAçıklama = TxtAçıklama.Text;
            det.Görev = int.Parse(TxtGörev.EditValue.ToString());
            det.Saat = TxtSaat.Text;
            det.Tarihi = TxtTarih.Text;
            db.TblGörevDetaylar.Add(det);
            db.SaveChanges();
            XtraMessageBox.Show("Görev detayları başarılı bir şekilde " +
                "eklendi", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            DetayListe();


        }
    }
}
