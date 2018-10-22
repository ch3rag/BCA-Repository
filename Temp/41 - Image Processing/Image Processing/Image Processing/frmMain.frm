VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmMain 
   AutoRedraw      =   -1  'True
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Image Processing"
   ClientHeight    =   9495
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   15195
   ForeColor       =   &H8000000B&
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   MousePointer    =   99  'Custom
   ScaleHeight     =   633
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   1013
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdUndo 
      Caption         =   "Undo"
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   3360
      TabIndex        =   83
      Top             =   8880
      Width           =   1305
   End
   Begin VB.CommandButton cmdRedo 
      Caption         =   "Redo"
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   4770
      TabIndex        =   82
      Top             =   8880
      Width           =   1305
   End
   Begin VB.CommandButton cmdReset 
      Caption         =   "Reset"
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   6150
      TabIndex        =   81
      Top             =   8880
      Width           =   1305
   End
   Begin VB.PictureBox pBoxWindow 
      AutoRedraw      =   -1  'True
      BackColor       =   &H80000000&
      ForeColor       =   &H8000000A&
      Height          =   6345
      Left            =   0
      MousePointer    =   1  'Arrow
      ScaleHeight     =   419
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   619
      TabIndex        =   74
      Top             =   60
      Width           =   9345
      Begin VB.PictureBox pboxTemp 
         AutoRedraw      =   -1  'True
         AutoSize        =   -1  'True
         BackColor       =   &H80000002&
         BorderStyle     =   0  'None
         ForeColor       =   &H80000003&
         Height          =   6345
         Left            =   2880
         MousePointer    =   1  'Arrow
         ScaleHeight     =   423
         ScaleMode       =   3  'Pixel
         ScaleWidth      =   623
         TabIndex        =   76
         Top             =   1020
         Visible         =   0   'False
         Width           =   9345
      End
      Begin VB.PictureBox pBoxOutput 
         AutoRedraw      =   -1  'True
         AutoSize        =   -1  'True
         BackColor       =   &H80000005&
         BorderStyle     =   0  'None
         ForeColor       =   &H8000000A&
         Height          =   6345
         Left            =   0
         MousePointer    =   1  'Arrow
         ScaleHeight     =   423
         ScaleMode       =   3  'Pixel
         ScaleWidth      =   623
         TabIndex        =   75
         Top             =   0
         Width           =   9345
      End
   End
   Begin VB.HScrollBar hsbPic 
      Enabled         =   0   'False
      Height          =   225
      Left            =   0
      TabIndex        =   73
      Top             =   6420
      Width           =   9405
   End
   Begin VB.VScrollBar vsbPic 
      Enabled         =   0   'False
      Height          =   6285
      Left            =   9390
      TabIndex        =   72
      Top             =   120
      Width           =   225
   End
   Begin VB.Frame fmeFilter 
      Caption         =   "Filters"
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   9345
      Left            =   9690
      TabIndex        =   22
      Top             =   30
      Width           =   5415
      Begin VB.Frame Frame3 
         Caption         =   "Effects"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   4455
         Left            =   120
         TabIndex        =   48
         Top             =   4680
         Width           =   5175
         Begin VB.TextBox txtConvo 
            Height          =   285
            Left            =   4500
            Locked          =   -1  'True
            TabIndex        =   71
            Text            =   "1"
            Top             =   1800
            Width           =   555
         End
         Begin VB.CommandButton cmdResetMat 
            Caption         =   "Reset Matrix"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   555
            Left            =   2970
            TabIndex        =   70
            Top             =   3660
            Width           =   2055
         End
         Begin VB.CommandButton cmdApplyConvo 
            Caption         =   "Apply Convolution"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   555
            Left            =   2970
            TabIndex        =   69
            Top             =   2850
            Width           =   2055
         End
         Begin VB.HScrollBar hsbConvo 
            Height          =   405
            Left            =   2910
            Max             =   10
            Min             =   1
            TabIndex        =   67
            Top             =   2130
            Value           =   1
            Width           =   2145
         End
         Begin VB.Frame fmeConMat 
            Caption         =   "Convolution Matrix"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   2655
            Left            =   180
            TabIndex        =   57
            Top             =   1650
            Width           =   2595
            Begin VB.TextBox txtMat 
               BeginProperty Font 
                  Name            =   "Lucida Sans Unicode"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   435
               Index           =   8
               Left            =   1950
               MaxLength       =   3
               TabIndex        =   66
               Top             =   1950
               Width           =   435
            End
            Begin VB.TextBox txtMat 
               BeginProperty Font 
                  Name            =   "Lucida Sans Unicode"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   435
               Index           =   7
               Left            =   1080
               MaxLength       =   3
               TabIndex        =   65
               Top             =   1950
               Width           =   435
            End
            Begin VB.TextBox txtMat 
               BeginProperty Font 
                  Name            =   "Lucida Sans Unicode"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   435
               Index           =   6
               Left            =   210
               MaxLength       =   3
               TabIndex        =   64
               Top             =   1950
               Width           =   435
            End
            Begin VB.TextBox txtMat 
               BeginProperty Font 
                  Name            =   "Lucida Sans Unicode"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   435
               Index           =   5
               Left            =   1890
               MaxLength       =   3
               TabIndex        =   63
               Top             =   1230
               Width           =   435
            End
            Begin VB.TextBox txtMat 
               BeginProperty Font 
                  Name            =   "Lucida Sans Unicode"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   435
               Index           =   4
               Left            =   1050
               MaxLength       =   3
               TabIndex        =   62
               Top             =   1230
               Width           =   435
            End
            Begin VB.TextBox txtMat 
               BeginProperty Font 
                  Name            =   "Lucida Sans Unicode"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   435
               Index           =   3
               Left            =   180
               MaxLength       =   3
               TabIndex        =   61
               Top             =   1230
               Width           =   435
            End
            Begin VB.TextBox txtMat 
               BeginProperty Font 
                  Name            =   "Lucida Sans Unicode"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   435
               Index           =   2
               Left            =   1920
               MaxLength       =   3
               TabIndex        =   60
               Top             =   450
               Width           =   435
            End
            Begin VB.TextBox txtMat 
               BeginProperty Font 
                  Name            =   "Lucida Sans Unicode"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   435
               Index           =   1
               Left            =   1080
               MaxLength       =   3
               TabIndex        =   59
               Top             =   450
               Width           =   435
            End
            Begin VB.TextBox txtMat 
               BeginProperty Font 
                  Name            =   "Lucida Sans Unicode"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   435
               Index           =   0
               Left            =   210
               MaxLength       =   3
               TabIndex        =   58
               Top             =   450
               Width           =   435
            End
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Top Sobel"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   16
            Left            =   90
            TabIndex        =   56
            Top             =   1020
            Width           =   1125
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Bottom Sobel"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   15
            Left            =   1380
            TabIndex        =   55
            Top             =   1020
            Width           =   1125
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Left Sobel"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   14
            Left            =   2670
            TabIndex        =   54
            Top             =   1020
            Width           =   1125
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Right Sobel"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   13
            Left            =   3930
            TabIndex        =   53
            Top             =   1020
            Width           =   1125
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Blur"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   12
            Left            =   90
            TabIndex        =   52
            Top             =   330
            Width           =   1125
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Emboss"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   11
            Left            =   1380
            TabIndex        =   51
            Top             =   330
            Width           =   1125
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Outline"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   10
            Left            =   2700
            TabIndex        =   50
            Top             =   330
            Width           =   1125
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Sharpen"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   9
            Left            =   3930
            TabIndex        =   49
            Top             =   330
            Width           =   1125
         End
         Begin VB.Label lblFilterScale 
            Alignment       =   2  'Center
            Caption         =   "Filter Scale"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Left            =   2850
            TabIndex        =   68
            Top             =   1800
            Width           =   1035
         End
      End
      Begin VB.Frame Frame2 
         Caption         =   "Basic"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   4035
         Left            =   120
         TabIndex        =   23
         Top             =   390
         Width           =   5175
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Monotone"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   8
            Left            =   3915
            TabIndex        =   47
            Top             =   3300
            Width           =   1125
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Sepia Tone"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   7
            Left            =   2655
            TabIndex        =   46
            Top             =   3300
            Width           =   1125
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Grayscale"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   6
            Left            =   1365
            TabIndex        =   45
            Top             =   3300
            Width           =   1125
         End
         Begin VB.HScrollBar hsbFilter 
            Height          =   345
            Index           =   4
            Left            =   1260
            Max             =   128
            Min             =   -128
            TabIndex        =   43
            Top             =   2610
            Width           =   2445
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Apply"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Index           =   4
            Left            =   4380
            TabIndex        =   42
            Top             =   2610
            Width           =   705
         End
         Begin VB.TextBox txtFilter 
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   360
            Index           =   4
            Left            =   3750
            Locked          =   -1  'True
            TabIndex        =   41
            Text            =   "0"
            Top             =   2610
            Width           =   615
         End
         Begin VB.HScrollBar hsbFilter 
            Height          =   345
            Index           =   3
            Left            =   1260
            Max             =   128
            Min             =   -128
            TabIndex        =   39
            Top             =   2070
            Width           =   2445
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Apply"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Index           =   3
            Left            =   4380
            TabIndex        =   38
            Top             =   2070
            Width           =   705
         End
         Begin VB.TextBox txtFilter 
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   360
            Index           =   3
            Left            =   3750
            Locked          =   -1  'True
            TabIndex        =   37
            Text            =   "0"
            Top             =   2100
            Width           =   615
         End
         Begin VB.TextBox txtFilter 
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   360
            Index           =   2
            Left            =   3750
            Locked          =   -1  'True
            TabIndex        =   35
            Text            =   "0"
            Top             =   1530
            Width           =   615
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Apply"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Index           =   2
            Left            =   4380
            TabIndex        =   34
            Top             =   1530
            Width           =   705
         End
         Begin VB.HScrollBar hsbFilter 
            Height          =   345
            Index           =   2
            Left            =   1260
            Max             =   128
            Min             =   -128
            TabIndex        =   33
            Top             =   1530
            Width           =   2445
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Color Invert"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   495
            Index           =   5
            Left            =   75
            TabIndex        =   32
            Top             =   3300
            Width           =   1125
         End
         Begin VB.HScrollBar hsbFilter 
            Height          =   345
            Index           =   1
            Left            =   1260
            Max             =   8
            Min             =   -8
            TabIndex        =   30
            Top             =   990
            Width           =   2445
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Apply"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Index           =   1
            Left            =   4380
            TabIndex        =   29
            Top             =   990
            Width           =   705
         End
         Begin VB.TextBox txtFilter 
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   360
            Index           =   1
            Left            =   3750
            Locked          =   -1  'True
            TabIndex        =   28
            Text            =   "0"
            Top             =   1020
            Width           =   615
         End
         Begin VB.TextBox txtFilter 
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   360
            Index           =   0
            Left            =   3750
            Locked          =   -1  'True
            TabIndex        =   27
            Text            =   "0"
            Top             =   450
            Width           =   615
         End
         Begin VB.CommandButton cmdFilter 
            Caption         =   "Apply"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Index           =   0
            Left            =   4380
            TabIndex        =   26
            Top             =   450
            Width           =   705
         End
         Begin VB.HScrollBar hsbFilter 
            Height          =   345
            Index           =   0
            Left            =   1260
            Max             =   128
            Min             =   -128
            TabIndex        =   25
            Top             =   450
            Width           =   2445
         End
         Begin VB.Label lblFilter 
            Caption         =   "Blue"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Index           =   4
            Left            =   150
            TabIndex        =   44
            Top             =   2670
            Width           =   1005
         End
         Begin VB.Label lblFilter 
            Caption         =   "Green"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Index           =   3
            Left            =   150
            TabIndex        =   40
            Top             =   2130
            Width           =   1005
         End
         Begin VB.Label lblFilter 
            Caption         =   "Red"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Index           =   2
            Left            =   150
            TabIndex        =   36
            Top             =   1590
            Width           =   1005
         End
         Begin VB.Label lblFilter 
            Caption         =   "Contrast"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Index           =   1
            Left            =   150
            TabIndex        =   31
            Top             =   1050
            Width           =   1005
         End
         Begin VB.Label lblFilter 
            Caption         =   "Brightness"
            BeginProperty Font 
               Name            =   "Lucida Sans Unicode"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Index           =   0
            Left            =   150
            TabIndex        =   24
            Top             =   510
            Width           =   1005
         End
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Edit"
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2745
      Left            =   7650
      TabIndex        =   20
      Top             =   6660
      Width           =   1935
      Begin VB.CommandButton cmdFlipVertical 
         Caption         =   "Flip Vertical"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   210
         TabIndex        =   80
         Top             =   2160
         Width           =   1575
      End
      Begin VB.CommandButton cmdFlipHorizontal 
         Caption         =   "Flip Horizontal"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   210
         TabIndex        =   79
         Top             =   1590
         Width           =   1575
      End
      Begin VB.CommandButton cmdFlipLeft 
         Caption         =   "Flip Left"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   180
         TabIndex        =   78
         Top             =   1020
         Width           =   1575
      End
      Begin VB.CommandButton cmdFlipRight 
         Caption         =   "Flip Right"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   180
         TabIndex        =   77
         Top             =   450
         Width           =   1575
      End
   End
   Begin VB.TextBox txtColor 
      Height          =   285
      Index           =   2
      Left            =   2640
      MaxLength       =   3
      TabIndex        =   17
      Top             =   8760
      Width           =   465
   End
   Begin VB.Frame fmeColor 
      Caption         =   "Color"
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1545
      Left            =   90
      TabIndex        =   7
      Top             =   7710
      Width           =   3105
      Begin VB.CommandButton cmdPick 
         Caption         =   "Pick"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   180
         TabIndex        =   21
         Top             =   960
         Width           =   705
      End
      Begin VB.CommandButton cmdSetRGB 
         Caption         =   "Select RGB"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   1620
         TabIndex        =   18
         Top             =   330
         Width           =   1215
      End
      Begin VB.TextBox txtColor 
         Height          =   285
         Index           =   1
         Left            =   2010
         MaxLength       =   3
         TabIndex        =   16
         Top             =   1050
         Width           =   465
      End
      Begin VB.CommandButton cmdSelectColor 
         Caption         =   "Select Color"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   210
         TabIndex        =   15
         Top             =   330
         Width           =   1215
      End
      Begin VB.TextBox txtColor 
         Height          =   285
         Index           =   0
         Left            =   1500
         MaxLength       =   3
         TabIndex        =   14
         Top             =   1050
         Width           =   465
      End
      Begin VB.Label Label5 
         Caption         =   "  R         G          B"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   1560
         TabIndex        =   19
         Top             =   810
         Width           =   1425
      End
      Begin VB.Shape shpColorShow 
         FillStyle       =   0  'Solid
         Height          =   285
         Left            =   990
         Top             =   1050
         Width           =   435
      End
   End
   Begin VB.Frame fmeTools 
      Caption         =   "Tools"
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2145
      Left            =   3360
      TabIndex        =   3
      Top             =   6660
      Width           =   4125
      Begin VB.HScrollBar hsbCalli 
         Height          =   285
         Left            =   1560
         Max             =   10
         Min             =   3
         TabIndex        =   12
         Top             =   1530
         Value           =   3
         Width           =   2355
      End
      Begin VB.CommandButton cmdCalligraph 
         Caption         =   "Calligraphy "
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   210
         TabIndex        =   11
         Top             =   1530
         Width           =   1185
      End
      Begin VB.HScrollBar hsbSpray 
         Height          =   285
         Left            =   1530
         Max             =   5
         Min             =   1
         TabIndex        =   9
         Top             =   930
         Value           =   1
         Width           =   2355
      End
      Begin VB.CommandButton cmdSpray 
         Caption         =   "Paint Spray"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   180
         TabIndex        =   8
         Top             =   930
         Width           =   1185
      End
      Begin VB.HScrollBar hsbPencil 
         Height          =   285
         Left            =   1500
         Max             =   10
         Min             =   1
         TabIndex        =   5
         Top             =   300
         Value           =   1
         Width           =   2355
      End
      Begin VB.CommandButton cmdPencil 
         Caption         =   "Pencil"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   180
         TabIndex        =   4
         Top             =   330
         Width           =   1185
      End
      Begin VB.Label Label4 
         Alignment       =   2  'Center
         Caption         =   "Calligraphy Brush Size"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   225
         Left            =   1590
         TabIndex        =   13
         Top             =   1860
         Width           =   2265
      End
      Begin VB.Label Label3 
         Alignment       =   2  'Center
         Caption         =   "Spray Radius"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   225
         Left            =   1560
         TabIndex        =   10
         Top             =   1260
         Width           =   2265
      End
      Begin VB.Label lblStrokeSize 
         Alignment       =   2  'Center
         Caption         =   "Draw Width"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   225
         Left            =   1530
         TabIndex        =   6
         Top             =   660
         Width           =   2265
      End
   End
   Begin VB.Frame fmeMain 
      Caption         =   "Options"
      BeginProperty Font 
         Name            =   "Lucida Sans Unicode"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1005
      Left            =   90
      TabIndex        =   0
      Top             =   6630
      Width           =   3075
      Begin VB.CommandButton cmdSave 
         Caption         =   "Save Output"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   1500
         TabIndex        =   2
         Top             =   330
         Width           =   1395
      End
      Begin VB.CommandButton cmdLoad 
         Caption         =   "Load Image"
         BeginProperty Font 
            Name            =   "Lucida Sans Unicode"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   150
         TabIndex        =   1
         Top             =   330
         Width           =   1335
      End
   End
   Begin MSComDlg.CommonDialog cdb 
      Left            =   8850
      Top             =   210
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim currentTool As String
Dim mousePressed As Boolean
Dim pX As Single
Dim pY As Single
Const PI = 3.14159
Dim randomAngle As Single
Dim randomRadius As Single
Dim I As Single
Dim red As Integer
Dim green As Integer
Dim blue As Integer
Dim color As Long
Dim newCol As Long
Dim UNITONE As Long
Dim currentFilePath As String
'CONVOLUTION MATRICES
Dim BLUR(3, 3) As Single
Dim EMBOSS(3, 3) As Single
Dim OUTLINE(3, 3) As Single
Dim SHARP(3, 3) As Single
Dim TOPSOBEL(3, 3) As Single
Dim BOTTOMSOBEL(3, 3) As Single
Dim LEFTSOBEL(3, 3) As Single
Dim RIGHTSOBEL(3, 3) As Single
Dim TEMP(3, 3) As Single



