using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyControls;

namespace Calculator {
    public partial class frmMain : Form {
        private enum AngleMode {
            Degree,
            Radian,
            Gradient
        };
        private enum Function {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            OneByX,
            SquareRoot,
            Percent,
            Power10,
            Log10,
            LogE,
            Mod,
            Exponential,
            ThirdRootX,
            XCube,
            Tan,
            TanH,
            Pi,
            YRootX,
            XToY,
            Cos,
            CosH,
            Dms,
            Factorial,
            XSquare,
            Sin,
            SinH,
            Int,
            E,
            Random,
            EToX,
            None
        };

        private Font buttonFont = new Font("Calibri", 12, FontStyle.Bold);
        private Font mainLabelFont = new Font("Calibri", 20, FontStyle.Bold);
        private Font tempLabelFont = new Font("Calibri", 12, FontStyle.Italic | FontStyle.Bold);
        Color calcColor1 = Color.DarkTurquoise;
        Color calcColor2 = Color.DeepSkyBlue; 
        Color calcBorderColor = Color.Wheat;
        Color fontColor = Color.White;
        Color btnColor = Color.DodgerBlue;

        public frmMain() {
            InitializeComponent();
        }

        Label lblMain, lblTemp, lblMemory;
        bool isOverwrite, isDecimal, isMemorySet, isScientific, isLastUnary;
        double memory, current, userMemory;
        string unaryExp = "", unaryTemp = "";
        Function currentFunction = Function.None;
        private AngleMode angleMode;

        public void MainInput(string str, bool clear = false) {
            if (lblMain.Text == "0" || clear) {
                if (isScientific) lblMain.Text = Convert.ToDouble(str).ToString("E", System.Globalization.CultureInfo.InvariantCulture);
                else lblMain.Text = str; 
            } else if (isOverwrite) {
                lblMain.Text = str;
                isOverwrite = false;
            }
            else {
                lblMain.Text += str;
            }
        }

        private double GetAngle(double value) {
            switch (angleMode) {
                case AngleMode.Radian: return value;
                case AngleMode.Degree: return (value * Math.PI / 180);
                case AngleMode.Gradient: return (value * Math.PI / 200);
            }
            return value;
        }

        private double Factorial(double num) {
            if (num == 0) return 1;
            else return num * Factorial(num - 1);
        }
        private double GetRandom() {
            Random rand = new Random();
            return rand.NextDouble();
        }



