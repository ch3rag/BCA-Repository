using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using MyControls;
namespace MyMediaPlayer {
    public partial class frmMain : Form {

        OpenFileDialog dlg = new OpenFileDialog() {
            Filter =
                "Windows Media formats (.asf, .wma, .wmv, .wm) | *.asf; *.wma; *.wmv; *.wm | " +
                "Windows Media Metafiles (.asx, .wax, .wvx, .wmx, .wpl) | *.asx; *.wax; *.wvx; *.wmx; *.wpl | " +
                "Microsoft Digital Video Recording (.dvr-ms) | *.dvr-ms | " +
                "Windows Media Download Package (.wmd) | *.wmd | " +
                "Audio Visual Interleave (.avi) | *.avi | " +
                "Moving Pictures Experts Group (.mpg, .mpeg, .m1v, .mp2, .mp3, .mpa, .mpe, .m3u) | *.mpg; *.mpeg; *.m1v; *.mp2; *.mp3; *.mpa; *.mpe; *.m3u | " +
                "Musical Instrument Digital Interface (.mid, .midi, .rmi) | *.mid; *.midi; *.rmi | " +
                "Audio Interchange File Format (.aif, .aifc, .aiff) | *.aif; *.aifc; *.aiff |  " +
                "Sun Microsystems and NeXT (.au, .snd) | *.au; *.snd; |" +
                "Audio for Windows (.wav) | *.wav | " +
                "CD Audio Track (.cda) | *.cda | " +
                "Indeo Video Technology (.ivf) | *.ivf | " +
                "Windows Media Player Skins (.wmz, .wms) | *.wmz; *.wms; | " +
                "QuickTime Movie file (.mov) | *.mov | MP4 Audio file (.m4a) | *.m4a | " +
                "MP4 Video file (.mp4, .m4v, .mp4v, .3g2, .3gp2, .3gp, .3gpp) | *.mp4; *.m4v; *.mp4v; *.3g2; *.3gp2; *.3gp; *.3gpp | " +
                "Windows audio file (.aac, .adt, .adts) | *.aac; *.adt; *.adts | " +
                "MPEG-2 TS Video file (.m2ts) | *.m2ts | " +
                "Free Lossless Audio Codec (.flac) | *.flac",
            FilterIndex = 16
        };

        WMPLib.IWMPPlaylist currentPlayList;
        Timer seekUpdate = new Timer() {
            Interval = 1000
        };
        AxWindowsMediaPlayer player;
        HScrollBar seeker = new HScrollBar() {
            Dock = DockStyle.Fill,
            Maximum = 1000,
            Minimum = 0,
        };
        HScrollBar volume = new HScrollBar() {
            Width = 100,
            Maximum = 100,
            Minimum = 0,
            Margin = new Padding(15)
        };
        Label lblElapsed = new Label() {
            Text = "--:--",
            AutoSize = true
        };
        Label lblDuration = new Label() {
            Text = "--:--",
            AutoSize = true
        };

        Button btnPlay, btnPause, btnStop, btnNext, btnPrevious, btnFastForward, btnRewind, btnFullScreen, btnScreenShot, btnPlayList;
        Image imgMute = Image.FromFile(Environment.CurrentDirectory + "\\Icons\\mute.png");
        Image imgVolume = Image.FromFile(Environment.CurrentDirectory + "\\Icons\\volume.png");
        ListBox playlist;
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            seeker.Scroll += Seeker_Scroll;
            seekUpdate.Tick += SeekUpdate_Tick;
            volume.Scroll += Volume_Scroll;
            seekUpdate.Start();
            TableLayoutPanel mainPanel = new TableLayoutPanel() {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1,
                AutoSize = true
            };

            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            TableLayoutPanel controlPanel = new TableLayoutPanel() {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1,
                AutoSize = true
            };

            controlPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            controlPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            TableLayoutPanel seekPanel = new TableLayoutPanel() {
                RowCount = 1,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            seekPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            seekPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            seekPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            seekPanel.Controls.Add(lblElapsed, 0, 0);
            seekPanel.Controls.Add(seeker, 1, 0);
            seekPanel.Controls.Add(lblDuration, 2, 0);
            controlPanel.Controls.Add(seekPanel, 0, 0);

            Text = "My Media Player";
            MainMenu mainMenu = new MainMenu();
            MenuItem fileMenu = new MenuItem("&Media");
            MenuItem openMenu = new MenuItem("Open File", OnClickOpenMenu, Shortcut.CtrlO);
            MenuItem openMultipleFiles = new MenuItem("Open Multiple Files", OnClickOpenMultipleFilesMenu);
            fileMenu.MenuItems.Add(openMenu);
            fileMenu.MenuItems.Add(openMultipleFiles);
            mainMenu.MenuItems.Add(fileMenu);

            this.Menu = mainMenu;

            player = new AxWindowsMediaPlayer() {
                Dock = DockStyle.Fill
            };


            TableLayoutPanel playerPanel = new TableLayoutPanel() {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));

