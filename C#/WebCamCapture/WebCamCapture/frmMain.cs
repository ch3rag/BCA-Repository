using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WebCamCapture {
    public partial class frmMain : Form {

        ComboBox cmbDeviceList = new ComboBox();
        PictureBox pBox = new PictureBox() {
            Dock = DockStyle.Fill
        };
        Bitmap frame;
        VideoCaptureDevice device;
        FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        ListView lstImages = new ListView() {
            Dock = DockStyle.Fill,
            View = View.LargeIcon,
        };
        Button btnConnect = new Button() {
            Text = "Connect"
        };
        Button btnDisconnect = new Button() {
            Text = "Disconnect",
            Enabled = false
        };
        Button btnCapture = new Button() {
            Text = "Capture",
            Enabled = false
        };
        bool paused;

        public frmMain() {
            InitializeComponent();
        }
        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            pBox.Image = null;
        }
        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            System.Environment.Exit(0);
        }
        private void frmMain_Load(object sender, EventArgs e) {

            LoadGallary();
            btnConnect.Click += ConnectButton_Click;
            btnCapture.Click += CaptureButton_Click;
            btnDisconnect.Click += DisconnectButton_Click;

            Label lblDeviceList = new Label {
                Text = "Device List",
                TextAlign = ContentAlignment.MiddleCenter
            };     
            foreach (FilterInfo device in videoDevices) {
                cmbDeviceList.Items.Add(device.Name);
            }

            Panel mainPanel = new TableLayoutPanel() {
                Padding = new Padding(5),
                Dock = DockStyle.Fill
            };
            TabControl tabControl = new TabControl() {
                Dock = DockStyle.Fill
            };
            TabPage cameraPage = new TabPage() {
                Text = "Camera"
            };
            FlowLayoutPanel menuBar = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Top,
                BackColor = Color.AliceBlue,
                AutoSize = true,
                Padding = new Padding(20)
            };
            TabPage gallaryPage = new TabPage() {
                Text = "Gallary"
            };

            tabControl.TabPages.Add(cameraPage);
            tabControl.TabPages.Add(gallaryPage);
            menuBar.Controls.Add(lblDeviceList);
            menuBar.Controls.Add(cmbDeviceList);
            menuBar.Controls.Add(btnConnect);
            menuBar.Controls.Add(btnDisconnect);
            menuBar.Controls.Add(btnCapture);

            TableLayoutPanel cameraPageTable = new TableLayoutPanel() {
                ColumnCount = 1,
                RowCount = 2,
                Dock = DockStyle.Fill
            };
            cameraPageTable.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            cameraPageTable.RowStyles.Add(new RowStyle(SizeType.Percent, 80));
            cameraPageTable.Controls.Add(menuBar, 0, 0);
            cameraPageTable.Controls.Add(pBox, 0, 1);
            cameraPage.Controls.Add(cameraPageTable);
            gallaryPage.Controls.Add(lstImages);
            mainPanel.Controls.Add(tabControl);
            this.Controls.Add(mainPanel);
            cmbDeviceList.SelectedIndex = 0;
        }
        private void DisconnectButton_Click(object sender, EventArgs e) {
            btnCapture.Enabled = false;
            device.NewFrame -= Device_NewFrame;
            btnConnect.Enabled = true;
            pBox.Image = null;
            btnDisconnect.Enabled = false;
        }
        private void CaptureButton_Click(object sender, EventArgs e) {
            try {
                frame.Save("./gallary/" + DateTime.Now.Millisecond + ".bmp");
                paused = true;
                DrawImage(frame);
                if (MessageBox.Show("Photo Captured Successfully", "Webcam", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) {
                    paused = false;
                }
            } catch (Exception) {
                MessageBox.Show("Error While Saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ConnectButton_Click(object sender, EventArgs e) {
            try {
                device = new VideoCaptureDevice(videoDevices[this.cmbDeviceList.SelectedIndex].MonikerString);
                device.NewFrame += Device_NewFrame;
                device.Start();
                btnCapture.Enabled = true;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
            } catch(Exception) {
                MessageBox.Show("Error while connecting to the device.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs) {
            if (!paused) {
                this.frame = (Bitmap)eventArgs.Frame.Clone();
                DrawImage(frame);
            }
        }
        private void DrawImage(Bitmap image) {
            Graphics g = pBox.CreateGraphics();
            g.DrawImage(image, (pBox.Width - image.Width) / 2, (pBox.Height - image.Height) / 2);
        }
        private void LoadGallary() {
            DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory + @"\gallary");
            if (!directory.Exists) directory.Create();
            int index = 0;
            lstImages.LargeImageList = new ImageList() {
                ImageSize = new Size(160, 160)
            };
            foreach (FileInfo info in directory.GetFiles()) {
                if(info.Extension == ".bmp") {
                    lstImages.LargeImageList.Images.Add(Image.FromFile(info.FullName));
                    lstImages.Items.Add(info.Name, index);
                    index++;
                }
            }
            lstImages.LargeImageList.ImageSize = new Size(160, 160);
        }
    }
}
