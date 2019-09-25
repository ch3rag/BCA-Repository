using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Text;

namespace MyWordPad {
    public partial class frmMain : Form {
        #region Control & Variable Declarations
        RichTextBox rtxtBox = new RichTextBox();
        PrintDocument printDocument = new PrintDocument();
        Bitmap printImage;
        FlowLayoutPanel toolBar = new FlowLayoutPanel();
        ComboBox cmbFonts = new ComboBox();
        ComboBox cmbFontSizes = new ComboBox();
        string currentFont;
        float currentFontSize;
        bool isSaved;
        string currentFileName;
        bool isExists;
        string currentFilePath;
        CheckBox boldCheckBox;
        CheckBox italicCheckBox;
        CheckBox underlineCheckBox;
        CheckBox strikeThroughCheckBox;
        CheckBox superScriptCheckBox;
        CheckBox subScriptCheckBox;
        Button backColorButton;
        Button foreColorButton;
        CheckBox leftAlignCheckBox;
        CheckBox centerAlignCheckBox;
        CheckBox rightAlignCheckBox;
        CheckBox bulletCheckBox;
        Button increaseIndentCheckBox;
        Button decreaseIndentCheckBox;
        Button findButton;
        Button replaceButton;
        frmfindAndReplaceForm frmReplace;
        #endregion
        public frmMain() {
            InitializeComponent();
        }
        #region Form Handlers
        private void frmMain_Load(object sender, EventArgs e) { 
            #region Variable Initialization
            currentFileName = "Untitled";
            this.FormClosing += FrmMain_FormClosing;
            frmReplace = new frmfindAndReplaceForm(rtxtBox);
            #endregion
            printDocument.PrintPage += PrintDocument_PrintPage;
            #region frmMain Settings
            UpdateTitle();
            #endregion
            #region Rich Text Box Settings
            rtxtBox.Dock = DockStyle.Fill;
            rtxtBox.TextChanged += RtxtBox_TextChanged;
            rtxtBox.SelectionChanged += RtxtBox_SelectionChanged;
            #endregion


            #region Menu Creation
            MainMenu mainMenu = new MainMenu();
            #region File Menu
            MenuItem fileMenu = new MenuItem("&File");
            MenuItem newMenu = new MenuItem("New", OnClickNewMenu, Shortcut.CtrlN);
            MenuItem openMenu = new MenuItem("Open", OnClickOpenMenu, Shortcut.CtrlO);
            MenuItem saveMenu = new MenuItem("Save", OnClickSaveMenu, Shortcut.CtrlS);
            MenuItem saveAsMenu = new MenuItem("Save As", OnClickSaveAsMenu, Shortcut.CtrlShiftS);
            MenuItem printMenu = new MenuItem("Print", OnClickPrintMenu, Shortcut.CtrlP);
            MenuItem printPreviewMenu = new MenuItem("Print Preview", OnClickPrintPreviewMenu, Shortcut.CtrlShiftP);
            MenuItem exitMenu = new MenuItem("Exit", OnClickExitMenu, Shortcut.CtrlF4);
            fileMenu.MenuItems.Add(newMenu);
            fileMenu.MenuItems.Add(openMenu);
            fileMenu.MenuItems.Add(saveMenu);
            fileMenu.MenuItems.Add(saveAsMenu);
            fileMenu.MenuItems.Add(new MenuItem("-"));
            fileMenu.MenuItems.Add(printMenu);
            fileMenu.MenuItems.Add(printPreviewMenu);
            fileMenu.MenuItems.Add(new MenuItem("-"));
            fileMenu.MenuItems.Add(exitMenu);
            #endregion
            #region Edit Menu
            MenuItem editMenu = new MenuItem("&Edit");
            MenuItem cutMenu = new MenuItem("Cut", OnClickCutMenu, Shortcut.CtrlX);
            MenuItem copyMenu = new MenuItem("Copy", OnClickCopyMenu, Shortcut.CtrlC);
            MenuItem pasteMenu = new MenuItem("Paste", OnClickPasteMenu, Shortcut.CtrlV);
            MenuItem undoMenu = new MenuItem("Undo", OnClickUndoMenu, Shortcut.CtrlZ);
            MenuItem redoMenu = new MenuItem("Redo", OnClickRedoMenu, Shortcut.CtrlShiftZ);
            MenuItem selectAllMenu = new MenuItem("Select All", OnClickSelectAllMenu, Shortcut.CtrlA);
            editMenu.MenuItems.Add(cutMenu);
            editMenu.MenuItems.Add(copyMenu);
            editMenu.MenuItems.Add(pasteMenu);
            editMenu.MenuItems.Add(new MenuItem("-"));
            editMenu.MenuItems.Add(undoMenu);
            editMenu.MenuItems.Add(redoMenu);
            editMenu.MenuItems.Add(new MenuItem("-"));
            editMenu.MenuItems.Add(selectAllMenu);
            #endregion

            #region Format Menu
            MenuItem formatMenu = new MenuItem("&Format");
            MenuItem fontMenu = new MenuItem("Font", OnClickFontMenu, Shortcut.CtrlF);
            MenuItem wordWrapMenu = new MenuItem("Word Wrap", OnClickWordWrapMenu);
            MenuItem autoDragDropMenu = new MenuItem("Auto Drag & Drop", OnClickAutoDragDropMenu);
            wordWrapMenu.Checked = true;

            formatMenu.MenuItems.Add(fontMenu);
            formatMenu.MenuItems.Add(wordWrapMenu);
            formatMenu.MenuItems.Add(autoDragDropMenu);
            #endregion

            mainMenu.MenuItems.Add(fileMenu);
            mainMenu.MenuItems.Add(editMenu);
            mainMenu.MenuItems.Add(formatMenu);
            this.Menu = mainMenu;
            #endregion

            #region Toolbar Creation

            toolBar.Height = 90;
            toolBar.Dock = DockStyle.Top;
            toolBar.BackColor = Color.AliceBlue;

            #region Font Panel
            FlowLayoutPanel fontPanel = new FlowLayoutPanel() {
                BackColor = Color.AliceBlue,
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true
            };

            InstalledFontCollection collection = new InstalledFontCollection();
            foreach (FontFamily family in collection.Families) {
                cmbFonts.Items.Add(family.Name);
            }

            cmbFonts.Width = 160;
            int[] fontSizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            cmbFontSizes.DataSource = fontSizes;
            cmbFontSizes.Width = 50;
            currentFont = rtxtBox.Font.Name;
            currentFontSize = rtxtBox.Font.Size;
            cmbFonts.SelectedValueChanged += CmbFonts_SelectedValueChanged;
            cmbFontSizes.SelectedValueChanged += CmbFontSizes_SelectedValueChanged;
            FlowLayoutPanel fontTypePanel = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Top,
                AutoSize = true,
            };

