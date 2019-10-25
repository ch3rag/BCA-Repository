using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace MyControls {
    public class MyTableLayoutPanel : TableLayoutPanel {
        private bool isPainted;
        public MyTableLayoutPanel(int rows, int cols, DockStyle dock, Padding pad, Color backColor) {
            this.RowCount = rows;
            this.ColumnCount = cols;
            this.Dock = dock;
            this.BackColor = backColor;
            this.Padding = pad;
        }
        public MyTableLayoutPanel(int rows, int cols, DockStyle dock, Color color) : this(rows, cols, dock, Padding.Empty, color) { }
        public MyTableLayoutPanel(int rows, int cols, DockStyle dock) : this(rows, cols, dock, Padding.Empty, Color.Transparent) { }
        public MyTableLayoutPanel(int rows, int cols, DockStyle dock, Padding pad) : this(rows, cols, dock, pad, Color.Transparent) { }

        public void SetRowDimension(SizeType type, params int[] dim) {
            for (int i = 0; i < dim.Length; i++) {
                this.RowStyles.Add(new RowStyle(type, dim[i]));
            }
        }

        public void SetColumnDimension(SizeType type, params int[] dim) {
            for (int i = 0; i < dim.Length; i++) {
                this.ColumnStyles.Add(new ColumnStyle(type, dim[i]));
            }
        }

        public void SetBorder(Pen pen) {
            if(!isPainted)
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
