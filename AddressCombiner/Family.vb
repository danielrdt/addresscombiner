Public Class Family
    Private _members As New List(Of Person)

    Public ReadOnly Property Count As Integer
        Get
            Return _members.Count
        End Get
    End Property

    Public ReadOnly Property Members As Person()
        Get
            Return _members.ToArray
        End Get
    End Property

    Public ReadOnly Property FirstMember As Person
        Get
            Return _members.First
        End Get
    End Property

    Public ReadOnly Property Nachname As String
        Get
            Return _members.First.Nachname
        End Get
    End Property

    Public ReadOnly Property Strasse As String
        Get
            Return _members.First.Strasse
        End Get
    End Property

    Public ReadOnly Property PLZ As UInteger
        Get
            Return _members.First.PLZ
        End Get
    End Property

    Public ReadOnly Property Ort As String
        Get
            Return _members.First.Ort
        End Get
    End Property

    Public Sub New(firstMember As Person)
        _members.Add(firstMember)
    End Sub

    Public Sub AddMember(member As Person)
        _members.Add(member)
    End Sub
End Class