            FlowLayoutPanel fontButtonPanel = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
            };


            boldCheckBox = CreateCheckBox("B", new Font("Arial", 10, FontStyle.Bold), 0, 0, true, Appearance.Button, BoldCheckBox_Click);
            italicCheckBox = CreateCheckBox("I", new Font("Arial", 10, FontStyle.Italic), 0, 0, true, Appearance.Button, ItalicCheckBox_Click);
            underlineCheckBox = CreateCheckBox("U", new Font("Arial", 10, FontStyle.Underline), 0, 0, true, Appearance.Button, UnderlineCheckBox_Click);
            strikeThroughCheckBox = CreateCheckBox("abc", new Font("Arial", 10, FontStyle.Strikeout), 0, 0, true, Appearance.Button, StrikeThroughCheckBox_Click);
            superScriptCheckBox = CreateCheckBox("X²", new Font("Arial", 10, FontStyle.Regular), 0, 0, true, Appearance.Button, SuperScriptCheckBox_Click);
            subScriptCheckBox = CreateCheckBox("Yₓ", new Font("Arial", 10, FontStyle.Regular), 0, 0, true, Appearance.Button, SubScriptCheckBox_Click);

            fontButtonPanel.Controls.Add(boldCheckBox);
            fontButtonPanel.Controls.Add(italicCheckBox);
            fontButtonPanel.Controls.Add(underlineCheckBox);
            fontButtonPanel.Controls.Add(strikeThroughCheckBox);
            fontButtonPanel.Controls.Add(superScriptCheckBox);
            fontButtonPanel.Controls.Add(subScriptCheckBox);

