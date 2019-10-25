using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
namespace MyAssistant {
    public partial class frmMain : Form {
        SpeechSynthesizer assistant = new SpeechSynthesizer();
        SpeechRecognitionEngine listenAlways = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine engine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        private bool listening;
        TextBox txtInput;
        Button btnListen;
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            
            this.Text = "My Assistant";
            this.Width = 400;
            this.Height = 300;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.BackColor = Color.White;
            TableLayoutPanel mainContainer = new TableLayoutPanel() {
                RowCount = 2,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            TableLayoutPanel buttonContainer = new TableLayoutPanel() {
                ColumnCount = 3,
                RowCount = 1,
                Dock = DockStyle.Fill,
                AutoSize = true,
            };
            buttonContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            buttonContainer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            buttonContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            btnListen = new Button() {
                Text = "Start Listening",
                AutoSize = true,
                Font = new Font("Trebuchet MS", 12)
            };
            btnListen.Click += BtnListen_Click;
            buttonContainer.Controls.Add(btnListen, 1, 0);
            mainContainer.Controls.Add(buttonContainer, 0, 0);
            GroupBox inputTextBox = new GroupBox() {
                Text = "Input",
                Dock = DockStyle.Fill
            };

            txtInput = new TextBox() {
                ReadOnly = true,
                Multiline = true,
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            inputTextBox.Controls.Add(txtInput);
            mainContainer.Controls.Add(inputTextBox, 0, 1);
            this.Controls.Add(mainContainer);

            assistant.SpeakAsync("SAY 'HELLO' TO GIVE ANY COMMAND.");
            txtInput.Text = "Say \"HELLO\" to give any command.";

            Choices startListen = new Choices(new string[] { "HELLO" });
            Grammar startGrammar = new Grammar(new GrammarBuilder(startListen));
            listenAlways.LoadGrammar(startGrammar);
            listenAlways.SetInputToDefaultAudioDevice();
            listenAlways.RecognizeAsync(RecognizeMode.Multiple);
            listenAlways.SpeechRecognized += ListenAlways_SpeechRecognized;


            Choices engineChoices = new Choices();

            engineChoices.Add(new string[] { "STOP LISTENING", "TERMINATE", "WHAT IS THE TIME" });

            Choices appChoices = new Choices(new string[] { "NOTEPAD", "MYCOMPUTER", "CHROME" });
            GrammarBuilder appOpenGrammar = new GrammarBuilder();
            appOpenGrammar.Append("OPEN");
            appOpenGrammar.Append(appChoices);
            engineChoices.Add(appOpenGrammar);

            GrammarBuilder engineGrammarBuilder = new GrammarBuilder(engineChoices);

            Grammar engineGrammar = new Grammar(engineGrammarBuilder);

            engine.LoadGrammar(engineGrammar);
            engine.SetInputToDefaultAudioDevice();
            engine.SpeechRecognized += Engine_SpeechRecognized;

        }

        private void ListenAlways_SpeechRecognized(object sender, SpeechRecognizedEventArgs e) {
            switch (e.Result.Text.ToUpper()) {
                case "HELLO":
                    txtInput.Text = "Listening...";
                    listening = true;
                    btnListen.Text = "Stop Listening..";
                    listenAlways.RecognizeAsyncStop();
                    engine.RecognizeAsync(RecognizeMode.Multiple);
                    break;
            }
        }

        private void BtnListen_Click(object sender, EventArgs e) {
            if(!listening) {
                listenAlways.RecognizeAsyncCancel();
                listenAlways.RecognizeAsyncStop();
                listenAlways.EmulateRecognize("HELLO");
            } else {
                engine.RecognizeAsyncCancel();
                engine.RecognizeAsyncStop();
                engine.EmulateRecognize("STOP LISTENING");
            }
        }

        private void Engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e) {
            switch (e.Result.Text) {
                case "STOP LISTENING":
                    txtInput.Text = "Say \"Hello\" To Give Any Command";
                    listening = false;
                    btnListen.Text = "Start Listening";
                    listenAlways.RecognizeAsync(RecognizeMode.Multiple);
                    engine.RecognizeAsyncStop();
                    break;
                case "TERMINATE":
                    System.Environment.Exit(0);
                    break;
                case "WHAT IS THE TIME":
                    assistant.SpeakAsync(DateTime.Now.ToLongTimeString());
                    break;
                default:
                    switch(e.Result.Words[0].Text) {
                        case "OPEN":
                            switch(e.Result.Words[1].Text) {
                                case "MYCOMPUTER":
                                    System.Diagnostics.Process.Start("explorer.exe", Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));    
                                    break;
                                default:
                                    System.Diagnostics.Process.Start(e.Result.Words[1].Text + ".exe");
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }
    }
}


