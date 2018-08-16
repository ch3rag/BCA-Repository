VERSION 5.00
Begin VB.Form frmMarkSheet 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Marksheet"
   ClientHeight    =   7065
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   6930
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7065
   ScaleWidth      =   6930
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   495
      Left            =   2640
      TabIndex        =   17
      Top             =   6480
      Width           =   1215
   End
   Begin VB.Frame fmeMarks 
      Caption         =   "Marks"
      Height          =   2415
      Left            =   120
      TabIndex        =   6
      Top             =   3960
      Width           =   6735
      Begin VB.Label lblPercent 
         Caption         =   "100.00%"
         Height          =   255
         Left            =   5880
         TabIndex        =   31
         Top             =   960
         Width           =   615
      End
      Begin VB.Label lblTotal 
         Alignment       =   1  'Right Justify
         Caption         =   "500"
         Height          =   255
         Left            =   5760
         TabIndex        =   30
         Top             =   480
         Width           =   375
      End
      Begin VB.Label Label5 
         Caption         =   "/500"
         Height          =   255
         Left            =   6120
         TabIndex        =   29
         Top             =   480
         Width           =   375
      End
      Begin VB.Shape Shape1 
         Height          =   975
         Left            =   3840
         Shape           =   4  'Rounded Rectangle
         Top             =   360
         Width           =   2775
      End
      Begin VB.Line Line1 
         X1              =   3600
         X2              =   3600
         Y1              =   360
         Y2              =   2160
      End
      Begin VB.Label Label3 
         Caption         =   "Total"
         Height          =   495
         Left            =   3960
         TabIndex        =   28
         Top             =   480
         Width           =   1215
      End
      Begin VB.Label Label4 
         Caption         =   "Percentage"
         Height          =   495
         Left            =   3960
         TabIndex        =   27
         Top             =   960
         Width           =   1215
      End
      Begin VB.Label lblSub1Show 
         Alignment       =   1  'Right Justify
         Caption         =   "100"
         Height          =   255
         Left            =   2640
         TabIndex        =   26
         Top             =   480
         Width           =   375
      End
      Begin VB.Label lblSub2Show 
         Alignment       =   1  'Right Justify
         Caption         =   "100"
         Height          =   255
         Left            =   2640
         TabIndex        =   25
         Top             =   840
         Width           =   375
      End
      Begin VB.Label lblSub3Show 
         Alignment       =   1  'Right Justify
         Caption         =   "100"
         Height          =   255
         Left            =   2640
         TabIndex        =   24
         Top             =   1200
         Width           =   375
      End
      Begin VB.Label lblSub4Show 
         Alignment       =   1  'Right Justify
         Caption         =   "100"
         Height          =   255
         Left            =   2640
         TabIndex        =   23
         Top             =   1560
         Width           =   375
      End
      Begin VB.Label lblSub5Show 
         Alignment       =   1  'Right Justify
         Caption         =   "100"
         Height          =   255
         Left            =   2640
         TabIndex        =   22
         Top             =   1920
         Width           =   375
      End
      Begin VB.Label lblSub1 
         Caption         =   "Subject 1"
         Height          =   375
         Left            =   120
         TabIndex        =   16
         Top             =   480
         Width           =   1455
      End
      Begin VB.Label lblSub2 
         Caption         =   "Subject 2"
         Height          =   375
         Left            =   120
         TabIndex        =   15
         Top             =   840
         Width           =   1455
      End
      Begin VB.Label lblSub3 
         Caption         =   "Subject 3"
         Height          =   375
         Left            =   120
         TabIndex        =   14
         Top             =   1200
         Width           =   1455
      End
      Begin VB.Label lblSub4 
         Caption         =   "Subject 4"
         Height          =   375
         Left            =   120
         TabIndex        =   13
         Top             =   1560
         Width           =   1455
      End
      Begin VB.Label lblSub5 
         Caption         =   "Subject 5"
         Height          =   375
         Left            =   120
         TabIndex        =   12
         Top             =   1920
         Width           =   1455
      End
      Begin VB.Label Label6 
         Caption         =   "/100"
         Height          =   255
         Left            =   3000
         TabIndex        =   11
         Top             =   480
         Width           =   855
      End
      Begin VB.Label Label7 
         Caption         =   "/100"
         Height          =   255
         Left            =   3000
         TabIndex        =   10
         Top             =   840
         Width           =   855
      End
      Begin VB.Label Label8 
         Caption         =   "/100"
         Height          =   255
         Left            =   3000
         TabIndex        =   9
         Top             =   1200
         Width           =   855
      End
      Begin VB.Label Label9 
         Caption         =   "/100"
         Height          =   255
         Left            =   3000
         TabIndex        =   8
         Top             =   1560
         Width           =   855
      End
      Begin VB.Label Label10 
         Caption         =   "/100"
         Height          =   255
         Left            =   3000
         TabIndex        =   7
         Top             =   1920
         Width           =   855
      End
   End
   Begin VB.Frame fmeDetails 
      Caption         =   "Details"
      Height          =   2415
      Left            =   120
      TabIndex        =   1
      Top             =   1440
      Width           =   6735
      Begin VB.Label lblClassShow 
         Caption         =   "###"
         Height          =   375
         Left            =   1800
         TabIndex        =   21
         Top             =   1800
         Width           =   1215
      End
      Begin VB.Label lblFatherShow 
         Caption         =   "###"
         Height          =   495
         Left            =   1800
         TabIndex        =   20
         Top             =   1320
         Width           =   4695
      End
      Begin VB.Label lblNameShow 
         Caption         =   "###"
         Height          =   495
         Left            =   1800
         TabIndex        =   19
         Top             =   840
         Width           =   4815
      End
      Begin VB.Label lblIDShow 
         Caption         =   "t###"
         Height          =   255
         Left            =   1800
         TabIndex        =   18
         Top             =   360
         Width           =   4695
      End
      Begin VB.Label lblClass 
         Caption         =   "Class"
         Height          =   375
         Left            =   120
         TabIndex        =   5
         Top             =   1800
         Width           =   1215
      End
      Begin VB.Label lblFatherName 
         Caption         =   "Father's Name"
         Height          =   495
         Left            =   120
         TabIndex        =   4
         Top             =   1320
         Width           =   1215
      End
      Begin VB.Label lblStuName 
         Caption         =   "Student's Name"
         Height          =   495
         Left            =   120
         TabIndex        =   3
         Top             =   840
         Width           =   1215
      End
      Begin VB.Label Label2 
         Caption         =   "Student I.D."
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   360
         Width           =   1215
      End
   End
   Begin VB.Shape Shape2 
      BorderColor     =   &H80000006&
      BorderStyle     =   6  'Inside Solid
      Height          =   735
      Left            =   4080
      Shape           =   4  'Rounded Rectangle
      Top             =   600
      Width           =   2775
   End
   Begin VB.Line Line2 
      X1              =   2640
      X2              =   4200
      Y1              =   480
      Y2              =   480
   End
   Begin VB.Label lblTimeD 
      Caption         =   "Time"
      Height          =   255
      Left            =   4200
      TabIndex        =   35
      Top             =   960
      Width           =   975
   End
   Begin VB.Label lblTime 
      Height          =   255
      Left            =   5280
      TabIndex        =   34
      Top             =   960
      Width           =   1455
   End
   Begin VB.Label lblDate 
      Height          =   255
      Left            =   5280
      TabIndex        =   33
      Top             =   720
      Width           =   1455
   End
   Begin VB.Label lblTimeStamp 
      Caption         =   "Date "
      Height          =   255
      Left            =   4200
      TabIndex        =   32
      Top             =   720
      Width           =   975
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      Caption         =   "MarkSheet"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   0
      TabIndex        =   0
      Top             =   120
      Width           =   6855
   End
End
Attribute VB_Name = "frmMarkSheet"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub cmdExit_Click()
    End
End Sub

Private Sub Form_Load()

    lblIDShow.Caption = frmMain.txtID.Text
    lblNameShow.Caption = frmMain.txtName.Text
    lblFatherShow.Caption = frmMain.txtFather.Text
    lblClassShow.Caption = frmMain.cmbClass.Text
    lblSub1Show.Caption = frmMain.txtSub1.Text
    lblSub2Show.Caption = frmMain.txtSub2.Text
    lblSub3Show.Caption = frmMain.txtSub3.Text
    lblSub4Show.Caption = frmMain.txtSub4.Text
    lblSub5Show.Caption = frmMain.txtSub5.Text
    lblTotal.Caption = Val(frmMain.txtSub1.Text) + Val(frmMain.txtSub2.Text) + Val(frmMain.txtSub3.Text) + Val(frmMain.txtSub4.Text) + Val(frmMain.txtSub5.Text)
    lblPercent.Caption = Format(Val(lblTotal.Caption) / 500, "##0.00%")
    lblTime.Caption = Format(Now, "hh:mm:ss")
    lblDate.Caption = Format(Now, "dd/mm/yyyy")
    frmMarkSheet.Show
End Sub

