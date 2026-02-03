Imports System.Reflection
Public Class Interpreter
    ''' <summary>
    ''' The console interpreter for working in PTL.
    ''' </summary>
    Public Sub New()
        Console.WriteLine("Welcome to PTL Revision " + Assembly.GetEntryAssembly().GetName().Version.Major.ToString() + ".")
        While True
            Prompt()
        End While
    End Sub
    Sub Prompt()
        Console.Write(">> ")
        Parse(Console.ReadLine())
    End Sub
End Class