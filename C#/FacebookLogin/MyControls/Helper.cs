using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace MyControls {
    public static class Helper {
        public static PaintEventHandler DrawBorder(Pen pen) {
            return new PaintEventHandler((sender, e) => {
                Control control = sender as Control;
                using (Graphics graphics = e.Graphics) {
                    graphics.DrawRectangle(pen, pen.Width / 2, pen.Width / 2, control.ClientSize.Width - pen.Width, control.ClientSize.Height - pen.Width);
                }
            });
        }
        public static PaintEventHandler DrawGradient(Color c1, Color c2, float angle) {
            return new PaintEventHandler((sender, e) => {
                Control control = sender as Control;
                LinearGradientBrush brush = new LinearGradientBrush(control.ClientRectangle, c1, c2, angle);
                using (Graphics graphics = e.Graphics) {
                    graphics.FillRectangle(brush, brush.Rectangle);
                }
            });
        }
        
        public static PaintEventHandler DrawBorderAndGradient(Pen pen, Color c1, Color c2, float angle) {
            
            return new PaintEventHandler((sender, e) => {
                Control control = sender as Control;
                LinearGradientBrush brush = new LinearGradientBrush(control.ClientRectangle, c1, c2, angle);
                using (Graphics graphics = e.Graphics) {
                    graphics.FillRectangle(brush, brush.Rectangle);
                    graphics.DrawRectangle(pen, pen.Width / 2, pen.Width / 2, control.ClientSize.Width - pen.Width, control.ClientSize.Height - pen.Width);
                }
            });
        }
    }
}
