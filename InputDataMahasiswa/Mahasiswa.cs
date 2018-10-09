using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputDataMahasiswa
{
    public partial class Mahasiswa : Form
    {
        public Mahasiswa()
        {
            InitializeComponent();
        }

        public void btnTampil_Click(object sender, EventArgs e)
        {
            if (!mskNpm.MaskFull)
            {
                MessageBox.Show("NPM harus diisi!!!", "Peringatan", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                mskNpm.Focus();
                return;
            }

            if (!(txtNama.Text.Length > 0))
            {
                MessageBox.Show("Nama Harus Diisi!!!", "Peringatan", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtNama.Focus();
                return;
            }

            if (!(txtTempatLahir.Text.Length > 0))
            {
                MessageBox.Show("Tempat Lahir harus diisi!!!", "Peringatan", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtTempatLahir.Focus();
                return;
            }

            if (!(dtpTanggalLahir.Text.Length > 0))
            {
                MessageBox.Show("NPM harus diisi!!!", "Peringatan", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                dtpTanggalLahir.Focus();
                return;
            }

            var jeniskelamin = rdoLakilaki.Checked ? "Laki-Laki" : "Perempuan";

            var msg = string.Format("NPM: {0} \nNama: {1} \nJenis Kelamin: {2} \nTempat & Tgl Lahir: {3}",
                mskNpm.Text, txtNama.Text, jeniskelamin, txtTempatLahir.Text + ", " + this.dtpTanggalLahir.Text);

            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void btnTutup_Click(object sender, EventArgs e)
        {
            var msg = "Apakah Anda yakin ?";

            var result = MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
                this.Close();
        }

        public void txtTempatLahir_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
