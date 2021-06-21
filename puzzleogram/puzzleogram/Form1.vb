Public Class PUZZLEOGRAM
    Private logoAnimation, delay As Decimal
    Private username As String
    Private speach As Integer
    Private tut1box1, tut1box2, tut1box3 As Boolean
    'Dim array
    Dim cmdtut1box(2) As Button
    Dim cmdtut2box(4) As Button
    Dim cmdtut5box(24) As Button
    Dim easy1boxes(24) As Button
    Dim easy2boxes(24) As Button
    Dim easy3boxes(24) As Button
    Dim med1boxes(99) As Button
    Dim med2boxes(99) As Button
    Dim med3boxes(99) As Button
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(800, 260)
        Me.BackColor = Color.Black
        logoAnimation = -800
        pbxMainlogo.Location = New Point(-760, 130)
        tmrAnimation.Enabled = True
        delay = 0
        pbxNextTUT.Location = New Point(337, 548)
        pbxSpeachBox.Location = New Point(18, 363)
        lblSpeach.Location = New Point(74, 392)
        gpbTutoriallvl1.Text = ""
        gpbTutoriallvl2.Text = ""
        gpbTutoriallvl3.Text = ""
        gpbTutoriallvl4.Text = ""
        gpbTutoriallvl5.Text = ""

        My.Computer.Audio.Play(My.Resources.BG, AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub tmrAnimation_Tick(sender As Object, e As EventArgs) Handles tmrAnimation.Tick
        If delay = 0 Then
            logoAnimation = logoAnimation + 10
            pbxMainlogo.Location = New Point(logoAnimation, 13)
            If logoAnimation = -10 Then
                tmrAnimation.Enabled = False
                tmrDelay.Enabled = True
            End If
        Else
            logoAnimation = logoAnimation + 0.05
            Me.Opacity = logoAnimation
            If logoAnimation = 1 Then
                tmrAnimation.Enabled = False
            End If
        End If

    End Sub

    Private Sub tmrDelay_Tick(sender As Object, e As EventArgs) Handles tmrDelay.Tick
        delay = delay + 1
        If delay = 60 Then
            animationMainScreen()
        End If
    End Sub
    Private Sub animationMainScreen()
        tmrDelay.Enabled = False
        pbxMainlogo.Visible = False
        Me.Size = New Size(950, 690)
        Me.Opacity = 0
        logoAnimation = 0
        gpbMainMenu.Visible = True
        gpbMainMenu.Location = New Point(0, -40)
        gpbMainMenu.Size = New Size(950, 690)
        tmrAnimation.Enabled = True

    End Sub

    Private Sub pbxPlayButton_Hover(sender As Object, e As EventArgs) Handles pbxPlayButton.MouseHover
        pbxPlayButton.Image = My.Resources.play_button_pressed
    End Sub
    Private Sub pbxPlayButton_Leave(sender As Object, e As EventArgs) Handles pbxPlayButton.MouseLeave
        pbxPlayButton.Image = My.Resources.play_button1
    End Sub

    Private Sub pbxPlayButton_Click(sender As Object, e As EventArgs) Handles pbxPlayButton.Click

        gpbMainMenu.Visible = False
        gpbUsername.Visible = True
        gpbUsername.Location = New Point(0, -40)
        gpbUsername.Size = New Size(950, 690)
        txtName.Select()
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        lblName.Text = txtName.Text
    End Sub
    Private Sub pbxNext_Click(sender As Object, e As EventArgs) Handles pbxNext.Click
        gpbUsername.Visible = False
        username = txtName.Text
        gpbTutorial.Visible = True
        gpbTutorial.Location = New Point(0, -40)
        gpbTutorial.Size = New Size(950, 690)
        lblSpeach.Parent = pbxSpeachBox
        lblSpeach.Location = New Point(32, 27)
        lblSpeach.Text = username + ", Welcome to Puzzleogram !! " & Environment.NewLine & "Are you ready for the puzzle??" & Environment.NewLine & "If not you can just quit the game right now."
        speach = 1
    End Sub


    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        If cmdtut1box(0).Tag = 1 And cmdtut1box(1).Tag = 1 And cmdtut1box(2).Tag = 1 Then
            cmdtut1box(0).Tag = 0
            speach = 4
            pbxSolved.Parent = gpbTutoriallvl1
            pbxSolved.Location = New Point(150, 3)
            solved()
            cmdtut1box(0).SendToBack()
            cmdtut1box(1).SendToBack()
            pbxNextTUT.Enabled = True
            lblSpeach.Text = "Humm... Looks like you are not as dumb " & Environment.NewLine & "as i thought." & Environment.NewLine & "Now try this new one."
        End If

        If gpbTutoriallvl2.Visible = True Then
            Dim fill As Integer = 0
            Dim blank As Integer = 0
            For i = 1 To 4
                If cmdtut2box(i).Tag = 1 Then
                    fill += 1
                Else
                    fill = 0
                End If
            Next
            If cmdtut2box(0).Tag = 0 Then
                blank = 1
            End If
            If fill = 4 And blank = 1 Then
                cmdtut2box(1).Tag = 0
                speach = 5
                pbxSolved.Parent = gpbTutoriallvl2
                pbxSolved.Location = New Point(150, 3)
                solved()
                pbxNextTUT.Enabled = True
                lblSpeach.Text = "WOW... that was fast .... " & Environment.NewLine & "Here is the next tutorial..." & Environment.NewLine & "Try to get this one...."
            End If
        End If
        If gpbTutoriallvl3.Visible = True Then
            If cmdtut3box1.Tag = 1 And cmdtut3box2.Tag = 1 And cmdtut3box3.Tag = 0 And cmdtut3box4.Tag = 1 And cmdtut3box5.Tag = 1 Then
                cmdtut3box1.Tag = 0
                speach = 6
                pbxSolved.Parent = gpbTutoriallvl3
                pbxSolved.Location = New Point(150, 3)
                solved()
                pbxNextTUT.Enabled = True
                lblSpeach.Text = "IMPROVEMENT!!!" & Environment.NewLine & "GOOD JOB!" & Environment.NewLine & "TIME TO GET IN TO SOME REAL DEAL!"
            End If
        End If
        If gpbTutoriallvl4.Visible = True Then
            If cmdtut4box1.Tag = 1 And cmdtut4box2.Tag = 1 And cmdtut4box3.Tag = 0 And cmdtut4box4.Tag = 1 And cmdtut4box5.Tag = 1 And cmdtut4box6.Tag = 1 And cmdtut4box7.Tag = 1 And cmdtut4box8.Tag = 1 And cmdtut4box9.Tag = 1 Then
                cmdtut4box1.Tag = 0
                speach = 7
                pbxSolved.Parent = gpbTutoriallvl4
                pbxSolved.Location = New Point(80, 50)
                solved()
                pbxNextTUT.Enabled = True
                lblSpeach.Text = "Now that is what I called a good player" & Environment.NewLine & "Lets try a HARDER one!" & Environment.NewLine & "Lets see if you can finish it in 1 min."
            End If
        End If
        If gpbTutoriallvl5.Visible = True Then
            Dim fill As Integer = 0
            Dim blank As Integer = 0
            For i = 0 To 24
                If cmdtut5box(i).Tag = 1 Then
                    fill += 1
                ElseIf cmdtut5box(6).Tag = 0 And cmdtut5box(7).Tag = 0 And cmdtut5box(8).Tag = 0 And
                cmdtut5box(11).Tag = 0 And cmdtut5box(13).Tag = 0 And
                cmdtut5box(16).Tag = 0 And cmdtut5box(17).Tag = 0 And cmdtut5box(18).Tag = 0 Then
                    blank = 1
                End If
            Next

            If fill = 17 And blank = 1 And tut5 = 0 Then
                speach = 8
                pbxSolved.Parent = gpbTutoriallvl5
                pbxSolved.Location = New Point(210, 299)
                solved()
                pbxNextTUT.Enabled = True
                tut5 = 1
            Else
                fill = 0
                blank = 0
            End If
        End If
    End Sub
    Dim tut5 As Integer = 0
    Private Sub pbxNextTUT_Click(sender As Object, e As EventArgs) Handles pbxNextTUT.Click
        If speach = 1 Then
            lblSpeach.Text = "So this is the tutorial" & Environment.NewLine & " if you think you are better than me go on" & Environment.NewLine & " and click the skip button.Or else click NEXT."
            speach = 2
        ElseIf speach = 2 Then
            lblSpeach.Text = "I guess you are not that smart." & Environment.NewLine & "Are you sure you are ready for this?"
            speach = 3
        ElseIf speach = 3 Then
            lblSpeach.Text = "Ok first let me show you the easiest puzzle," & Environment.NewLine & "Left click on the squares to fill them in." & Environment.NewLine & " Fill in all the squares."
            gpbTutoriallvl1.Visible = True
            gpbTutoriallvl1.Location = New Point(218, 87)
            gpbTutoriallvl1.Size = New Size(500, 240)
            pbxNextTUT.Enabled = False
            For i = 0 To 2
                cmdtut1box(i) = New Button
                cmdtut1box(i).BackColor = Color.LightBlue
                cmdtut1box(i).Height = 110
                cmdtut1box(i).Width = 86
                cmdtut1box(i).Left = 92 * i + 222
                cmdtut1box(i).Top = 120
                gpbTutoriallvl1.Controls.Add(cmdtut1box(i))
                AddHandler cmdtut1box(i).MouseDown, AddressOf Box_Click

            Next
            tmrCheck.Enabled = True
        ElseIf speach = 4 Then
            lblSpeach.Text = "The numbers on the sides of the " & Environment.NewLine & "grid are hints." & Environment.NewLine & "Use these hints to solve the puzzle."
            gpbTutoriallvl1.Visible = False
            gpbTutoriallvl2.Visible = True
            gpbTutoriallvl2.Location = New Point(128, 91)
            gpbTutoriallvl2.Size = New Size(690, 240)
            pbxSolved.Visible = False
            pbxNextTUT.Enabled = False
            For i = 0 To 4
                cmdtut2box(i) = New Button
                cmdtut2box(i).BackColor = Color.LightBlue
                cmdtut2box(i).Height = 110
                cmdtut2box(i).Width = 86
                cmdtut2box(i).Left = 92 * i + 222
                cmdtut2box(i).Top = 120
                gpbTutoriallvl2.Controls.Add(cmdtut2box(i))
                AddHandler cmdtut2box(i).MouseDown, AddressOf Box_Click
            Next
        ElseIf speach = 5 Then
            lblSpeach.Text = "Some rows will have more than one number as a hint. " & Environment.NewLine & "You MUST leave at least one empty square" & Environment.NewLine & "in between each number."
            gpbTutoriallvl2.Visible = False
            gpbTutoriallvl3.Location = New Point(128, 69)
            gpbTutoriallvl3.Size = New Size(690, 240)
            pbxSolved.Visible = False
            pbxNextTUT.Enabled = False
            gpbTutoriallvl3.Visible = True
        ElseIf speach = 6 Then
            lblSpeach.Text = "You should never have to guess. " & Environment.NewLine & "Every puzzle can be worked out logically."
            gpbTutoriallvl3.Visible = False
            gpbTutoriallvl4.Location = New Point(295, 11)
            gpbTutoriallvl4.Size = New Size(312, 355)
            pbxSolved.Visible = False
            pbxNextTUT.Enabled = False
            gpbTutoriallvl4.Visible = True
        ElseIf speach = 7 Then
            Me.Size = New Size(950, 728)
            gpbTutorial.Size = New Size(950, 728)
            pbxSpeachBox.Visible = False
            lblSpeach.Visible = False
            lblTag.Visible = False
            pbxNextTUT.Location = New Point(674, 330)
            gpbTutoriallvl4.Visible = False
            gpbTutoriallvl5.Location = New Point(27, 50)
            gpbTutoriallvl5.Size = New Size(579, 649)
            pbxSolved.Visible = False
            lblReminder.Visible = True
            pbxNextTUT.Enabled = False
            For i = 0 To 24
                cmdtut5box(i) = New Button
                cmdtut5box(i).BackColor = Color.LightBlue
                cmdtut5box(i).Height = 84
                cmdtut5box(i).Width = 63
                If i < 5 Then
                    cmdtut5box(i).Left = 68 * i + 230
                    cmdtut5box(i).Top = 210
                ElseIf i > 4 And i < 10 Then
                    cmdtut5box(i).Left = 68 * (i - 5) + 230
                    cmdtut5box(i).Top = 299
                ElseIf i > 9 And i < 15 Then
                    cmdtut5box(i).Left = 68 * (i - 10) + 230
                    cmdtut5box(i).Top = 386
                ElseIf i > 14 And i < 20 Then
                    cmdtut5box(i).Left = 68 * (i - 15) + 230
                    cmdtut5box(i).Top = 472
                ElseIf i > 19 And i < 25 Then
                    cmdtut5box(i).Left = 68 * (i - 20) + 230
                    cmdtut5box(i).Top = 556
                End If
                gpbTutoriallvl5.Controls.Add(cmdtut5box(i))
                AddHandler cmdtut5box(i).MouseDown, AddressOf Box_Click
            Next
            gpbTutoriallvl5.Visible = True
        ElseIf speach = 8 Then
            gpbTutoriallvl5.Visible = False
            Me.Size = New Size(950, 690)
            lblReminder.Visible = False
            gpbTutorial.Size = New Size(950, 690)
            pbxSpeachBox.Visible = True
            lblSpeach.Visible = True
            lblTag.Visible = True
            pbxNextTUT.Location = New Point(337, 548)
            speach = 9
            lblSpeach.Text = "Now you are ready to goto the real world, kid.." & Environment.NewLine & "HaVe FuN pLayInG oUr GamE ;)"
        ElseIf speach = 9 Then
            gpbTutorial.Visible = False
            Me.Size = New Size(817, 615)
            plLvlSelection.Visible = True
            plLvlSelection.Location = New Point(0, 0)
            plLvlSelection.Size = New Size(802, 581)
        End If
    End Sub
    'SKIP AND SOLVE BUTTON
    Private Sub cmdSkip_Click(sender As Object, e As EventArgs) Handles pbxSkip.Click
        gpbTutorial.Visible = False
        Me.Size = New Size(817, 615)
        plLvlSelection.Size = New Size(802, 581)
        plLvlSelection.Visible = True
        plLvlSelection.Location = New Point(0, 0)

    End Sub
    Dim solveanimate As Integer
    Private Sub solved()
        pbxSolved.Image = imlsolve.Images(0)
        solveanimate = 0
        pbxSolved.Visible = True
        pbxSolved.BringToFront()
        tmrSolve.Enabled = True
    End Sub

    Private Sub Box_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdtut3box1.MouseDown, cmdtut3box2.MouseDown, cmdtut3box3.MouseDown, cmdtut3box4.MouseDown, cmdtut3box5.MouseDown,
        cmdtut4box1.MouseDown, cmdtut4box2.MouseDown, cmdtut4box3.MouseDown, cmdtut4box4.MouseDown, cmdtut4box5.MouseDown, cmdtut4box6.MouseDown, cmdtut4box7.MouseDown, cmdtut4box8.MouseDown, cmdtut4box9.MouseDown
        If e.Button = MouseButtons.Left Then
            If sender.Tag = 1 Then
                sender.Image = Nothing
                sender.tag = 0
                sender.text = Nothing
            ElseIf sender.text = Nothing Then
                sender.Image = imlBoxes.Images(0)
                sender.tag = 1
                sender.text = "  "
            End If
        ElseIf e.Button = MouseButtons.Right Then
            If sender.text = " " Then
                sender.Image = Nothing
                sender.tag = 0
                sender.text = Nothing
            ElseIf sender.text = Nothing Then
                sender.Image = imlBoxes.Images(1)
                sender.tag = 0
                sender.text = " "
            End If
        End If
    End Sub
    'EASY 1
    Private Sub easy1()
        plEasy1.Visible = True
        plEasy1.Size = New Size(552, 484)
        For i = 0 To 24
            easy1boxes(i) = New Button
            easy1boxes(i).BackColor = Color.LightBlue
            easy1boxes(i).Height = 64
            easy1boxes(i).Width = 64
            If i < 5 Then
                easy1boxes(i).Left = 66 * i + 214
                easy1boxes(i).Top = 146
            ElseIf i > 4 And i < 10 Then
                easy1boxes(i).Left = 66 * (i - 5) + 214
                easy1boxes(i).Top = 212
            ElseIf i > 9 And i < 15 Then
                easy1boxes(i).Left = 66 * (i - 10) + 214
                easy1boxes(i).Top = 278
            ElseIf i > 14 And i < 20 Then
                easy1boxes(i).Left = 66 * (i - 15) + 214
                easy1boxes(i).Top = 344
            ElseIf i > 19 And i < 25 Then
                easy1boxes(i).Left = 66 * (i - 20) + 214
                easy1boxes(i).Top = 410
            End If
            plEasy1.Controls.Add(easy1boxes(i))
            AddHandler easy1boxes(i).MouseDown, AddressOf Box_Click
        Next
        tmrLevelChecker.Enabled = True
    End Sub
    'EASY 2
    Private Sub easy2()
        plEasy2.Visible = True
        plEasy2.Size = New Size(477, 540)
        For i = 0 To 24
            easy2boxes(i) = New Button
            easy2boxes(i).BackColor = Color.LightBlue
            easy2boxes(i).Height = 63
            easy2boxes(i).Width = 63
            If i < 5 Then
                easy2boxes(i).Left = 65 * i + 144
                easy2boxes(i).Top = 208
            ElseIf i > 4 And i < 10 Then
                easy2boxes(i).Left = 65 * (i - 5) + 144
                easy2boxes(i).Top = 273
            ElseIf i > 9 And i < 15 Then
                easy2boxes(i).Left = 65 * (i - 10) + 144
                easy2boxes(i).Top = 337
            ElseIf i > 14 And i < 20 Then
                easy2boxes(i).Left = 65 * (i - 15) + 144
                easy2boxes(i).Top = 402
            ElseIf i > 19 And i < 25 Then
                easy2boxes(i).Left = 65 * (i - 20) + 144
                easy2boxes(i).Top = 467
            End If
            plEasy2.Controls.Add(easy2boxes(i))
            AddHandler easy2boxes(i).MouseDown, AddressOf Box_Click
        Next
        tmrLevelChecker.Enabled = True
    End Sub
    'EASY 3
    Private Sub easy3()
        plEasy3.Visible = True
        plEasy3.Size = New Size(618, 546)
        For i = 0 To 24
            easy3boxes(i) = New Button
            easy3boxes(i).BackColor = Color.LightBlue
            easy3boxes(i).Height = 71
            easy3boxes(i).Width = 71
            If i < 5 Then
                easy3boxes(i).Left = 74 * i + 239
                easy3boxes(i).Top = 166
            ElseIf i > 4 And i < 10 Then
                easy3boxes(i).Left = 74 * (i - 5) + 239
                easy3boxes(i).Top = 240
            ElseIf i > 9 And i < 15 Then
                easy3boxes(i).Left = 74 * (i - 10) + 239
                easy3boxes(i).Top = 314
            ElseIf i > 14 And i < 20 Then
                easy3boxes(i).Left = 74 * (i - 15) + 239
                easy3boxes(i).Top = 389
            ElseIf i > 19 And i < 25 Then
                easy3boxes(i).Left = 74 * (i - 20) + 239
                easy3boxes(i).Top = 462
            End If
            plEasy3.Controls.Add(easy3boxes(i))
            AddHandler easy3boxes(i).MouseDown, AddressOf Box_Click
        Next
        tmrLevelChecker.Enabled = True
    End Sub
    'MED 1
    Private Sub med1()
        plMed1.Visible = True
        plMed1.Size = New Size(631, 588)
        For i = 0 To 99
            med1boxes(i) = New Button
            med1boxes(i).BackColor = Color.LightBlue
            med1boxes(i).Height = 44
            med1boxes(i).Width = 44
            If i < 10 Then
                med1boxes(i).Left = 44 * i + 184
                med1boxes(i).Top = 140
            ElseIf i > 9 And i < 20 Then
                med1boxes(i).Left = 44 * (i - 10) + 184
                med1boxes(i).Top = 140 + (44 * 1)
            ElseIf i > 19 And i < 30 Then
                med1boxes(i).Left = 44 * (i - 20) + 184
                med1boxes(i).Top = 140 + (44 * 2)
            ElseIf i > 29 And i < 40 Then
                med1boxes(i).Left = 44 * (i - 30) + 184
                med1boxes(i).Top = 140 + (44 * 3)
            ElseIf i > 39 And i < 50 Then
                med1boxes(i).Left = 44 * (i - 40) + 184
                med1boxes(i).Top = 140 + (44 * 4)
            ElseIf i > 49 And i < 60 Then
                med1boxes(i).Left = 44 * (i - 50) + 184
                med1boxes(i).Top = 140 + (44.5 * 5)
            ElseIf i > 59 And i < 70 Then
                med1boxes(i).Left = 44 * (i - 60) + 184
                med1boxes(i).Top = 140 + (44 * 6)
            ElseIf i > 69 And i < 80 Then
                med1boxes(i).Left = 44 * (i - 70) + 184
                med1boxes(i).Top = 140 + (44 * 7)
            ElseIf i > 79 And i < 90 Then
                med1boxes(i).Left = 44 * (i - 80) + 184
                med1boxes(i).Top = 140 + (44 * 8)
            ElseIf i > 89 And i < 100 Then
                med1boxes(i).Left = 44 * (i - 90) + 184
                med1boxes(i).Top = 140 + (44 * 9)
            End If
            plMed1.Controls.Add(med1boxes(i))
            AddHandler med1boxes(i).MouseDown, AddressOf Box_Click
        Next
        tmrLevelChecker.Enabled = True
    End Sub

    'MED 2
    Private Sub med2()
        plMed2.Visible = True
        plMed2.Size = New Size(603, 605)
        For i = 0 To 99
            med2boxes(i) = New Button
            med2boxes(i).BackColor = Color.LightBlue
            med2boxes(i).Height = 45
            med2boxes(i).Width = 45
            If i < 10 Then
                med2boxes(i).Left = 45 * i + 145
                med2boxes(i).Top = 144
            ElseIf i > 9 And i < 20 Then
                med2boxes(i).Left = 45 * (i - 10) + 145
                med2boxes(i).Top = 144 + (45.5 * 1)
            ElseIf i > 19 And i < 30 Then
                med2boxes(i).Left = 45 * (i - 20) + 145
                med2boxes(i).Top = 144 + (45.5 * 2)
            ElseIf i > 29 And i < 40 Then
                med2boxes(i).Left = 45 * (i - 30) + 145
                med2boxes(i).Top = 144 + (45.5 * 3)
            ElseIf i > 39 And i < 50 Then
                med2boxes(i).Left = 45 * (i - 40) + 145
                med2boxes(i).Top = 144 + (45.5 * 4)
            ElseIf i > 49 And i < 60 Then
                med2boxes(i).Left = 45 * (i - 50) + 145
                med2boxes(i).Top = 144 + (45.5 * 5)
            ElseIf i > 59 And i < 70 Then
                med2boxes(i).Left = 45 * (i - 60) + 145
                med2boxes(i).Top = 144 + (45.5 * 6)
            ElseIf i > 69 And i < 80 Then
                med2boxes(i).Left = 45 * (i - 70) + 145
                med2boxes(i).Top = 144 + (45.5 * 7)
            ElseIf i > 79 And i < 90 Then
                med2boxes(i).Left = 45 * (i - 80) + 145
                med2boxes(i).Top = 144 + (45.5 * 8)
            ElseIf i > 89 And i < 100 Then
                med2boxes(i).Left = 45 * (i - 90) + 145
                med2boxes(i).Top = 144 + (45.5 * 9)
            End If
            plMed2.Controls.Add(med2boxes(i))
            AddHandler med2boxes(i).MouseDown, AddressOf Box_Click
        Next
        tmrLevelChecker.Enabled = True
    End Sub

    'MED 3
    Private Sub med3()
        plMed3.Visible = True
        plMed3.Size = New Size(605, 606)
        For i = 0 To 99
            med3boxes(i) = New Button
            med3boxes(i).BackColor = Color.LightBlue
            med3boxes(i).Height = 38
            med3boxes(i).Width = 38
            If i < 10 Then
                med3boxes(i).Left = 39.4 * i + 206
                med3boxes(i).Top = 207
            ElseIf i > 9 And i < 20 Then
                med3boxes(i).Left = 39.4 * (i - 10) + 206
                med3boxes(i).Top = 207 + (39 * 1)
            ElseIf i > 19 And i < 30 Then
                med3boxes(i).Left = 39.4 * (i - 20) + 206
                med3boxes(i).Top = 207 + (39 * 2)
            ElseIf i > 29 And i < 40 Then
                med3boxes(i).Left = 39.4 * (i - 30) + 206
                med3boxes(i).Top = 207 + (39 * 3)
            ElseIf i > 39 And i < 50 Then
                med3boxes(i).Left = 39.4 * (i - 40) + 206
                med3boxes(i).Top = 207 + (39 * 4)
            ElseIf i > 49 And i < 60 Then
                med3boxes(i).Left = 39.4 * (i - 50) + 206
                med3boxes(i).Top = 207 + (39.5 * 5)
            ElseIf i > 59 And i < 70 Then
                med3boxes(i).Left = 39.4 * (i - 60) + 206
                med3boxes(i).Top = 207 + (39 * 6)
            ElseIf i > 69 And i < 80 Then
                med3boxes(i).Left = 39.4 * (i - 70) + 206
                med3boxes(i).Top = 207 + (39 * 7)
            ElseIf i > 79 And i < 90 Then
                med3boxes(i).Left = 39.4 * (i - 80) + 206
                med3boxes(i).Top = 207 + (39 * 8)
            ElseIf i > 89 And i < 100 Then
                med3boxes(i).Left = 39.4 * (i - 90) + 206
                med3boxes(i).Top = 207 + (39 * 9)
            End If
            plMed3.Controls.Add(med3boxes(i))
            AddHandler med3boxes(i).MouseDown, AddressOf Box_Click
        Next
        tmrLevelChecker.Enabled = True
    End Sub
    Dim stoploop As Integer = 0
    Dim stoploop2 As Integer = 0
    Dim stoploop3 As Integer = 0
    Dim stoploop4 As Integer = 0
    Dim stoploop5 As Integer = 0
    Dim stoploop6 As Integer = 0
    'CHECKER
    Private Sub tmrLevelChecker_Tick(sender As Object, e As EventArgs) Handles tmrLevelChecker.Tick
        If plEasy1.Visible = True Then
            Dim fill As Integer = 0
            Dim blank As Integer = 0
            For i = 0 To 24
                If easy1boxes(i).Tag = 1 Then
                    fill += 1
                ElseIf easy1boxes(0).Tag = 0 And easy1boxes(4).Tag = 0 And easy1boxes(11).Tag = 0 And
                    easy1boxes(13).Tag = 0 And easy1boxes(21).Tag = 0 And easy1boxes(23).Tag = 0 Then
                    blank = 1
                End If
            Next
            If fill = 19 And blank = 1 And stoploop = 0 Then
                pbxSolved.Parent = plEasy1
                pbxSolved.Location = New Point(188, 165)
                solved()
                tmrSolveDelay.Enabled = True
                stoploop = 1
            Else
                fill = 0
                blank = 0
            End If
            If lvl1 = 20 Then
                Me.Size = New Size(817, 615)
                plLvlSelection.Visible = True
                plEasy1.Visible = False
                pbxLvl2.Visible = True
                tmrSolveDelay.Enabled = False
            End If
        ElseIf plEasy2.Visible = True Then
            Dim fill As Integer = 0
            Dim blank As Integer = 0
            For i = 0 To 24
                If easy2boxes(i).Tag = 1 Then
                    fill += 1
                ElseIf easy2boxes(0).Tag = 0 And easy2boxes(4).Tag = 0 And easy2boxes(6).Tag = 0 And easy2boxes(7).Tag = 0 And
                    easy2boxes(8).Tag = 0 And easy2boxes(10).Tag = 0 And easy2boxes(14).Tag = 0 And easy2boxes(16).Tag = 0 And
                    easy2boxes(17).Tag = 0 And easy2boxes(18).Tag = 0 And easy2boxes(20).Tag = 0 And easy2boxes(24).Tag = 0 Then
                    blank = 1
                End If
            Next
            If fill = 13 And blank = 1 And stoploop2 = 0 Then
                pbxSolved.Parent = plEasy2
                pbxSolved.Location = New Point(188, 165)
                solved()
                tmrSolveDelay.Enabled = True
                stoploop2 = 1
            Else
                fill = 0
                blank = 0
            End If
            If lvl2 = 20 Then
                Me.Size = New Size(817, 615)
                plLvlSelection.Visible = True
                plEasy2.Visible = False
                pbxLvl3.Visible = True
                tmrSolveDelay.Enabled = False
            End If
        ElseIf plEasy3.Visible = True Then
            Dim fill As Integer = 0
            Dim blank As Integer = 0
            For i = 0 To 24
                If easy3boxes(i).Tag = 0 Then
                    blank += 1
                ElseIf easy3boxes(2).Tag = 1 And easy3boxes(6).Tag = 1 And easy3boxes(7).Tag = 1 And easy3boxes(8).Tag = 1 And
                    easy3boxes(10).Tag = 1 And easy3boxes(12).Tag = 1 And easy3boxes(14).Tag = 1 And easy3boxes(16).Tag = 1 And
                    easy3boxes(17).Tag = 1 And easy3boxes(18).Tag = 1 And easy3boxes(21).Tag = 1 And easy3boxes(23).Tag = 1 Then
                    fill = 1
                End If
            Next
            If blank = 13 And fill = 1 And stoploop3 = 0 Then
                pbxSolved.Parent = plEasy3
                pbxSolved.Location = New Point(188, 165)
                solved()
                tmrSolveDelay.Enabled = True
                stoploop3 = 1
            Else
                fill = 0
                blank = 0
            End If
            If lvl3 = 20 Then
                Me.Size = New Size(817, 615)
                plLvlSelection.Visible = True
                plEasy3.Visible = False
                pbxLvl4.Visible = True
                tmrSolveDelay.Enabled = False
            End If
        ElseIf plMed1.Visible = True Then
            Dim filla As Integer = 0
            Dim blanka As Integer = 0
            Dim fillb As Integer = 0
            Dim blankb As Integer = 0
            For a = 0 To 49
                If med1boxes(a).Tag = 1 Then
                    filla += 1
                ElseIf med1boxes(0).Tag = 0 And med1boxes(4).Tag = 0 And med1boxes(5).Tag = 0 And med1boxes(9).Tag = 0 And
                    med1boxes(13).Tag = 0 And med1boxes(14).Tag = 0 And med1boxes(15).Tag = 0 And med1boxes(16).Tag = 0 And
                    med1boxes(22).Tag = 0 And med1boxes(27).Tag = 0 And med1boxes(31).Tag = 0 And med1boxes(33).Tag = 0 And
                    med1boxes(34).Tag = 0 And med1boxes(35).Tag = 0 And med1boxes(36).Tag = 0 And med1boxes(38).Tag = 0 And
                    med1boxes(40).Tag = 0 And med1boxes(42).Tag = 0 And med1boxes(43).Tag = 0 And med1boxes(44).Tag = 0 And
                    med1boxes(45).Tag = 0 And med1boxes(46).Tag = 0 And med1boxes(47).Tag = 0 And med1boxes(49).Tag = 0 Then
                    blanka = 1
                End If
            Next
            For b = 50 To 99
                If med1boxes(b).Tag = 0 Then
                    blankb += 1
                ElseIf med1boxes(51).Tag = 1 And med1boxes(54).Tag = 1 And med1boxes(55).Tag = 1 And med1boxes(58).Tag = 1 And
                    med1boxes(61).Tag = 1 And med1boxes(65).Tag = 1 And med1boxes(68).Tag = 1 And med1boxes(71).Tag = 1 And
                    med1boxes(78).Tag = 1 And med1boxes(82).Tag = 1 And med1boxes(83).Tag = 1 And med1boxes(84).Tag = 1 And
                    med1boxes(85).Tag = 1 And med1boxes(86).Tag = 1 And med1boxes(87).Tag = 1 And med1boxes(91).Tag = 1 And med1boxes(98).Tag = 1 Then
                    fillb = 1
                End If
            Next
            If blanka = 1 And filla = 26 And fillb = 1 And blankb = 33 And stoploop4 = 0 Then
                pbxSolved.Parent = plMed1
                pbxSolved.Location = New Point(188, 165)
                solved()
                tmrSolveDelay.Enabled = True
                stoploop4 = 1
            Else
                filla = 0
                blanka = 0
                fillb = 0
                blankb = 0
            End If
            If lvl4 = 20 Then
                Me.Size = New Size(817, 615)
                plLvlSelection.Visible = True
                plMed1.Visible = False
                pbxLvl5.Visible = True
                tmrSolveDelay.Enabled = False
            End If
        ElseIf plMed2.Visible = True Then
            Dim filla As Integer = 0
            Dim blanka As Integer = 0
            Dim fillb As Integer = 0
            Dim blankb As Integer = 0
            For a = 0 To 49
                If med2boxes(a).Tag = 0 Then
                    blanka += 1
                ElseIf med2boxes(6).Tag = 1 And med2boxes(16).Tag = 1 And med2boxes(17).Tag = 1 And med2boxes(18).Tag = 1 And
                    med2boxes(19).Tag = 1 And med2boxes(21).Tag = 1 And med2boxes(25).Tag = 1 And med2boxes(26).Tag = 1 And
                    med2boxes(27).Tag = 1 And med2boxes(28).Tag = 1 And med2boxes(29).Tag = 1 And med2boxes(30).Tag = 1 And
                    med2boxes(34).Tag = 1 And med2boxes(35).Tag = 1 And med2boxes(36).Tag = 1 And med2boxes(40).Tag = 1 And
                    med2boxes(43).Tag = 1 And med2boxes(44).Tag = 1 And med2boxes(45).Tag = 1 And med2boxes(46).Tag = 1 Then
                    filla = 1
                End If
            Next
            For b = 50 To 99
                If med2boxes(b).Tag = 1 Then
                    fillb += 1
                ElseIf med2boxes(51).Tag = 0 And med2boxes(58).Tag = 0 And med2boxes(59).Tag = 0 And med2boxes(75).Tag = 0 And
                    med2boxes(77).Tag = 0 And med2boxes(78).Tag = 0 And med2boxes(82).Tag = 0 And med2boxes(84).Tag = 0 And
                    med2boxes(85).Tag = 0 And med2boxes(87).Tag = 0 And med2boxes(88).Tag = 0 And med2boxes(89).Tag = 0 And
                    med2boxes(90).Tag = 0 And med2boxes(95).Tag = 0 And med2boxes(98).Tag = 0 And med2boxes(99).Tag = 0 Then
                    blankb = 1
                End If
            Next
            If blanka = 30 And filla = 1 And fillb = 34 And blankb = 1 And stoploop5 = 0 Then
                pbxSolved.Parent = plMed2
                pbxSolved.Location = New Point(188, 165)
                solved()

                tmrSolveDelay.Enabled = True
                stoploop5 = 1
            Else
                filla = 0
                blanka = 0
                fillb = 0
                blankb = 0
            End If
            If lvl5 = 20 Then
                Me.Size = New Size(817, 615)
                plLvlSelection.Visible = True
                plMed2.Visible = False
                pbxLvl6.Visible = True
                tmrSolveDelay.Enabled = False
            End If
        ElseIf plMed3.Visible = True Then
            Dim filla As Integer = 0
            Dim blanka As Integer = 0
            Dim fillb As Integer = 0
            Dim blankb As Integer = 0
            For a = 0 To 49
                If med3boxes(a).Tag = 1 Then
                    filla += 1
                ElseIf med3boxes(4).Tag = 0 And med3boxes(5).Tag = 0 And med3boxes(12).Tag = 0 And med3boxes(13).Tag = 0 And
                    med3boxes(16).Tag = 0 And med3boxes(17).Tag = 0 And med3boxes(21).Tag = 0 And med3boxes(24).Tag = 0 And
                    med3boxes(25).Tag = 0 And med3boxes(28).Tag = 0 And med3boxes(31).Tag = 0 And med3boxes(33).Tag = 0 And
                    med3boxes(36).Tag = 0 And med3boxes(38).Tag = 0 And med3boxes(40).Tag = 0 And med3boxes(42).Tag = 0 And med3boxes(47).Tag = 0 And med3boxes(49).Tag = 0 Then
                    blanka = 1
                End If
            Next
            For b = 50 To 99
                If med3boxes(b).Tag = 1 Then
                    fillb += 1
                ElseIf med3boxes(50).Tag = 0 And med3boxes(52).Tag = 0 And med3boxes(57).Tag = 0 And med3boxes(59).Tag = 0 And
                    med3boxes(61).Tag = 0 And med3boxes(63).Tag = 0 And med3boxes(66).Tag = 0 And med3boxes(68).Tag = 0 And
                    med3boxes(71).Tag = 0 And med3boxes(74).Tag = 0 And med3boxes(75).Tag = 0 And med3boxes(78).Tag = 0 And
                    med3boxes(82).Tag = 0 And med3boxes(83).Tag = 0 And med3boxes(86).Tag = 0 And med3boxes(87).Tag = 0 And med3boxes(94).Tag = 0 And med3boxes(95).Tag = 0 Then
                    blankb = 1
                End If
            Next
            If blanka = 1 And filla = 32 And fillb = 32 And blankb = 1 And stoploop6 = 0 Then
                pbxSolved.Parent = plMed3
                pbxSolved.Location = New Point(188, 165)
                solved()
                tmrSolveDelay.Enabled = True
                stoploop6 = 1
            Else
                filla = 0
                blanka = 0
                fillb = 0
                blankb = 0
            End If
            If lvl6 = 20 Then
                Me.Size = New Size(817, 615)
                plLvlSelection.Visible = True
                plMed3.Visible = False
                tmrSolveDelay.Enabled = False
            End If
        End If
    End Sub

    Private Sub pbxLvl1_Click(sender As Object, e As EventArgs) Handles pbxLvl1.Click
        Me.Size = New Size(960, 720)
        plLevel1.Size = New Size(950, 690)
        plLvlSelection.Visible = False
        plLevel1.Visible = True
        plLevel1.Location = New Point(0, 0)
        easy1()
    End Sub
    Private Sub pbxLvl2_Click(sender As Object, e As EventArgs) Handles pbxLvl2.Click
        Me.Size = New Size(960, 720)
        plLvlSelection.Visible = False
        plLevel1.Visible = False
        plLevel2.Size = New Size(950, 690)
        plLevel2.Visible = True
        plLevel2.Location = New Point(0, 0)
        easy2()
    End Sub

    Private Sub pbxLvl3_Click(sender As Object, e As EventArgs) Handles pbxLvl3.Click
        Me.Size = New Size(960, 720)
        plLvlSelection.Visible = False
        plLevel2.Visible = False
        plLevel3.Size = New Size(950, 690)
        plLevel3.Visible = True
        plLevel3.Location = New Point(0, 0)
        easy3()
    End Sub

    Private Sub lblDev_Click(sender As Object, e As EventArgs) Handles lblDev.Click
        pbxLvl1.Visible = True
        pbxLvl2.Visible = True
        pbxLvl3.Visible = True
        pbxLvl4.Visible = True
        pbxLvl5.Visible = True
        pbxLvl6.Visible = True
    End Sub

    Private Sub BACKBUTTON(sender As Object, e As EventArgs) Handles pbxBack1.Click, pbxBack2.Click, pbxBack3.Click, pbxBack4.Click, pbxBack5.Click, pbxBack6.Click
        plLevel1.Visible = False
        plLevel2.Visible = False
        plLevel3.Visible = False
        plLevel4.Visible = False
        plLevel5.Visible = False
        plLevel6.Visible = False
        Me.Size = New Size(817, 615)
        plLvlSelection.Size = New Size(802, 581)
        plLvlSelection.Visible = True
        plLvlSelection.Location = New Point(0, 0)
    End Sub

    Private Sub tmrSolve_Tick(sender As Object, e As EventArgs) Handles tmrSolve.Tick

        pbxSolved.Image = imlsolve.Images(solveanimate)
        solveanimate += 1
        If solveanimate = 42 Then
            tmrSolve.Enabled = False
        End If
    End Sub
    Dim lvl1 As Decimal = 0
    Dim lvl2 As Decimal = 0
    Dim lvl3 As Decimal = 0
    Dim lvl4 As Decimal = 0
    Dim lvl5 As Decimal = 0
    Dim lvl6 As Decimal = 0
    Private Sub tmrSolveDelay_Tick(sender As Object, e As EventArgs) Handles tmrSolveDelay.Tick
        If plEasy1.Visible = True Then
            lvl1 += 1
        ElseIf plEasy2.Visible = True Then
            lvl2 += 1
        ElseIf plEasy3.Visible = True Then
            lvl3 += 1
        ElseIf plmed1.Visible = True Then
            lvl4 += 1
        ElseIf plmed2.Visible = True Then
            lvl5 += 1
        ElseIf plmed3.Visible = True Then
            lvl6 += 1
        End If
    End Sub

    Private Sub pbxLvl4_Click(sender As Object, e As EventArgs) Handles pbxLvl4.Click
        Me.Size = New Size(960, 720)
        plLvlSelection.Visible = False
        plLevel3.Visible = False
        plLevel4.Size = New Size(950, 690)
        plLevel4.Visible = True
        plLevel4.Location = New Point(0, 0)
        med1()
    End Sub
    Private Sub pbxLvl5_Click(sender As Object, e As EventArgs) Handles pbxLvl5.Click
        Me.Size = New Size(960, 720)
        plLvlSelection.Visible = False
        plLevel4.Visible = False
        plLevel5.Size = New Size(950, 690)
        plLevel5.Visible = True
        plLevel5.Location = New Point(0, 0)
        med2()
    End Sub
    Private Sub pbxLvl6_Click(sender As Object, e As EventArgs) Handles pbxLvl6.Click
        Me.Size = New Size(960, 720)
        plLvlSelection.Visible = False
        plLevel5.Visible = False
        plLevel6.Size = New Size(950, 690)
        plLevel6.Visible = True
        plLevel6.Location = New Point(0, 0)
        med3()
    End Sub
End Class
