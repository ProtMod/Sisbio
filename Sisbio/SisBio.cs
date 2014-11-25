using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    /* 
     * Informação da Classe
     * Classe principal, serve para gerenciar a Janela onde todas informações são processadas e dispostas
     */
    public partial class SisBio : Form
    {

        #region Variáveis

        // Instancia a classe Processo
        private Process p = new Process();

        #endregion

        #region Métodos

        #region Form

        public SisBio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Seleciona a DB PDB como default
            DB.SelectedIndex = 4;

            // Evita erros ao trabalhar com algumas requisições
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3;

            // Desabilita o botão BLAST para o usuário não tentar enviar requisição sem arquivo
            BLASTButton.Enabled = false;

            // Limpa o Label
            PercentLabel.Text = "";

            // Seta o status como aguardando
            StatusLabel.Text = "Waiting for user input.";
        }

        #endregion

        #region Botões

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Seta Parâmetros da janela de busca, como título e quais tipos de arquivos pode-se buscar
                PathSeeker.Filter = "Fasta File|*.fasta;*.txt|All Files|*.*";
                PathSeeker.Title = "Select a valid Fasta file";

                if (PathSeeker.ShowDialog() == DialogResult.OK)
                {
                    diretorioBox.Text = PathSeeker.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BLASTButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Checa se a caixa de texto está vazia, para poder salvar os arquivos de saída corretamente.
                if (SaveBox.Text.Equals(""))
                {
                    throw new Exception("No save path. Please type a valid path.");
                }

                // Desabilita o botão de busca no BLAST para o usuário não enviar mais de uma requisição por vez
                BLASTButton.Enabled = false;

                // Inicia o trabalho através de Factory
                Task.Factory.StartNew(() => work());

                // Zera a pBar
                pBar.Value = 0;

                // Zera o contador de porcentagem de download
                PercentLabel.Text = "0 / 100";
            }
            catch (Exception ex)
            {
                // Zera a pBar
                pBar.Value = 0;

                // Zera o contador de porcentarem de download
                PercentLabel.Text = "0 / 0";

                // Exibe a mensagem de erro para o usuário
                MessageBox.Show("Wrong or corrupted filetype input! \n ERROR: " + ex.ToString());
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            // Seleciona o diretório para salvar os arquivos
            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                this.SaveBox.Text = SaveDialog.SelectedPath;
            }
        }

        #endregion

        #region Outros controles

        private void diretorioBox_TextChanged(object sender, EventArgs e)
        {

            // Se o texto do diretóri for mudado, habilita o botão de busca no BLAST
            if (diretorioBox.Text.Equals(""))
            {
                BLASTButton.Enabled = false;
            }
            else
            {
                BLASTButton.Enabled = true;
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instancia e mostra a janela de informações
            About about = new About();
            about.Show();
        }

        #endregion

        # region Outros métodos

        /* ATENÇÃO!
         * Factories trabalham em threads diferentes da thread principal, e objetos instanciados em uma thread não podem
         * ser acessados de outra thread a menos que uma chamada para verificar se o objeto precisa ser invocado seja feita.
         * Para isso uma classe auxiliar foi criada com a intenção de generalizar esta chamada, tornando o código mais limpo.
         * 
         * Esta informação vale para o método work()
         */
        private void work()
        {
            try
            {

                // Instancia a Classe de Downloads
                DownloadClass DC = new DownloadClass();

                // Indica o caminho onde os arquivos de download serão salvos
                DC.path = SaveBox.Text.ToString() + @"\";

                // Seta o estado de processamento como andamendo
                this.UIThread(delegate { StatusLabel.Text = "Processing..."; });

                // Altera a informação do progresso no label
                this.UIThread(delegate { PercentLabel.Text = "0 / 100"; });

                // Lê o arquivo das sequências
                string file = string.Empty;
                System.IO.StreamReader sr = new System.IO.StreamReader(diretorioBox.Text);
                file = sr.ReadToEnd();
                sr.Close();

                // Checa o tipo de banco desejado para análise
                int combo = 0;
                if (DB.InvokeRequired)
                {
                    DB.Invoke(new MethodInvoker(delegate { combo = DB.SelectedIndex; }));
                }
                else
                {
                    combo = DB.SelectedIndex;
                }

                // Conta o número de sequências no arquivo
                int seqNum = 0;
                foreach (char c in file)
                {
                    if (c.Equals(">"))
                    {
                        seqNum++;
                    }
                }

                // Chama a função de processamento de dados recebendo uma lista de strings, porém o tipo da variável foi escolhido como o mais genérico possível
                var url = p.processFile(file, combo, pBar, PercentLabel);

                // Instancia a variável e captura o nome dos trabalhos para inserção como nome de arquivos
                List<string> jobName = new List<string>();

                int index = 0;
                foreach (var item in p.JobNames)
                {
                    jobName.Add(p.JobNames[index]);
                    index++;
                }

                for (int links = 0; links < url.Count; links++)
                {
                    // Insere as informações de interesse em pilhas na classe DownloadClass
                    DC.PopulateItemsQueue(url[links], jobName[links]);
                }

                try
                {
                    // Dispara o download da fila criada anteriormente
                    DC.Download(pBar, PercentLabel, Strip);

                    // Autoriza o usuário a requisitar outra consulta
                    this.UIThread(delegate { BLASTButton.Enabled = true; });
                }
                catch (Exception err)
                {
                    MessageBox.Show("Failed to download files. Error type: " + err.ToString());
                    this.UIThread(delegate { StatusLabel.Text = "Error!"; });
                    this.UIThread(delegate { PercentLabel.Text = "0 / 0"; });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
        
        #endregion
    }
}
