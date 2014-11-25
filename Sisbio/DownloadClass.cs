using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace TCC
{
    public class DownloadClass
    {
        #region Variáveis

        // Caminho onde os arquivos devem ser salvos com seu encapsulamento
        private string _path = @"C:\Users\Artur\Desktop\TCC_Downloads\";
        public string path
        {
            get { return _path; }
            set { _path = value; }
        }

        // Pilha de itens e nomes para download, onde itens = URL e nomes = nome de arquivo
        private Queue<string> _items = new Queue<string>();
        private Queue<string> _names = new Queue<string>();

        // Lista de restultados com o corpo dos arquivos para ser tratado e salvo.
        private List<string> _results = new List<string>();

        // Variáveis contadoras de sucesso e erro
        private int _sucesso = 0;
        private int _erro = 0;

        // Barra de progresso instanciada para receber as informações da barra de progresso da janela inicial.
        private ProgressBar _pBar;

        // Label instanciado para receber as informações do label da janela inicial
        private Label _pLabel;

        // ToolStripStatusLabel para receber as informações do ToolStripStatusLabel da janela inicial.
        private StatusStrip _statusLabel;

        #endregion

        #region Métodos

        public void PopulateItemsQueue(string url, string name)
        {
            _items.Enqueue(@"http://" + url);
            _names.Enqueue(name);
        }

        public void Download(ProgressBar pBar, Label pLabel, StatusStrip StatusLabel)
        {
            _pBar = pBar;
            _pLabel = pLabel;
            _statusLabel = StatusLabel;
            DownloadItem();
        }

        private void DownloadItem()
        {
            if (_items.Any())
            {
                var nextItem = _items.Dequeue();

                var webClient = new WebClient();
                webClient.DownloadStringCompleted += OnGetDownloadedStringCompleted;
                webClient.DownloadStringAsync(new Uri(nextItem));
                return;
            }

            ProcessResults();
        }

        private void ProcessResults()
        {
            int index = 0;
            foreach (var file in _results)
            {
                File.WriteAllText(_path + _names.Dequeue() + ".txt", _results[index]);
                index++;

                if (_pBar.InvokeRequired)
                {
                    _pBar.Invoke(new MethodInvoker(delegate { _pBar.Value++; }));
                }
                else
                {
                    _pBar.Value++;
                }

                if (_pLabel.InvokeRequired)
                {
                    _pLabel.Invoke(new MethodInvoker(delegate { _pLabel.Text = (int)((_pBar.Value * 100) / _pBar.Maximum) + " / 100"; }));
                }
                else
                {
                    _pLabel.Text = (int)((_pBar.Value * 100) / _pBar.Maximum) + " / 100";
                }

                if (_statusLabel.InvokeRequired)
                {
                    _statusLabel.Invoke(new MethodInvoker(delegate { _statusLabel.Items[0].Text = "Finished."; }));
                }
                else
                {
                    _statusLabel.Items[0].Text = "Finished";
                }

            }
            MessageBox.Show(_sucesso + " files downloaded and " + _erro + " files not downloaded. Out of " + (_sucesso + _erro) + " files.");
        }

        private void OnGetDownloadedStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null && !string.IsNullOrEmpty(e.Result))
            {
                // do something with e.Result string.
                _results.Add(e.Result);
                _sucesso++;
            }

            if (e.Error != null)
            {
                _erro++;
            }

            DownloadItem();
        }

        #endregion
    }
}
