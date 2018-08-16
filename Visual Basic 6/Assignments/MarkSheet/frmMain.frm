VERSION 5.00
Begin VB.Form frmMain 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Marksheet Creator"
   ClientHeight    =   6840
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   6945
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6840
   ScaleWidth      =   6945
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame fmeDetails 
      Caption         =   "Details"
      Height          =   2535
      Left            =   120
      TabIndex        =   21
      Top             =   120
      Width           =   6735
      Begin VB.TextBox txtID 
         Height          =   285
         Left            =   1440
         TabIndex        =   1
         Top             =   360
         Width           =   1215
      End
      Begin VB.TextBox txtName 
         Height          =   285
         Left            =   1440
         TabIndex        =   2
         Top             =   840
         Width           =   4935
      End
      Begin VB.TextBox txtFather 
         Height          =   285
         Left            =   1440
         TabIndex        =   3
         Top             =   1320
         Width           =   4935
      End
      Begin VB.ComboBox cmbClass 
         Height          =   315
         Left            =   1440
         TabIndex        =   4
         Top             =   1920
         Width           =   1575
      End
      Begin VB.Label Label1 
         Caption         =   "Student I.D."
         Height          =   255
         Left            =   120
         TabIndex        =   25
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label lblStuName 
         Caption         =   "Student's Name"
         Height          =   495
         Left            =   120
         TabIndex        =   24
         Top             =   840
         Width           =   1215
      End
      Begin VB.Label lblFatherName 
         Caption         =   "Father's Name"
         Height          =   495
         Left            =   120
         TabIndex        =   23
         Top             =   1320
         Width           =   1215
      End
      Begin VB.Label lblClass 
         Caption         =   "Class"
         Height          =   495
         Left            =   120
         TabIndex        =   22
         Top             =   1920
         Width           =   1215
      End
   End
   Begin VB.CommandButton cmdSubmit 
      Caption         =   "&Submit"
      Height          =   615
      Left            =   2520
      TabIndex        =   10
      Top             =   6120
      Width           =   1815
   End
   Begin VB.Frame fmeMarks 
      Caption         =   "Marks"
      Height          =   2775
      Left            =   120
      TabIndex        =   0
      Top             =   3000
      Width           =   6735
      Begin VB.TextBox txtSub5 
         Height          =   285
         Left            =   1680
         TabIndex        =   9
         Top             =   2280
         Width           =   1215
      End
      Begin VB.TextBox txtSub4 
         Height          =   285
         Left            =   1680
         TabIndex        =   8
         Top             =   1800
         Width           =   1215
      End
      Begin VB.TextBox txtSub3 
         Height          =   285
         Left            =   1680
         TabIndex        =   7
         Top             =   1320
         Width           =   1215
      End
      Begin VB.TextBox txtSub2 
         Height          =   285
         Left            =   1680
         TabIndex        =   6
         Top             =   840
         Width           =   1215
      End
      Begin VB.TextBox txtSub1 
         Height          =   285
         Left            =   1680
         TabIndex        =   5
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label Label10 
         Caption         =   "/100"
         Height          =   255
         Left            =   3000
         TabIndex        =   20
         Top             =   2280
         Width           =   855
      End
      Begin VB.Label Label9 
         Caption         =   "/100"
         Height          =   255
         Left            =   3000
         TabIndex        =   19
         Top             =   1800
         Width           =   855
      End
      Begin VB.Label Label8 
         Caption         =   "/100"
         Height          =   255
         Left            =   3000
         TabIndex        =   18
         Top             =   1320
         Width           =   855
      End
      Begin VB.Label Label7 
         Caption         =   "/100"
         Height          =   255
         Left            =   3000
         TabIndex        =   17
         Top             =   840
         Width           =   855
      End
      Begin VB.Label Label6 
         Caption         =   "/100"
         Height          =   255
         Left            =   3000
         TabIndex        =   16
         Top             =   360
         Width           =   855
      End
      Begin VB.Label lblSub5 
         Caption         =   "Subject 5"
         Height          =   375
         Left            =   120
         TabIndex        =   15
         Top             =   2280
         Width           =   1455
      End
      Begin VB.Label lblSub4 
         Caption         =   "Subject 4"
         Height          =   375
         Left            =   120
         TabIndex        =   14
         Top             =   1800
         Width           =   1455
      End
      Begin VB.Label lblSub3 
         Caption         =   "Subject 3"
         Height          =   375
         Left            =   120
         TabIndex        =   13
         Top             =   1320
         Width           =   1455
      End
      Begin VB.Label lblSub2 
         Caption         =   "Subject 2"
         Height          =   375
         Left            =   120
         TabIndex        =   12
         Top             =   840
         Width           =   1455
      End
      Begin VB.Label lblSub1 
         Caption         =   "Subject 1"
         Height          =   375
         Left            =   120
         TabIndex        =   11
         Top             =   360
         Width           =   1455
      End
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdSubmit_Click()

    getValues
    frmMain.Hide
    Load frmMarkSheet
    
