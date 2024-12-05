using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public partial class CreateBackupCopy : Form
    {

        public CreateBackupCopy()
        {
            InitializeComponent();

            Util.OpenAndSaveProductsPath(productsFolderTbx, this);
        }

        private void findProductFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder_browser = new FolderBrowserDialog();
            folder_browser.Description = "Seleciona a pasta onde estão os arquivos de produto.";
            if (folder_browser.ShowDialog() == DialogResult.OK)
                productsFolderTbx.Text = folder_browser.SelectedPath;
        }

        private void findTargetFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder_browser = new FolderBrowserDialog();
            folder_browser.Description = "Seleciona a pasta onde a cópia de segurança será feita.";
            if (folder_browser.ShowDialog() == DialogResult.OK)
            {
                targetFolderTbx.Text = folder_browser.SelectedPath;

                DateTime time = DateTime.Now;

                targetFolderTbx.Text += string.Format(@"\copia_{0}_{1}_{2}.zip", time.Day, time.Month, time.Year);
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productsFolderTbx.Text))
            {
                MessageBox.Show("Nenhuma pasta selecionada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Directory.Exists(productsFolderTbx.Text))
            {
                MessageBox.Show("A pasta selecionada é inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(targetFolderTbx.Text))
            {
                MessageBox.Show("Nenhum local de destino.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            filesLbx.Items.Clear();

            string startPath = productsFolderTbx.Text;
            string zipPath = targetFolderTbx.Text;

            List<string> founded_files = new List<string>();

            bool created = false;

            BackgroundWorker bk = new BackgroundWorker();
            bk.DoWork += delegate
            {
                string[] files = Directory.GetFiles(startPath, "*.*", SearchOption.AllDirectories)
                    .Where(p => p.ToLower().EndsWith(".amf") || p.ToLower().EndsWith(".amcf")).ToArray(); //Somente arquivos compatíveis

                try
                {
                    using (FileStream zipToOpen = new FileStream(zipPath, FileMode.CreateNew))
                    {
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                        {
                            for (int i = 0; i < files.Length; i++)
                            {
                                string file = files[i];

                                archive.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);

                                founded_files.Add(Path.GetFileName(file));
                            }
                        }
                    }

                    created = true;
                }
                catch { }
            };
            bk.RunWorkerCompleted += delegate
            {
                filesLbx.Items.AddRange(founded_files.ToArray());

                if (created)
                {
                    MessageBox.Show("Cópia criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Deseja abrir o local onde o arquivo foi salvo?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        System.Diagnostics.Process.Start("explorer.exe", string.Format("/select, \"{0}\"", zipPath));
                }
                else
                    MessageBox.Show("Erro ao criar a cópia, tente localizar a pasta específica dos arquivos ou verifique se já não existe um arquivo de destino com esse nome.", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Text = "";

                createBtn.Text = "Criar Cópia";
                createBtn.Enabled = findProductFolderBtn.Enabled = findTargetFolderBtn.Enabled = true;
            };
            bk.RunWorkerAsync();

            this.Text = "Fazendo a busca dos arquivos...";

            createBtn.Text = "Aguarde...";
            createBtn.Enabled = findProductFolderBtn.Enabled = findTargetFolderBtn.Enabled = false;
        }

    }
}
