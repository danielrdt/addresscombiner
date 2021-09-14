Public Class Person
    Private Shared _MitgliedsNrCol As Integer = -1
    Private Shared _AnredeCol As Integer = -1
    Private Shared _NachnameCol As Integer = -1
    Private Shared _VornameCol As Integer = -1
    Private Shared _StrasseCol As Integer = -1
    Private Shared _OrtCol As Integer = -1
    Private Shared _PLZCol As Integer = -1
    Private Shared _EMailCol As Integer = -1
    Private Shared _TelefonCol As Integer = -1
    Private Shared _GeburtsdatumCol As Integer = -1

    Public Shared Sub ExamineCols(colLine As String)
        Dim cols = colLine.Split(Chr(59))
        For i = 0 To cols.Count - 1
            Dim colName = cols(i).Trim(Chr(34))
            Select Case colName
                Case "Mitglieds-Nr"
                    _MitgliedsNrCol = i
                Case "Anrede"
                    _AnredeCol = i
                Case "Nachname"
                    _NachnameCol = i
                Case "Vorname"
                    _VornameCol = i
                Case "Straße"
                    _StrasseCol = i
                Case "Ort"
                    _OrtCol = i
                Case "PLZ"
                    _PLZCol = i
                Case "E-Mail"
                    _EMailCol = i
                Case "Telefon"
                    _TelefonCol = i
                Case "Geburtsdatum"
                    _GeburtsdatumCol = i
            End Select
        Next
    End Sub

    Public ReadOnly Property MitgliedsNr As UInteger
    Public ReadOnly Property Anrede As String
    Public ReadOnly Property Nachname As String
    Public ReadOnly Property Vorname As String
    Public ReadOnly Property Strasse As String
    Public ReadOnly Property Ort As String
    Public ReadOnly Property PLZ As UInteger
    Public ReadOnly Property EMail As String
    Public ReadOnly Property Telefon As String
    Public ReadOnly Property Geburtsdatum As Date
    Public ReadOnly Property Age As Integer
        Get
            Dim years = Date.Now.Year - Geburtsdatum.Year
            If Date.Now < New Date(Date.Now.Year, Geburtsdatum.Month, Geburtsdatum.Day) Then
                years -= 1
            End If
            Return years
        End Get
    End Property

    Public ReadOnly Property FamilyDescriptor As String
        Get
            Return String.Format("{0}-{1}-{2}", PLZ.ToString, Strasse, Nachname)
        End Get
    End Property

    Public Sub New(line As String)
        Dim cols = line.Split(Chr(59))
        If _MitgliedsNrCol >= 0 Then _MitgliedsNr = CUInt(cols(_MitgliedsNrCol).Trim(Chr(34)))
        If _AnredeCol >= 0 Then _Anrede = cols(_AnredeCol).Trim(Chr(34))
        If _NachnameCol >= 0 Then _Nachname = cols(_NachnameCol).Trim(Chr(34))
        If _VornameCol >= 0 Then _Vorname = cols(_VornameCol).Trim(Chr(34))
        If _StrasseCol >= 0 Then _Strasse = cols(_StrasseCol).Trim(Chr(34))
        If _OrtCol >= 0 Then _Ort = cols(_OrtCol).Trim(Chr(34))
        If _PLZCol >= 0 Then _PLZ = CUInt(cols(_PLZCol).Trim(Chr(34)))
        If _EMailCol >= 0 Then _EMail = cols(_EMailCol).Trim(Chr(34))
        If _TelefonCol >= 0 Then _Telefon = cols(_TelefonCol).Trim(Chr(34))
        If _GeburtsdatumCol >= 0 Then _Geburtsdatum = Date.Parse(cols(_GeburtsdatumCol).Trim(Chr(34)))
    End Sub
End Class