            fontTypePanel.Controls.Add(cmbFonts);
            fontTypePanel.Controls.Add(cmbFontSizes);
            fontPanel.Controls.Add(fontTypePanel);
            fontPanel.Controls.Add(fontButtonPanel);
            #endregion
            #region Align And Color Panel
            FlowLayoutPanel alignAndColorPanel = new FlowLayoutPanel() {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown
            };

            FlowLayoutPanel alignButtonPanel = new FlowLayoutPanel() {
                AutoSize = true
            };

            leftAlignCheckBox = CreateIconCheckBox(35, 30, "/Icons/leftAlign.png", LeftAlignCheckBox_Click);
            centerAlignCheckBox = CreateIconCheckBox(35, 30, "/Icons/centerAlign.png", CenterAlignCheckBox_Click);
            rightAlignCheckBox = CreateIconCheckBox(35, 30, "/Icons/rightAlign.png", RightAlignCheckBox_Click);

            alignButtonPanel.Controls.Add(leftAlignCheckBox);
            alignButtonPanel.Controls.Add(centerAlignCheckBox);
            alignButtonPanel.Controls.Add(rightAlignCheckBox);

            FlowLayoutPanel colorSelectionPanel = new FlowLayoutPanel() {
                AutoSize = true,
            };
            backColorButton = CreateButton("⓬ █", new Font("Arial", 10), 55, 30, false, BackColorButton_Click);
            foreColorButton = CreateButton("A █", new Font("Arial", 10), 55, 30, false, ForeColorButton_Click);

            colorSelectionPanel.Controls.Add(foreColorButton);
            colorSelectionPanel.Controls.Add(backColorButton);
            alignAndColorPanel.Controls.Add(alignButtonPanel);
            alignAndColorPanel.Controls.Add(colorSelectionPanel);


            #endregion

            FlowLayoutPanel bulletAndMarginPanel = new FlowLayoutPanel() {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown
            };

            bulletCheckBox = CreateIconCheckBox(35, 30, "/Icons/bullet.png", OnClickBulletCheckBox);
            decreaseIndentCheckBox = CreateIconButton(35, 30, "/Icons/decreaseIndent.png", OnClickDecreaseIndentButton);
            increaseIndentCheckBox = CreateIconButton(35, 30, "/Icons/increaseIndent.png", OnClickIncreaseIndentButton);

            findButton = CreateButton("Find", new Font("Arial", 8), 57, 30, false, OnClickFindButton);
            replaceButton = CreateButton("Replace", new Font("Arial", 8), 57, 30, false, OnClickReplaceButton);
            
