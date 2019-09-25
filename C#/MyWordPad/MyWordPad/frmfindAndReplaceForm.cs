using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MyWordPad {
    

    public partial class frmfindAndReplaceForm : Form {
        public enum DialogShowModes {
            ReplaceMode,
            FindMode
        };

        TableLayoutPanel inputArea;
        TableLayoutPanel buttonArea;
        TextBox txtFind;
        TextBox txtReplace;
        Button btnFindNext;
        Button btnReplace;
        Button btnReplaceAll;
        Button btnClose;
        RichTextBox rtxtBox;
        bool isReplacable;
        public frmfindAndReplaceForm(RichTextBox richTextBox) {
            InitializeComponent();
            this.rtxtBox = richTextBox;
        }


        private void frmfindAndReplaceForm_Load(object sender, EventArgs e) {
            this.FormClosing += FrmfindAndReplaceForm_FormClosing;
            this.Width = 500;
            this.Height = 160;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.TopMost = true;
            FlowLayoutPanel mainPanel = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.TopDown,
                Dock = DockStyle.Fill
            };

            txtFind = new TextBox() { Width = 360 };
            txtReplace = new TextBox() { Width = 360 };
            inputArea = new TableLayoutPanel() {
                Padding = new Padding(2),
                AutoSize = true,
                RowCount = 2,
                ColumnCount = 2
            };

            buttonArea = new TableLayoutPanel() {
                Padding = new Padding(5),
                Width = 480,
                Height = 50,
                RowCount = 1,
                ColumnCount = 4,
            };

            buttonArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            buttonArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            buttonArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            buttonArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));

            inputArea.Controls.Add(new Label() { Text = "Find What: " }, 0, 0);
            inputArea.Controls.Add(new Label() { Text = "Replace With: " }, 0, 1);
            inputArea.Controls.Add(txtFind, 1, 0);
            inputArea.Controls.Add(txtReplace, 1, 1);

            btnReplace = new Button() {
                Text = "&Replace",
                Anchor = AnchorStyles.None,
                Dock = DockStyle.Fill
            };
            btnFindNext = new Button() {
                Text = "Find Next",
                Anchor = AnchorStyles.None,
                Dock = DockStyle.Fill
            };

            btnReplaceAll = new Button() {
                Text = "Replace All",
                Anchor = AnchorStyles.None,
                Dock = DockStyle.Fill
            };

            btnClose = new Button() {
                Text = "Close",
                Anchor = AnchorStyles.None,
                Dock = DockStyle.Fill
            };

            btnClose.Click += BtnClose_Click;
            btnFindNext.Click += BtnFindNext_Click;
            btnReplace.Click += BtnReplace_Click;
            btnReplaceAll.Click += BtnReplaceAll_Click;

            buttonArea.Controls.Add(btnFindNext, 0, 0);
            buttonArea.Controls.Add(btnReplace, 1, 0);
            buttonArea.Controls.Add(btnReplaceAll, 2, 0);
            buttonArea.Controls.Add(btnClose, 3, 0);
            mainPanel.Controls.Add(inputArea);
            mainPanel.Controls.Add(buttonArea);
            this.Controls.Add(mainPanel);
        }

        private void BtnReplaceAll_Click(object sender, EventArgs e) {
            Regex regex = new Regex(txtFind.Text);
            MatchCollection matches = regex.Matches(rtxtBox.Text, 0);
            foreach(Match match in matches) {
                rtxtBox.SelectionStart = match.Index;
                rtxtBox.SelectionLength = match.Length;
                rtxtBox.SelectedText = txtReplace.Text;
            }
            MessageBox.Show("Replace Finished. " + matches.Count + " Occcurances Replaced.", "Find & Replace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnReplace_Click(object sender, EventArgs e) {
            if (isReplacable && rtxtBox.SelectedText.Equals(txtFind.Text)) {
                rtxtBox.SelectedText = txtReplace.Text;
                isReplacable = false;
            } else {
                MessageBox.Show("Replace Finished.", "Find & Replace", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnFindNext_Click(object sender, EventArgs e) {
            Regex regex = new Regex(txtFind.Text);
            int selectionIndex;
            if(isReplacable) {
                selectionIndex = rtxtBox.SelectionStart + rtxtBox.SelectionLength;
            } else {
                selectionIndex = rtxtBox.SelectionStart;
            }
            Match match = regex.Match(rtxtBox.Text, selectionIndex);
            if(match.Success) {
                rtxtBox.Focus();
                rtxtBox.SelectionStart = match.Index;
                rtxtBox.SelectionLength = match.Length;
                isReplacable = true;
            } else {
                MessageBox.Show("Search Finished.", "Find & Replace", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            this.Visible = false;
        }

        private void FrmfindAndReplaceForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Visible = false;
        }

        public void Display(DialogShowModes mode) {
            this.Visible = true;
            this.Focus();
            switch(mode) {
                case DialogShowModes.FindMode:
                    this.Text = "Find";
                    txtReplace.Enabled = false;
                    btnReplace.Enabled = false;
                    btnReplaceAll.Enabled = false;
                    break;
                case DialogShowModes.ReplaceMode:
                    this.Text = "Replace";
                    txtReplace.Enabled = true;
                    btnReplace.Enabled = true;
                    btnReplaceAll.Enabled = true;
                    break;
            }
        }
    }
}
