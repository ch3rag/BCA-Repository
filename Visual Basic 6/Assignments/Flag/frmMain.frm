VERSION 5.00
Begin VB.Form frmMain 
   Caption         =   "Form1"
   ClientHeight    =   4650
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   7065
   LinkTopic       =   "Form1"
   ScaleHeight     =   4650
   ScaleWidth      =   7065
   StartUpPosition =   3  'Windows Default
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Paint()
    Line (0, 0)-(frmMain.ScaleWidth - 10, frmMain.ScaleHeight / 3), RGB(255, 153, 51), BF
    Line (0, frmMain.ScaleHeight / 3)-(frmMain.ScaleWidth, 2 * frmMain.ScaleHeight / 3), vbWhite, BF
    Line (0, 2 * frmMain.ScaleHeight / 3)-(frmMain.ScaleWidth, frmMain.ScaleHeight), vbGreen, BF
    Circle (frmMain.ScaleWidth / 2, frmMain.ScaleHeight / 2), frmMain.ScaleHeight / 6, vbBlue
    X1 = frmMain.ScaleWidth / 2
    Y1 = frmMain.ScaleHeight / 2
    For i = 0 To 345 Step 15
        angle = i * ((22 / 7) / 180)
        X2 = X1 + frmMain.ScaleHeight / 6 * Cos(angle)
        Y2 = Y1 + frmMain.ScaleHeight / 6 * Sin(angle)
        Line (X1, Y1)-(X2, Y2), vbBlue
    Next i
End Sub