            playlist = new ListBox() {
                Dock = DockStyle.Fill
            };
            Panel playerContainer = new Panel() { Dock = DockStyle.Fill };
            playerContainer.Controls.Add(player);
            playerPanel.Controls.Add(playerContainer, 0, 0);
            playerPanel.Controls.Add(playlist, 1, 0);

            mainPanel.Controls.Add(playerPanel, 0, 0);
            mainPanel.Controls.Add(controlPanel, 0, 1);

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
            };

            TableLayoutPanel buttonPanelContainer = new TableLayoutPanel() {
                RowCount = 1,
                ColumnCount = 2,
                AutoSize = true,
                Dock = DockStyle.Fill,
            };

            buttonPanelContainer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            

            controlPanel.Controls.Add(buttonPanelContainer, 0, 1);

            FlowLayoutPanel volumePanel = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill,
                AutoSize = true,
            };

            volumePanel.Controls.Add(volume);
            Button btnVolume = CreateIconButton(45, 45, "\\Icons\\volume.png", OnClickVolumeButton);
            volumePanel.Controls.Add(btnVolume);

            btnPlay = CreateIconButton(45, 45, "\\Icons\\play.png", OnClickPlayButton, false);
            btnPause = CreateIconButton(45, 45, "\\Icons\\pause.png", OnClickPauseButton, false);
            btnStop = CreateIconButton(45, 45, "\\Icons\\stop.png", OnClickStopButton, false);
            btnPrevious = CreateIconButton(45, 45, "\\Icons\\prev.png", OnClickPreviousButton, false);
            btnRewind = CreateIconButton(45, 45, "\\Icons\\rewind.png", OnClickRewindButton, false);
            btnFastForward = CreateIconButton(45, 45, "\\Icons\\ff.png", OnClickFastForwardButton, false);
            btnNext = CreateIconButton(45, 45, "\\Icons\\next.png", OnClickNextButton, false);
            btnFullScreen = CreateIconButton(45, 45, "\\Icons\\fullscreen.png", OnClickFullScreenButton,false);
            btnScreenShot = CreateIconButton(45, 45, "\\Icons\\ss.png", OnClickScreenShotButton, false);


            buttonPanel.Controls.Add(btnPlay);
            buttonPanel.Controls.Add(btnPause);
            buttonPanel.Controls.Add(btnStop);
            buttonPanel.Controls.Add(btnPrevious);
            buttonPanel.Controls.Add(btnRewind);
            buttonPanel.Controls.Add(btnFastForward);
            buttonPanel.Controls.Add(btnNext);
            buttonPanel.Controls.Add(btnPlayList);
            buttonPanel.Controls.Add(btnFullScreen);
            buttonPanel.Controls.Add(btnScreenShot);
            buttonPanelContainer.Controls.Add(buttonPanel, 0, 0);
            buttonPanelContainer.Controls.Add(volumePanel, 1, 0);
            this.Controls.Add(mainPanel);
            player.uiMode = "none";
            currentPlayList = player.playlistCollection.newPlaylist("Current");
            player.currentPlaylist = currentPlayList;
            playlist.SelectedIndexChanged += Playlist_SelectedIndexChanged;
            player.Ctlenabled = false;
            player.settings.volume = 50;
            volume.Value = 50;
        }

        private void OnClickOpenMultipleFilesMenu(object sender, EventArgs e) {
            dlg.Multiselect = true;
            if(dlg.ShowDialog() == DialogResult.OK) {
                foreach(string file in dlg.FileNames) {
                    AddAndPlay(file);
                }
            }
        }

        private void Playlist_SelectedIndexChanged(object sender, EventArgs e) {
            player.Ctlcontrols.playItem(player.currentPlaylist.Item[playlist.SelectedIndex]);
        }

        private void Volume_Scroll(object sender, ScrollEventArgs e) {
            player.settings.volume = volume.Value;
        }

        private void Seeker_Scroll(object sender, ScrollEventArgs e) {
            if((player.playState == WMPLib.WMPPlayState.wmppsPlaying)) {
                if (player.Ctlcontrols.currentItem.duration > 0)
                    player.Ctlcontrols.currentPosition = (((float)seeker.Value / 1000) * player.Ctlcontrols.currentItem.duration);
            }
        }

        private void SeekUpdate_Tick(object sender, EventArgs e) {
            if((player.playState == WMPLib.WMPPlayState.wmppsPlaying)) {
                if(player.Ctlcontrols.currentItem.duration > 0)
                    seeker.Value = (int)((1000 / player.Ctlcontrols.currentItem.duration) * player.Ctlcontrols.currentPosition);
                lblElapsed.Text = player.Ctlcontrols.currentPositionString;
                lblDuration.Text = player.Ctlcontrols.currentItem.durationString;
            }
        }

        private void OnClickVolumeButton(object sender, EventArgs e) {
            Button btn = sender as Button;
            if(!player.settings.mute) {
                btn.Image = imgMute;
                volume.Enabled = false;
                player.settings.mute = true;
            } else {
                btn.Image = imgVolume;
                volume.Enabled = true;
                player.settings.mute = false;
            }
        }
        private void OnClickPlayButton(object sender, EventArgs e) {
            if(!(player.playState == WMPLib.WMPPlayState.wmppsPlaying)) {
                player.Ctlcontrols.play();
                Disable(btnPlay);
                Enable(btnPause, btnStop, btnFastForward, btnRewind, btnScreenShot);
            }
        }
        private void OnClickPauseButton(object sender, EventArgs e) {
            player.Ctlcontrols.pause();
            Disable(btnPause, btnFastForward, btnRewind);
            Enable(btnPlay);
        }
        private void OnClickStopButton(object sender, EventArgs e) {
            player.Ctlcontrols.stop();
            Disable(btnStop, btnPause, btnFastForward, btnRewind, btnScreenShot, btnFullScreen);
            Enable(btnPlay);
            lblElapsed.Text = "--:--";
            lblDuration.Text = "--:--";
        }

        private void OnClickNextButton(object sender, EventArgs e) {
            player.Ctlcontrols.next();
        }
        private void OnClickPreviousButton(object sender, EventArgs e) {
            player.Ctlcontrols.previous();
        }
        private void OnClickFastForwardButton(object sender, EventArgs e) {
            if ((player.playState == WMPLib.WMPPlayState.wmppsPlaying)) {
                player.Ctlcontrols.fastForward();
                Disable(btnFastForward, btnScreenShot);
                Enable(btnRewind);
            }
        }
        private void OnClickRewindButton(object sender, EventArgs e) {
            if ((player.playState == WMPLib.WMPPlayState.wmppsPlaying)) {
                player.Ctlcontrols.fastReverse();
                Disable(btnRewind, btnScreenShot);
                Enable(btnFastForward);
            }
        }
        private void OnClickFullScreenButton(object sender, EventArgs e) {
            player.fullScreen = true;
        }
        private void OnClickScreenShotButton(object sender, EventArgs e) {
            if ((player.playState == WMPLib.WMPPlayState.wmppsPlaying)) {
                OnClickPauseButton(sender, e);
                SaveFileDialog dlg = new SaveFileDialog() {
                    Filter = "Bitmap Image (*.bmp) | *.bmp "
                };
                if(dlg.ShowDialog() == DialogResult.OK) {
                    CreateBitmap().Save(dlg.FileName);
                }
            }
        }

        private Bitmap CreateBitmap() {
            Bitmap bitmap = new Bitmap(player.Width, player.Height);
            player.Update();
            using (Graphics g = Graphics.FromImage(bitmap)) {
                g.CopyFromScreen(player.PointToScreen(Point.Empty), Point.Empty, new Size(player.Width - 5, player.Height - 5));
            }
            return bitmap;
        }

        private void OnClickOpenMenu(object sender, EventArgs e) {
              
            if(dlg.ShowDialog() == DialogResult.OK) {
                AddAndPlay(dlg.FileName);
            }
        }

        private void AddAndPlay(string fileName) {
            WMPLib.IWMPMedia mediaItem = player.newMedia(fileName);
            currentPlayList.appendItem(mediaItem);
            playlist.Items.Add(System.IO.Path.GetFileName(fileName));
            if (!(player.playState == WMPLib.WMPPlayState.wmppsPlaying)) {
                player.Ctlcontrols.play();
            }
            Disable(btnPlay);
            Enable(btnPause, btnStop, btnFullScreen, btnFastForward, btnRewind, btnScreenShot, btnNext, btnPrevious);
            player.Ctlcontrols.playItem(player.currentPlaylist.Item[player.currentPlaylist.count - 1]);
        }

        
        private Button CreateIconButton(int width, int height, string path, EventHandler handler, bool isEnabled = true) {
            
            Button button = new Button() {
                Width = width,
                Height = height,
                Image = Image.FromFile(Environment.CurrentDirectory + path),
                Enabled = isEnabled
            };
            button.Click += handler;
            return button;
        }

        private void Enable(params Control[] controls) {
            foreach (Control control in controls) {
                control.Enabled = true;
            }
        }
        private void Disable(params Control[] controls) {
            foreach (Control control in controls) {
                control.Enabled = false;
            }
        }
    }
}
