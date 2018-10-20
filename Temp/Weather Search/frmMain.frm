VERSION 5.00
Object = "{48E59290-9880-11CF-9754-00AA00C00908}#1.0#0"; "MSINET.OCX"
Begin VB.Form frmrMain 
   BackColor       =   &H00C0C0C0&
   Caption         =   "Search"
   ClientHeight    =   6135
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   6975
   LinkTopic       =   "Form1"
   ScaleHeight     =   6135
   ScaleWidth      =   6975
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdSearch 
      Caption         =   "Search"
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   5370
      TabIndex        =   2
      Top             =   1020
      Width           =   1095
   End
   Begin VB.TextBox txtInput 
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   300
      Left            =   1170
      TabIndex        =   1
      Top             =   1020
      Width           =   4035
   End
   Begin InetCtlsObjects.Inet iNet 
      Left            =   6360
      Top             =   60
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
      Protocol        =   5
      RemotePort      =   443
      URL             =   "https://"
   End
   Begin VB.Label lblDetail 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Longitude: "
      BeginProperty Font 
         Name            =   "Lucida Console"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   315
      Index           =   7
      Left            =   375
      TabIndex        =   11
      Top             =   5520
      Width           =   2145
   End
   Begin VB.Label lblDetail 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Latitude: "
      BeginProperty Font 
         Name            =   "Lucida Console"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   315
      Index           =   6
      Left            =   375
      TabIndex        =   10
      Top             =   4980
      Width           =   6375
   End
   Begin VB.Label lblDetail 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Direction: "
      BeginProperty Font 
         Name            =   "Lucida Console"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   315
      Index           =   5
      Left            =   375
      TabIndex        =   9
      Top             =   4440
      Width           =   6210
   End
   Begin VB.Label lblDetail 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Pressure: "
      BeginProperty Font 
         Name            =   "Lucida Console"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   315
      Index           =   3
      Left            =   375
      TabIndex        =   8
      Top             =   3480
      Width           =   1950
   End
   Begin VB.Label lblDetail 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Wind: "
      BeginProperty Font 
         Name            =   "Lucida Console"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   315
      Index           =   4
      Left            =   375
      TabIndex        =   7
      Top             =   3960
      Width           =   1170
   End
   Begin VB.Label lblDetail 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Temperature: "
      BeginProperty Font 
         Name            =   "Lucida Console"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   315
      Index           =   2
      Left            =   375
      TabIndex        =   6
      Top             =   2940
      Width           =   6315
   End
   Begin VB.Label lblDetail 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Country: "
      BeginProperty Font 
         Name            =   "Lucida Console"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   315
      Index           =   1
      Left            =   375
      TabIndex        =   5
      Top             =   2460
      Width           =   6210
   End
   Begin VB.Label lblDetail 
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "City: "
      BeginProperty Font 
         Name            =   "Lucida Console"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   315
      Index           =   0
      Left            =   375
      TabIndex        =   4
      Top             =   1980
      Width           =   6210
   End
   Begin VB.Label lblCity 
      Alignment       =   2  'Center
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "City"
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   300
      Left            =   510
      TabIndex        =   3
      Top             =   1020
      Width           =   465
   End
   Begin VB.Shape shp1 
      BorderStyle     =   0  'Transparent
      DrawMode        =   8  'Xor Pen
      FillColor       =   &H008080FF&
      FillStyle       =   0  'Solid
      Height          =   255
      Left            =   1380
      Top             =   360
      Width           =   3975
   End
   Begin VB.Shape shp2 
      BorderStyle     =   0  'Transparent
      DrawMode        =   10  'Mask Pen
      FillStyle       =   0  'Solid
      Height          =   255
      Left            =   1380
      Top             =   120
      Width           =   3975
   End
   Begin VB.Label lblTitle 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Weather Search"
      BeginProperty Font 
         Name            =   "Lucida Console"
         Size            =   21.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   435
      Left            =   1575
      TabIndex        =   0
      Top             =   180
      Width           =   3585
   End
   Begin VB.Shape Shape3 
      BorderColor     =   &H80000007&
      BorderStyle     =   0  'Transparent
      FillColor       =   &H00E0E0E0&
      FillStyle       =   0  'Solid
      Height          =   735
      Left            =   390
      Top             =   840
      Width           =   6255
   End
End
Attribute VB_Name = "frmrMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim json As Collection

Private Sub cmdSearch_Click()
   lblDetail(0).Caption = "City: "
   lblDetail(1).Caption = "Country: "
   lblDetail(2).Caption = "Temperature: "
   lblDetail(3).Caption = "Pressure: "
   lblDetail(4).Caption = "Wind: "
   lblDetail(5).Caption = "Direction: "
   lblDetail(6).Caption = "Latitude: "
   lblDetail(7).Caption = "Longitude: "
    Call doSearch(txtInput.Text)
End Sub


Private Sub doSearch(query As String)
    Dim URL As String
    Dim data As String
    If query = "" Then
        Call MsgBox("No city entered!", vbOKOnly + vbCritical, "Error")
    Else
        URL = "http://api.openweathermap.org/data/2.5/weather?q=" & query & "&appid=dc24747f658480e73ae9491a9181b5d8"
        data = iNet.OpenURL(URL)
        If InStr(1, data, query, 1) = 0 Then Call MsgBox("City not found!", vbOKOnly + vbCritical, "Error"): Exit Sub
        Set json = loadJSON(data)
        Call displayData
    End If
