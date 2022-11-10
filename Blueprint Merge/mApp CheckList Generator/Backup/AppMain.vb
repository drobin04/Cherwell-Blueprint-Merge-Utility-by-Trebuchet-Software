Public Class AppMain

    Dim LK As New LicKey

    Private Sub AppMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LK.SerialNo = 1
        LK.ProductID = 1
        LK.OptValue = 0

        Dim Code As String = LK.KeyCode
        tbKey.Text = Code
        tbLen.Text = tbKey.Text.Length
        Call SetChecks()
    End Sub

    Private Sub tbKey_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbKey.TextChanged

        LK.KeyCode = tbKey.Text.ToUpper

        If LK.SerialNo = 0 Then
            tbDecode.Text = "Invalid Key Entered"
        Else
            tbDecode.Text = "Serial: " & LK.SerialNo.ToString & vbCrLf
            tbDecode.Text = tbDecode.Text & "ProdID: " & LK.ProductID.ToString & vbCrLf
            tbDecode.Text = tbDecode.Text & "OptVal: " & LK.OptValue.ToString & vbCrLf
        End If

        Call SetChecks()
    End Sub

    Private Function NumbersOnly(ByVal pstrChar As Char, ByVal oTextBox As TextBox) As Boolean
        'Validate the entry for a textbox limiting it to only numeric values and the decimal point
       
        If pstrChar <> vbBack Then
            Return IIf(IsNumeric(pstrChar), False, True) 'Check if numeric is returned
        End If

        Return False 'For backspace
    End Function

    Private Sub SetChecks()
        tbSerial.Text = LK.SerialNo
        tbPID.Text = LK.ProductID
        dtpExpire.Value = LK.ExpDate

        CheckBox1.Checked = LK.OptionEnabled(1)
        CheckBox2.Checked = LK.OptionEnabled(2)
        CheckBox3.Checked = LK.OptionEnabled(3)
        CheckBox4.Checked = LK.OptionEnabled(4)
        CheckBox5.Checked = LK.OptionEnabled(5)
        CheckBox6.Checked = LK.OptionEnabled(6)
        CheckBox7.Checked = LK.OptionEnabled(7)
        CheckBox8.Checked = LK.OptionEnabled(8)
        CheckBox9.Checked = LK.OptionEnabled(9)
        CheckBox10.Checked = LK.OptionEnabled(10)
        CheckBox11.Checked = LK.OptionEnabled(11)
        CheckBox12.Checked = LK.OptionEnabled(12)
        CheckBox13.Checked = LK.OptionEnabled(13)
        CheckBox14.Checked = LK.OptionEnabled(14)
        CheckBox15.Checked = LK.OptionEnabled(15)
        CheckBox16.Checked = LK.OptionEnabled(16)
    End Sub

    Private Sub tbPID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPID.TextChanged
        Try
            LK.ProductID = Val(tbPID.Text)
        Catch ex As Exception
            LK.SerialNo = 0
        End Try

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub tbSerial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSerial.TextChanged
        Try
            LK.SerialNo = Val(tbSerial.Text)
        Catch ex As Exception
            LK.SerialNo = 0
        End Try

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            LK.SetOption(1)
        Else
            LK.UnsetOption(1)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            LK.SetOption(2)
        Else
            LK.UnsetOption(2)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            LK.SetOption(3)
        Else
            LK.UnsetOption(3)
        End If

        tbKey.Text = LK.KeyCode
    End Sub


    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked Then
            LK.SetOption(4)
        Else
            LK.UnsetOption(4)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked Then
            LK.SetOption(5)
        Else
            LK.UnsetOption(5)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked Then
            LK.SetOption(6)
        Else
            LK.UnsetOption(6)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked Then
            LK.SetOption(7)
        Else
            LK.UnsetOption(7)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked Then
            LK.SetOption(8)
        Else
            LK.UnsetOption(8)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked Then
            LK.SetOption(9)
        Else
            LK.UnsetOption(9)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox10.CheckedChanged
        If CheckBox10.Checked Then
            LK.SetOption(10)
        Else
            LK.UnsetOption(10)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked Then
            LK.SetOption(11)
        Else
            LK.UnsetOption(11)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox12.CheckedChanged
        If CheckBox12.Checked Then
            LK.SetOption(12)
        Else
            LK.UnsetOption(12)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox16_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox16.CheckedChanged
        If CheckBox16.Checked Then
            LK.SetOption(16)
        Else
            LK.UnsetOption(16)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox15_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox15.CheckedChanged
        If CheckBox15.Checked Then
            LK.SetOption(15)
        Else
            LK.UnsetOption(15)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox14_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked Then
            LK.SetOption(14)
        Else
            LK.UnsetOption(14)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub CheckBox13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox13.CheckedChanged
        If CheckBox13.Checked Then
            LK.SetOption(13)
        Else
            LK.UnsetOption(13)
        End If

        tbKey.Text = LK.KeyCode
    End Sub

    Private Sub dtpExpire_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpExpire.ValueChanged
        Try
            LK.ExpDate = dtpExpire.Value
            tbKey.Text = LK.KeyCode

        Catch ex As Exception
            Dim OV As UInt16 = 65535
            LK.OptValue = OV
            dtpExpire.Value = LK.ExpDate
            tbKey.Text = LK.KeyCode
        End Try

        Call SetChecks()

    End Sub

    Private Sub tbPID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPID.KeyPress
        If NumbersOnly(e.KeyChar, tbPID) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub tbSerial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSerial.KeyPress
        If NumbersOnly(e.KeyChar, tbSerial) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
End Class
