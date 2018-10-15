VERSION 5.00
Object = "{48E59290-9880-11CF-9754-00AA00C00908}#1.0#0"; "MSINET.OCX"
Object = "{0D452EE1-E08F-101A-852E-02608C4D0BB4}#2.0#0"; "FM20.DLL"
Begin VB.Form frmMain 
   Caption         =   "Web Search"
   ClientHeight    =   7530
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   9930
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   14.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   ScaleHeight     =   7530
   ScaleWidth      =   9930
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox txtInput 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   60
      TabIndex        =   1
      Top             =   1080
      Width           =   8595
   End
   Begin InetCtlsObjects.Inet iNet 
      Left            =   9300
      Top             =   60
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
      Protocol        =   5
      RemotePort      =   443
      URL             =   "https://"
   End
   Begin VB.CommandButton cmdConnect 
      Caption         =   "Search"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   8760
      TabIndex        =   0
      Top             =   1080
      Width           =   1095
   End
   Begin MSForms.TextBox txtData 
      Height          =   6015
      Left            =   60
      TabIndex        =   3
      Top             =   1500
      Width           =   9795
      VariousPropertyBits=   -1400879077
      ScrollBars      =   1
      Size            =   "17277;10610"
      FontName        =   "Arial"
      FontHeight      =   285
      FontCharSet     =   0
      FontPitchAndFamily=   2
   End
   Begin VB.Label lblTitile 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "Web  Search"
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   21.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   675
      Left            =   600
      TabIndex        =   2
      Top             =   240
      Width           =   8415
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Function hexToDec(hex As String) As Long
    Dim dec As Long
    pow = 1
    hex = Trim(hex)
    For i = Len(hex) To 1 Step -1
        Char = Mid(hex, i, 1)
        If IsNumeric(Char) Then
            dec = dec + pow * Val(Char)
        Else
            dec = dec + (Asc(Char) - 87) * pow
        End If
        pow = pow * 16
    Next i
    hexToDec = dec
End Function
Private Sub cmdConnect_Click()
    Dim query As String
    Dim document As String
    iNet.Cancel
    txtData.Text = ""
    query = Replace(txtInput.Text, " ", "%20")
    document = iNet.OpenURL(generateRequest(query))
    parse document
End Sub

Private Function parse(str As String)
    Dim i As Integer
    Dim code As String
    i = InStr(InStr(InStr(1, str, "[") + 1, str, "[") + 1, str, "[") + 2
    str = Mid(str, i, InStr(i, str, """]") - i)
    For i = 1 To Len(str)
        Char = Mid(str, i, 1)
        If Char = "\" Then
            If Mid(str, i + 1, 1) = "u" Then
                code = Mid(str, i + 2, 4)
                txtData.Text = txtData.Text + ChrW((hexToDec(code)))
                i = i + 5
            End If
        Else
            txtData.Text = txtData.Text + Char
        End If
    Next i
End Function

Private Function generateRequest(query As String) As String
    Dim url As String
    url = url & "en.wikipedia.org/w/api.php"
    url = url & "?action=opensearch"
    url = url & "&search=" & query
    url = url & "&limit=1"
    url = url & "&namespace=0"
    url = url & "&format=json"
    generateRequest = url
End Function