        private void FunctionInputUnary(Function func) {
            isDecimal = false;
            isLastUnary = true;
            current = Convert.ToDouble(lblMain.Text);
            double currentAngle = GetAngle(current);
            switch (func) {
                case Function.OneByX:
                    CreateEvalutation("reciproc", true);
                    current = 1 / current;
                    break;
                case Function.SquareRoot:
                    CreateEvalutation("sqrt", true);
                    current = Math.Sqrt(current);
                    break;
                case Function.Power10:
                    CreateEvalutation("powerTen", true);
                    current = Math.Pow(10, current);
                    break;
                case Function.Log10:
                    CreateEvalutation("log", true);
                    current = Math.Log10(current);
                    break;
                case Function.ThirdRootX:
                    CreateEvalutation("cuberoot", true);
                    current = Math.Pow(current, 0.3333333333);
                    break;
                case Function.XCube:
                    CreateEvalutation("cube", true);
                    current = Math.Pow(current, 3);
                    break;
                case Function.Tan:
                    CreateEvalutation("tan", true);
                    current = Math.Tan(currentAngle);
                    break;
                case Function.TanH:
                    CreateEvalutation("tanh", true);
                    current = Math.Tanh(currentAngle);
                    break;
                case Function.Cos:
                    CreateEvalutation("cos", true);
                    current = Math.Cos(currentAngle);
                    break;
                case Function.CosH:
                    CreateEvalutation("cosh", true);
                    current = Math.Cosh(currentAngle);
                    break;
                case Function.Sin:
                    CreateEvalutation("sin", true);
                    current = Math.Sin(currentAngle);
                    break;
                case Function.SinH:
                    CreateEvalutation("sinh", true);
                    current = Math.Sinh(currentAngle);
                    break;
                case Function.Dms:
                    CreateEvalutation("dms", true);
                    int d = (int)current;
                    double m = Math.Round((current - d) * 0.6, 2);
                    double s = Math.Round(((current - d) - (m / 0.6)) * 0.36, 4);
                    current = d + m + s;
                    break;
                case Function.Factorial:
                    CreateEvalutation("fact", true);
                    current = Factorial(current);
                    break;
                case Function.XSquare:
                    CreateEvalutation("square", true);
                    current = current * current;
                    break;
                case Function.Int:
                    CreateEvalutation("int", true);
                    current = (int)current;
                    break;
                case Function.EToX:
                    CreateEvalutation("powe", true);
                    current = Math.Exp(current);
                    break;
                case Function.LogE:
                    CreateEvalutation("loge", true);
                    current = Math.Log(current);
                    break;
                case Function.Percent:
                    current = memory / 100 * current;
                    break;
                case Function.Exponential:
                    MainInput(current.ToString("E", System.Globalization.CultureInfo.InvariantCulture), true);
                    return;
                case Function.Pi:
                    current = Math.PI;
                    break;
                case Function.Random:
                    current = GetRandom();
                    break;
                case Function.E:
                    current = Math.E;
                    break;
            }
            MainInput(current.ToString(), true);
        }


        private void FunctionInput(Function func) {
            isLastUnary = false;
            isDecimal = false;
            current = Convert.ToDouble(lblMain.Text);
            isOverwrite = true;
            EvaluatePending();
            currentFunction = func;
            switch (func) {
                case Function.Addition:
                    CreateEvalutation("+");
                    break;
                case Function.Subtraction:
                    CreateEvalutation("-");
                    break;
                case Function.Division:
                    CreateEvalutation("/");
                    break;
                case Function.Multiplication:
                    CreateEvalutation("*");
                    break;
                case Function.Mod:
                    CreateEvalutation("Mod");
                    break;
                case Function.XToY:
                    CreateEvalutation("^");
                    break;
                case Function.YRootX:
                    CreateEvalutation("yroot");
                    break;
            }
        }

        private void EvaluatePending() {
            switch (currentFunction) {
                case Function.Addition:
                    memory = current + memory;
                    break;
                case Function.Subtraction:
                    memory = memory - current;
                    break;
                case Function.Division:
                    memory = memory / current;
                    break;
                case Function.Multiplication:
                    memory = current * memory;
                    break;
                case Function.Mod:
                    memory = memory % current;
                    break;
                case Function.XToY:
                    memory = Math.Pow(memory, current);
                    break;
                case Function.YRootX:
                    memory = Math.Pow(memory, (1 / current));
                    break;
                default:
                    memory = current;
                    return;
            }
            MainInput(memory.ToString(), true);
            currentFunction = Function.None;
        }
        
        private void CreateEvalutation(string func, bool isUnary = false) {
            if (!isUnary) {
                if (unaryExp != "") {
                    unaryExp = "";
                    unaryTemp = "";
                    lblTemp.Text += " " + func + " ";
                } else {
                    lblTemp.Text += current + " " + func + " ";
                }
            } else {
                if (unaryExp == "") {
                    unaryTemp = lblTemp.Text;
                    unaryExp = func + "(" + current + ")";
                } else {
                    unaryExp = func + "(" + unaryExp + ")";
                }
                lblTemp.Text = unaryTemp + unaryExp;
            }
        }