End Sub

Private Sub displayData()
    lblDetail(0).Caption = lblDetail(0).Caption + json.Item("name")
    lblDetail(1).Caption = lblDetail(1).Caption + json.Item("sys").Item("country")
    lblDetail(2).Caption = lblDetail(2).Caption & (Val(json.Item("main").Item("temp")) - 273) & " Celsius"
    lblDetail(3).Caption = lblDetail(3).Caption + json.Item("main").Item("pressure") + " hpa"
    lblDetail(4).Caption = lblDetail(4).Caption + json.Item("wind").Item("speed") + " m/s"
    lblDetail(5).Caption = lblDetail(5).Caption + json.Item("wind").Item("deg")
    lblDetail(6).Caption = lblDetail(6).Caption + json.Item("coord").Item("lat")
    lblDetail(7).Caption = lblDetail(7).Caption + json.Item("coord").Item("lon")
End Sub


Private Function loadJSON(Str As String) As Collection
    Dim json As New Collection
    Debug.Print "INPUT STRING: " + Str
    Str = Replace(Str, """", "'")
    Set json = parseJSON(Str, json, 2)
    Set loadJSON = json
End Function

Private Sub incPointer(ByRef pointer As Integer, ByRef char As String, ByRef Str As String, Optional inc As Integer = 1)
    pointer = pointer + inc
    char = Mid(Str, pointer, 1)
End Sub

Private Function parseJSON(JSONstring As String, col As Collection, ByRef pointer As Integer, Optional arFlag As Boolean) As Collection
    Dim char As String
    Dim key As String
    Dim value As String
    
    'GET THE FIRST CHARACTER
    char = Mid(JSONstring, pointer, 1)
    
    'EXTRACT THE KEY
    If char = "'" Then
        Call incPointer(pointer, char, JSONstring)
        Do While Not char = "'"
            key = key + char
            Call incPointer(pointer, char, JSONstring)
        Loop
        'INCREMENT POINTER TO CHARACTER AFTER COLON
        Call incPointer(pointer, char, JSONstring, 2)
    End If
    
    'IF IT CURLY BRACE THEN CREATE A NEW COLLECTION OBJECT
    If char = "{" Then
        Dim newCol As New Collection
        
        'PARSE THE NESTED JSON OBJECT
        pointer = pointer + 1
        Set newCol = parseJSON(JSONstring, newCol, pointer)
        
        'ATTACH THE POINTER TO NEW COLLECTION TO IT'S KEY
        Call col.Add(newCol, key)
        
        
        'INCREMENT POINTER AFTER CLOSING CURLY BRACE
        Call incPointer(pointer, char, JSONstring)
        
        If arFlag Then Set parseJSON = col: Exit Function
        
        'IF STILL ELEMENTS LEFT THE PARSE THE REST AND EXIT ELSE EXIT
        
        If char = "," Then
            pointer = pointer + 1
            Set parseJSON = parseJSON(JSONstring, col, pointer): Exit Function
        Else
            Set parseJSON = col
            Exit Function
        End If
        
    'IF IT IS OPENING SQUARE BRACKETS THEN CREATE AN ARRAY OF COLLECTION
    ElseIf char = "[" Then
        Dim newColAr() As Collection
        Dim i  As Integer
        i = 0
        pointer = pointer + 1
        Do While Not char = "]"
            ReDim Preserve newColAr(i) As Collection
            Set newColAr(i) = New Collection
            'Debug.Print newColAr(i).Count
            Set newColAr(i) = parseJSON(JSONstring, newColAr(i), pointer, True)
            'Debug.Print newColAr(i).Count
            i = i + 1
            Call incPointer(pointer, char, JSONstring, 0)
            If char = "," Then Call incPointer(pointer, char, JSONstring, 1)
        Loop
        Call col.Add(newColAr, key)
        Call incPointer(pointer, char, JSONstring, 1)
        If char = "," Then
            pointer = pointer + 1
            Set parseJSON = parseJSON(JSONstring, col, pointer): Exit Function
        Else
            Set parseJSON = col: Exit Function
        End If
    End If
    
    'EXTRACT THE VALUE UNTIL THE START OF NEXT KEY VALUE PAIR OR UNTIL THE END OF LIST IS REACHED
    
    Do While Not (char = "," Or char = "]" Or char = "}")
        'DROP SINGLE QUOTES
        If char <> "'" Then value = value + char
        Call incPointer(pointer, char, JSONstring)
    Loop
    
    'INSERT THE KEY VALUE PAIR INTO THE COLLECTION
     Call col.Add(value, key)
     'Debug.Print key & " => " & value
     
    If arFlag Then Set parseJSON = col: Exit Function
    
    If char = "," Then
        Call incPointer(pointer, char, JSONstring)
        Set parseJSON = parseJSON(JSONstring, col, pointer)
        Exit Function
    ElseIf char = "]" Or char = "}" Then
        Set parseJSON = col
        Exit Function
    End If
   
End Function

