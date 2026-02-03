' Parser for Peach Tea Language (PTL)
' Authored by Elliott McKelvey for The 3000 Company

Imports PTL.Functions
Imports System.Reflection
Imports System.IO
Public Module Parser
    Public Memory As New Dictionary(Of String, String)()
    Public FuncNames As New Dictionary(Of String, String)()
    Public Silent As Boolean = False
    ''' <summary>
    ''' Checks for any valid startup arguments. If none are found, it will instead attempt to read from the first argument as a file.
    ''' </summary>
    Sub Main()
        RebuildFuncDict()
        If Environment.GetCommandLineArgs().Count > 1 Then
            If Environment.GetCommandLineArgs(1) = "--console" Or Environment.GetCommandLineArgs(1) = "-c" Then
                Dim RunInterpreter As New Interpreter
                Exit Sub
            Else
                Try
                    Dim Stream() = File.ReadAllLines(Environment.GetCommandLineArgs(1))
                    If Stream(0) = "#cond silent" Then
                        Silent = True
                    End If
                    For Each Line In Stream
                        If Line.StartsWith("//") = False Then
                            Parse(Line)
                        End If
                    Next
                    Console.ReadKey()
                Catch BadFile As Exception
                    Console.WriteLine(Environment.GetCommandLineArgs(1).ToString() & ": error getting info from stream")
                End Try
            End If
        End If
    End Sub
    ''' <summary>
    ''' Reads an input and executes it.
    ''' </summary>
    ''' <param name="InputString"></param>
    Sub Parse(InputString As String)
        If Not InputString = Nothing Then
            Dim GetArgStart As Integer
            Dim ArgLength As Integer
            Dim Pass = Split(InputString, "(")
            Dim Args As String
            Try
                GetArgStart = InputString.IndexOf("(") + 1
                ArgLength = InputString.LastIndexOf(")") - GetArgStart
                Args = InputString.Substring(GetArgStart, ArgLength)
            Catch ex As Exception
                Args = ""
            End Try
            Try
                If Memory.ContainsKey(InputString) Then
                    Console.WriteLine(Memory(InputString))
                Else
                    Dim Input As New PTLFunc
                    Console.Write(CallByName(Input, Pass(0), CallType.Method, Args))
                End If
            Catch
                If Not String.IsNullOrWhiteSpace(InputString) And Not InputString.StartsWith("#") Then
                    Console.WriteLine(Pass(0) + ": not defined")
                End If
            End Try
        End If
    End Sub
    ''' <summary>
    ''' Gets all established functions in the PTLFunc namespace and adds them to the dictionary Parser.FuncNames.
    ''' </summary>
    Sub RebuildFuncDict()
        Dim AllFunc As MethodInfo() = GetType(PTLFunc).GetMethods(BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
        For i = 0 To AllFunc.Length - 1
            Dim GetMethod As MethodInfo = CType(AllFunc(i), MethodInfo)
            If Not FuncNames.ContainsKey(GetMethod.Name) Then
                FuncNames.Add(GetMethod.Name, GetMethod.Name)
            End If
        Next
    End Sub
End Module