        private void frmMain_Load(object sender, EventArgs e) {

            Text = "Calculator";
            lblMain = CreateLabel("0", ContentAlignment.MiddleRight, mainLabelFont);
            lblMemory = CreateLabel("M", ContentAlignment.MiddleLeft, mainLabelFont);
            lblTemp = CreateLabel("", ContentAlignment.BottomRight, tempLabelFont);
            lblMemory.Visible = false;
            

            MyPanel mainPanel = new MyPanel(DockStyle.Fill, new Padding(4), Color.Transparent);
            MyTableLayoutPanel mainContainer = new MyTableLayoutPanel(7, 10, DockStyle.Fill, Color.White);
            mainContainer.SetRowDimension(SizeType.Percent, 20, 13, 13, 13, 13, 13, 13);
            mainContainer.SetColumnDimension(SizeType.Percent, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10);
            mainContainer.SetGradientBackground(calcColor2, calcColor1, 90f);
            MyTableLayoutPanel displayPanel = new MyTableLayoutPanel(2, 2, DockStyle.Fill, new Padding(10), Color.Transparent);

            displayPanel.SetBorderAndGradientBackground(new Pen(calcBorderColor, 2), calcColor1, calcColor2, 90f);
            displayPanel.SetRowDimension(SizeType.Percent, 30, 70);
            displayPanel.SetColumnDimension(SizeType.Percent, 10, 90);


            displayPanel.Controls.Add(lblTemp, 1, 0);
            displayPanel.Controls.Add(lblMain, 1, 1);
            displayPanel.Controls.Add(lblMemory, 0, 0);
            displayPanel.SetRowSpan(lblMemory, 2);

            mainContainer.Controls.Add(displayPanel, 0, 0);
            mainContainer.SetColumnSpan(displayPanel, 10);


            MyTableLayoutPanel degRadGradPanel = new MyTableLayoutPanel(1, 3, DockStyle.Fill, new Padding(3));
            degRadGradPanel.SetColumnDimension(SizeType.Percent, 36, 36, 27);
            degRadGradPanel.SetBorder(new Pen(calcBorderColor, 2));

            RadioButton degButton = CreateRadioButton("Degrees");
            RadioButton radButton = CreateRadioButton("Radians", true);
            RadioButton gradButton = CreateRadioButton("Gradians");

            degButton.Click += (s, args) => angleMode = AngleMode.Degree;
            radButton.Click += (s, args) => angleMode = AngleMode.Radian;
            gradButton.Click += (s, args) => angleMode = AngleMode.Gradient;

            degRadGradPanel.Controls.Add(degButton, 0, 0);
            degRadGradPanel.Controls.Add(radButton, 1, 0);
            degRadGradPanel.Controls.Add(gradButton, 2, 0);

            mainContainer.Controls.Add(degRadGradPanel, 0, 1);
            mainContainer.SetColumnSpan(degRadGradPanel, 5);


            Button btnMc = CreateButton("MC");
            Button btnMr = CreateButton("MR");
            Button btnMs = CreateButton("MS");
            Button btnMp = CreateButton("M+");
            Button btnMm = CreateButton("M-");
            mainContainer.Controls.Add(btnMc, 5, 1);
            mainContainer.Controls.Add(btnMr, 6, 1);
            mainContainer.Controls.Add(btnMs, 7, 1);
            mainContainer.Controls.Add(btnMp, 8, 1);
            mainContainer.Controls.Add(btnMm, 9, 1);

            MyPanel emptyPanel = new MyPanel(DockStyle.Fill, Padding.Empty, Color.Transparent);
            emptyPanel.SetBorder(new Pen(calcBorderColor, 1));

            Button btnE = CreateButton("e");
            Button btnLn = CreateButton("ln");
            Button btnRnd = CreateButton("Rnd");
            Button btnEToX = CreateButton("eⁿ");
            Button btnBksp = CreateButton("←");
            Button btnCE = CreateButton("CE");
            Button btnC = CreateButton("C");
            Button btnPlusMinus = CreateButton("±");
            Button btnSqrt = CreateButton("√");
            mainContainer.Controls.Add(emptyPanel, 0, 2);
            mainContainer.Controls.Add(btnE, 1, 2);
            mainContainer.Controls.Add(btnLn, 2, 2);
            mainContainer.Controls.Add(btnRnd, 3, 2);
            mainContainer.Controls.Add(btnEToX, 4, 2);
            mainContainer.Controls.Add(btnBksp, 5, 2);
            mainContainer.Controls.Add(btnCE, 6, 2);
            mainContainer.Controls.Add(btnC, 7, 2);
            mainContainer.Controls.Add(btnPlusMinus, 8, 2);
            mainContainer.Controls.Add(btnSqrt, 9, 2);


            Button btnInt = CreateButton("Int");
            Button btnSinh = CreateButton("sinh");
            Button btnSin = CreateButton("sin");
            Button btnXsquare = CreateButton("x²");
            Button btnFact = CreateButton("n!");
            Button btn7 = CreateButton("7");
            Button btn8 = CreateButton("8");
            Button btn9 = CreateButton("9");
            Button btnDiv = CreateButton("/");
            Button btnPercent = CreateButton("%");

            mainContainer.Controls.Add(btnInt, 0, 3);
            mainContainer.Controls.Add(btnSinh, 1, 3);
            mainContainer.Controls.Add(btnSin, 2, 3);
            mainContainer.Controls.Add(btnXsquare, 3, 3);
            mainContainer.Controls.Add(btnFact, 4, 3);
            mainContainer.Controls.Add(btn7, 5, 3);
            mainContainer.Controls.Add(btn8, 6, 3);
            mainContainer.Controls.Add(btn9, 7, 3);
            mainContainer.Controls.Add(btnDiv, 8, 3);
            mainContainer.Controls.Add(btnPercent, 9, 3);

            Button btnDms = CreateButton("dms");
            Button btnCosh = CreateButton("cosh");
            Button btnCos = CreateButton("cos");
            Button btnXPowerN = CreateButton("xⁿ");
            Button btnYRootX = CreateButton("ⁿ√x");
            Button btn4 = CreateButton("4");
            Button btn5 = CreateButton("5");
            Button btn6 = CreateButton("6");
            Button btnMult = CreateButton("*");
            Button btn1ByX = CreateButton("1/x");

            mainContainer.Controls.Add(btnDms, 0, 4);
            mainContainer.Controls.Add(btnCosh, 1, 4);
            mainContainer.Controls.Add(btnCos, 2, 4);
            mainContainer.Controls.Add(btnXPowerN, 3, 4);
            mainContainer.Controls.Add(btnYRootX, 4, 4);
            mainContainer.Controls.Add(btn4, 5, 4);
            mainContainer.Controls.Add(btn5, 6, 4);
            mainContainer.Controls.Add(btn6, 7, 4);
            mainContainer.Controls.Add(btnMult, 8, 4);
            mainContainer.Controls.Add(btn1ByX, 9, 4);


            Button btnPi = CreateButton("Pi");
            Button btnTanh = CreateButton("tanh");
            Button btnTan = CreateButton("tan");
            Button btnXCube = CreateButton("x³");
            Button btnThirdRootX = CreateButton("³√x");
            Button btn1 = CreateButton("1");
            Button btn2 = CreateButton("2");
            Button btn3 = CreateButton("3");
            Button btnMinus = CreateButton("-");
            Button btnEquals = CreateButton("=");

            mainContainer.Controls.Add(btnPi, 0, 5);
            mainContainer.Controls.Add(btnTanh, 1, 5);
            mainContainer.Controls.Add(btnTan, 2, 5);
            mainContainer.Controls.Add(btnXCube, 3, 5);
            mainContainer.Controls.Add(btnThirdRootX, 4, 5);
            mainContainer.Controls.Add(btn1, 5, 5);
            mainContainer.Controls.Add(btn2, 6, 5);
            mainContainer.Controls.Add(btn3, 7, 5);
            mainContainer.Controls.Add(btnMinus, 8, 5);
            mainContainer.Controls.Add(btnEquals, 9, 5);
            mainContainer.SetRowSpan(btnEquals, 2);


            CheckBox btnFE = CreateCheckBox("F-E");
            Button btnExp = CreateButton("Exp");
            Button btnMod = CreateButton("Mod");
            Button btnLog = CreateButton("log");
            Button btn10ToX = CreateButton("10ⁿ");
            Button btn0 = CreateButton("0");
            Button btnDot = CreateButton(".");
            Button btnPlus = CreateButton("+");

            mainContainer.Controls.Add(btnFE, 0, 6);
            mainContainer.Controls.Add(btnExp, 1, 6);
            mainContainer.Controls.Add(btnMod, 2, 6);
            mainContainer.Controls.Add(btnLog, 3, 6);
            mainContainer.Controls.Add(btn10ToX, 4, 6);
            mainContainer.Controls.Add(btn0, 5, 6);
            mainContainer.SetColumnSpan(btn0, 2);
            mainContainer.Controls.Add(btnDot, 7, 6);
            mainContainer.Controls.Add(btnPlus, 8, 6);


            mainPanel.Controls.Add(mainContainer);
            this.Controls.Add(mainPanel);

            btnBksp.Click += (s, args) => {
                if (lblMain.Text.Length == 1) lblMain.Text = "0";
                else lblMain.Text = lblMain.Text.Substring(0, lblMain.Text.Length - 1);
            };
            btnCE.Click += (s, args) => {
                lblMain.Text = "0";
                if (isLastUnary)
                    lblTemp.Text = unaryTemp;
                unaryTemp = "";
                unaryExp = "";
            };
            
            btnC.Click += (s, args) => {
                currentFunction = Function.None;
                lblMain.Text = "0";
                lblTemp.Text = "";
                unaryExp = "";
                unaryTemp = "";
            };
            btnEquals.Click += (s, args) => {
                current = Convert.ToDouble(lblMain.Text);
                EvaluatePending();
                lblTemp.Text = "";
                currentFunction = Function.None;
                isOverwrite = true;
            };
            btnDot.Click += (s, args) => { if (!isDecimal) MainInput("."); isDecimal = true; };
            
            btnPlusMinus.Click += (s, args) => {
                if (lblMain.Text[0] == '-') {
                    lblMain.Text = lblMain.Text.Substring(1);
                } else {
                    lblMain.Text = '-' + lblMain.Text;
                }
            };
            btnMs.Click += (s, args) => {
                userMemory = Convert.ToDouble(lblMain.Text);
                lblMemory.Visible = true;
                isOverwrite = true;
                isMemorySet = true;
            };
            btnMc.Click += (s, args) => {
                userMemory = 0;
                lblMemory.Visible = false;
                isMemorySet = false;
            };
            btnMr.Click += (s, args) => {
                lblMain.Text = userMemory.ToString();
                isOverwrite = true;
            };
            btnMp.Click += (s, args) => {
                if (isMemorySet) {
                    userMemory += Convert.ToDouble(lblMain.Text);
                    lblMain.Text = userMemory.ToString();
                    isOverwrite = true;
                }
            };
            btnMm.Click += (s, args) => {
                if (isMemorySet) {
                    userMemory -= Convert.ToDouble(lblMain.Text);
                    lblMain.Text = userMemory.ToString();
                    isOverwrite = true;
                }
            };
            

            btnFE.Click += (s, args) => {
                isScientific = btnFE.Checked;
                FunctionInputUnary(Function.Exponential);
                isOverwrite = true;
            };


            btn1.Click += (s, args) => MainInput("1");
            btn2.Click += (s, args) => MainInput("2");
            btn3.Click += (s, args) => MainInput("3");
            btn4.Click += (s, args) => MainInput("4");
            btn5.Click += (s, args) => MainInput("5");
            btn6.Click += (s, args) => MainInput("6");
            btn7.Click += (s, args) => MainInput("7");
            btn8.Click += (s, args) => MainInput("8");
            btn9.Click += (s, args) => MainInput("9");
            btn0.Click += (s, args) => MainInput("0");



            btnPlus.Click += (s, args) => FunctionInput(Function.Addition);
            btnMinus.Click += (s, args) => FunctionInput(Function.Subtraction);
            btnMult.Click += (s, args) => FunctionInput(Function.Multiplication);
            btnDiv.Click += (s, args) => FunctionInput(Function.Division);
            btnMod.Click += (s, args) => FunctionInput(Function.Mod);
            btnXPowerN.Click += (s, args) => FunctionInput(Function.XToY);
            btnYRootX.Click += (s, args) => FunctionInput(Function.YRootX);

            btn10ToX.Click += (s, args) => FunctionInputUnary(Function.Power10);
            btnLog.Click += (s, args) => FunctionInputUnary(Function.Log10);
            btnExp.Click += (s, args) => FunctionInputUnary(Function.Exponential);
            btnThirdRootX.Click += (s, args) => FunctionInputUnary(Function.ThirdRootX);
            btnXCube.Click += (s, args) => FunctionInputUnary(Function.XCube);
            btnTanh.Click += (s, args) => FunctionInputUnary(Function.TanH);
            btnTan.Click += (s, args) => FunctionInputUnary(Function.Tan);
            btnPi.Click += (s, args) => FunctionInputUnary(Function.Pi);
            btnCosh.Click += (s, args) => FunctionInputUnary(Function.CosH);
            btnCos.Click += (s, args) => FunctionInputUnary(Function.Cos);
            btnSinh.Click += (s, args) => FunctionInputUnary(Function.SinH);
            btnSin.Click += (s, args) => FunctionInputUnary(Function.Sin);            
            btnDms.Click += (s, args) => FunctionInputUnary(Function.Dms);
            btnFact.Click += (s, args) => FunctionInputUnary(Function.Factorial);
            btnXsquare.Click += (s, args) => FunctionInputUnary(Function.XSquare);
            btnInt.Click += (s, args) => FunctionInputUnary(Function.Int);
            btnLn.Click += (s, args) => FunctionInputUnary(Function.LogE);
            btnRnd.Click += (s, args) => FunctionInputUnary(Function.Random);
            btnEToX.Click += (s, args) => FunctionInputUnary(Function.EToX);
            btnE.Click += (s, args) => FunctionInputUnary(Function.E);
            btn1ByX.Click += (s, args) => FunctionInputUnary(Function.OneByX);
            btnSqrt.Click += (s, args) => FunctionInputUnary(Function.SquareRoot);
            btnPercent.Click += (s, args) => FunctionInputUnary(Function.Percent);
            
        }

        private RadioButton CreateRadioButton(string text, bool isChecked = false) {
            return new RadioButton() {
                Text = text,
                Dock = DockStyle.Fill,
                Checked = isChecked,
                Font = buttonFont,
                ForeColor = fontColor
            };
        }
        private CheckBox CreateCheckBox(string text) {
            return new CheckBox() {
                Text = text,
                Appearance = Appearance.Button,
                Dock = DockStyle.Fill,
                Font = buttonFont,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = fontColor,
                BackColor = btnColor
            };
        }

        private Button CreateButton(string text) {
            return new Button() {
                Text = text,
                Dock = DockStyle.Fill,
                Font = buttonFont,
                ForeColor = fontColor,
                BackColor = btnColor
            };
        }

        private Label CreateLabel(string text, ContentAlignment align, Font font) {
            return new Label() {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = align,
                Font = font,
                ForeColor = fontColor
            };
        }
    }
}
