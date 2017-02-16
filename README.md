# DB_CodeChallenge_VBNET
Little 15-minute class project. Get the list box to display the db records.

    Imports System.ComponentModel
    Imports System.Data.SqlClient

    Public Class Form1
        Dim dbConnect As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=N:\dpope3\Documents\Visual Studio 2015\Projects\DB_CodeChallenge_1\DB_CodeChallenge_1\Lotr.mdf;Integrated Security=True")
        Dim lotrCharacters As New BindingList(Of Character)

        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
            lbxLOTR.DataSource = lotrCharacters
            lbxLOTR.DisplayMember = "DisplayName"

            Try
                dbConnect.Open()
                Dim selectCommand As New SqlCommand("SELECT * FROM Character", dbConnect)
                Dim reader As SqlDataReader = selectCommand.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read
                        Dim dbCharacter As New Character()
                        dbCharacter.Name = reader.Item("Name").ToString
                        dbCharacter.Race = reader.Item("Race").ToString
                        lotrCharacters.Add(dbCharacter)
                    End While
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            Finally
                dbConnect.Close()
                dbConnect.Dispose()
            End Try
        End Sub
    End Class
