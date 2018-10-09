using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace InputDataMahasiswa
{
    public partial class FrmListMahasiswa : Form
    {
        public FrmListMahasiswa()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        public void InisialisasiListView()
        {
            lvwMahasiswa.View = System.Windows.Forms.View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;
            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Npm", 70, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Nama", 180, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Jenis Kelamin", 80, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Tempat Lahir", 75, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Tgl. Lahir", 75, HorizontalAlignment.Left);
        }

        public void ResetForm()
        {
            mskNpm.Clear();
            txtNama.Clear();
            rdoLakilaki.Checked = true;
            txtTempatLahir.Clear();
            dtpTanggalLahir.Value = DateTime.Today;

            mskNpm.Focus();
        }

        public void FrmListMahasiswa_Load(object sender, EventArgs e)
        {

        }

        public void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!mskNpm.MaskFull)
            {
                MessageBox.Show("NPM harus diisi!!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskNpm.Focus();
                return;
            }

            if (!(txtNama.Text.Length > 0))
            {
                MessageBox.Show("Nama harus diisi!!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNama.Focus();
                return;
            }

            var jenisKelamin = rdoLakilaki.Checked ? "Laki-laki" : "Perempuan";

            var result = MessageBox.Show("Apakah data ingin disimpan?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mskNpm.Text);
                item.SubItems.Add(txtNama.Text);
                item.SubItems.Add(jenisKelamin);
                item.SubItems.Add(txtTempatLahir.Text);
                item.SubItems.Add(dtpTanggalLahir.Value.ToString("dd/MM/yyyy"));

                lvwMahasiswa.Items.Add(item);

                ResetForm();
            }
        }

        public void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                var index = lvwMahasiswa.SelectedIndices[0];
                var nama = lvwMahasiswa.Items[index].SubItems[2].Text;

                var msg = string.Format("Apakah data mahasiswa '{0}' ingin hapus ?",
                    nama);

                var result = MessageBox.Show(msg, "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    lvwMahasiswa.Items[index].Remove();

                    for (var i = 0; i < lvwMahasiswa.Items.Count; i++)
                    {
                        var noUrut = i + 1;
                        lvwMahasiswa.Items[i].Text = noUrut.ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Data belum dipilih", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void btnTutup_Click(object sender, EventArgs e)
        {
            var msg = "Apakah Anda yakin ?";

            var result = MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
                this.Close();
        }

        public void lvwMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                var index = lvwMahasiswa.SelectedIndices[0];
                var npm = lvwMahasiswa.SelectedItems[0].SubItems[1].Text;
                var nama = lvwMahasiswa.SelectedItems[0].SubItems[2].Text;
                var jenisKelamin = lvwMahasiswa.SelectedItems[0].SubItems[3].Text;
                var tempatLahir = lvwMahasiswa.SelectedItems[0].SubItems[4].Text;
                var tanggaLahir = lvwMahasiswa.SelectedItems[0].SubItems[5].Text;
                DateTime dt = DateTime.ParseExact(tanggaLahir, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                mskNpm.Text = npm;
                txtNama.Text = nama;
                txtTempatLahir.Text = tempatLahir;

                if (jenisKelamin == "Laki-laki")
                {
                    rdoLakilaki.Checked = true;
                    rdoPerempuan.Checked = false;
                }
                else
                {
                    rdoLakilaki.Checked = false;
                    rdoPerempuan.Checked = true;
                }
                dtpTanggalLahir.Value = dt;
            }
        }
    }
}
