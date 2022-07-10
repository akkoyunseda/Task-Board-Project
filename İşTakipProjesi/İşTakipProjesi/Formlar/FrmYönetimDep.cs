using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using İşTakipProjesi.Entity;
using System.Windows.Forms;

namespace İşTakipProjesi.Formlar
{
    public partial class FrmYönetimDep : Form
    {
        public FrmYönetimDep()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();

        void YönetimListe()
        {
            var degerler = from x in db.Yönetim_Departmanı
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Soyad,
                               x.Mail,
                               x.Telefon,
                               x.Durum
                           };
            gridControl1.DataSource = degerler.Where(x => x.Durum == true).ToList();
        }

        private void FrmYönetimDep_Load(object sender, EventArgs e)
        {
            YönetimListe();
        }
    }
}
