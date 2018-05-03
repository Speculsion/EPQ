Module Module1
    Dim Masses(Count) As Double
    Dim Count, clock As Integer
    Dim TotalMass, TotalMassPosVector(Count, 2), MassPosVector(Count, 2), CentreOfMassPos(Count, 2) As Double
    Dim xval(Count), yval(Count), zval(Count) As Double


    Public Function SumOfMassesAndLocations(ByVal Masses() As Double, ByVal count As Integer)
        Console.WriteLine("Enter a mass and press enter and then enter the location as a 3D position vector...")
        Dim tempReply As Char
        count = 0
        Do
            Masses(count) = Console.ReadLine()
            TotalMass = TotalMass + Masses(count)
            Console.WriteLine("Enter a location... Press enter between every dimension.")
            xval(count) = Console.ReadLine()
            yval(count) = Console.ReadLine()
            zval(count) = Console.ReadLine()
            Console.WriteLine("Would you like to add another mass and location? Hit N if not, otherwise press enter then add another...")
            tempReply = Console.ReadLine()
            MassPosVector(count, 0) = Masses(count) * xval(count)
            MassPosVector(count, 1) = Masses(count) * yval(count)
            MassPosVector(count, 2) = Masses(count) * zval(count)

            TotalMassPosVector(count, 0) = TotalMassPosVector(count, 0) + MassPosVector(count, 0)
            TotalMassPosVector(count, 1) = TotalMassPosVector(count, 1) + MassPosVector(count, 1)
            TotalMassPosVector(count, 2) = TotalMassPosVector(count, 2) + MassPosVector(count, 2)

        Loop Until tempReply = "N"
        clock = count

        'For count = 0 To clock                 *This commented section prints ΣMiRi
        '   For count2 = 0 To 2          
        '       Console.WriteLine(TotalMassPosVector(count, count2))
        '   Next
        'Next

        Console.WriteLine("Your Σmass is: " & TotalMass)

        Return TotalMass
        Return TotalMassPosVector
        Return clock
    End Function

    Public Function CenterOfMass(ByVal clock As Integer, ByVal CentreOfMassPos(,) As Double, ByVal TotalMassPosVector(,) As Double)
        Dim Dimension(2) As String
        Dimension(0) = "X"
        Dimension(1) = "Y"
        Dimension(2) = "Z"
        For Count = 0 To clock
            For count2 = 0 To 2
                CentreOfMassPos(Count, count2) = TotalMassPosVector(Count, count2) / TotalMass
                Console.WriteLine("The center of mass of the payload capsule on axis " & Dimension(count2) & " is: " & CentreOfMassPos(Count, count2))
            Next
        Next

    End Function

    Sub Main()
        SumOfMassesAndLocations(Masses, Count)
        CenterOfMass(clock, CentreOfMassPos, TotalMassPosVector)
        Console.ReadLine()
    End Sub

End Module