Private Sub flipRight()
    Call saveUndo
    pboxTemp.Cls
    pboxTemp.Width = pBoxOutput.Height
    pboxTemp.Height = pBoxOutput.Width
    Dim X As Integer
    Dim Y As Integer
    Dim tX As Integer
    Dim tY As Integer
    
    For Y = 0 To pBoxOutput.ScaleHeight Step 1
        For X = 0 To pBoxOutput.ScaleWidth Step 1
               color = pBoxOutput.Point(X, Y)
               tX = pboxTemp.Width - Y
               tY = X
               pboxTemp.PSet (tX, tY), color
        Next X
    Next Y
    pBoxOutput.Picture = pboxTemp.Image
    Call setScrolls
    Call saveRedo
    
End Sub

Private Sub flipLeft()
    Call saveUndo
    pboxTemp.Cls
    pboxTemp.Width = pBoxOutput.Height
    pboxTemp.Height = pBoxOutput.Width
    Dim X As Integer
    Dim Y As Integer
    Dim tX As Integer
    Dim tY As Integer
    
    For Y = 0 To pBoxOutput.ScaleHeight Step 1
        For X = 0 To pBoxOutput.ScaleWidth Step 1
               color = pBoxOutput.Point(X, Y)
               tX = Y
               tY = pboxTemp.Height - X
               pboxTemp.PSet (tX, tY), color
        Next X
    Next Y
    pBoxOutput.Picture = pboxTemp.Image
    Call setScrolls
    Call saveRedo
    
