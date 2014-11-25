using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC
{
    public static class Progress
    {
        public delegate void ProgressUpdate();

        public static event ProgressUpdate OnProgressUpdate;

        public static void changeValue()
        {
            if (OnProgressUpdate != null)
            {
                OnProgressUpdate();
            }
        }
    }
}
