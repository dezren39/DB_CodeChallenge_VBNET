Public Class Character

    Private cName As String
    Private cRace As String


    Public Property Name() As String
        Get
            Return cName
        End Get
        Set(ByVal value As String)
            cName = value
        End Set
    End Property

    Public Property Race() As String
        Get
            Return cRace
        End Get
        Set(ByVal value As String)
            cRace = value
        End Set
    End Property

    Public ReadOnly Property DisplayName() As String
        Get
            Dim cDisplayName As String = cName + " - " + cRace
            Return cDisplayName
        End Get
    End Property
End Class
