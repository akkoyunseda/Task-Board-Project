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
    public partial class FrmİnsanKaynakları : Form
    {
        public FrmİnsanKaynakları()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();

        void İnsanKaynakListe()
        {
            var degerler = from x in db.İnsan_Kaynakları_Departmanı
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
        private void FrmİnsanKaynakları_Load(object sender, EventArgs e)
        {
            İnsanKaynakListe();
        }
    }
}
