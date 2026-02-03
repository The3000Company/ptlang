Imports System.Reflection

Namespace Functions
    Partial Class PTLFunc
        Public Property Version As String = "PTL Revision " + Assembly.GetEntryAssembly().GetName().Version.Major.ToString()
        Public Property OS As String = Runtime.InteropServices.RuntimeInformation.OSDescription.ToString()
        Public Property Platform As String = Runtime.InteropServices.RuntimeInformation.OSArchitecture.ToString()
        Public Function envinfo(Args As String)
            If Args = "" Then
                Return Version + ", " + OS + " " + Platform + vbCrLf
            Else
                Try
                    Return CallByName(Me, Args, CallType.Get) + vbCrLf
                Catch
                    Return "envinfo: " + Args + ": bad argument" + vbCrLf
                End Try
            End If
        End Function
    End Class
End Namespace