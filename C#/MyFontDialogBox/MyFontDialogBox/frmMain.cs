using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyFontDialogBox {
    
    public partial class frmMain : Form {
        #region Member Declaration
        ComboBox cmbFontNames = new ComboBox() {
            DropDownStyle = ComboBoxStyle.Simple,
            Dock = DockStyle.Fill
        };
        ComboBox cmbFontStyles = new ComboBox() {
            DropDownStyle = ComboBoxStyle.Simple,
            Dock = DockStyle.Fill
        };
        ComboBox cmbFontSizes = new ComboBox() {
            DropDownStyle = ComboBoxStyle.Simple,
            Dock = DockStyle.Fill
        };
        ComboBox cmbFontColor = new ComboBox() {
            Dock = DockStyle.Fill
        };
        ComboBox cmbUnderlineStyle = new ComboBox() {
            Dock = DockStyle.Fill
        };
        ComboBox cmbUnderlineColor = new ComboBox() {
            Dock = DockStyle.Fill
        };
        CheckBox chkStrikeThrough = new CheckBox {
            Text = "Strikethrough",
            AutoSize = true
        };
        CheckBox chkDoubleStrikeThrough = new CheckBox() {
            Text = "Double Strikethrough",
            AutoSize = true
        };
        CheckBox chkSuperScript = new CheckBox() {
            Text = "SuperScript",
            AutoSize = true
        };
        CheckBox chkSubScript = new CheckBox() {
            Text = "SubScript",
            AutoSize = true
        };
        CheckBox chkSmallCaps = new CheckBox() {
            Text = "Small Caps",
            AutoSize = true
        };
        CheckBox chkAllCaps = new CheckBox() {
            Text = "All Caps",
            AutoSize = true
        };
        CheckBox chkHidden = new CheckBox() {
            Text = "Hidden",
            AutoSize = true
        };
        RichTextBox rtxtBox = new RichTextBox() {
            ReadOnly = true,
            BorderStyle = BorderStyle.None,
            BackColor = Color.White,
            Multiline = false,
            SelectionAlignment = HorizontalAlignment.Center
        };
        GroupBox previewBox = new GroupBox {
            Dock = DockStyle.Fill,
            Text = "Preview"
        };
        int offset;
        bool strikeThrough;
        bool smallCaps;
        bool changeInCode = false;
        #endregion

        
        public frmMain() {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            CenterTextBox();
        }

        private void CenterTextBox() {
            Size size = TextRenderer.MeasureText(rtxtBox.Text, rtxtBox.Font);
            rtxtBox.Height = size.Height + 10;
            rtxtBox.Width = size.Width;
            rtxtBox.Left = (previewBox.Width - rtxtBox.Width) / 2;
            rtxtBox.Top = (previewBox.Height - rtxtBox.Height) / 2 + offset;

        }

        private void frmMain_Load(object sender, EventArgs e) {
            this.Width = 460;
            this.Height = 500;
            this.Text = "Font";
            this.BackColor = Color.White;

            Panel mainPanel = new Panel() {
                Dock = DockStyle.Fill
            };

            TableLayoutPanel subPanelContainer = new TableLayoutPanel() {
                RowCount = 5,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(5)
            };

            TableLayoutPanel fontSelectPanel = new TableLayoutPanel() {
                RowCount = 4,
                ColumnCount = 3,
                Dock = DockStyle.Fill
            };


            subPanelContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            subPanelContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
            subPanelContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 17));
            subPanelContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 3));
            subPanelContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 10));

            
            fontSelectPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            fontSelectPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            fontSelectPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));

            fontSelectPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            fontSelectPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
            fontSelectPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15));
            fontSelectPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));

            fontSelectPanel.Controls.Add(new Label() { Text = "Font:" }, 0, 0);
            fontSelectPanel.Controls.Add(new Label() { Text = "Font Style:" }, 1, 0);
            fontSelectPanel.Controls.Add(new Label() { Text = "Size:" }, 2, 0);

            fontSelectPanel.Controls.Add(new Label() { Text = "Font Color:" }, 0, 2);
            fontSelectPanel.Controls.Add(new Label() { Text = "Underline Style:" }, 1, 2);
            fontSelectPanel.Controls.Add(new Label() { Text = "Underline Color:" }, 2, 2);
            
            InstalledFontCollection collection = new InstalledFontCollection();
            foreach (FontFamily family in collection.Families) {
                cmbFontNames.Items.Add(family.Name);
            }

            foreach (string style in Enum.GetNames(typeof(FontStyle))) {
                if(!style.Equals("Strikeout"))
                    cmbFontStyles.Items.Add(style);
            }

            for (int i = 8; i < 72; i++) {
                cmbFontSizes.Items.Add(i);
            }

            fontSelectPanel.Controls.Add(cmbFontNames, 0, 1);
            fontSelectPanel.Controls.Add(cmbFontStyles, 1, 1);
            fontSelectPanel.Controls.Add(cmbFontSizes, 2, 1);

            fontSelectPanel.Controls.Add(cmbFontColor, 0, 3);
            fontSelectPanel.Controls.Add(cmbUnderlineStyle, 1, 3);
            fontSelectPanel.Controls.Add(cmbUnderlineColor, 2, 3);

            subPanelContainer.Controls.Add(fontSelectPanel, 0, 0);

            GroupBox effectBox = new GroupBox() {
                Text = "Effects",
                Dock =  DockStyle.Fill
            };

            TableLayoutPanel checkBoxContainer = new TableLayoutPanel() {
                RowCount = 4,
                ColumnCount = 2,
                Dock = DockStyle.Fill
            };

            effectBox.Controls.Add(checkBoxContainer);
            checkBoxContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            checkBoxContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            checkBoxContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            checkBoxContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            checkBoxContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            checkBoxContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            checkBoxContainer.Controls.Add(chkStrikeThrough, 0, 0);
            checkBoxContainer.Controls.Add(chkDoubleStrikeThrough, 0, 0);
            checkBoxContainer.Controls.Add(chkSuperScript, 0, 0);
            checkBoxContainer.Controls.Add(chkSubScript, 0, 0);
            checkBoxContainer.Controls.Add(chkAllCaps, 0, 1);
            checkBoxContainer.Controls.Add(chkSmallCaps, 0, 1);
            checkBoxContainer.Controls.Add(chkHidden, 0, 1);
            subPanelContainer.Controls.Add(effectBox, 0, 1);

            previewBox.Controls.Add(rtxtBox);
            subPanelContainer.Controls.Add(previewBox, 0, 2);
            subPanelContainer.Controls.Add(new Label() { Text = "This is the body theme font. The current document theme defines which font will be used.", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 0, 3);


            TableLayoutPanel buttonPanel = new TableLayoutPanel() {
                RowCount = 1,
                ColumnCount = 2,
                Dock = DockStyle.Fill
            };

            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));


            FlowLayoutPanel leftButtonsContainer = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.LeftToRight,
                Anchor = AnchorStyles.Left
            };

            FlowLayoutPanel rightButtonsContainer = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.RightToLeft,
                Anchor = AnchorStyles.Right
            };

            Button btnSetAsDefault = new Button() { Text = "Set As Default", AutoSize = true };
            Button btnTextEffects = new Button() { Text = "Text Effects...", AutoSize = true };
            Button btnOk = new Button() { Text = "OK", AutoSize = true };
            Button btnCancel = new Button() { Text = "Cancel", AutoSize = true };
            btnOk.Click += (s, args) => this.Close();
            btnCancel.Click += (s, args) => this.Close();

            leftButtonsContainer.Controls.Add(btnSetAsDefault);
            leftButtonsContainer.Controls.Add(btnTextEffects);

            rightButtonsContainer.Controls.Add(btnCancel);
            rightButtonsContainer.Controls.Add(btnOk);

            buttonPanel.Controls.Add(leftButtonsContainer, 0, 0);
            buttonPanel.Controls.Add(rightButtonsContainer, 1, 0);

            subPanelContainer.Controls.Add(buttonPanel);
            
            mainPanel.Controls.Add(subPanelContainer);
            this.Controls.Add(mainPanel);

            cmbFontNames.SelectedIndex = 0;
            cmbFontSizes.SelectedIndex = 0;
            cmbFontStyles.SelectedIndex = 0;


            cmbFontNames.SelectedValueChanged += CmbFontNames_SelectedValueChanged;
            cmbFontSizes.SelectedValueChanged += CmbFontSizes_SelectedValueChanged;
            cmbFontStyles.SelectedValueChanged += CmbFontStyles_SelectedValueChanged;
            cmbFontColor.Click += CmbFontColor_Click;
            chkStrikeThrough.Click += ChkStrikeThrough_Click;
            chkSubScript.Click += ChkSubScript_Click;
            chkSuperScript.Click += ChkSuperScript_Click;
            chkAllCaps.Click += ChkAllCaps_Click;
            chkSmallCaps.Click += ChkSmallCaps_Click;
            UpdateFont();
        }

        private void ChkSmallCaps_Click(object sender, EventArgs e) {
            smallCaps = chkSmallCaps.Checked;
            UpdateFont();
        }

        private void ChkAllCaps_Click(object sender, EventArgs e) {
            if (chkAllCaps.Checked) {
                rtxtBox.Text = rtxtBox.Text.ToUpper();
            } else {
                rtxtBox.Text = cmbFontNames.Text;
            }
            CenterTextBox();
        }
        private void ChkSuperScript_Click(object sender, EventArgs e) {
            if (chkSuperScript.Checked)
                offset -= 10;
            else
                offset += 10;
            CenterTextBox();
        }
        private void ChkSubScript_Click(object sender, EventArgs e) {
            if (chkSubScript.Checked)
                offset += 10;
            else
                offset -= 10;
            CenterTextBox();
        }
        private void ChkStrikeThrough_Click(object sender, EventArgs e) {
            strikeThrough = chkStrikeThrough.Checked;
            UpdateFont();
        }
        private void CmbFontColor_Click(object sender, EventArgs e) {
            ColorDialog dlg = new ColorDialog();
            DialogResult result = dlg.ShowDialog();
            if(result == DialogResult.OK) {
                cmbFontColor.BackColor = dlg.Color;
                rtxtBox.ForeColor = dlg.Color;
            }
        }

        private void CmbFontStyles_SelectedValueChanged(object sender, EventArgs e) {
            if (!changeInCode) {
                UpdateFont();
            }
        }
        private void CmbFontSizes_SelectedValueChanged(object sender, EventArgs e) {
            if (!changeInCode) {
                UpdateFont();
            }
        }
        private void CmbFontNames_SelectedValueChanged(object sender, EventArgs e) {
            if (!changeInCode) {
                UpdateFont();
            }
        }
        private void UpdateFont() {
            FontStyle isStrike = 0;
            if (strikeThrough) isStrike = FontStyle.Strikeout;
            rtxtBox.Text = cmbFontNames.Text;
            Font targetFont = rtxtBox.Font;
            int index = 0;
            FontFamily family = new FontFamily(cmbFontNames.Text);
            FontStyle style = (FontStyle)Enum.Parse(typeof(FontStyle), cmbFontStyles.Text);
            int fontSize = Convert.ToInt32(cmbFontSizes.Text);

            if (family.IsStyleAvailable(style)) {
                targetFont = new Font(family, fontSize, style | isStrike);
            } else {
                changeInCode = true;
                foreach (string fontStyleName in Enum.GetNames(typeof(FontStyle))) {
                    FontStyle fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), fontStyleName);
                    if (family.IsStyleAvailable(fontStyle)) {
                        targetFont = new Font(family, fontSize, fontStyle | isStrike);
                        break;
                    }
                    index++;
                }
                cmbFontStyles.SelectedIndex = index;
                changeInCode = false;
            }
            rtxtBox.Font = targetFont;
            if(smallCaps) {
                Font forCapitals = rtxtBox.Font;
                Font forSmalls = new Font(rtxtBox.Font.FontFamily.Name, (int)(rtxtBox.Font.Size * 0.6), rtxtBox.Font.Style);
                string text = rtxtBox.Text;
                rtxtBox.Text = text.ToUpper();
                for (int i = 0; i < rtxtBox.Text.Length; i++) {
                    rtxtBox.SelectionStart = i;
                    rtxtBox.SelectionLength = 1;
                    char character = text[i];
                    if (character >= 'A' && character <= 'Z') rtxtBox.SelectionFont = forCapitals;
                    else rtxtBox.SelectionFont = forSmalls;
                }
            }
            CenterTextBox();
        }
    }
}