End Sub

Private Sub getValues()

    stuID = txtID.Text
    stuName = txtName.Text
    stuFather = txtFather.Text
    Class = cmbClass.Text
    sub1 = Val(txtSub1.Text)
    sub2 = Val(txtSub2.Text)
    sub3 = Val(txtSub3.Text)
    sub4 = Val(txtSub4.Text)
    sub5 = Val(txtSub5.Text)
    
End Sub




Private Sub Form_Load()
    Unload frmLogin
    Load frmMain
    frmMain.Show
    cmbClass.Clear
    cmbClass.AddItem ("B.C.A")
    cmbClass.AddItem ("B.Sc")
    cmbClass.AddItem ("B.Com.")
    cmbClass.AddItem ("B.A.")
    
End Sub

Private Sub txtID_KeyPress(KeyAscii As Integer)
    If ((KeyAscii >= vbKey0 And KeyAscii <= vbKey9) Or KeyAscii = vbKeyBack) Then
        Exit Sub
    Else
        KeyAscii = 0
        Beep
    End If
End Sub


Private Sub txtSub1_Change()
    If (Val(txtSub1.Text) < 0 Or Val(txtSub1.Text) > 100) Then
        txtSub1.Text = ""
    End If
End Sub
Private Sub txtSub2_Change()
    If (Val(txtSub2.Text) < 0 Or Val(txtSub2.Text) > 100) Then
        txtSub2.Text = ""
    End If
End Sub
Private Sub txtSub3_Change()
    If (Val(txtSub3.Text) < 0 Or Val(txtSub3.Text) > 100) Then
        txtSub3.Text = ""
    End If
End Sub
Private Sub txtSub4_Change()
    If (Val(txtSub4.Text) < 0 Or Val(txtSub4.Text) > 100) Then
        txtSub4.Text = ""
    End If
End Sub
Private Sub txtSub5_Change()
    If (Val(txtSub5.Text) < 0 Or Val(txtSub5.Text) > 100) Then
        txtSub5.Text = ""
    End If
End Sub
Private Sub txtSub2_KeyPress(KeyAscii As Integer)
    If ((KeyAscii >= vbKey0 And KeyAscii <= vbKey9) Or KeyAscii = vbKeyBack) Then
        Exit Sub
    Else
        KeyAscii = 0
    End If
End Sub
Private Sub txtSub3_KeyPress(KeyAscii As Integer)
    If ((KeyAscii >= vbKey0 And KeyAscii <= vbKey9) Or KeyAscii = vbKeyBack) Then
        Exit Sub
    Else
        KeyAscii = 0
    End If
End Sub

Private Sub txtSub4_KeyPress(KeyAscii As Integer)
    If ((KeyAscii >= vbKey0 And KeyAscii <= vbKey9) Or KeyAscii = vbKeyBack) Then
        Exit Sub
    Else
        KeyAscii = 0
    End If
End Sub

Private Sub txtSub5_KeyPress(KeyAscii As Integer)
    If ((KeyAscii >= vbKey0 And KeyAscii <= vbKey9) Or KeyAscii = vbKeyBack) Then
        Exit Sub
    Else
        KeyAscii = 0
    End If
End Sub

