Imports System.Text.RegularExpressions
Namespace Functions
    Partial Class PTLFunc
        Public Function define(Args As String)
            Dim FuncValues = Split(Args, ", ", 2)
            Try
                If FuncValues(0).IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?""""] ".ToCharArray) <> -1 Or Regex.IsMatch(FuncValues(0), "^[0-9 ]+$") Then
                    Return "define: bad object name" + vbCrLf
                End If
                If FuncNames.ContainsKey(FuncValues(0)) Then
                    Return "define: object already exists in PTL.Functions.PTLFunc" + vbCrLf
                End If
                If Not Memory.ContainsKey(FuncValues(1)) Then
                    Try
                        Dim Value = Convert.ToInt64(FuncValues(1))
                        Memory.Add(FuncValues(0), Value)
                        If Silent = False Then
                            Console.WriteLine(FuncValues(0) + " = " + FuncValues(1) + " : as " + Value.GetType.ToString())
                        End If
                    Catch ChangeType As Exception
                        Memory.Add(FuncValues(0), FuncValues(1))
                        If Silent = False Then
                            Console.WriteLine(FuncValues(0) + " = " + FuncValues(1) + " : as " + FuncValues(1).GetType.ToString())
                        End If
                    End Try
                Else
                    Memory.Add(FuncValues(0), Memory(FuncValues(1)))
                End If
                Return ""
            Catch
                If Memory.ContainsKey(FuncValues(0)) Then
                    Return "define: " + FuncValues(0) + ": already exists" + vbCrLf
                End If
                Return "define: bad arguments" + vbCrLf
            End Try
        End Function
        Public Function def(Args As String)
            Return define(Args)
        End Function
    End Class
End Namespace