End Sub

Private Sub flipHorizontal()
    Call saveUndo
    pboxTemp.Cls
    Dim X As Integer
    Dim Y As Integer
    Dim tX As Integer
    Dim tY As Integer
    
    For Y = 0 To pBoxOutput.ScaleHeight Step 1
        For X = 0 To pBoxOutput.ScaleWidth Step 1
               color = pBoxOutput.Point(X, Y)
               tX = pboxTemp.Width - X
               tY = Y
               pboxTemp.PSet (tX, tY), color
        Next X
    Next Y
    pBoxOutput.Picture = pboxTemp.Image
    Call setScrolls
    Call saveRedo
End Sub

Private Sub flipVerical()
    Call saveUndo
    pboxTemp.Cls
    Dim X As Integer
    Dim Y As Integer
    Dim tX As Integer
    Dim tY As Integer
    
    For Y = 0 To pBoxOutput.ScaleHeight Step 1
        For X = 0 To pBoxOutput.ScaleWidth Step 1
               color = pBoxOutput.Point(X, Y)
               tX = X
               tY = pboxTemp.Height - Y
               pboxTemp.PSet (tX, tY), color
        Next X
    Next Y
    pBoxOutput.Picture = pboxTemp.Image
    Call setScrolls
    Call saveRedo
