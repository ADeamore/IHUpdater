Imports System.IO
Imports System.Net
Imports Microsoft.VisualBasic.Logging

Public Class Form1

    Dim Firstinstall As Boolean = False

    Private Sub btn_Launch_Click(sender As Object, e As EventArgs) Handles btn_Launch.Click
        ' MsgBox("Hello World!")
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub doform1() Handles MyBase.Shown
        'ADD A CATCH TO CHECK TO SEE IF YOU'RE ONLINE. IF YOU'RE NOT, FAIL OUT AND ALLOW FOR LAUNCHING.
        start_tree()
    End Sub

    Private Sub Text_Display_Gui_Click(sender As Object, e As EventArgs) Handles Text_Display_Gui.Click

    End Sub

    Function start_tree() As Task
        Dim needupdate As Boolean
        needupdate = False

        Dim textfile As String = My.Application.Info.DirectoryPath + "\Filelist.txt"

        Try
            My.Computer.FileSystem.DeleteFile(textfile)
        Catch ex As Exception

        End Try

        Try
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "\fileblacklist.txt")
        Catch ex As Exception

        End Try

        Try
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "\folderblacklist.txt")
        Catch ex As Exception

        End Try


        Dim remoteUri As String = "https://f004.backblazeb2.com/file/InfiniteHorizons/fileblacklist.txt"
        Dim fileName As String = "fileblacklist.txt"
        Dim password As String = "..."
        Dim username As String = "..."

        Using client As New WebClient()
            client.Credentials = New NetworkCredential(username, password)
            client.DownloadFile(remoteUri, fileName)
        End Using

        remoteUri = "https://f004.backblazeb2.com/file/InfiniteHorizons/folderblacklist.txt"
        fileName = "folderblacklist.txt"

        Using client As New WebClient()
            client.Credentials = New NetworkCredential(username, password)
            client.DownloadFile(remoteUri, fileName)
        End Using

        Dim localfilepath As String = My.Application.Info.DirectoryPath + "\IHDir\"

        If Not Directory.Exists(localfilepath) Then
            Firstinstall = True
            Directory.CreateDirectory(localfilepath)
        End If

        Loop_Files(localfilepath, localfilepath, textfile)

        'DELETE ME ------------------------------------------------------------------------
        Process.Start(My.Application.Info.DirectoryPath)
        'DELETE ME ------------------------------------------------------------------------

        Dim percentage As Int16
        percentage = 0

        Text_Display_Gui.Text = "Compiling File List for Version Pairity Check" + Environment.NewLine + "File List compiled, Comparing Versions. " + percentage.ToString() + "%"

        Compare_Versions()
    End Function

    Function Loop_Files(vardirectory As String, masterdirectory As String, textfile As String) As Task

        Dim folderblacklist As New ArrayList
        FileOpen(1, My.Application.Info.DirectoryPath + "\folderblacklist.txt", OpenMode.Input)
        Do While Not EOF(1)
            folderblacklist.Add(LineInput(1))
        Loop
        FileClose(1)

        Dim fileblacklist As New ArrayList
        FileOpen(1, My.Application.Info.DirectoryPath + "\fileblacklist.txt", OpenMode.Input)
        Do While Not EOF(1)
            fileblacklist.Add(LineInput(1))
        Loop
        FileClose(1)

        For Each foldername As String In Directory.GetDirectories(vardirectory)
            Dim pass As Boolean = True

            For Each Item In folderblacklist
                If foldername.Contains(Item) Then
                    pass = False
                    Exit For
                End If
            Next

            If pass Then
                Loop_Files(foldername, masterdirectory, textfile)
            End If
        Next

        Dim StrFile As String
        StrFile = Dir(vardirectory + "\")
        Dim streamwriterfile As StreamWriter
        streamwriterfile = My.Computer.FileSystem.OpenTextFileWriter(textfile, True)

        Do While Len(StrFile) > 0

            Dim pass As Boolean = True
            For Each item In fileblacklist
                If item = StrFile Then
                    pass = False
                End If
            Next

            If pass Then
                'remove masterpath from current path, append path to file name
                Dim recordstring As String = vardirectory + "\" + StrFile
                recordstring = recordstring.Replace(masterdirectory, "").Trim()

                'record to file
                streamwriterfile.WriteLine(recordstring)
            End If

            StrFile = Dir()
        Loop

        streamwriterfile.Close()

    End Function


    Function Compare_Versions() As Task

        Dim textfile As String = My.Application.Info.DirectoryPath + "\onlinelist.txt"
        Try
            My.Computer.FileSystem.DeleteFile(textfile)
        Catch ex As Exception

        End Try

        ' Download online version of file
        Dim remoteUri As String = "https://f004.backblazeb2.com/file/InfiniteHorizons/Filelist.txt"
        Dim fileName As String = "onlinelist.txt"
        Dim password As String = "..."
        Dim username As String = "..."

        Using client As New WebClient()
            client.Credentials = New NetworkCredential(username, password)
            client.DownloadFile(remoteUri, fileName)
        End Using

        ' Compare files (ignore whitelisted files (TODO: make whitelist)) (trust that they wont both be in the same order)
        Dim localtext As String = My.Application.Info.DirectoryPath + "\Filelist.txt"
        Dim remotetext As String = My.Application.Info.DirectoryPath + "\onlinelist.txt"
        Dim localarray As New ArrayList
        Dim remotearray As New ArrayList
        Dim getarray As New ArrayList
        Dim deletearray As New ArrayList

        FileOpen(1, localtext, OpenMode.Input)
        Do While Not EOF(1)
            localarray.Add(LineInput(1))
        Loop
        FileClose(1)

        FileOpen(1, remotetext, OpenMode.Input)
        Do While Not EOF(1)
            remotearray.Add(LineInput(1))
        Loop
        FileClose(1)

        Dim counter As Int16
        counter = 0

        Dim total As Int16
        total = localarray.Count + remotearray.Count

        For Each Item In localarray
            If Not remotearray.Contains(Item) Then
                deletearray.Add(Item)
            End If
            counter = counter + 1
            If counter Mod 5 = 0 Then
                Text_Display_Gui.Text = "Compiling File List for Version Pairity Check" + Environment.NewLine + "File List compiled, Comparing Versions. " + (Math.Round(counter / total * 100)).ToString() + "%"
                System.Windows.Forms.Application.DoEvents()
            End If
        Next

        For Each Item In remotearray
            If Not localarray.Contains(Item) Then
                getarray.Add(Item)
            End If
            counter = counter + 1
            If counter Mod 5 = 0 Then
                Text_Display_Gui.Text = "Compiling File List for Version Pairity Check" + Environment.NewLine + "File List compiled, Comparing Versions. " + (Math.Round(counter / total * 100)).ToString() + "%"
                System.Windows.Forms.Application.DoEvents()
            End If
        Next

        ' Get new files, Delete unneeded files (check to see if full dorectories dont exist. if they dont delete the directory)

        counter = 0
        total = deletearray.Count + getarray.Count

        Dim localdirectory As String = My.Application.Info.DirectoryPath + "\IHDir\"
        For Each Item In deletearray
            Dim deletefile As String = Item.ToString

            deletefile.Replace("ï»¿", "")

            If deletefile.First() = "\" Then
                deletefile = deletefile.Replace("\", "")
            End If
            File.Delete(localdirectory + Item)

            counter = counter + 1

            If counter Mod 5 = 0 Then

                Text_Display_Gui.Text = "Compiling File List for Version Pairity Check" + Environment.NewLine +
                    "File List compiled, Comparing Versions. 100%" + Environment.NewLine +
                    "Files Updating. "(Math.Round(counter / total * 100)).ToString() + "%"

                System.Windows.Forms.Application.DoEvents()
            End If
        Next
        For Each Item In getarray
            Dim getfile As String = Item

            If getfile.First() = "\" Then
                getfile = getfile.Replace("\", "")
            End If

            getfile = getfile.Replace("ï»¿", "")

            ' actually get the file from the domain

            Dim fileurl As String = getfile.Replace("\", "/")
            remoteUri = "https://f004.backblazeb2.com/file/InfiniteHorizons/IHDir/" + fileurl
            fileName = localdirectory + getfile

            remoteUri = remoteUri.Replace("+", "%2b")
            remoteUri = remoteUri.Replace(" ", "%20")

            Dim pathtrack As String

            Dim lastslash As Int32 = 0
            Dim count As Int32 = 0

            For Each c As Char In fileName
                If c = "\" Then
                    lastslash = count
                End If
                count = count + 1
            Next

            pathtrack = fileName.Substring(0, lastslash)


            Try
                My.Computer.FileSystem.CreateDirectory(pathtrack)
            Catch ex As Exception

            End Try

            Using client As New WebClient()
                client.Credentials = New NetworkCredential(username, password)
                client.DownloadFile(remoteUri, "temp.tmp")
            End Using

            My.Computer.FileSystem.CopyFile(My.Application.Info.DirectoryPath + "\Temp.tmp", fileName)
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "\Temp.tmp")

            counter = counter + 1

            If counter Mod 5 = 0 Then

                If Firstinstall Then
                    Text_Display_Gui.Text = "Compiling File List for Version Pairity Check" + Environment.NewLine +
                        "File List compiled, Comparing Versions. 100%" + Environment.NewLine +
                        "Downloading pack for the first time: " + (Math.Round(counter / total * 100)).ToString() + "%"

                    System.Windows.Forms.Application.DoEvents()
                Else
                    Text_Display_Gui.Text = "Compiling File List for Version Pairity Check" + Environment.NewLine +
                        "File List compiled, Comparing Versions. 100%" + Environment.NewLine +
                        "Files Updating. " + (Math.Round(counter / total * 100)).ToString() + "%"

                    System.Windows.Forms.Application.DoEvents()
                End If

            End If
        Next

        ' Un-grey launch button
    End Function


End Class
