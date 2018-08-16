VERSION 5.00
Begin VB.Form frmLogin 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Login"
   ClientHeight    =   3090
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   4680
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3090
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdReset 
      Caption         =   "Reset"
      Height          =   495
      Left            =   2993
      TabIndex        =   5
      Top             =   2040
      Width           =   1215
   End
   Begin VB.CommandButton cmdSubmit 
      Caption         =   "Submit"
      Height          =   495
      Left            =   473
      TabIndex        =   4
      Top             =   2040
      Width           =   1215
   End
   Begin VB.TextBox txtPassword 
      Height          =   285
      IMEMode         =   3  'DISABLE
      Left            =   1853
      PasswordChar    =   "*"
      TabIndex        =   3
      Top             =   960
      Width           =   2535
   End
   Begin VB.TextBox txtUsername 
      Height          =   285
      Left            =   1853
      TabIndex        =   2
      Top             =   240
      Width           =   2535
   End
   Begin VB.Label lblPassword 
      Caption         =   "Password"
      Height          =   495
      Left            =   240
      TabIndex        =   1
      Top             =   960
      Width           =   1215
   End
   Begin VB.Label lblUsername 
      Caption         =   "Username"
      Height          =   495
      Left            =   293
      TabIndex        =   0
      Top             =   240
      Width           =   1215
   End
End
Attribute VB_Name = "frmLogin"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub cmdReset_Click()
    reset
End Sub

Private Sub cmdSubmit_Click()
    If LCase(txtUsername.Text) = "administrator" And LCase(txtPassword.Text) = "password" Then Load frmMain Else dlgError.Show: frmLogin.Hide
End Sub

Public Sub reset()
    txtUsername.Text = ""
    txtPassword.Text = ""
End Sub
