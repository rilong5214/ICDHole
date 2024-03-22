<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlcHole
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PlaceHole = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DpBox = New System.Windows.Forms.TextBox()
        Me.YobiBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ItaBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PeneBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'PlaceHole
        '
        Me.PlaceHole.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlaceHole.Location = New System.Drawing.Point(79, 152)
        Me.PlaceHole.Name = "PlaceHole"
        Me.PlaceHole.Size = New System.Drawing.Size(136, 49)
        Me.PlaceHole.TabIndex = 5
        Me.PlaceHole.Text = "穴配置"
        Me.PlaceHole.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(55, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "穴深さ"
        '
        'DpBox
        '
        Me.DpBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.DpBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.DpBox.Location = New System.Drawing.Point(151, 35)
        Me.DpBox.Name = "DpBox"
        Me.DpBox.Size = New System.Drawing.Size(100, 20)
        Me.DpBox.TabIndex = 2
        '
        'YobiBox
        '
        Me.YobiBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.YobiBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.YobiBox.Location = New System.Drawing.Point(151, 9)
        Me.YobiBox.Name = "YobiBox"
        Me.YobiBox.Size = New System.Drawing.Size(100, 20)
        Me.YobiBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "呼び（M6，M8...）"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "板厚検知"
        '
        'ItaBox
        '
        Me.ItaBox.AutoCompleteCustomSource.AddRange(New String() {"0", "1"})
        Me.ItaBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ItaBox.Location = New System.Drawing.Point(151, 67)
        Me.ItaBox.Name = "ItaBox"
        Me.ItaBox.Size = New System.Drawing.Size(100, 20)
        Me.ItaBox.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(55, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "貫通"
        '
        'PeneBox
        '
        Me.PeneBox.AutoCompleteCustomSource.AddRange(New String() {"0", "1"})
        Me.PeneBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.PeneBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.PeneBox.Location = New System.Drawing.Point(151, 100)
        Me.PeneBox.Name = "PeneBox"
        Me.PeneBox.Size = New System.Drawing.Size(100, 20)
        Me.PeneBox.TabIndex = 4
        '
        'FrmPlcHole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 213)
        Me.Controls.Add(Me.PeneBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ItaBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.YobiBox)
        Me.Controls.Add(Me.DpBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PlaceHole)
        Me.Name = "FrmPlcHole"
        Me.Text = "タップ穴配置"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PlaceHole As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents DpBox As TextBox
    Friend WithEvents YobiBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ItaBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PeneBox As TextBox
End Class
