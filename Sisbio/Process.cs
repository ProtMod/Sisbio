using Service;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WatiN.Core;


namespace TCC
{
    public class Process
    {
        #region Variáveis

        // Listas para armazenar os cabeçalhos, corpos das sequências e URLs de download
        private List<string> sequences = new List<string>();
        private List<string> URLs = new List<string>();

        private List<string> names = new List<string>();
        public List<string> Names
        {
            get { return names; }
            set { names = value; }
        }

        private List<string> _jobNames = new List<string>();
        public List<string> JobNames
        {
            get { return _jobNames; }
        }

        object obj = new object();

        string comboString = string.Empty;

        #endregion

        #region Métodos

        public List<string> processFile(string content, int combo, System.Windows.Forms.ProgressBar pBar, System.Windows.Forms.Label PercentLabel)
        {
            try
            {
                // Checagem simples se o arquivo é um arquivo fasta
                if (content.IndexOf('>').Equals(-1))
                {
                    throw new Exception("File not valid!");
                }

                switch (combo)
                {
                    case 0:
                        comboString = "nr";
                        break;

                    case 1:
                        comboString = "refseq_protein";
                        break;

                    case 2:
                        comboString = "swissprot";
                        break;

                    case 3:
                        comboString = "pat";
                        break;

                    case 4:
                        comboString = "pdb";
                        break;

                    case 5:
                        comboString = "env_nr";
                        break;

                    case 6:
                        comboString = "tsa_nr";
                        break;

                    default:
                        throw new Exception("Valor não válido para combobox!");
                }

                // Limpa as sequências já que as variáveis são globais (classe)
                sequences.Clear();
                names.Clear();

                // Número de sequências dadas como entrada
                int seqNumb = 0;

                // Ao fazer este split, a primeira posição do vetor é vazia;
                string[] temp = content.Split('>');

                // Esta variável serve para anular a posição vazia
                bool first = true;

                // Varrer o vetor para armazenar seus valores em uma lista, pulando a primeira posição, que é vazia
                foreach (var str in temp)
                {
                    if (!first)
                    {
                        // Variável para separar em quebras de linhas por expressões regulares
                        string[] splited = Regex.Split(str, "\n");

                        // String vazia para armazenar o corpo da sequência, caso o usuário tenha inserido várias quebras de linha dentro do corpo da sequência
                        string emptyStr = string.Empty;

                        // Armazena o corpo da sequência
                        for (int i = 1; i < splited.Length; i++)
                        {
                            emptyStr += splited[i];
                        }

                        // Separa cabeçalho e sequência
                        names.Add(splited[0].Replace("\r",""));
                        sequences.Add(emptyStr);
                    }
                    first = false;
                }

                // Conta quantas sequências possui no arquivo
                seqNumb = names.Count;

                // Função que cria Threads conforme o número de sequências contidas no arquivo
                return Access(seqNumb, pBar, PercentLabel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private Thread criarThread(int i)
        {
            Thread.Sleep(i * 100);
            Thread t = new Thread(new ThreadStart(() =>
            {
                DataPushService dps = new DataPushService(sequences[i], names[i], comboString);
                lock (obj)
                {
                    URLs.Add(dps.URL);
                    _jobNames.Add(dps.jobName);
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            return t;
        }

        private List<string> Access(int Threads, System.Windows.Forms.ProgressBar pBar, System.Windows.Forms.Label PercentLabel)
        {
            List<Thread> _Threads = new List<Thread>();
            Thread[] vThread = new Thread[11];

            int MaxStep = Threads * 2; 
            int contaThread = 0;
            
            pBar.Minimum = 0;
            pBar.Value = pBar.Minimum;

            if (pBar.InvokeRequired)
            {
                pBar.Invoke(new MethodInvoker(delegate { pBar.Maximum = MaxStep; }));
                pBar.Invoke(new MethodInvoker(delegate { pBar.Minimum = 0; }));
                pBar.Invoke(new MethodInvoker(delegate { pBar.Value = pBar.Minimum; }));
            }
            else
            {
                pBar.Maximum = Threads * 2;
                pBar.Minimum = 0;
                pBar.Value = pBar.Minimum;
            }

            for (int i = 0; i < Threads; i++)
            {
                Thread t = criarThread(i);
                _Threads.Add(t);
                t.Start();
                vThread[i % 11] = t;

                if (i % 10 == 0 && i != 0)
                {
                    foreach (Thread T in vThread)
                    {
                        if (T.IsAlive)
                        {
                            T.Join();
                        }                       
                    }

                    Thread.Sleep(1000);
                }
            }

            //espera todas as threads terminarem
            foreach (Thread t in _Threads)
            {
                contaThread++;

                if (t.IsAlive)
                {
                    t.Join();
                }

                if (pBar.InvokeRequired)
                {
                    pBar.Invoke(new MethodInvoker(delegate { pBar.Value++; }));
                }
                else
                {
                    pBar.Value++;
                }

                if (PercentLabel.InvokeRequired)
                {
                    PercentLabel.Invoke(new MethodInvoker(delegate { PercentLabel.Text = (int)((pBar.Value*100)/pBar.Maximum) + " / 100"; }));
                }
                else
                {
                    PercentLabel.Text = (int)((pBar.Value * 100) / pBar.Maximum) + " / 100";
                }
            }

            return URLs;
        }

        private void start(Thread T)
        {
            T.Start();
        }

        #endregion
     }
}
