Namespace Functions
    Partial Class PTLFunc
        Public Function redef(Args As String)
            Dim FuncValues = Split(Args, ", ", 2)
            Try
                If Memory.ContainsKey(FuncValues(0)) Then
                    If Not Memory.ContainsKey(FuncValues(1)) Then
                        Memory(FuncValues(0)) = FuncValues(1)
                    Else
                        Memory(FuncValues(0)) = Memory(FuncValues(1))
                    End If
                Else
                    Return "redef: " + FuncValues(0) + ": not defined" + vbCrLf
                End If
            Catch
                Return "redef: bad arguments" + vbCrLf
            End Try
            Return ""
        End Function
        Public Function rdef(Args As String)
            Return redef(Args)
        End Function
    End Class
End Namespace