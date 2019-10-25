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
    public partial class frmMain : Form {

        public delegate dynamic ListFunction(params dynamic[] args);

        public class Argument {

            private Type dataType;
            private Dictionary<string, Type> argMap = new Dictionary<string, Type>();
            public Dictionary<string, Type> ArgMap { get { return this.argMap; } }
            public Type DataType { get { return this.dataType; } }
            public string Prefix { get; set; }
            public int Count { get { return argMap.Count; } }

            public Argument() { }
            public Argument(Type dataType, string prefix) {
                argMap = new Dictionary<string, Type>();
                this.dataType = dataType;
                Prefix = prefix;
            }

            public Argument AddArgument(string name, Type dataType) {
                argMap.Add(name, dataType);
                return this;
            }
        }

        public struct Function {
            public string Name { get; set; }
            public string Description { get; set; }
            public string ArgsDescription { get; set; }
            public Argument Arguments { get; set; }
            public object BindedFunction { get; set; }
        }

        private Dictionary<string, Dictionary<string, Function>> functionMapping = new Dictionary<string, Dictionary<string, Function>>();
        private Dictionary<string, Function> mathFunctions = new Dictionary<string, Function>();
        private Dictionary<string, Function> logicalFunctions = new Dictionary<string, Function>();

        public frmMain() { InitializeComponent(); }

        TextBox txtSearchBox;
        ComboBox cmbCategory;
        ListBox lstFunctions;
        Label lblFunctionArgsDescription, lblFunctionDescription;

        private void frmMain_Load(object sender, EventArgs e) {

            DefineFunctions();

            Text = "Insert Funtion";
            TableLayoutPanel mainContainer = new TableLayoutPanel() {
                RowCount = 8,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(5),
                AutoSize = true
            };
            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            mainContainer.Controls.Add(new Label() {
                Text = "Search A Function",
                AutoSize = true,
                Dock = DockStyle.Fill
            }, 0, 0);

            txtSearchBox = new TextBox() {
                Text = "Type a brief description of what you want to do and then click Go",
                Dock = DockStyle.Fill,
            };

            txtSearchBox.KeyPress += (s, args) => {
                if (args.KeyChar == 13) BtnGo_Click(s, args);
            };

            Button btnGo = new Button() {
                Text = "Go"
            };

            btnGo.Click += BtnGo_Click;

            TableLayoutPanel searchContainer = new TableLayoutPanel() {
                RowCount = 1,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            searchContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            searchContainer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            searchContainer.Controls.Add(txtSearchBox, 0, 0);
            searchContainer.Controls.Add(btnGo, 1, 0);
           
            mainContainer.Controls.Add(searchContainer, 0, 1);

            FlowLayoutPanel categoryContainer = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            categoryContainer.Controls.Add(new Label() {
                Text = "Or select a category:",
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });

            cmbCategory = new ComboBox() { };
            categoryContainer.Controls.Add(cmbCategory);
            mainContainer.Controls.Add(categoryContainer, 0, 2);

            mainContainer.Controls.Add(new Label() {
                Text = "Select a function:",
                Dock = DockStyle.Fill
            }, 0, 3);

            lstFunctions = new ListBox() {
                Dock =  DockStyle.Fill
            };
            mainContainer.Controls.Add(lstFunctions, 0, 4);

            lblFunctionArgsDescription = new Label() {
                Text = "Function Args Description",
                Font = new Font("Arial", 8, FontStyle.Bold),
                Dock = DockStyle.Fill
            };

            lblFunctionDescription = new Label() {
                Text = "Function Description",
                Dock = DockStyle.Fill
            };

            mainContainer.Controls.Add(lblFunctionArgsDescription, 0, 5);
            mainContainer.Controls.Add(lblFunctionDescription, 0, 6);

            FlowLayoutPanel buttonContainer = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            Button btnCanel = new Button() {
                Text = "Cancel"
            };

            btnCanel.Click += (s, args) => this.Close();

            Button btnOk = new Button() {
                Text = "Ok"
            };

            btnOk.Click += BtnOk_Click;

            buttonContainer.Controls.Add(btnCanel);
            buttonContainer.Controls.Add(btnOk);
            mainContainer.Controls.Add(buttonContainer, 0, 7);
            this.Controls.Add(mainContainer);

            cmbCategory.SelectedIndexChanged += CmbCategory_SelectedIndexChanged;
            lstFunctions.SelectedIndexChanged += LstFunctions_SelectedIndexChanged;
            foreach(string category in functionMapping.Keys) {
                cmbCategory.Items.Add(category);
            }
        }

        private void BtnOk_Click(object sender, EventArgs e) {
            Dictionary<string, Function> outFuncCat;
            if(!functionMapping.TryGetValue(cmbCategory.Text, out outFuncCat)) {
                MessageBox.Show("No Category Selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Function outFunc;
            if(!outFuncCat.TryGetValue(lstFunctions.Text, out outFunc)) {
                MessageBox.Show("No Function Selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmFunctionArguments argsForm = new frmFunctionArguments();
            argsForm.Init(outFunc);
            argsForm.Visible = true;
            this.Visible = false;
        }

        private void BtnGo_Click(object sender, EventArgs e) {
            for (int i = 0; i < cmbCategory.Items.Count; i++) {
                Dictionary<string, Function> funcCat = functionMapping[cmbCategory.Items[i].ToString()];
                int index = 0;
                foreach(KeyValuePair<string, Function> pair in funcCat) {
                    if(txtSearchBox.Text.Equals(pair.Key, StringComparison.OrdinalIgnoreCase)) {
                        cmbCategory.SelectedIndex = i;
                        lstFunctions.SelectedIndex = index;
                    }
                    index++;
                }
            }
        }

        private void LstFunctions_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstFunctions.Text != "") {
                Function selectedFunction = functionMapping[cmbCategory.Text][lstFunctions.Text];
                lblFunctionArgsDescription.Text = selectedFunction.ArgsDescription;
                lblFunctionDescription.Text = selectedFunction.Description;
            }
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e) {
            lstFunctions.Items.Clear();
            foreach(string functionName in functionMapping[cmbCategory.Text].Keys) {
                lstFunctions.Items.Add(functionName);
            }
        }

        private void DefineFunctions() {
            mathFunctions.Add("SUM", new Function() {
                Name = "SUM",
                Description = "Adds all the numbers in a range of cells.",
                ArgsDescription = "SUM(number1, number2...)",
                Arguments = new Argument(typeof(double), "Number"),
                BindedFunction = new ListFunction((args) => args.Aggregate(0.0, (a, x) => a + x))
            });

            mathFunctions.Add("AVERAGE", new Function() {
                Name = "AVERAGE",
                Description = "Returns the average (arithmetic mean) of the arguments.",
                ArgsDescription = "AVERAGE(number1, number2, ...)",
                Arguments = new Argument(typeof(double), "Number"),
                BindedFunction = new ListFunction((args) => args.Aggregate(0.0, (a, x) => a + x) / args.Length)
            });

            mathFunctions.Add("MAX", new Function() {
                Name = "MAX",
                Description = "Returns the largest value in a set of values.",
                ArgsDescription = "MAX(number1, number2, ...)",
                Arguments = new Argument(typeof(double), "Number"),
                BindedFunction = new ListFunction((args) => args.Max())
            });

            mathFunctions.Add("MIN", new Function() {
                Name = "MIN",
                Description = "Returns the smallest value in a set of values.",
                ArgsDescription = "MIN(number1, number2, ...)",
                Arguments = new Argument(typeof(double), "Number"),
                BindedFunction = new ListFunction((args) => args.Min())
            });


            mathFunctions.Add("SIN", new Function() {
                Name = "SIN",
                Description = "Returns the sine of the given angle.",
                ArgsDescription = "SIN(number)",
                Arguments = new Argument().AddArgument("Number", typeof(double)),
                BindedFunction = new ListFunction((num) => Math.Sin(num[0]))
            });

            mathFunctions.Add("COS", new Function() {
                Name = "COS",
                Description = "Returns the cosine of the given angle.",
                ArgsDescription = "COS(number)",
                Arguments = new Argument().AddArgument("Number", typeof(double)),
                BindedFunction = new ListFunction((num) => Math.Cos(num[0]))
            });

            mathFunctions.Add("TAN", new Function() {
                Name = "TAN",
                Description = "Returns the tangent of the given angle.",
                ArgsDescription = "TAN(number)",
                Arguments = new Argument().AddArgument("Number", typeof(double)),
                BindedFunction = new ListFunction((num) => Math.Tan(num[0]))
            });

            functionMapping.Add("Math & Trig", mathFunctions);

            logicalFunctions.Add("IF", new Function() {
                Name = "IF",
                Description = "The IF function returns one value if a condition you specify evaluates to TRUE, and another value if that condition evaluates to FALSE.",
                ArgsDescription = "IF(locical_test, value_if_true, value_if_false)",
                Arguments = new Argument().AddArgument("Logical_test", typeof(bool)).AddArgument("Value_if_true", typeof(object)).AddArgument("Value_if_false", typeof(object)),
                BindedFunction = new ListFunction((args) => args[0] ? args[1] : args[2])
            });


            logicalFunctions.Add("AND", new Function() {
                Name = "AND",
                Description = "Returns TRUE if all its arguments evaluate to TRUE; returns FALSE if one or more arguments evaluate to FALSE.",
                ArgsDescription = "AND(logical1, logical2, logical3....)",
                Arguments = new Argument(typeof(bool), "Logical"),
                BindedFunction = new ListFunction((args) => args.Aggregate(true, (acc, x) => acc & x))
            });

            logicalFunctions.Add("OR", new Function() {
                Name = "OR",
                Description = "Returns TRUE if any argument is TRUE; returns FALSE if all arguments are FALSE.",
                ArgsDescription = "OR(logical1, logical2, logical3....)",
                Arguments = new Argument(typeof(bool), "Logical"),
                BindedFunction = new ListFunction((args) => args.Aggregate(true, (acc, x) => acc | x))
            });

            logicalFunctions.Add("NOT", new Function() {
                Name = "NOT",
                Description = "Reverses the value of its argument. Use NOT when you want to make sure a value is not equal to one particular value.",
                ArgsDescription = "NOT(logical)",
                Arguments = new Argument().AddArgument("Logical", typeof(bool)),
                BindedFunction = new ListFunction((args) => !args[0])
            });

            logicalFunctions.Add("XOR", new Function() {
                Name = "XOR",
                Description = "Returns a logical Exclusive Or of all arguments.",
                ArgsDescription = "XOR(logical1, logical2, logical3....)",
                Arguments = new Argument(typeof(bool), "Logical"),
                BindedFunction = new ListFunction((args) => args.Aggregate(true, (acc, x) => acc ^ x))
            });


            functionMapping.Add("Logical", logicalFunctions);
        }
    }
}
