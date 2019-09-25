using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
namespace MyControls {
    public class MyPanel : Panel {
        private bool isPainted;
        public MyPanel(DockStyle dock, Padding padding, Color backColor) {
            this.Dock = dock;
            this.BackColor = backColor;
            this.Padding = padding;
        }

        public void SetBorder(Pen pen) {
            if (!isPainted)
                this.Paint += Helper.DrawBorder(pen);
            isPainted = true;
        }

        public void SetGradientBackground(Color c1, Color c2, float angle) {
            if (!isPainted)
                this.Paint += Helper.DrawGradient(c1, c2, angle);
            isPainted = true;
        }

        public void SetBorderAndGradientBackground(Pen pen, Color c1, Color c2, float angle) {
            if (!isPainted)
                this.Paint += Helper.DrawBorderAndGradient(pen, c1, c2, angle);
            isPainted = true;
        }
    }
}