End Sub

Private Sub initMat(mat As Variant, i0j0 As Single, i0j1 As Single, i0j2 As Single, i1j0 As Single, i1j1 As Single, i1j2 As Single, i2j0 As Single, i2j1 As Single, i2j2 As Single)
    mat(0, 0) = i0j0: mat(0, 1) = i0j1: mat(0, 2) = i0j2
    mat(1, 0) = i1j0: mat(1, 1) = i1j1: mat(1, 2) = i1j2
    mat(2, 0) = i2j0: mat(2, 1) = i2j1: mat(2, 2) = i2j2
End Sub

Private Sub loadMat()
    Call initMat(BLUR, 0.9, 0.9, 0.9, 0.9, 0.9, 0.9, 0.9, 0.9, 0.9)
    Call initMat(EMBOSS, -10, -5, 0, -5, 5, 5, 0, 5, 10)
    Call initMat(OUTLINE, -10, -10, -10, -10, 80, -10, -10, -10, -10)
    Call initMat(SHARP, 0, -8, 0, -8, 40, -8, 0, -8, 0)
    Call initMat(TOPSOBEL, 6, 12, 6, 0, 0, 0, -6, -12, -6)
    Call initMat(BOTTOMSOBEL, -6, -12, -6, 0, 0, 0, 6, 12, 6)
    Call initMat(LEFTSOBEL, 6, 0, -6, 12, 0, -12, 6, 0, -6)
    Call initMat(RIGHTSOBEL, -6, 0, 6, -12, 0, 12, -6, 0, 6)
