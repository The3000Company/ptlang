Namespace Functions
    Partial Class PTLFunc
        Public Function print(Args As String)
            Try
                If Args = "" Then
                    Return "print: needs arguments" + vbCrLf
                End If
                If Args.StartsWith("""") Then
                    Return Args.Substring(Args.IndexOf("""") + 1, Args.LastIndexOf("""") - 1) + vbCrLf
                End If
                If Memory.ContainsKey(Args) Then
                    Return Memory(Args) + vbCrLf
                Else
                    If Not GetType(PTLFunc).GetMethod(Args.Split("(")(0)) = Nothing Then
                        Parser.Parse(Args)
                    Else
                        Return "print: " + Args + ": not defined" + vbCrLf
                    End If
                End If
            Catch ex As Exception
                Return "print: " + Args + ": not defined" + vbCrLf
            End Try
        End Function
    End Class
End Namespace