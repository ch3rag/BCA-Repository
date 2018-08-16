VERSION 5.00
Begin VB.Form dlgError 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Error"
   ClientHeight    =   1425
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   3765
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1425
   ScaleWidth      =   3765
   ShowInTaskbar   =   0   'False
   Begin VB.PictureBox Picture1 
      BorderStyle     =   0  'None
      Height          =   615
      Left            =   120
      Picture         =   "dlgError.frx":0000
      ScaleHeight     =   615
      ScaleWidth      =   615
      TabIndex        =   2
      Top             =   120
      Width           =   615
   End
   Begin VB.CommandButton OKButton 
      Caption         =   "OK"
      Height          =   375
      Left            =   1275
      TabIndex        =   0
      Top             =   840
      Width           =   1215
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      Caption         =   "Invalid Username or Password!"
      Height          =   495
      Left            =   120
      TabIndex        =   1
      Top             =   240
      Width           =   3735
   End
End
Attribute VB_Name = "dlgError"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub OKButton_Click()
    dlgError.Hide
    frmLogin.reset
    frmLogin.Show
End Sub