End Sub

Private Sub applyConvolutionFilter(mat As Variant)
    Dim X As Integer
    Dim Y As Integer
    Dim I As Integer
    Dim J As Integer
    Dim avgRed As Integer
    Dim avgGreen As Integer
    Dim avgBlue As Integer
    Dim factor As Integer
    factor = hsbConvo.Value
    
    For Y = 1 To pBoxOutput.ScaleHeight - 1 Step 1
        For X = 1 To pBoxOutput.ScaleWidth - 1 Step 1
            For I = -1 To 1
                For J = -1 To 1
                    color = pBoxOutput.Point(X + J, Y + I)
                    getColors (color)
                    avgRed = avgRed + red * mat(1 + I, 1 + J) * factor
                    avgGreen = avgGreen + green * mat(1 + I, 1 + J) * factor
                    avgBlue = avgBlue + blue * mat(1 + I, 1 + J) * factor
                Next J
            Next I
            avgRed = avgRed / 9
            avgGreen = avgGreen / 9
            avgBlue = avgBlue / 9
            newCol = RGB(constrain((avgRed), 0, 255), constrain((avgGreen), 0, 255), constrain((avgBlue), 0, 255))
            pboxTemp.PSet (X, Y), newCol
           
        Next X
    Next Y
    pBoxOutput.Picture = pboxTemp.Image
    pboxTemp.Picture = LoadPicture(cdb.FileName)
End Sub
Private Sub applyPixelFilter(filterFn As String)
    Dim X As Integer
    Dim Y As Integer
    For Y = 0 To pBoxOutput.ScaleHeight Step 1
        For X = 0 To pBoxOutput.ScaleWidth Step 1
            color = pBoxOutput.Point(X, Y)
            newCol = CallByName(Me, filterFn, VbMethod, color)
            pBoxOutput.PSet (X, Y), newCol
        Next X
    Next Y
