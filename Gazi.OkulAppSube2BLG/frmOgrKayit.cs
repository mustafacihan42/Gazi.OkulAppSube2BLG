using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OkulApp.BLL;
using Gazi.OkulAppSube2BLG;

namespace OkulAppSube1BIL
{
    public partial class frmOgrKayit : Form
    {
        public int OgrenciId { get; set; }

        public frmOgrKayit()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                bool sonuc = obl.OgrenciEkle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme başarılı!" : "Ekleme başarısız!!");

                //kaydet yaptıktan sonra mevcut ad-soyad-numara bileşenleri temizlemimizi sağlar.
                txtAd.Clear();
                txtSoyad.Clear();
                txtNumara.Clear();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numara daha önce kayıtlı");
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu!!");
            }
        }
        private void btnBul_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmOgrBul (this);
                frm.Show();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciSil(OgrenciId) ? "Silme Başarılı" : "Başarısız!");
                // Mevcut kayıdı sildikten sonra da textboxları temizler
                txtAd.Clear();
                txtSoyad.Clear();
                txtNumara.Clear();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciGuncelle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim(), OgrenciId = OgrenciId }) ? "Güncelleme Başarılı" : "Güncelleme Başarısız!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}







