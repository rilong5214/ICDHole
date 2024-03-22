Option Strict Off
Option Explicit On

Imports System.Runtime.InteropServices


Public Class FrmPlcHole
    Inherits System.Windows.Forms.Form

    'リターンキーをTABキーと同じ動きをさせる
    <System.Security.Permissions.UIPermission(
    System.Security.Permissions.SecurityAction.Demand,
    Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)>
    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        'Returnキーが押されているか調べる
        'AltかCtrlキーが押されている時は、本来の動作をさせる
        If ((keyData And Keys.KeyCode) = Keys.Return) AndAlso
        ((keyData And (Keys.Alt Or Keys.Control)) = Keys.None) Then
            'Tabキーを押した時と同じ動作をさせる
            'Shiftキーが押されている時は、逆順にする
            Me.ProcessTabKey((keyData And Keys.Shift) <> Keys.Shift)

        ElseIf ((keyData And Keys.KeyCode) = Keys.Return) AndAlso ((keyData And Keys.KeyCode) = Keys.Right) Then
            PlaceHole.PerformClick()
            '本来の処理はさせない
            Return True
        End If



        'return the key to the base class if not used.
        Return MyBase.ProcessDialogKey(keyData)


    End Function

    'TextBoxに数字しか入力できないようにする
    'TextBox1のKeyPressイベントハンドラ
    Private Sub YobiDpBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles YobiBox.KeyPress, DpBox.KeyPress
        'キーが [0]～[9] または [BackSpace] 以外の場合イベントをキャンセル
        If Not (("0"c <= e.KeyChar And e.KeyChar <= "9"c) Or e.KeyChar = ControlChars.Back) Then
            'コントロールの既定の処理を省略する場合は true
            e.Handled = True
        End If
    End Sub

    Private Sub ItaBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ItaBox.KeyPress, PeneBox.KeyPress
        '0～9と、バックスペース以外の時は、イベントをキャンセルする
        If Not (("0"c = e.KeyChar Or e.KeyChar = "1"c) Or e.KeyChar = ControlChars.Back) Then
            'コントロールの既定の処理を省略する場合は true
            e.Handled = True
        End If
    End Sub


    Private Sub PlaceHole_Click(sender As Object, e As EventArgs) Handles PlaceHole.Click
        Dim ICADObj As Object
        Dim sMacro As String
        Dim Ita1 As Double
        Dim ita2 As Double
        Dim HoleInfo(,) As Double = {
        {1.6, 1.6, 1.22}, {2, 2, 1.57}, {3, 3, 2.46}, {4, 4, 3.24}, {5, 5, 4.13}, {6, 6, 4.92}, {8, 8, 6.65}, {10, 10, 8.38}, {12, 12, 10.1}}

        If Not Double.TryParse(ItaBox.Text, Ita1) Then
            MsgBox("Please enter a valid number!!")
            Exit Sub
        End If

        If Ita1 = 0 Then
            Ita1 = 436207616
            ita2 = 1
        ElseIf Ita1 = 1 Then
            Ita1 = 503316480
            ita2 = 2
        Else
            MsgBox("Please enter 0 or 1!!")
        End If

        Dim Yobi As String
        Yobi = YobiBox.Text
        Dim index As Integer
        For i As Integer = 0 To HoleInfo.GetLength(0) - 1
            If HoleInfo(i, 0) = Yobi Then
                index = i
                Exit For
            End If
        Next

        Dim Pene As Double
        If Not Double.TryParse(PeneBox.Text, Pene) Then
            MsgBox("Please enter a valid number!!")
            Exit Sub
        End If

        Debug.Print("Yobi=", HoleInfo(index, 0).ToString)

        If Pene = 1 Then
            sMacro = ";BLOAD " + ControlChars.NewLine
            sMacro &= ";JLOD                                                                           " + ControlChars.NewLine
            sMacro &= ";JELM                                                                           " + ControlChars.NewLine
            sMacro &= "@IOFF                                                                           " + ControlChars.NewLine
            sMacro &= "@IOFF                                                                           " + ControlChars.NewLine
            sMacro &= ";LAY                                                                            " + ControlChars.NewLine
            sMacro &= ";LOD                                                                            " + ControlChars.NewLine
            sMacro &= ".ZUMEN /タップ穴(貫通形状)@3D                   /                               " + ControlChars.NewLine
            sMacro &= ".DIR1 /C:\ICADSX\JISPARTS\USER\_旧式\3D\01_ねじ穴(英)\05_TAP THRU      /        " + ControlChars.NewLine
            sMacro &= "                                                                                " + ControlChars.NewLine
            sMacro &= ".DIR2 /                                                                /        " + ControlChars.NewLine
            sMacro &= "                                                                                " + ControlChars.NewLine
            sMacro &= ".DIR3 /                                                                /        " + ControlChars.NewLine
            sMacro &= "                                                                                " + ControlChars.NewLine
            sMacro &= ".DIR4 /                                                                /        " + ControlChars.NewLine
            sMacro &= "                                                                                " + ControlChars.NewLine
            sMacro &= ".HAICHI /M" + Yobi.ToString + "TAP_THRU                              /                              " + ControlChars.NewLine
            sMacro &= ".ATR1 /33554432/                                                                " + ControlChars.NewLine
            sMacro &= ".ATR2 /4       /                                                                " + ControlChars.NewLine
            sMacro &= ".GENTENX /434.827885  /                                                         " + ControlChars.NewLine
            sMacro &= ".GENTENY /205.860544  /                                                         " + ControlChars.NewLine
            sMacro &= ".COMMENT /タップ穴_M" + Yobi.ToString + " /                     " + ControlChars.NewLine
            sMacro &= ".ATR3 /" + Ita1.ToString + " /                                                            " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= "..HOLATR /1/                                                                    " + ControlChars.NewLine
            sMacro &= "..HOLTEG /1/                                                                    " + ControlChars.NewLine
            sMacro &= "..HOLNUM /7/                                                                    " + ControlChars.NewLine
            sMacro &= "..NPARM1 /16777216/                                                             " + ControlChars.NewLine
            sMacro &= "..PRTVER /" + ita2.ToString + "/                                                                    " + ControlChars.NewLine
            sMacro &= ".YOBI /M6                      /                                                " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= ".PARAM /l                                               /                       " + ControlChars.NewLine
            sMacro &= ".ATAI /" + DpBox.Text + "  /                                                            " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= ".PARAM /d                                               /                       " + ControlChars.NewLine
            sMacro &= ".ATAI /" + Yobi.ToString + "/                                                            " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= ".PARAM /a                                               /                       " + ControlChars.NewLine
            sMacro &= ".ATAI /" + HoleInfo(index, 2).ToString + "/                                                            " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= ".PARAM /                                                /                       " + ControlChars.NewLine
            sMacro &= ".ATAI /0           /                                                            " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            If Ita1 = 436207616 Then
                GoTo Jump1
            End If
            sMacro &= "..BHMODE /1/                                                                    " + ControlChars.NewLine
            sMacro &= "..BHNAME /l/                                                                    " + ControlChars.NewLine
            sMacro &= "..FRMMOD /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..FRMBAS / /                                                                    " + ControlChars.NewLine
            sMacro &= "..FRMPAR / /                                                                    " + ControlChars.NewLine
            sMacro &= "..VARPNM //                                                                     " + ControlChars.NewLine
            sMacro &= "..CVARPR /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..ZAGRAD /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..HOLTYP /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..BTMADJ /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..BLTMOD /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..HOLMAN /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..EXLENG /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..HOLMLE /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..BLTHED /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..SIKVAL /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..EXCVAL /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..PREVAL /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..KNPMAX /9/                                                                    " + ControlChars.NewLine
            sMacro &= "..ADJPOS /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..ADJPOS /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..ADJPOS /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..ADJPOS /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..ADJPOS /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..ADJPOS /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..ADJPOS /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..ADJPOS /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..ADJPOS /0.000000/                                                             " + ControlChars.NewLine
            sMacro &= "..HANTEN /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..HANTEN /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..HANTEN /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..HANTEN /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..HANTEN /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..HANTEN /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..HANTEN /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..HANTEN /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..HANTEN /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..ACTKPT /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..ACTKPT /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..ACTKPT /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..ACTKPT /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..ACTKPT /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..ACTKPT /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..ACTKPT /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..ACTKPT /0/                                                                    " + ControlChars.NewLine
            sMacro &= "..ACTKPT /0/                                                                    " + ControlChars.NewLine