End Sub

Private Sub getColors(color As Long)
    red = getRed(color)
    blue = getBlue(color)
    green = getGreen(color)
End Sub

Private Function constrain(val As Integer, min As Integer, max As Integer) As Integer
    If val < min Then
        constrain = min
    ElseIf val > max Then
        constrain = max
    Else
        constrain = val
    End If
End Function

Public Function fnRed(color As Long) As Long
    getColors (color)
    red = constrain(red + hsbFilter(2).Value, 0, 255)
    green = constrain(green, 0, 255)
    blue = constrain(blue, 0, 255)
    fnRed = RGB(red, green, blue)
End Function

Public Function fnGreen(color As Long) As Long
    getColors (color)
    red = constrain(red, 0, 255)
    green = constrain(green + hsbFilter(3).Value, 0, 255)
    blue = constrain(blue, 0, 255)
    fnGreen = RGB(red, green, blue)
End Function

Public Function fnBlue(color As Long) As Long
    getColors (color)
    red = constrain(red, 0, 255)
    green = constrain(green, 0, 255)
    blue = constrain(blue + hsbFilter(4).Value, 0, 255)
    fnBlue = RGB(red, green, blue)
End Function


Public Function fnBright(color As Long) As Long
    getColors (color)
    red = constrain(red + hsbFilter(0).Value, 0, 255)
    green = constrain(green + hsbFilter(0).Value, 0, 255)
    blue = constrain(blue + hsbFilter(0).Value, 0, 255)
    fnBright = RGB(red, green, blue)
End Function

Public Function fnContrast(color As Long) As Long
    Dim factor As Single
    getColors (color)
    If hsbFilter(1).Value < 0 Then factor = 1 / Abs(hsbFilter(1).Value) Else factor = 1 + hsbFilter(1).Value / 10
    red = constrain(red * factor, 0, 255)
    green = constrain(green * factor, 0, 255)
    blue = constrain(blue * factor, 0, 255)
    fnContrast = RGB(red, green, blue)
End Function

Public Function fnInvert(color As Long) As Long
    getColors (color)
    red = 255 - red
    green = 255 - green
    blue = 255 - blue
    fnInvert = RGB(red, green, blue)
End Function

Public Function fnSepia(color As Long) As Long
    getColors (color)
    red = constrain(red * 0.393 + green * 0.769 + blue * 0.189, 0, 255)
    green = constrain(red * 0.349 + green * 0.686 + blue * 0.168, 0, 255)
    blue = constrain(red * 0.272 + green * 0.534 + blue * 0.131, 0, 255)
    fnSepia = RGB(red, green, blue)
End Function

Public Function fnGrayscale(color As Long) As Long
    getColors (color)
    newCol = (red + green + blue) / 3
    fnGrayscale = RGB(newCol, newCol, newCol)
End Function

Public Function fnUnitone(color As Long) As Long
    getColors (color)
    Dim factor As Double
    factor = map((red + blue + green) / 3, 0, 255, 0, 1)
    red = getRed(UNITONE) * factor
    green = getGreen(UNITONE) * factor
    blue = getBlue(UNITONE) * factor
    fnUnitone = RGB(red, green, blue)
End Function


Private Sub cmdCalligraph_Click()
    currentTool = "CALLIGRAPH"
    Call enableTool(True, False, True, False, False, True)
    pBoxOutput.DrawWidth = 3
End Sub

Private Sub cmdFilter_Click(Index As Integer)
    If Index < hsbFilter.Count Then
        If hsbFilter(Index).Value = 0 Then Exit Sub
    End If
    Call saveUndo
    Select Case Index
        Case 0:
            applyPixelFilter ("fnBright")
        Case 1:
            applyPixelFilter ("fnContrast")
        Case 2:
            applyPixelFilter ("fnRed")
        Case 3:
            applyPixelFilter ("fnGreen")
        Case 4:
            applyPixelFilter ("fnBlue")
        Case 5:
            applyPixelFilter ("fnInvert")
        Case 6:
            applyPixelFilter ("fnGrayscale")
        Case 7:
            applyPixelFilter ("fnSepia")
        Case 8:
            cdb.color = 0
            cdb.ShowColor
            If cdb.color = 0 Then Exit Sub Else UNITONE = cdb.color: applyPixelFilter ("fnUnitone"): cdb.color = 0
        Case 9:
            applyConvolutionFilter (SHARP)
        Case 10:
            applyConvolutionFilter (OUTLINE)
        Case 11:
            applyConvolutionFilter (EMBOSS)
        Case 12:
            applyConvolutionFilter (BLUR)
        Case 13:
            applyConvolutionFilter (RIGHTSOBEL)
        Case 14:
            applyConvolutionFilter (LEFTSOBEL)
        Case 15:
            applyConvolutionFilter (BOTTOMSOBEL)
        Case 16:
            applyConvolutionFilter (TOPSOBEL)
    End Select
    If Index < hsbFilter.Count Then
        hsbFilter(Index).Value = 0
    End If
    Call saveRedo
