using System;
using System.Windows.Forms;

namespace TCC
{
    /* Informação da Classe
     * Classe para generalizar a chamada de threads a objetos criados por outras threads.
     * Esta classe é estática para possibilitar a chamada de qualquer outra classe no programa sem haver
     * necessidade de instanciar, evitando a criação de objetos desnecessários.
     */ 
    static class ControlExtensions
    {

        static public void UIThread(this Control control, Action code)
        {
            // Se o controle requerer invocação invoque e execute a ação, se não execute a ação
            if (control.InvokeRequired)
            {
                control.BeginInvoke(code);
                return;
            }
            code.Invoke();
        }
    }
}