Jump1:
            sMacro &= "..PRTEND /1/                    " + ControlChars.NewLine

        ElseIf Pene = 0 Then

            sMacro = ";BLOAD                                                                          " + ControlChars.NewLine
            sMacro &= ";JLOD                                                                           " + ControlChars.NewLine
            sMacro &= ";JELM                                                                           " + ControlChars.NewLine
            sMacro &= "@IOFF                                                                           " + ControlChars.NewLine
            sMacro &= "@IOFF                                                                           " + ControlChars.NewLine
            sMacro &= ";LAY                                                                            " + ControlChars.NewLine
            sMacro &= ";LOD                                                                            " + ControlChars.NewLine
            sMacro &= ".ZUMEN /タップ穴(下穴連動)@3D                   /                               " + ControlChars.NewLine
            sMacro &= ".DIR1 /C:\ICADSX\JISPARTS\USER\_旧式\3D\01_ねじ穴(英)\04_TAP           /        " + ControlChars.NewLine
            sMacro &= "                                                                                " + ControlChars.NewLine
            sMacro &= ".DIR2 /                                                                /        " + ControlChars.NewLine
            sMacro &= "                                                                                " + ControlChars.NewLine
            sMacro &= ".DIR3 /                                                                /        " + ControlChars.NewLine
            sMacro &= "                                                                                " + ControlChars.NewLine
            sMacro &= ".DIR4 /                                                                /        " + ControlChars.NewLine
            sMacro &= "                                                                                " + ControlChars.NewLine
            sMacro &= ".HAICHI /M" + Yobi.ToString + "TAP_" + DpBox.Text + "DP.                             /                              " + ControlChars.NewLine
            sMacro &= ".ATR1 /33554432/                                                                " + ControlChars.NewLine
            sMacro &= ".ATR2 /5       /                                                                " + ControlChars.NewLine
            sMacro &= ".GENTENX /434.827885  /                                                         " + ControlChars.NewLine
            sMacro &= ".GENTENY /210.860544  /                                                         " + ControlChars.NewLine
            sMacro &= ".COMMENT /_M" + Yobi.ToString + "                                             /                     " + ControlChars.NewLine
            sMacro &= ".ATR3 /436207616   /                                                            " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= "..HOLATR /1/                                                                    " + ControlChars.NewLine
            sMacro &= "..HOLTEG /1/                                                                    " + ControlChars.NewLine
            sMacro &= "..HOLNUM /4/                                                                    " + ControlChars.NewLine
            sMacro &= "..NPARM1 /16777216/                                                             " + ControlChars.NewLine
            sMacro &= "..PRTVER /1/                                                                    " + ControlChars.NewLine
            sMacro &= ".YOBI /M" + Yobi.ToString + "                      /                                                " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= ".PARAM /l                                               /                       " + ControlChars.NewLine
            sMacro &= ".ATAI /" + DpBox.Text + "          /                                                            " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= ".PARAM /lr                                              /                       " + ControlChars.NewLine
            sMacro &= ".ATAI /1.25        /                                                            " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= ".PARAM /d                                               /                       " + ControlChars.NewLine
            sMacro &= ".ATAI /" + Yobi.ToString + "           /                                                            " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= ".PARAM /a                                               /                       " + ControlChars.NewLine
            sMacro &= ".ATAI /" + HoleInfo(index, 2).ToString + "        /                                                            " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= ".PARAM /                                                /                       " + ControlChars.NewLine
            sMacro &= ".ATAI /0           /                                                            " + ControlChars.NewLine
            sMacro &= ":                                                                               " + ControlChars.NewLine
            sMacro &= "..PRTEND /1/                                                     " + ControlChars.NewLine

        End If




        Try
            ICADObj = CreateObject("ICAD.Application")
            ICADObj.Activate()

            ICADObj.RunCommand(sMacro, ICADOLEA.COMMANDMODE.MODE_MACRO)
        Finally
            If Not ICADObj Is Nothing Then
                While System.Runtime.InteropServices.Marshal.ReleaseComObject(ICADObj) > 0
                End While
            End If

        End Try


        Debug.Print(sMacro)

        While Marshal.ReleaseComObject(ICADObj) > 0
        End While
    End Sub

    Private Sub FrmPlcHole_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
