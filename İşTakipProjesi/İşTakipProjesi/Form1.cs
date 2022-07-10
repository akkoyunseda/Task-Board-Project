using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İşTakipProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rDepartman.Visible = false;
            ribbonPage3.Visible = false;
            ribbonPage4.Visible = false;
            ribbonPage5.Visible = false;
            ribbonPage6.Visible = false;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmDepartmanlar frm = new Formlar.FrmDepartmanlar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYönetimDep frm2 = new Formlar.FrmYönetimDep();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmİnsanKaynakları frm3 = new Formlar.FrmİnsanKaynakları();
            frm3.MdiParent = this;
            frm3.Show();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersoneller frm4 = new Formlar.FrmPersoneller();
            frm4.MdiParent = this;
            frm4.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFirmalar frm5 = new Formlar.FrmFirmalar();
            frm5.MdiParent = this;
            frm5.Show();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGörevListesi frm6 = new Formlar.FrmGörevListesi();
            frm6.MdiParent = this;
            frm6.Show();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGörevDetayları frm7 = new Formlar.FrmGörevDetayları();
            frm7.MdiParent = this;
            frm7.Show();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmAdminler frm9 = new Formlar.FrmAdminler();
            frm9.MdiParent = this;
            frm9.Show();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmAnaSayfa frm8 = new Formlar.FrmAnaSayfa();
            frm8.MdiParent = this;
            frm8.Show();
            
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmİkGiriş frm10 = new Formlar.FrmİkGiriş();
            frm10.MdiParent = this;
            frm10.Show();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form1 fr = new Form1();
            fr.ribbonPage5.Visible = true;
            fr.Show();
            fr.ribbonPage1.Visible = false;
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmAktifGörevler frm11 = new Formlar.FrmAktifGörevler();
            frm11.MdiParent = this;
            frm11.Show();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmTamamGörevler frm12 = new Formlar.FrmTamamGörevler();
            frm12.MdiParent = this;
            frm12.Show();
        }
    }
}