            FlowLayoutPanel bulletAndIndentButtonContainer = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };

            FlowLayoutPanel findAndReplaceButtonContainer = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };

            bulletAndIndentButtonContainer.Controls.Add(bulletCheckBox);
            bulletAndIndentButtonContainer.Controls.Add(decreaseIndentCheckBox);
            bulletAndIndentButtonContainer.Controls.Add(increaseIndentCheckBox);

            findAndReplaceButtonContainer.Controls.Add(findButton);
            findAndReplaceButtonContainer.Controls.Add(replaceButton);

            bulletAndMarginPanel.Controls.Add(bulletAndIndentButtonContainer);
            bulletAndMarginPanel.Controls.Add(findAndReplaceButtonContainer);
            toolBar.Controls.Add(fontPanel);
            toolBar.Controls.Add(CreateToolBarSeperator());
            toolBar.Controls.Add(alignAndColorPanel);
            toolBar.Controls.Add(CreateToolBarSeperator());
            toolBar.Controls.Add(bulletAndMarginPanel);
            toolBar.Controls.Add(CreateToolBarSeperator());

            #endregion
            currentFont = rtxtBox.Font.Name;
            currentFontSize = rtxtBox.Font.Size;

            #region Adding Controls
            this.Controls.Add(rtxtBox);
            this.Controls.Add(toolBar);
            #endregion
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult result = PromptSave();
            if (result == DialogResult.Cancel) {
                e.Cancel = true;
            }
            else if (result == DialogResult.Yes) {
                PromptSave();
            }
        }
        #endregion
        #region Rich Text Box Handlers
        private void RtxtBox_TextChanged(object sender, EventArgs e) {
            isSaved = false;
        }
        private void RtxtBox_SelectionChanged(object sender, EventArgs e) {
            Font font = rtxtBox.SelectionFont;
            if (font != null) {
                boldCheckBox.Enabled = true;
                italicCheckBox.Enabled = true;
                underlineCheckBox.Enabled = true;
                strikeThroughCheckBox.Enabled = true;
                cmbFonts.Text = font.Name;
                cmbFontSizes.Text = font.Size.ToString();
                boldCheckBox.Checked = font.Bold;
                italicCheckBox.Checked = font.Italic;
                underlineCheckBox.Checked = font.Underline;
                strikeThroughCheckBox.Checked = font.Strikeout;
            } else {
                cmbFonts.Text = "";
                cmbFontSizes.Text = "";
                boldCheckBox.Checked = false;
                italicCheckBox.Checked = false;
                underlineCheckBox.Checked = false;
                strikeThroughCheckBox.Checked = false;
                boldCheckBox.Enabled = false;
                italicCheckBox.Enabled = false;
                underlineCheckBox.Enabled = false;
                strikeThroughCheckBox.Enabled = false;
            }

            if (rtxtBox.SelectionCharOffset == -10) {
                subScriptCheckBox.Checked = true;
            } else {
                subScriptCheckBox.Checked = false;
            }
            if (rtxtBox.SelectionCharOffset == 10) {
                superScriptCheckBox.Checked = true;
            } else { 
                superScriptCheckBox.Checked = false;
            }
            foreColorButton.ForeColor = rtxtBox.SelectionColor;
            backColorButton.ForeColor = rtxtBox.SelectionBackColor;
            foreColorButton.BackColor = System.Drawing.Color.FromArgb(foreColorButton.ForeColor.ToArgb() ^ 0xFFFFFF);
            backColorButton.BackColor = System.Drawing.Color.FromArgb(backColorButton.ForeColor.ToArgb() ^ 0xFFFFFF);
            leftAlignCheckBox.Checked = rtxtBox.SelectionAlignment == HorizontalAlignment.Left;
            centerAlignCheckBox.Checked = rtxtBox.SelectionAlignment == HorizontalAlignment.Center;
            rightAlignCheckBox.Checked = rtxtBox.SelectionAlignment == HorizontalAlignment.Right;
            bulletCheckBox.Checked = rtxtBox.SelectionBullet;
        }
        #endregion
        #region Margin, Bullets, Search/Replace
        private void OnClickIncreaseIndentButton(object sender, EventArgs e) {
            rtxtBox.SelectionIndent += 10;
        }
        private void OnClickDecreaseIndentButton(object sender, EventArgs e) {
            rtxtBox.SelectionIndent -= 10;
        }
        private void OnClickBulletCheckBox(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked) {
                rtxtBox.SelectionBullet = true;
            } else {
                rtxtBox.SelectionBullet = false;
            }
        }
        private void OnClickFindButton(object sender, EventArgs e) {
            frmReplace.Display(frmfindAndReplaceForm.DialogShowModes.FindMode);
        }
        private void OnClickReplaceButton(object sender, EventArgs e) {
            frmReplace.Display(frmfindAndReplaceForm.DialogShowModes.ReplaceMode);
        }
        #endregion
        #region Font Style Toolbar Handlers
        private void ForeColorButton_Click(object sender, EventArgs e) {
            ColorDialog dlg = new ColorDialog();
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK) {
                rtxtBox.SelectionColor = dlg.Color;
            }
        }
        private void BackColorButton_Click(object sender, EventArgs e) {
            ColorDialog dlg = new ColorDialog();
            DialogResult result = dlg.ShowDialog();
            if(result == DialogResult.OK) {
                rtxtBox.SelectionBackColor = dlg.Color;
            }
        }
        private void RightAlignCheckBox_Click(object sender, EventArgs e) {
            rtxtBox.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void CenterAlignCheckBox_Click(object sender, EventArgs e) {
            rtxtBox.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void LeftAlignCheckBox_Click(object sender, EventArgs e) {
            rtxtBox.SelectionAlignment = HorizontalAlignment.Left;
            
        }
        private void CmbFontSizes_SelectedValueChanged(object sender, EventArgs e) {
            try {
                currentFontSize = Convert.ToInt32(cmbFontSizes.SelectedItem.ToString());
                UpdateFont();
            } catch(Exception 
            ex) { }
        }
        private void CmbFonts_SelectedValueChanged(object sender, EventArgs e) {
            try {
                currentFont = cmbFonts.SelectedItem.ToString();
                UpdateFont();
            } catch(Exception ex) { }
        }
        private void UpdateFont() {
            Font newFont = new Font(currentFont, currentFontSize, GetCurrentStyles());
            rtxtBox.SelectionFont = newFont;
        }
        private void SubScriptCheckBox_Click(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked) {
                rtxtBox.SelectionCharOffset = -10;
            }
            else {
                rtxtBox.SelectionCharOffset = 0;
            }
        }
        private void SuperScriptCheckBox_Click(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked) {
                rtxtBox.SelectionCharOffset = 10;
            }
            else {
                rtxtBox.SelectionCharOffset = 0;
            }
        }
        private void StrikeThroughCheckBox_Click(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked) {
                rtxtBox.SelectionFont = new Font(rtxtBox.SelectionFont, GetCurrentStyles() | FontStyle.Strikeout);
            }
            else {
                rtxtBox.SelectionFont = new Font(rtxtBox.SelectionFont, RemoveStyles(FontStyle.Strikeout));
            }
        }
        private void UnderlineCheckBox_Click(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked) {
                rtxtBox.SelectionFont = new Font(rtxtBox.SelectionFont, GetCurrentStyles() | FontStyle.Underline);
            }
            else {
                rtxtBox.SelectionFont = new Font(rtxtBox.SelectionFont, RemoveStyles(FontStyle.Underline));
            }
        }
        private void ItalicCheckBox_Click(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked) {
                rtxtBox.SelectionFont = new Font(rtxtBox.SelectionFont, GetCurrentStyles() | FontStyle.Italic);
            }
            else {
                rtxtBox.SelectionFont = new Font(rtxtBox.SelectionFont, RemoveStyles(FontStyle.Italic));
            }
        }
        private void BoldCheckBox_Click(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked) {
                rtxtBox.SelectionFont = new Font(rtxtBox.SelectionFont, GetCurrentStyles() | FontStyle.Bold);
            } else {
                rtxtBox.SelectionFont = new Font(rtxtBox.SelectionFont, RemoveStyles(FontStyle.Bold));
            }
        }
        #endregion
        #region File Menu Handlers
        private void OnClickNewMenu(object sender, EventArgs e) {
            DialogResult result = PromptSave();
            if (result != DialogResult.Cancel) {
                rtxtBox.Clear();
                isSaved = false;
                isExists = false;
                currentFileName = "Untitled";
                currentFilePath = "";
                UpdateTitle();
            }
        }
        private void OnClickOpenMenu(object sender, EventArgs e) {
            DialogResult result = PromptSave();
            if(result != DialogResult.Cancel) {
                OpenFileDialog fileDialog = new OpenFileDialog();
                DialogResult res = fileDialog.ShowDialog();
                if (res == DialogResult.OK) {
                    using (StreamReader reader = new StreamReader(fileDialog.FileName)) {
                        rtxtBox.Text = reader.ReadToEnd();
                    }
                    currentFilePath = fileDialog.FileName;
                    currentFileName = Path.GetFileName(currentFilePath);
                    UpdateTitle();
                    isExists = true;
                    isSaved = true;
                }
            }
        }
        private void OnClickSaveMenu(object sender, EventArgs e) {
            SaveFile();
            UpdateTitle();
        }
        private void OnClickSaveAsMenu(object sender, EventArgs e) {
            SaveFile(true);
        }
        private void OnClickPrintMenu(object sender, EventArgs e) {
            printImage = CreateBitmap();
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            DialogResult result = printDialog.ShowDialog();
            if(result == DialogResult.OK) {
                printDocument.Print();
            }
        }
        private void OnClickPrintPreviewMenu(object sender, EventArgs e) {
            printImage = CreateBitmap();
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = printDocument;
            if (dlg.ShowDialog() == DialogResult.OK) {
                dlg.Document.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {
            e.Graphics.DrawImage(printImage, 2, 2);
        }
        private Bitmap CreateBitmap() {
            Bitmap bitmap = new Bitmap(rtxtBox.Width , rtxtBox.Height);
            rtxtBox.Update();
            using (Graphics g = Graphics.FromImage(bitmap)) {
                g.CopyFromScreen(rtxtBox.PointToScreen(Point.Empty), Point.Empty, new Size(rtxtBox.Width - 5, rtxtBox.Height - 5));
            }
            return bitmap;
        }
        private void OnClickExitMenu(object sender, EventArgs e) {
            DialogResult result = PromptSave();
            rtxtBox.Text = result.ToString();
            if (result != DialogResult.Cancel) {
                System.Environment.Exit(0);
            }
        }
        private void SaveFile(bool saveAsFlag = false) {
            if (!isSaved || saveAsFlag) {
                if (isExists && !saveAsFlag) {
                    using (StreamWriter writer = new StreamWriter(currentFilePath)) {
                        writer.Write(rtxtBox.Text);
                    }
                    isSaved = true;
                }
                else {
                    SaveFileDialog fileDialog = new SaveFileDialog();
                    DialogResult result = fileDialog.ShowDialog();
                    if (result == DialogResult.OK) {
                        using (StreamWriter writer = new StreamWriter(fileDialog.FileName)) {
                            writer.Write(rtxtBox.Text);
                        }
                        currentFilePath = fileDialog.FileName;
                        currentFileName = Path.GetFileName(currentFilePath);
                        isExists = true;
                        isSaved = true;
                        UpdateTitle();
                    }
                }
            }
        }
        private DialogResult PromptSave() {
            DialogResult result = DialogResult.Yes;
            if (!isSaved) {
                result = MessageBox.Show("Do you want to save changes to " + currentFileName + "?", "WordPad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes) SaveFile();
            }
            return result;
        }
        private void UpdateTitle() {
            this.Text = "WordPad - " + currentFileName;
        }
        #endregion
        #region Edit Menu Handlers
        private void OnClickCutMenu(object sender, EventArgs e) {
            rtxtBox.Cut();
        }
        private void OnClickCopyMenu(object sender, EventArgs e) {
            rtxtBox.Copy();
        }
        private void OnClickPasteMenu(object sender, EventArgs e) {
            rtxtBox.Paste();
        }
        private void OnClickSelectAllMenu(object sender, EventArgs e) {
            rtxtBox.SelectAll();
        }
        private void OnClickUndoMenu(object sender, EventArgs e) {
            rtxtBox.Undo();
        }
        private void OnClickRedoMenu(object sender, EventArgs e) {
            rtxtBox.Redo();
        }
        #endregion
        #region Format Menu Handlers
        private void OnClickFontMenu(object sender, EventArgs e) {
            FontDialog dlg = new FontDialog();
            if(dlg.ShowDialog() == DialogResult.OK) {
                rtxtBox.SelectionFont = dlg.Font;
                currentFont = rtxtBox.SelectionFont.Name;
                currentFontSize = rtxtBox.SelectionFont.Size;
            }
        }
        private void OnClickWordWrapMenu(object sender, EventArgs e) {
            MenuItem thisMenu = sender as MenuItem;
            thisMenu.Checked = !thisMenu.Checked;
            rtxtBox.WordWrap = thisMenu.Checked;


        }
        private void OnClickAutoDragDropMenu(object sender, EventArgs e) {
            MenuItem thisMenu = sender as MenuItem;
            thisMenu.Checked = !thisMenu.Checked;
            rtxtBox.EnableAutoDragDrop = thisMenu.Checked;
        }
        #endregion
        #region Helpers
        private FontStyle GetCurrentStyles() {
            FontStyle fontStyle = new FontStyle();
            if (rtxtBox.SelectionFont != null) {
                if (rtxtBox.SelectionFont.Bold) fontStyle |= FontStyle.Bold;
                if (rtxtBox.SelectionFont.Italic) fontStyle |= FontStyle.Italic;
                if (rtxtBox.SelectionFont.Underline) fontStyle |= FontStyle.Underline;
                if (rtxtBox.SelectionFont.Strikeout) fontStyle |= FontStyle.Strikeout;
            }
            return fontStyle;
        }
        private FontStyle RemoveStyles(FontStyle toRemove) {
            FontStyle fontStyle = new FontStyle();
            if (rtxtBox.SelectionFont != null) {
                if (rtxtBox.SelectionFont.Bold && toRemove != FontStyle.Bold) fontStyle |= FontStyle.Bold;
                if (rtxtBox.SelectionFont.Italic && toRemove != FontStyle.Italic) fontStyle |= FontStyle.Italic;
                if (rtxtBox.SelectionFont.Underline && toRemove != FontStyle.Underline) fontStyle |= FontStyle.Underline;
                if (rtxtBox.SelectionFont.Strikeout && toRemove != FontStyle.Strikeout) fontStyle |= FontStyle.Strikeout;
            }
            return fontStyle;
        }
        private CheckBox CreateCheckBox(string text, Font font, int width, int height, bool autoSize, Appearance appearance, EventHandler handler) {
            CheckBox check = new CheckBox() {
                Text = text,
                Font = font,
                Width = width,
                Height = height,
                AutoSize = autoSize,
                Appearance = appearance
            };
            check.Click += handler;
            return check;
        }
        private Button CreateButton(string text, Font font, int width, int height, bool autoSize, EventHandler handler) {
            Button check = new Button() {
                Text = text,
                Font = font,
                Width = width,
                Height = height,
                AutoSize = autoSize,
            };
            check.Click += handler;
            return check;
        }
        private CheckBox CreateIconCheckBox(int width, int height, string path, EventHandler handler) {
            CheckBox check = new CheckBox() {
                Width = width,
                Height = height,
                Appearance = Appearance.Button,
                Image = Image.FromFile(Environment.CurrentDirectory + path)
            };
            check.Click += handler;
            return check;
        }
        private Panel CreateToolBarSeperator() {
            Panel tBarSeperator = new Panel() {
                BorderStyle = BorderStyle.Fixed3D,
                BackColor = Color.Gray,
                Width = 1,
                Height = toolBar.Height - 5
            };
            return tBarSeperator;
        }
        private Button CreateIconButton(int width, int height, string path, EventHandler handler) {
            Button button = new Button() {
                Width = width,
                Height = height,
                Image = Image.FromFile(Environment.CurrentDirectory + path),
            };
            button.Click += handler;
            return button;
        }
        #endregion
    }
}