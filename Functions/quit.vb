Namespace Functions
    Partial Class PTLFunc
        Public Function quit(Args As String)
            If Args = "" Then
                End
            Else
                Return "Use quit() to exit PTL." + vbCrLf
            End If
        End Function
    End Class
End Namespace