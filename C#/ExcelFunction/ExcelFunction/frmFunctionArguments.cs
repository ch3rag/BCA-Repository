using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelFunction {
    public partial class frmFunctionArguments : Form {

        public frmFunctionArguments() {
            InitializeComponent();

            TableLayoutPanel mainContainer = new TableLayoutPanel() {
                RowCount = 4,
                ColumnCount = 1,
                Dock = DockStyle.Fill
            };

            mainContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            argsGroupBox = new GroupBox() {
                Text = "Function Name",
                Dock = DockStyle.Fill,
            };

            argsBox = new TableLayoutPanel() {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            argsGroupBox.Controls.Add(argsBox);

            mainContainer.Controls.Add(argsGroupBox, 0, 0);
            lblDescription = new Label() {
                Text = "Function Description",
                Dock = DockStyle.Fill
            };

            lblResult = new Label() {
                Text = "Formula Result",
                Dock = DockStyle.Fill
            };

            mainContainer.Controls.Add(lblDescription, 0, 1);
            mainContainer.Controls.Add(lblResult, 0, 2);

            FlowLayoutPanel buttonContainer = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill,
                AutoSize = true
            };
            Button btnCanel = new Button() {
                Text = "Cancel"
            };
            Button btnOk = new Button() {
                Text = "Ok"
            };

            btnOk.Click += (s, args) => System.Environment.Exit(0);
            btnCanel.Click += (s, args) => System.Environment.Exit(0);

            buttonContainer.Controls.Add(btnCanel);
            buttonContainer.Controls.Add(btnOk);
            mainContainer.Controls.Add(buttonContainer, 0, 3);
            this.Controls.Add(mainContainer);
        }

        class ArgBox : TableLayoutPanel {
            private Label lblLHS, lblRHS;
            private  TextBox txtInput;
            public Label LblLHS { get { return lblLHS; } }
            public Label LblRHS { get { return lblRHS; } }
            public TextBox TxtInput { get { return txtInput; } }

            public ArgBox(string prefix, string postfix, int index, Type type) {
                lblLHS = new Label() {
                    Text = prefix,
                    Font = new Font("Arial", 8, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                lblRHS = new Label() {
                    Text = postfix,
                    ForeColor = Color.Gray,
                    Font = new Font("Arial", 8, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                txtInput = new TextBox() {
                    Dock = DockStyle.Fill
                };

                txtInput.Tag = new Tuple<int, Type>(index, type);

                this.RowCount = 1;
                this.ColumnCount = 3;

                this.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                this.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                this.Controls.Add(lblLHS, 0, 0);
                this.Controls.Add(txtInput, 1, 0);
                this.Controls.Add(lblRHS, 2, 0);

                this.AutoSize = true;
                this.Dock = DockStyle.Top;

                txtInput.Click += OnClickTxtInput;
                txtInput.Enter += OnClickTxtInput;
                txtInput.TextChanged += OnTxtInputTextChange;

            }
        }

        public static void OnTxtInputTextChange(object sender, EventArgs e) {
            TextBox txt = sender as TextBox;
            Tuple<int, Type> pair = (Tuple<int, Type>)txt.Tag;
            if(txt.Text == "") {    // TEXT BOX EMPTY
                argBoxes[pair.Item1].LblRHS.ForeColor = Color.Gray;
                argBoxes[pair.Item1].LblRHS.Text = pair.Item2.Name;
            } else {
                object evaluated = JSEval.Eval(txt.Text);
                if (evaluated.ToString() != "" && (evaluated.GetType().Name == pair.Item2.Name || pair.Item2 == typeof(object))) {
                    argBoxes[pair.Item1].LblRHS.ForeColor = Color.Gray;
                    argBoxes[pair.Item1].LblRHS.Text = evaluated.ToString();
                    EvaluateFormula(); 
                } else {
                    argBoxes[pair.Item1].LblRHS.ForeColor = Color.Red;
                    argBoxes[pair.Item1].LblRHS.Text = "Invalid Input";
                }
            }
        }

        public static void EvaluateFormula() {
            int loopCount = argBoxes.Count;
            if (currentFunction.Arguments.Count == 0) loopCount -= 1;
            object[] args = new object[loopCount];
            for (int i = 0; i < loopCount; i++) {
                object value = JSEval.Eval(argBoxes[i].TxtInput.Text);
                if (value == null || value.ToString() == "") {
                    lblResult.Text = "Formula Result = ";
                    return;
                } else {
                    args[i] = value;
                }
            }
            dynamic func = currentFunction.BindedFunction;
            lblResult.Text = "Formula Result = " + func(args).ToString();
        }

        public static void OnClickTxtInput(object sender, EventArgs e) {
            int index = ((Tuple<int, Type>)(sender as TextBox).Tag).Item1;
            if (currentFunction.Arguments.Count == 0 && index == argBoxes.Count - 1) {
                argBoxes.Add(new ArgBox(currentFunction.Arguments.Prefix + (index + 2).ToString(), currentFunction.Arguments.DataType.Name, index + 1, currentFunction.Arguments.DataType));
                argsBox.Controls.Add(argBoxes[index + 1]);
            }
        }

        Label lblDescription;
        static Label lblResult;
        static List<ArgBox> argBoxes = new List<ArgBox>();
        static frmMain.Function currentFunction;
        GroupBox argsGroupBox;
        static TableLayoutPanel argsBox;

        private void frmFunctionArguments_Load(object sender, EventArgs e) {
            Text = "Arguments";    
        }

        public void Init(frmMain.Function function) {

            currentFunction = function;
            argsGroupBox.Text = currentFunction.Name;
            lblDescription.Text = currentFunction.Description;
            if(currentFunction.Arguments.Count == 0) {
                for (int i = 0; i < 2; i++) {
                    argBoxes.Add(new ArgBox(currentFunction.Arguments.Prefix + (i + 1).ToString(), currentFunction.Arguments.DataType.Name, i, currentFunction.Arguments.DataType));
                    argsBox.Controls.Add(argBoxes[i]);
                }
            } else {
                int i = 0;
                foreach(KeyValuePair<string, Type> pair in currentFunction.Arguments.ArgMap) {
                    argBoxes.Add(new ArgBox(pair.Key, pair.Value.Name, i++, pair.Value));
                    argsBox.Controls.Add(argBoxes[argBoxes.Count - 1]);
                }
            }
        }
    }
}
