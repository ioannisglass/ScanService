using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanApp
{
    class ScrollEventListView : ListView
    {
        public event ScrollEventHandler Scroll;
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int MOUSEWHEEL = 0x020A;
        private const int KEYDOWN = 0x0100;

        protected virtual void OnScroll(ScrollEventArgs e)
        {
            ScrollEventHandler handler = Scroll;
            if (Scroll != null)
                handler(this, e);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //if (m.Msg == MOUSEWHEEL || m.Msg == WM_VSCROLL || (m.Msg == KEYDOWN && (m.WParam == (IntPtr)40 || m.WParam == (IntPtr)35)))
            if (m.Msg == MOUSEWHEEL || m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL)
            {
                // Trap WM_VSCROLL 
                OnScroll(new ScrollEventArgs((ScrollEventType)(m.WParam.ToInt64() & 0xffff), 0));
            }
        }
    }
}
