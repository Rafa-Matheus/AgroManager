using DHS.SQL;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace AmazonAgro
{
    public partial class Main : Form
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private PostgreSQLAdapter sql;
        private Font font;
        private Pen pen;
        private bool warn_user;
        public Main(PostgreSQLAdapter sql)
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            this.sql = sql;

            ProcessManager.Initialize(sql);

            //Deve ser declarado ANTES do monitor para evitar loop
            RefreshProcesses(true);

            //Monitor de processos
            ProcessWatcher watcher = new ProcessWatcher(sql);
            watcher.ProcessChanged += delegate
            {
                //Avisar
                if (!flag_changed_by_user)
                {
                    warn_user = true;
                }

                RefreshProcesses(false);

                if (warn_user)
                {
                    processesPnl.Refresh();

                    MessageBox.Show("Houve uma alteração no processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                flag_changed_by_user = false;
            };
            watcher.Start();

            this.FormClosing += (o, args) =>
            {
                //Realizar logout
                UserManager.Logout(sql);
            };

            restartBtn.Enabled = UserManager.IsAdmin;

            admBtn.Visible = UserManager.IsAdmin;

            font = new Font("Segoe UI", 15, FontStyle.Regular);

            pen = new Pen(Brushes.White, 2f);

            //Expandir todos e ocultar outros
            processesPnl.Dock = toolsPnl.Dock = admPnl.Dock = DockStyle.Fill;
            toolsPnl.Visible = admPnl.Visible = false;

            //Visibilidade dos botões se não for administrador
            if (!UserManager.IsAdmin)
            {
                goalsBtn.Visible = materialsBtn.Visible = composeBtn.Visible = UserManager.CheckPermission(UserManager.CurrentUserId, 0, sql); //Laboratório
                pricingBtn.Visible = costingBtn.Visible = packsBtn.Visible = overviewBtn.Visible = UserManager.CheckPermission(UserManager.CurrentUserId, 1, sql); //Custear
                recBtn.Visible = leafBtn.Visible = UserManager.CheckPermission(UserManager.CurrentUserId, 2, sql); //Fazer Recomendações
            }
        }

        public void RefreshProcesses(bool change_in_data_base)
        {
            process_index = 0;

            int process_length;
            if ((process_length = ProcessManager.GetCurrentProcessIndex(sql)) != -1)
            {
                for (int i = 0; i <= process_length; i++)
                {
                    //Somente antes do último
                    GotoNextProcess(i < process_length - 1 || i == processes.Length, change_in_data_base);

                    if (i < process_length)
                        process_index++;
                }
            }
            else
                SetProcessHandler(false, false);
        }

        #region Controle de processo
        private int process_index = 0;
        private Process[] processes = {
            new Process("Criar Metas", 0, 0),
            new Process("Testar Metas", 0, 0),
            new Process("Aprovar Fórmula", 0, -1),
            new Process("Custear", 1, 1),
            new Process("Ordem de Produção", 2, 0)
        };

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (process_index < processes.Length)
            {
                //Somente se o processo estiver terminado
                Process process = processes[process_index];
                if (!process.IsFinished) { process.HandleAction(); return; }

                GotoNextProcess(false, true);
            }
        }

        private bool flag_changed_by_user;
        public void GotoNextProcess(bool is_finished, bool change_in_data_base)
        {
            if (process_index < processes.Length)
            {
                //Definir no gerenciador de processos
                if (change_in_data_base)
                {
                    ProcessManager.SetCurrentProcessIndex(process_index, sql);
                    flag_changed_by_user = true;
                }

                SetProcessHandler(is_finished, change_in_data_base);
            }
        }

        private void SetProcessHandler(bool is_finished, bool change_in_data_base)
        {
            Process process = processes[process_index];
            process.IsFinished = is_finished;

            process.SetHandler(delegate
            {
                if (!UserManager.IsAdmin && !UserManager.CheckPermission(UserManager.CurrentUserId, processes[process_index].Permission, sql))
                {
                    MessageBox.Show("Desculpe, você não tem permissão para realizar essa tarefa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (process.IsFinished) return;

                switch (process_index)
                {
                    case 0:
                        new Goals(sql).ShowDialog();
                        break;
                    case 3:
                        new Costing(sql).ShowDialog();
                        break;
                }

                if (process_index + 1 < processes.Length)
                {
                    if (MessageBox.Show(string.Format("Deseja ir para o próxima tarefa? ({0}) Isso irá impedir você de retroceder.", processes[process_index + 1].Title), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        InputPassword input_password = new InputPassword(sql);
                        if (input_password.ShowDialog() == DialogResult.OK)
                        {
                            process_index++;

                            process.IsFinished = true;

                            GotoNextProcess(false, true);

                            warn_user = false;

                            //Abrir janela
                            nextWindowBtn.PerformClick();
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Finalizar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        InputPassword input_password = new InputPassword(sql);
                        if (input_password.ShowDialog() == DialogResult.OK)
                        {
                            //Definir no gerenciador de processos
                            if (change_in_data_base)
                            {
                                ProcessManager.SetCurrentProcessIndex(processes.Length, sql);
                                flag_changed_by_user = true;
                            }

                            //MessageBox.Show("Todas as tarefas foram finalizadas!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            process_index = processes.Length;

                            warn_user = false;

                            process.IsFinished = true;

                            processesPnl.Refresh();
                        }
                    }
                }
            });

            processesPnl.Refresh();
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            //Somente se já realizou um processo
            if (process_index == 0) return;

            if (UserManager.IsAdmin)
                if (MessageBox.Show("Deseja mesmo reiniciar o processo?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    if (new InputPassword(sql).ShowDialog() == DialogResult.OK)
                    {
                        //Limpar gerenciador de processos
                        ProcessManager.Clear(sql);
                        flag_changed_by_user = true;

                        process_index = 0;

                        warn_user = false;

                        SetProcessHandler(false, false);
                    }
        }
        #endregion

        #region Botões
        private void costingBtn_Click(object sender, EventArgs e)
        {
            new SQLForm(sql, @".\tables\base_precos.xml").Show(); ;
        }

        private void leafBtn_Click(object sender, EventArgs e)
        {
            new LeafAnalysis(sql).ShowDialog();
        }

        private void recBtn_Click(object sender, EventArgs e)
        {
            new LeafSearch(sql).ShowDialog();
        }

        private void composeBtn_Click(object sender, EventArgs e)
        {
            new ComposeMaterials(sql).ShowDialog();
        }

        private void goalsBtn_Click(object sender, EventArgs e)
        {
            new Goals(sql).ShowDialog();
        }

        private void materialsBtn_Click(object sender, EventArgs e)
        {
            new Materials(sql).ShowDialog();
        }

        private void costingBtn_Click_1(object sender, EventArgs e)
        {
            new Costing(sql).ShowDialog();
        }

        private void overviewBtn_Click(object sender, EventArgs e)
        {
            new Overview(sql).ShowDialog();
        }

        private void clientsBtn_Click(object sender, EventArgs e)
        {
            new SQLForm(sql, @".\tables\clientes.xml").Show();
        }

        private void setserverBtn_Click(object sender, EventArgs e)
        {
            new PostgreSQLSetup(sql).ShowDialog();
        }

        private void packsBtn_Click(object sender, EventArgs e)
        {
            new SQLForm(sql, @".\tables\embalagens.xml").Show();
        }

        private void usersBtn_Click(object sender, EventArgs e)
        {
            new SQLForm(sql, @".\tables\users.xml").Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createCopyBtn_Click(object sender, EventArgs e)
        {
            new CreateBackupCopy().ShowDialog();
        }
        #endregion

        #region Gráficos
        private float circle_size = 50;
        private float spacing = 100;
        private void processes_paint(object sender, PaintEventArgs e)
        {
            //Desenhar saudação
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            GraphicsPath path = new GraphicsPath();
            DrawUtil.DrawText(process_index == processes.Length ? "Parabéns! Todas as tarefas foram realizadas" : string.Format(warn_user ? "{0}, veja abaixo a tarefa pendente:" : "Olá {0}! Veja abaixo quais\nas tarefas a fazer:", UserManager.CurrentUser), font, processesPnl.ClientRectangle, new PointF(.5f, 10), new PointF(.5f, .5f), e.Graphics, path);
            e.Graphics.FillPath(Brushes.White, path);

            //Desenhar círculos
            int count = processes.Length;
            float x = (processesPnl.Width - ((circle_size * processes.Length) + (spacing * (count - 1)))) / 2;

            for (int i = 0; i < count; i++)
            {
                RectangleF process_rect = new RectangleF(x + circle_size * i, 150, circle_size, circle_size);
                if (i < process_index)
                    e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(112, 168, 59)), process_rect);

                //Utiliza o aviso
                if (i == process_index)
                    e.Graphics.FillEllipse(new SolidBrush(warn_user ? Color.Yellow : Color.Gray), process_rect);

                e.Graphics.DrawEllipse(pen, process_rect);

                if (i < count - 1)
                    e.Graphics.DrawLine(pen, new PointF(x + circle_size * (i + 1), 150 + (circle_size / 2)), new PointF(x + circle_size * (i + 1) + spacing, 150 + (circle_size / 2)));

                //Nome do processo
                Font new_font = new Font(font.FontFamily, 10, FontStyle.Regular);
                SizeF sz = e.Graphics.MeasureString(processes[i].Title, new_font);

                RectangleF text_rect = new RectangleF((x + circle_size * i) - (((sz.Width * .95f) - circle_size) / 2), 210, sz.Width, sz.Height);

                //Aviso
                if (warn_user)
                    if (i == process_index)
                        //Destaque
                        e.Graphics.FillRectangle(Brushes.Red, text_rect);

                e.Graphics.DrawString(processes[i].Title, new_font, Brushes.White, text_rect.Location);

                x += spacing;
            }
        }
        #endregion

        #region Abas de navegação
        private void navigation_click(object sender, EventArgs e)
        {
            processesPnl.Visible = processesBtn.Checked;
            toolsPnl.Visible = toolsBtn.Checked;
            admPnl.Visible = admBtn.Checked;
        }
        #endregion

    }
}
