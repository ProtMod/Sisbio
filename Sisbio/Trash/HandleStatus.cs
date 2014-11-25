using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    public static class HandeStatus
    {
        private static int progress = 0;

        public delegate void AddStatusDelegate();

        public static class UpdateStatusBar
        {

            public static BLASTaumotizer mainwin;

            public static event AddStatusDelegate UpdatepBar;

            public static void CallUpdatepBar()
            {
                ThreadSafeStatus();
            }

            private static void ThreadSafeStatus()
            {
                if (mainwin != null && mainwin.InvokeRequired)  // we are in a different thread to the main window
                    mainwin.Invoke(new AddStatusDelegate(ThreadSafeStatus), new object[] { });
                else
                    UpdatepBar();
            }

        }


        public delegate void SetProgresspBarDelegate(int value);

        public static class UpdateStatusBarProgress
        {
            public static BLASTaumotizer mainwin;

            public static event SetProgresspBarDelegate SetpBarMaximum;

            public static void CallSetpBarMaximum()
            {
                progress+=10;
                int value = progress;
                ThreadSafeSet(value);
            }

            private static void ThreadSafeSet(int value)
            {
                if (mainwin != null && mainwin.InvokeRequired)  // we are in a different thread to the main window
                    mainwin.Invoke(new SetProgresspBarDelegate(ThreadSafeSet), new object[] { value });
                else
                    SetpBarMaximum(value);
            }
        }
    }
}

/*public delegate void AddStatusMessageDelegate (string strMessage);

    public static class UpdateStatusBarMessage
        {

        public static Form mainwin;

        public static event AddStatusMessageDelegate OnNewStatusMessage;

        public static void ShowStatusMessage (string strMessage)
            {
            ThreadSafeStatusMessage (strMessage);
            }

        private static void ThreadSafeStatusMessage (string strMessage)
            {
            if (mainwin != null && mainwin.InvokeRequired)  // we are in a different thread to the main window
                mainwin.Invoke (new AddStatusMessageDelegate (ThreadSafeStatusMessage), new object [] { strMessage });  // call self from main thread
            else
                OnNewStatusMessage (strMessage);
            }

        }*/
