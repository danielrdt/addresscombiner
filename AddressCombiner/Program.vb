Imports System

Module Program
    Sub Main(args As String())
        If args.Count() < 1 Then
            Console.WriteLine("No File")
            Exit Sub
        End If

        Dim persons As New List(Of Person)

        Using addressFile = IO.File.OpenText(args(0))
            Dim firstLine = True
            Do
                Dim addressLine = addressFile.ReadLine()
                If String.IsNullOrEmpty(addressLine) Then Exit Do

                If firstLine Then
                    Person.ExamineCols(addressLine)
                    firstLine = False
                Else
                    Try
                        persons.Add(New Person(addressLine))
                    Catch ex As Exception
                        Console.WriteLine("ERROR: Could not translate:" & addressLine)
                    End Try
                End If
            Loop
        End Using

        Dim families As New Dictionary(Of String, Family)

        Dim family As Family = Nothing
        For Each person In persons
            Dim desc = person.FamilyDescriptor
            If Not families.TryGetValue(desc, family) Then
                families(desc) = New Family(person)
            Else
                family.AddMember(person)
            End If
        Next

        Dim singlePersons As New List(Of Person)
        Dim finalFamilies As New List(Of Family)
        For Each fam In families.Values
            If fam.Count = 1 Then
                singlePersons.Add(fam.FirstMember)
            Else
                finalFamilies.Add(fam)
            End If
        Next

        Using outfile = IO.File.CreateText("addresses.csv")
            outfile.WriteLine("Anrede;Nachname;Vorname;Straße;PLZ;Ort")
            Console.WriteLine("Found following Families:")
            For Each fam In finalFamilies
                Console.WriteLine("Familie {0}; {1}, {2} {3} - {4} Members", fam.Nachname, fam.Strasse, fam.PLZ.ToString, fam.Ort, fam.Count)
                outfile.WriteLine("Familie;{0};;{1};{2};{3}", fam.Nachname, fam.Strasse, fam.PLZ.ToString, fam.Ort)
                For Each person In fam.Members
                    Console.WriteLine("    {0} {1} {2} ({3} Jahre)", person.Anrede, person.Vorname, person.Nachname, person.Age)
                Next
            Next

            Console.WriteLine(" ")
            Console.WriteLine(" ")
            Console.WriteLine("Found following Singles:")
            For Each person In singlePersons
                Console.WriteLine("{4} {0}; {1}, {2} {3}", person.Nachname, person.Strasse, person.PLZ.ToString, person.Ort, person.Anrede)
                outfile.WriteLine("{0};{1};{2};{3};{4};{5}", person.Anrede, person.Nachname, person.Vorname, person.Strasse, person.PLZ.ToString, person.Ort)
            Next
        End Using

        Console.WriteLine(" ")

        Console.WriteLine("Found {0} Persons, {3} Families. Having {1} Addresses - saved {2}", persons.Count, finalFamilies.Count + singlePersons.Count, persons.Count - (finalFamilies.Count + singlePersons.Count), finalFamilies.Count)

        Console.ReadKey()
    End Sub
End Module
