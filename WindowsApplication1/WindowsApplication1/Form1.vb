Imports System.Data.OleDb
Public Class Form1
    Dim read As String
    Dim datafile As String
    Dim connstring As String
    Dim myconnection As OleDbConnection = New OleDbConnection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        read = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="

        datafile = "C:\Users\matty\Documents\DB1.mdb"

        connstring = read & datafile

        myconnection.ConnectionString = connstring

        Dim cmd As OleDbCommand = New OleDbCommand("select * from [Login] where [Username] = '" & TextBox1.Text & "' and [Password] = '" & TextBox2.Text & "'", myconnection)
        myconnection.Open()

        Dim dr As OleDbDataReader = cmd.ExecuteReader

        Dim userfound As Boolean = False
        Dim firstname As String = ""
        Dim lastname As String = ""

        While dr.Read
            userfound = True
            firstname = dr("firstname").ToString
            lastname = dr("lastname").ToString



        End While

        If userfound = True Then
            Form2.Show()
            Me.Hide()
            Form2.TextBox1.Text = "Welcome" & " " & firstname & " " & lastname
        Else
            MsgBox("Sorry, username or password not found", MsgBoxStyle.OkOnly, "Invalid Login")



        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = True
        Else
            TextBox2.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim ob As New Form4
        ob.Show()
        Me.Hide()
    End Sub
End Class