End Sub

Private Sub cmdFlipHorizontal_Click()
    Call flipHorizontal
End Sub

Private Sub cmdFlipLeft_Click()
    Call flipLeft
End Sub

Private Sub cmdFlipRight_Click()
    Call flipRight
End Sub

Private Sub cmdFlipVertical_Click()
    Call flipVerical
End Sub

Private Sub cmdLoad_Click()
     cdb.FileName = ""
     cdb.ShowOpen
    If cdb.FileName = "" Then Exit Sub Else pBoxOutput.Picture = LoadPicture(cdb.FileName): pboxTemp.Picture = LoadPicture(cdb.FileName): currentFilePath = cdb.FileName
    Call setScrolls
End Sub

Private Sub setScrolls()
    If pBoxOutput.Width > pBoxWindow.Width Then
        hsbPic.Enabled = True
        hsbPic.min = 0
        hsbPic.max = pBoxOutput.Width - pBoxWindow.Width
    Else
        hsbPic.Enabled = False
    End If
    
    
    If pBoxOutput.Height > pBoxWindow.Height Then
        vsbPic.Enabled = True
        vsbPic.min = 0
        vsbPic.max = pBoxOutput.Height - pBoxWindow.Height
    Else
        vsbPic.Enabled = False
    End If
    
End Sub
Private Sub cmdPick_Click()
    currentTool = "PICK"
End Sub

Private Sub cmdRedo_Click()
    pBoxOutput.Picture = LoadPicture(App.Path & "\TEMP\REDO.JPG")
End Sub

Private Sub cmdReset_Click()
    If Not currentFilePath = "" Then pBoxOutput.Picture = LoadPicture(currentFilePath): Call setScrolls
End Sub

Private Sub cmdSave_Click()
    cdb.FileName = ""
    cdb.ShowSave
    If cdb.FileName = "" Then Exit Sub Else Call SavePicture(pBoxOutput.Image, cdb.FileName)
End Sub

Private Sub cmdSelectColor_click()
    cdb.color = 0
    cdb.ShowColor
    If cdb.color <> 0 Then pBoxOutput.ForeColor = cdb.color: Call updateShowColor
End Sub

Private Sub cmdSpray_Click()
    currentTool = "SPRAY"
    Call enableTool(True, True, False, True, True, False)
    pBoxOutput.DrawWidth = hsbPencil.Value
End Sub


Private Sub cmdUndo_Click()
    pBoxOutput.Picture = LoadPicture(App.Path & "\TEMP\UNDO.JPG")
End Sub


Private Sub cmdApplyConvo_Click()
    Call saveUndo
    For I = 0 To 2
        For J = 0 To 2
            TEMP(I, J) = val(txtMat(J + I * 3).Text)
        Next J
    Next I
    applyConvolutionFilter (TEMP)
    Call saveRedo
End Sub

Private Sub cmdResetMat_Click()
    For I = 0 To txtMat.Count - 1
        txtMat(I).Text = ""
    Next
End Sub

Private Sub Form_Activate()
    Call updateShowColor
    Call enableTool(True, False, True, False, True, False)
End Sub

Private Sub Form_Load()
    cdb.Filter = "Images(*.jpg, *.bmp, *.gif, *.wmf, *.ico)|*.jpg;*.bmp;*.gif;*.wmf;*.ico"
    Call saveRedo
    Call saveUndo
    Call loadMat
End Sub

Private Sub updateShowColor()
    shpColorShow.FillColor = pBoxOutput.ForeColor
    txtColor(0).Text = getRed(pBoxOutput.ForeColor)
    txtColor(1).Text = getGreen(pBoxOutput.ForeColor)
    txtColor(2).Text = getBlue(pBoxOutput.ForeColor)
End Sub

Private Function inputNumbers(KeyAscii As Integer) As Integer
    If (KeyAscii >= vbKey0 And KeyAscii <= vbKey9) Or KeyAscii = vbKeyBack Or KeyAscii = Asc("-") Then inputNumbers = KeyAscii Else KeyAscii = 0
End Function

Function map(val As Double, min As Double, max As Double, mapmin As Double, mapmax As Double) As Double
    map = mapmin + ((mapmax - mapmin) / (max - min)) * (val - min)
End Function

Private Sub hsbConvo_Change()
    txtConvo.Text = hsbConvo.Value
End Sub



Private Sub hsbFilter_Change(Index As Integer)
    txtFilter(Index).Text = hsbFilter(Index).Value
End Sub

Private Sub hsbPencil_Change()
    pBoxOutput.DrawWidth = hsbPencil.Value
End Sub

Private Sub saveUndo()
  Call SavePicture(pBoxOutput.Image, App.Path & "\Temp\UNDO.jpg")
  cmdUndo.Enabled = True
End Sub

Private Sub saveRedo()
    Call SavePicture(pBoxOutput.Image, App.Path & "\Temp\REDO.jpg")
    cmdRedo.Enabled = True
End Sub

Private Sub hsbPic_Change()
    pBoxOutput.Left = -hsbPic.Value
End Sub

Private Sub hsbPic_Scroll()
    pBoxOutput.Left = -hsbPic.Value
End Sub


Private Sub pBoxOutput_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Call saveUndo
    mousePressed = True
    pX = X
    pY = Y
    Select Case currentTool
        Case "PICK":
            color = pBoxOutput.Point(X, Y)
            pBoxOutput.ForeColor = color
            Call updateShowColor
    End Select
End Sub

Private Sub pBoxOutput_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    If mousePressed Then
        Select Case currentTool
            Case "PENCIL":
                pBoxOutput.Line (X, Y)-(pX, pY)
            Case "SPRAY":
                Dim I As Integer
                For I = 0 To 100
                    randomRadius = getNextGaussian(0, 1) * hsbSpray.Value
                    randomAngle = Rnd() * 2 * PI
                    X = X + randomRadius * Cos(randomAngle)
                    Y = Y + randomRadius * Sin(randomAngle)
                    pBoxOutput.PSet (X, Y)
                Next I
            Case "CALLIGRAPH":
                For I = 0 To 100 Step 5
                    cX = lerp(pX, X, (I / 100))
                    cY = lerp(pY, Y, (I / 100))
                    pBoxOutput.Line (cX - hsbCalli.Value, cY - 3)-(cX + hsbCalli.Value, cY + 3)
                Next I
        End Select
    End If
    pX = X
    pY = Y
End Sub

Private Function lerp(a As Single, b As Single, d As Single) As Single
    lerp = (1 - d) * a + b * d
End Function
Private Sub pBoxOutput_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    mousePressed = False
    Call saveRedo
End Sub


Private Sub txtColor_Change(Index As Integer)
    If Len(txtColor(Index).Text) = 3 And Index <> txtColor.Count - 1 Then txtColor(Index + 1).SetFocus: txtColor(Index + 1).SelStart = 0: txtColor(Index + 1).SelLength = Len(txtColor(Index + 1).Text)
End Sub

Private Sub txtColor_KeyPress(Index As Integer, KeyAscii As Integer)
    KeyAscii = inputNumbers(KeyAscii)
End Sub

Private Sub cmdSetRGB_Click()
    For I = 0 To txtColor.Count - 1
        If val(txtColor(I).Text) > 255 Or val(txtColor(I).Text) < 0 Or txtColor(I).Text = "" Then
            Call MsgBox("Invalid color!", vbCritical + vbOKOnly, "Error")
            Exit Sub
        End If
    Next
    pBoxOutput.ForeColor = RGB(val(txtColor(0).Text), val(txtColor(1).Text), val(txtColor(2).Text))
    Call updateShowColor
End Sub

Private Sub cmdPencil_Click()
    Call enableTool(False, True, True, False, True, False)
    pBoxOutput.MousePointer = 99
    currentTool = "PENCIL"
    pBoxOutput.DrawWidth = hsbPencil.Value
End Sub

Private Function getNextGaussian(mu As Double, sigma As Double)
    Static haveNextGaussian As Boolean
    Static nextGaussian As Double
    If haveNextGaussian Then
        getNextGaussian = nextGaussian
        haveNextGaussian = False
        Exit Function
    End If
    
    Dim U1 As Double
    Dim U2 As Double
    Dim Z As Double
    Dim multiplier As Double
    Do
        U1 = 2 * Rnd() - 1
        U2 = 2 * Rnd() - 1
        Z = U1 * U1 + U2 * U2
    Loop While (Z >= 1 Or Z = 0)
    multiplier = Sqr(-2 * Log(Z) / Z)
    nextGaussian = U2 * multiplier + 1
    haveNextGaussian = True
    getNextGaussian = U1 * multiplier + 1
End Function

Private Function getRed(hex As Long)
    getRed = hex And &HFF
End Function

Private Function getGreen(hex As Long)
    getGreen = Int(hex / &H100) Mod &H100
End Function

Private Function getBlue(hex As Long)
    getBlue = Int(hex / &H10000) Mod &H100
End Function

Private Sub enableTool(pB As Boolean, pS As Boolean, sB As Boolean, sS As Boolean, cB As Boolean, cS As Boolean)
    cmdPencil.Enabled = pB
    cmdSpray.Enabled = sB
    cmdCalligraph.Enabled = cB
    hsbPencil.Enabled = pS
    hsbSpray.Enabled = sS
    hsbCalli.Enabled = cS
End Sub

Private Sub txtMat_KeyPress(Index As Integer, KeyAscii As Integer)
    KeyAscii = inputNumbers(KeyAscii)
End Sub

Private Sub vsbPic_Change()
    pBoxOutput.Top = -vsbPic.Value
End Sub

Private Sub vsbPic_Scroll()
 pBoxOutput.Top = -vsbPic.Value
End Sub
