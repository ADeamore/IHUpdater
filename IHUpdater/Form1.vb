Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net
Imports System.Net.WebRequestMethods
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.VisualBasic.Logging
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms

Public Class Form1

    Dim Firstinstall As Boolean = False
    Dim scrollstart As Int32 = 0
    Dim changelog As New ArrayList
    Dim scrollsize As Int16 = 33
    Dim changelogdisplaylist As New ArrayList
    Dim showonlaunch As Boolean = False
    Dim minecraftrunning = False
    Dim version As Int32 = 1
    Dim worldmapvisible As Boolean = 0
    Dim canlaunch As Boolean = 0
    Dim mapdimension As String = "InfiniteHorizonWorld"
    Dim hasminecraftfolder As Boolean = My.Computer.FileSystem.DirectoryExists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.Minecraft\")
    Dim hastempminecraftfolder As Boolean = My.Computer.FileSystem.DirectoryExists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.MinecraftTemp\")

    Private Async Sub btn_Launch_Click(sender As Object, e As EventArgs) Handles btn_Launch.Click
        ' MsgBox("Hello World!")

        minecraftrunning = True

        canlaunch = 0
        btn_Launch.Enabled = False

        If showonlaunch = False Then
            Me.Visible = False
        End If

        Dim tasks As New List(Of Task)()
        tasks.Add(Task.Run(AddressOf waitforminecraftclose))

        Await Task.WhenAll(tasks)

        minecraftrunning = False

        canlaunch = 1
        If Not worldmapvisible = 1 Then
            Me.btn_Launch.Enabled = True
        End If

        Me.Visible = True

    End Sub
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'move the browser off the screen
        dynmap_browser.Location = New Point(Me.Width, 0)

        'set up the browser to run
        'set its url to the default
        Dim environment As CoreWebView2Environment
        Await dynmap_browser.EnsureCoreWebView2Async(environment)
        dynmap_browser.Source = New Uri("http://infinitehorizons.apexmc.co:8123/?worldname=InfiniteHorizonsWorld&mapname=flat")

    End Sub
    Private Sub doform1() Handles MyBase.Shown


        Me.MaximumSize = My.Computer.Screen.WorkingArea.Size

        lbl_creator_credits.Text = "Modpack Compiled by: " + Environment.NewLine +
            "Kate 'BurgundyPetal' H. and Avaela 'ItAvvy' D." + Environment.NewLine +
            "Launcher Designed by: " + Environment.NewLine +
            "Avaela 'ItAvvy' D."

        'load config for visibility checkbox

        If Not System.IO.File.Exists(My.Application.Info.DirectoryPath + "\keeplauncher.txt") Then
            Dim streamwriterfile As StreamWriter
            streamwriterfile = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath + "\keeplauncher.txt", False)
            streamwriterfile.Write(showonlaunch)
            streamwriterfile.Close()
        End If

        FileOpen(1, My.Application.Info.DirectoryPath + "\keeplauncher.txt", OpenMode.Input)
        Dim showtype As String = LineInput(1)
        If (showtype.Contains("False")) Then showonlaunch = False
        If (showtype.Contains("True")) Then showonlaunch = True
        FileClose(1)

        tickbox_launcherstay.Checked = showonlaunch

        System.Windows.Forms.Application.DoEvents()
        'ADD A CATCH TO CHECK TO SEE IF YOU'RE ONLINE. IF YOU'RE NOT, FAIL OUT AND ALLOW FOR LAUNCHING.

        Dim hasnetwork = CheckForInternetConnection()

        'DELETE ME -----------------------------
        hasnetwork = False
        'DELETE ME -----------------------------

        If hasnetwork Then

            'check to see if it needs to unfuck files
            If hastempminecraftfolder = 1 Then
                Text_Display_Gui.Text = "Fixing files from previous launch..."
                System.Windows.Forms.Application.DoEvents()

                Dim works As Boolean = 0
                If hasminecraftfolder Then
                    Try
                        My.Computer.FileSystem.RenameDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.Minecraft\", "IHDir")
                        works = 1
                    Catch ex As Exception
                        works = 0
                    End Try
                    If works = 1 Then
                        hasminecraftfolder = 1
                    End If
                End If

                Try
                    My.Computer.FileSystem.RenameDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.MinecraftTemp\", ".Minecraft")
                Catch ex As Exception
                End Try
            End If


            'Check to see if the launcher needs an update
            Text_Display_Gui.Text = "Checking to see if the launcher needs an update:"
            System.Windows.Forms.Application.DoEvents()

            Try
                My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "\IHFileSwap.exe")
            Catch ex As Exception

            End Try

            Try
                My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "\remotelauncherversion.txt")
            Catch ex As Exception

            End Try

            Dim remoteUri As String = "https://download.adeamore.com/remotelauncherversion.txt"
            Dim fileName As String = "\remotelauncherversion.txt"
            Dim password As String = "..."
            Dim username As String = "..."

            Using client As New WebClient()
                client.Credentials = New NetworkCredential(username, password)
                client.DownloadFile(remoteUri, My.Application.Info.DirectoryPath + fileName)
            End Using

            Dim ollauncherver As Int32 = 0

            FileOpen(1, My.Application.Info.DirectoryPath + "\remotelauncherversion.txt", OpenMode.Input)
            ollauncherver = Convert.ToInt32(LineInput(1))
            FileClose(1)

            Try
                My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "\remotelauncherversion.txt")
            Catch ex As Exception

            End Try

            If Not version = ollauncherver Then
                'download new launcher here

                remoteUri = "https://download.adeamore.com/IHFileSwap.exe"
                fileName = "\IHFileSwap.exe"

                Using client As New WebClient()
                    client.Credentials = New NetworkCredential(username, password)
                    client.DownloadFile(remoteUri, My.Application.Info.DirectoryPath + fileName)
                End Using

                remoteUri = "https://download.adeamore.com/IHUpdater.exe"
                fileName = "\IHUpdatertemp.exe"

                Using client As New WebClient()
                    client.Credentials = New NetworkCredential(username, password)
                    client.DownloadFile(remoteUri, My.Application.Info.DirectoryPath + fileName)
                End Using

                Process.Start(My.Application.Info.DirectoryPath + "\IHFileSwap.exe")

                hasnetwork = False

                Me.Close()

            End If


        End If

        If hasnetwork Then 'download changelog

            Text_Display_Gui.Text = "Compiling File List for Version Pairity Check:"
            System.Windows.Forms.Application.DoEvents()

            Try
                My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "\changelog.txt")
            Catch ex As Exception

            End Try


            Dim remoteUri As String = "https://download.adeamore.com/changelog.txt"
            Dim fileName As String = "\changelog.txt"
            Dim password As String = "..."
            Dim username As String = "..."

            Using client As New WebClient()
                client.Credentials = New NetworkCredential(username, password)
                client.DownloadFile(remoteUri, My.Application.Info.DirectoryPath + fileName)
            End Using
        End If

        'set up changelog arraylist


        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "\changelog.txt") Then 'setup changelog
            FileOpen(1, My.Application.Info.DirectoryPath + "\changelog.txt", OpenMode.Input)
            Do While Not EOF(1)
                Me.changelog.Add(LineInput(1))
            Loop
            FileClose(1)

            changelogdisplaylist.Clear()
            Dim changecount As Int32 = scrollstart
            While changecount < scrollstart + scrollsize
                Try
                    changelogdisplaylist.Add(changelog(changecount))
                Catch ex As Exception
                    changelogdisplaylist.Add("")
                End Try
                changecount = changecount + 1
            End While

            changelog_text.Text = ""

            Dim temptext As String = ""

            For Each item In changelogdisplaylist
                Dim tempitem As String = item
                temptext = temptext + tempitem + Environment.NewLine
            Next
            changelog_text.Text = temptext
        Else
            btn_changelog.Enabled = False
        End If
        System.Windows.Forms.Application.DoEvents()

        'start running the actual file check stuff

        If hasnetwork Then
            'download and make sure you dont need to file wipe

            Dim remoteUri As String = "https://download.adeamore.com/versionnumber.txt"
            Dim fileName As String = "\olversionnumber.txt"
            Dim password As String = "..."
            Dim username As String = "..."

            Using client As New WebClient()
                client.Credentials = New NetworkCredential(username, password)
                client.DownloadFile(remoteUri, My.Application.Info.DirectoryPath + fileName)
            End Using

            Dim localversionnumber As Int16 = 0
            Dim remoteversionnumber As Int16 = 0

            If System.IO.File.Exists(My.Application.Info.DirectoryPath + "\versionnumber.txt") Then

                FileOpen(1, My.Application.Info.DirectoryPath + "\olversionnumber.txt", OpenMode.Input)
                remoteversionnumber = Convert.ToInt32(LineInput(1))
                FileClose(1)

                FileOpen(1, My.Application.Info.DirectoryPath + "\versionnumber.txt", OpenMode.Input)
                localversionnumber = Convert.ToInt32(LineInput(1))
                FileClose(1)

                If Not (localversionnumber = remoteversionnumber) Then
                    Text_Display_Gui.Text = "Got notice of need for a complete fresh install." + Environment.NewLine +
                        "Deleting previous folder. If the application" + Environment.NewLine +
                        "stalls out please ignore until it fixes itself."
                    System.Windows.Forms.Application.DoEvents()
                    Try
                        System.IO.Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\IHDir\", True)
                    Catch ex As Exception

                    End Try
                End If

                Try
                    My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "\olversionnumber.txt")
                Catch ex As Exception

                End Try
            Else
                FileOpen(1, My.Application.Info.DirectoryPath + "\olversionnumber.txt", OpenMode.Input)
                remoteversionnumber = Convert.ToInt32(LineInput(1))
                FileClose(1)
            End If

            'run version check and file pairity stuff
            start_tree()

            'clean up from handling version checks
            If Not localversionnumber = remoteversionnumber Then
                Try
                    My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "\versionnumber.txt")
                Catch ex As Exception

                End Try

                Dim streamwriterfile As StreamWriter
                streamwriterfile = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath + "\versionnumber.txt", True)
                streamwriterfile.WriteLine(ToString(remoteversionnumber))
                streamwriterfile.Close()
            End If

            'clean up local files
            Try
                System.IO.File.Delete(My.Application.Info.DirectoryPath + "fileblacklist.txt")
            Catch ex As Exception

            End Try
            Try
                System.IO.File.Delete(My.Application.Info.DirectoryPath + "folderblacklist.txt")
            Catch ex As Exception

            End Try
            Try
                System.IO.File.Delete(My.Application.Info.DirectoryPath + "filegreylist.txt")
            Catch ex As Exception

            End Try
            Try
                System.IO.File.Delete(My.Application.Info.DirectoryPath + "filelist.txt")
            Catch ex As Exception

            End Try
            Try
                System.IO.File.Delete(My.Application.Info.DirectoryPath + "onlinelist.txt")
            Catch ex As Exception

            End Try


        Else
            If Not System.IO.File.Exists(My.Application.Info.DirectoryPath + "\MinecraftLauncher.exe") Then
                Text_Display_Gui.Text = "No network connection detected." + Environment.NewLine + " Client can't install required files to run."
            Else
                Text_Display_Gui.Text = "Current network not established." + Environment.NewLine + " Switching to previous client version to attempt being able to launch."
                canlaunch = 1
                If Not worldmapvisible = True Then
                    btn_Launch.Enabled = True
                End If
                btn_Launch.Text = "LAUNCH OFFLINE"
            End If
        End If
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub Text_Display_Gui_Click(sender As Object, e As EventArgs) Handles Text_Display_Gui.Click

    End Sub

    Function start_tree() As Task
        Dim needupdate As Boolean
        needupdate = False
        Dim totalfiles As Int32 = 0

        Dim textfile As String = My.Application.Info.DirectoryPath + "\Filelist.txt"

        'delete local data files from previous run

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

        'download the remote blacklists

        Dim remoteUri As String = "https://download.adeamore.com/fileblacklist.txt"
        Dim fileName As String = "fileblacklist.txt"
        Dim password As String = "..."
        Dim username As String = "..."

        Using client As New WebClient()
            client.Credentials = New NetworkCredential(username, password)
            client.DownloadFile(remoteUri, fileName)
        End Using

        remoteUri = "https://download.adeamore.com/folderblacklist.txt"
        fileName = "folderblacklist.txt"

        Using client As New WebClient()
            client.Credentials = New NetworkCredential(username, password)
            client.DownloadFile(remoteUri, fileName)
        End Using

        remoteUri = "https://download.adeamore.com/filegreylist.txt"
        fileName = "filegreylist.txt"

        Using client As New WebClient()
            client.Credentials = New NetworkCredential(username, password)
            client.DownloadFile(remoteUri, fileName)
        End Using

        'generate the working directory

        Dim localfilepath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\IHDir\"

        If Not Directory.Exists(localfilepath) Then
            Directory.CreateDirectory(localfilepath)
        End If

        If Not System.IO.File.Exists(My.Application.Info.DirectoryPath + "\MinecraftLauncher.exe") Then
            Firstinstall = True
        End If

        'run loopfiles to generate the local file list
        totalfiles = Loop_Files(localfilepath, localfilepath, textfile, totalfiles)

        'DELETE ME ------------------------------------------------------------------------
        'Process.Start(My.Application.Info.DirectoryPath)
        'DELETE ME ------------------------------------------------------------------------

        Dim percentage As Int16
        percentage = 0

        Text_Display_Gui.Text = "Compiling File List for Version Pairity Check: File Count: " + totalfiles.ToString + Environment.NewLine + "File List compiled, Comparing Versions. " + percentage.ToString() + "%"

        'compare the local list version to the remote version and download remote files
        Compare_Versions(totalfiles)

        canlaunch = 1
        If Not worldmapvisible = True Then
            btn_Launch.Enabled = 1
        End If
    End Function

    Function Loop_Files(vardirectory As String, masterdirectory As String, textfile As String, totalfiles As Int32) As Int32

        'store the blacklists into arrays to compare later

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

        Dim filegreylist As New ArrayList
        FileOpen(1, My.Application.Info.DirectoryPath + "\filegreylist.txt", OpenMode.Input)
        Do While Not EOF(1)
            filegreylist.Add(LineInput(1))
        Loop
        FileClose(1)

        'loop through the folders, skipping blacklisted ones
        For Each foldername As String In Directory.GetDirectories(vardirectory)
            Dim pass As Boolean = True

            For Each Item In folderblacklist
                If foldername.Contains(Item) Then
                    pass = False
                    Exit For
                End If
            Next

            If pass Then
                'if they're not blacklisted, recurse back into the function and go again.
                totalfiles = Loop_Files(foldername, masterdirectory, textfile, totalfiles)
            End If
        Next

        'after recursion hits a pause point, actually store the listed files into the masterlist

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

                'record hash to file on next line
                Dim s As New SHA256Managed
                Dim fileBytes() As Byte = IO.File.ReadAllBytes(vardirectory + "\" + StrFile)
                Dim hash() As Byte = s.ComputeHash(fileBytes)

                Dim calculatedHash As String = ByteArrayToString(hash)
                streamwriterfile.WriteLine(calculatedHash)

                totalfiles = totalfiles + 1

                Text_Display_Gui.Text = "Compiling File List for Version Pairity Check: File Count: " + totalfiles.ToString
                System.Windows.Forms.Application.DoEvents()

            End If

            StrFile = Dir()
        Loop

        streamwriterfile.Close()

        Return totalfiles

    End Function

    Function ByteArrayToString(ByVal arrInput() As Byte) As String
        Dim sb As New System.Text.StringBuilder(arrInput.Length * 2)
        For i As Integer = 0 To arrInput.Length - 1
            sb.Append(arrInput(i).ToString("X2"))
        Next
        Return sb.ToString().ToLower
    End Function


    Function Compare_Versions(totalfiles As Int32) As Task

        'load the greylist in again
        Dim filegreylist As New ArrayList
        FileOpen(1, My.Application.Info.DirectoryPath + "\filegreylist.txt", OpenMode.Input)
        Do While Not EOF(1)
            filegreylist.Add(LineInput(1))
        Loop
        FileClose(1)

        Dim textfile As String = My.Application.Info.DirectoryPath + "\onlinelist.txt"
        Try
            My.Computer.FileSystem.DeleteFile(textfile)
        Catch ex As Exception

        End Try

        ' Download online version of file
        Dim remoteUri As String = "https://download.adeamore.com/Filelist.txt"
        Dim fileName As String = "onlinelist.txt"
        Dim password As String = "..."
        Dim username As String = "..."

        Using client As New WebClient()
            client.Credentials = New NetworkCredential(username, password)
            client.DownloadFile(remoteUri, fileName)
        End Using

        ' Compare files
        Dim localtext As String = My.Application.Info.DirectoryPath + "\Filelist.txt"
        Dim remotetext As String = My.Application.Info.DirectoryPath + "\onlinelist.txt"
        Dim localarray As New ArrayList
        Dim localhash As New ArrayList
        Dim remotearray As New ArrayList
        Dim remotehash As New ArrayList
        Dim getarray As New ArrayList
        Dim deletearray As New ArrayList

        Dim intcount As Int16 = 0
        FileOpen(1, localtext, OpenMode.Input)
        Do While Not EOF(1)
            If (intcount Mod 2 = 1) Then
                localhash.Add(LineInput(1))
            Else
                localarray.Add(LineInput(1))
            End If

            intcount = intcount + 1
        Loop

        FileClose(1)

        intcount = 0
        FileOpen(1, remotetext, OpenMode.Input)
        Do While Not EOF(1)
            If (intcount Mod 2 = 1) Then
                remotehash.Add(LineInput(1))
            Else
                remotearray.Add(LineInput(1))
            End If

            intcount = intcount + 1
        Loop
        FileClose(1)

        Dim counter As Int16
        counter = 0

        Dim total As Int16
        total = localarray.Count + remotearray.Count + localarray.Count

        'loop through local files to see if something doesnt exist in the remote array. if something doesnt exist mark it for deletion.

        For Each Item In localarray
            If Not remotearray.Contains(Item) Then
                deletearray.Add(Item)
            End If
            counter = counter + 1
            If counter Mod 5 = 0 Then
                Text_Display_Gui.Text = "Compiling File List for Version Pairity Check: File Count: " + totalfiles.ToString + Environment.NewLine + "File List compiled, Comparing Versions. " + (Math.Round(counter / total * 100)).ToString() + "%"
                System.Windows.Forms.Application.DoEvents()
            End If
        Next

        'loop through remote files to see if something doesnt exist in the local array. if it doesnt exist mark it to be gotten.

        For Each Item In remotearray
            If Not localarray.Contains(Item) Then
                getarray.Add(Item)
            End If
            counter = counter + 1
            If counter Mod 5 = 0 Then
                Text_Display_Gui.Text = "Compiling File List for Version Pairity Check: File Count: " + totalfiles.ToString + Environment.NewLine + "File List compiled, Comparing Versions. " + (Math.Round(counter / total * 100)).ToString() + "%"
                System.Windows.Forms.Application.DoEvents()
            End If
        Next

        'loop through local files, compare hashes relevant to local files to remote hashes, if they dont match mark for both deletion and getting
        Dim inttracker As Int16 = 0
        For Each item In localarray
            Dim pass As Boolean = True

            'verify the file isnt in the greylist
            If Firstinstall = False Then
                For Each greyitem In filegreylist
                    If item.ToString.Contains(greyitem.ToString) Then
                        pass = False
                    End If
                Next
            End If

            If pass Then
                If remotearray.Contains(item) Then 'check to make sure both lists have the same file name in them
                    Dim remotevalue As Int16 = remotearray.LastIndexOf(item) 'get the index of the file name from the remote array
                    Dim hash1 As String = localhash.Item(inttracker) 'get the hash from both files
                    Dim hash2 As String = remotehash.Item(remotevalue)

                    If Not hash1 = hash2 Then 'if they're not equal, delete and replace them
                        deletearray.Add(item)
                        getarray.Add(item)
                    End If
                End If
            End If

            counter = counter + 1
            inttracker = inttracker + 1
            If counter Mod 5 = 0 Then
                Text_Display_Gui.Text = "Compiling File List for Version Pairity Check: File Count: " + totalfiles.ToString + Environment.NewLine + "File List compiled, Comparing Versions. " + (Math.Round(counter / total * 100)).ToString() + "%"
                System.Windows.Forms.Application.DoEvents()
            End If
        Next

        ' Get new files, Delete unneeded files (check to see if full dorectories dont exist. if they dont delete the directory)

        counter = 0
        total = deletearray.Count + getarray.Count

        'delete files marked for deletion
        Dim localdirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\IHDir\"
        For Each Item In deletearray
            Dim deletefile As String = Item.ToString

            deletefile.Replace("ï»¿", "")

            If deletefile.First() = "\" Then
                deletefile = deletefile.Replace("\", "")
            End If
            System.IO.File.Delete(localdirectory + Item)

            Console.WriteLine("deleting: " + Item)

            counter = counter + 1

            If counter Mod 5 = 0 Then

                Text_Display_Gui.Text = "Compiling File List for Version Pairity Check: File Count: " + totalfiles.ToString + Environment.NewLine +
                    "File List compiled, Comparing Versions. 100%" + Environment.NewLine +
                    "Files Updating. " + (Math.Round(counter / total * 100)).ToString() + "%"

                System.Windows.Forms.Application.DoEvents()
            End If
        Next

        'get files marked to get

        For Each Item In getarray

            Dim getfile As String = Item

            'fix random jank from filename storage

            If getfile.First() = "\" Then
                getfile = getfile.Replace("\", "")
            End If

            getfile = getfile.Replace("ï»¿", "")

            ' parse the filepath from the filename for manipulation

            Dim pathtrack As String

            Dim lastslash As Int32 = 0
            Dim count As Int32 = 0

            For Each c As Char In getfile
                If c = "\" Then
                    lastslash = count
                End If
                count = count + 1
            Next

            pathtrack = getfile.Substring(0, lastslash)

            'create the directory for it

            Try
                My.Computer.FileSystem.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\IHDir\" + pathtrack)
            Catch ex As Exception

            End Try

            'turn the filepath and filename into a usable url

            Dim fileurl As String = getfile.Replace("\", "/")

            Dim firsthalf As String = fileurl.Substring(0, lastslash + 1)
            Dim secondhalf As String = fileurl.Substring(lastslash + 1, fileurl.Length - (lastslash + 1))
            secondhalf = WebUtility.UrlEncode(secondhalf)

            fileurl = firsthalf + secondhalf

            'append the new url snippet to the backblaze url

            remoteUri = "https://download.adeamore.com/IHDir/" + fileurl
            fileName = localdirectory + getfile

            'download the file as temp.tmp, and then move it to the folder it needs to be in

            Using client As New WebClient()
                client.Credentials = New NetworkCredential(username, password)
                client.DownloadFile(remoteUri, "temp.tmp")
            End Using

            If My.Computer.FileSystem.FileExists(fileName) Then
                My.Computer.FileSystem.DeleteFile(fileName)
            End If

            My.Computer.FileSystem.CopyFile(My.Application.Info.DirectoryPath + "\Temp.tmp", fileName)
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "\Temp.tmp")

            Console.WriteLine("Downloaded: " + getfile)

            counter = counter + 1

            'incrementally update the percentage complete value


            If Firstinstall Then
                Text_Display_Gui.Text = "Compiling File List for Version Pairity Check: File Count: " + totalfiles.ToString + Environment.NewLine +
                    "File List compiled, Comparing Versions. 100%" + Environment.NewLine +
                    "Downloading pack for the first time: " + (Math.Round(counter / total * 100)).ToString() + "% " + Environment.NewLine + getfile

                System.Windows.Forms.Application.DoEvents()
            Else
                Text_Display_Gui.Text = "Compiling File List for Version Pairity Check: File Count: " + totalfiles.ToString + Environment.NewLine +
                    "File List compiled, Comparing Versions. 100%" + Environment.NewLine +
                    "Files Updating. " + (Math.Round(counter / total * 100)).ToString() + "% " + Environment.NewLine + getfile

                System.Windows.Forms.Application.DoEvents()
            End If

        Next

        If Firstinstall Then
            Text_Display_Gui.Text = "Compiling File List for Version Pairity Check: File Count: " + totalfiles.ToString + Environment.NewLine +
                            "File List compiled, Comparing Versions. 100%" + Environment.NewLine +
                            "Downloading pack for the first time: 100%" + Environment.NewLine +
                            "Downloading Minecraft Launcher."

            System.Windows.Forms.Application.DoEvents()

            remoteUri = "https://download.adeamore.com/MinecraftLauncher.exe"
            fileName = "\MinecraftLauncher.exe"

            'download the file as temp.tmp, and then move it to the folder it needs to be in

            Using client As New WebClient()
                client.Credentials = New NetworkCredential(username, password)
                client.DownloadFile(remoteUri, My.Application.Info.DirectoryPath + fileName)
            End Using


            Text_Display_Gui.Text = "Compiling File List for Version Pairity Check: File Count: " + totalfiles.ToString + Environment.NewLine +
                            "File List compiled, Comparing Versions. 100%" + Environment.NewLine +
                            "Downloading pack for the first time: 100%" + Environment.NewLine +
                            "Downloading Minecraft Launcher." + Environment.NewLine +
                            "Done!"

            System.Windows.Forms.Application.DoEvents()
        Else
            Text_Display_Gui.Text = "Compiling File List for Version Pairity Check: File Count: " + totalfiles.ToString + Environment.NewLine +
                "File List compiled, Comparing Versions. 100%" + Environment.NewLine +
                "Files Updating. 100%" + Environment.NewLine +
                "Done!"

            System.Windows.Forms.Application.DoEvents()

        End If

    End Function
    Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com") 'check to see if you can connect to google
                    Dim remoteUri As String = "https://download.adeamore.com/delete_this_file_to_force_offline_mode.txt" 'try downloading the changelog as an attempt to check network connection to the filehost
                    Dim fileName As String = "\temp.tmp"
                    Dim password As String = "..."
                    Dim username As String = "..."

                    Try
                        Using networkthing As New WebClient()
                            networkthing.Credentials = New NetworkCredential(username, password)
                            networkthing.DownloadFile(remoteUri, My.Application.Info.DirectoryPath + fileName)
                        End Using

                        System.IO.File.Delete(My.Application.Info.DirectoryPath + fileName)

                        Return True
                    Catch ex As WebException
                        Return False
                    End Try

                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Async Sub btn_credits_Click(sender As Object, e As EventArgs) Handles btn_credits.Click
        System.Diagnostics.Process.Start("https://docs.google.com/document/d/12__s3huWbCrtpk6Lvnd4MQ8OMquiTw7dJfRVeN64dL4/edit?usp=sharing")
    End Sub

    Private Async Sub btn_changelog_Click(sender As Object, e As EventArgs) Handles btn_changelog.Click
        If changelog_text.Visible Then
            changelog_text.Visible = False
            changelog_bbox.Visible = False
        Else
            changelog_text.Visible = True
            changelog_bbox.Visible = True
        End If
    End Sub

    Private Async Sub Label1_Scroll(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If changelog_text.Visible = True Then
            If e.Delta > 0 Then
                'scroll up
                scrollup()
            Else
                'scroll down
                scrolldown()
            End If
        End If
    End Sub

    Private Async Function scrollup() As Task
        scrollstart = scrollstart - 2
        If scrollstart < 0 Then scrollstart = 0

        changelogdisplaylist.Clear()
        Dim changecount As Int32 = scrollstart
        While changecount < scrollstart + scrollsize
            Try
                changelogdisplaylist.Add(changelog(changecount))
            Catch ex As Exception
                changelogdisplaylist.Add("")
            End Try
            changecount = changecount + 1
        End While

        changelog_text.Text = ""

        Dim temptext As String = ""

        For Each item In changelogdisplaylist
            Dim tempitem As String = item
            temptext = temptext + tempitem + Environment.NewLine
        Next
        changelog_text.Text = temptext
        System.Windows.Forms.Application.DoEvents()

    End Function
    Private Async Function scrolldown() As Task

        scrollstart = scrollstart + 2

        If scrollstart + scrollsize > changelog.Count Then scrollstart = changelog.Count - scrollsize

        changelogdisplaylist.Clear()
        Dim changecount As Int32 = scrollstart
        While changecount < scrollstart + scrollsize
            Try
                changelogdisplaylist.Add(changelog(changecount))
            Catch ex As Exception
                changelogdisplaylist.Add("")
            End Try
            changecount = changecount + 1
        End While

        changelog_text.Text = ""

        Dim temptext As String = ""

        For Each item In changelogdisplaylist
            Dim tempitem As String = item
            temptext = temptext + tempitem + Environment.NewLine
        Next
        changelog_text.Text = temptext
        System.Windows.Forms.Application.DoEvents()

    End Function

    Private Sub changelog_text_Click(sender As Object, e As EventArgs) Handles changelog_text.Click

    End Sub

    Private Sub tickbox_launcherstay_CheckedChanged(sender As Object, e As EventArgs) Handles tickbox_launcherstay.CheckedChanged

        showonlaunch = tickbox_launcherstay.Checked

        System.IO.File.Delete(My.Application.Info.DirectoryPath + "\keeplauncher.txt")

        Dim streamwriterfile As StreamWriter
        streamwriterfile = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath + "\keeplauncher.txt", showonlaunch)
        streamwriterfile.Write(showonlaunch)
        streamwriterfile.Close()
    End Sub

    Private Async Function waitforminecraftclose() As Task

        If hasminecraftfolder = 1 Then
            Try
                My.Computer.FileSystem.RenameDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.Minecraft\", ".MinecraftTemp")
            Catch ex As Exception
                MsgBox("Failed to rename .minecraft file to temporary folder. Ask Avvy what to do.")
            End Try
        End If

        Try
            My.Computer.FileSystem.RenameDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\IHDir\", ".Minecraft")
        Catch ex As Exception
            MsgBox("Failed to rename IHDir files to .minecraft. Ask Avvy what to do.")
        End Try

        Dim newprocess As New ProcessStartInfo("CMD.EXE")
        newprocess.WindowStyle = ProcessWindowStyle.Hidden
        newprocess.CreateNoWindow = True
        newprocess.UseShellExecute = False
        newprocess.Arguments = "/c MinecraftLauncher.exe"

        Dim minecraftlauncher = New Process
        minecraftlauncher.StartInfo = newprocess
        minecraftlauncher.Start()

        minecraftlauncher.WaitForExit()

        Try
            My.Computer.FileSystem.RenameDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.Minecraft\", "IHDir")
        Catch ex As Exception
            MsgBox("Failed to rename .minecraft files. To IHDir")
        End Try

        If hasminecraftfolder = 1 Then
            Try
                My.Computer.FileSystem.RenameDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.MinecraftTemp\", ".Minecraft")
            Catch ex As Exception
                MsgBox("Failed to rename temporary folder to .minecraft folder. Restart the launcher to attempt again.")
            End Try
        End If

    End Function

    Private Sub form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If minecraftrunning = True Then
            e.Cancel = True
            Me.Hide()
        End If

    End Sub

    Private Sub form1_resize(sender As Object, e As EventArgs) Handles Me.Resize
        If worldmapvisible = 0 Then
            dynmap_browser.Location = New Point(Me.Width, 0)
        Else
            dynmapresizer()
        End If
    End Sub

    Private Async Sub btn_worldmap_Click(sender As Object, e As EventArgs) Handles btn_worldmap.Click

        'disable all assets
        Text_Display_Gui.Enabled = 0
        lbl_creator_credits.Enabled = 0
        changelog_bbox.Enabled = 0
        changelog_text.Enabled = 0
        btn_credits.Enabled = 0
        btn_changelog.Enabled = 0
        tickbox_launcherstay.Enabled = 0
        btn_Launch.Enabled = 0
        btn_worldmap.Enabled = 0

        worldmapvisible = 1

        dynmap_browser.Source = New Uri("http://infinitehorizons.apexmc.co:8123/?worldname=InfiniteHorizonsWorld&mapname=flat")
        dynmap_browser.Reload()

    End Sub

    Private Sub dynmap_browser_Click(sender As Object, e As EventArgs) Handles dynmap_browser.Click

    End Sub

    Private Sub handledynmapload() Handles dynmap_browser.NavigationCompleted
        If worldmapvisible = True Then
            'set all assets to not be visible
            Text_Display_Gui.Visible = 0
            lbl_creator_credits.Visible = 0
            changelog_bbox.Visible = 0
            changelog_text.Visible = 0
            btn_credits.Visible = 0
            btn_changelog.Visible = 0
            btn_Launch.Visible = 0
            tickbox_launcherstay.Visible = 0
            btn_worldmap.Visible = 0

            'enable map specific items
            btn_returnfrommap.Visible = 1
            btn_returnfrommap.Enabled = 1
            lbl_playername.Visible = 1
            tbox_playername.Visible = 1
            tbox_playername.Enabled = 1
            btn_set_playername.Enabled = 1
            btn_set_playername.Visible = 1
            btn_launchpos.Visible = 1
            btn_launchpos.Enabled = 1
            tbox_xpos.Enabled = 1
            tbox_xpos.Visible = 1
            tbox_zpos.Visible = 1
            tbox_zpos.Enabled = 1
            lbl_xpos.Visible = 1
            lbl_zpos.Visible = 1
            lbl_dimension.Visible = 1
            dbox_dimensions.Visible = 1
            dbox_dimensions.Enabled = 1
            btn_dimensions.Visible = 1
            btn_dimensions.Enabled = 1
            btn_reload_map.Visible = 1
            btn_reload_map.Enabled = 1

            'set the location for the browser, and orientation
            dynmapresizer()
        End If
    End Sub

    Private Sub dynmapresizer()
        dynmap_browser.Location = New Point(0, 0)
        dynmap_browser.Size = New Point(Me.Width, Me.Height)
    End Sub

    Private Sub btn_returnfrommap_Click(sender As Object, e As EventArgs) Handles btn_returnfrommap.Click

        'set all assets to be visible
        Text_Display_Gui.Visible = 1
        lbl_creator_credits.Visible = 1
        btn_credits.Visible = 1
        btn_changelog.Visible = 1
        btn_Launch.Visible = 1
        tickbox_launcherstay.Visible = 1
        btn_worldmap.Visible = 1

        'disable map based assets
        lbl_playername.Visible = 0
        tbox_playername.Visible = 0
        tbox_playername.Enabled = 0
        btn_returnfrommap.Visible = 0
        btn_returnfrommap.Enabled = 0
        btn_set_playername.Enabled = 0
        btn_set_playername.Visible = 0
        btn_launchpos.Visible = 0
        btn_launchpos.Enabled = 0
        tbox_xpos.Enabled = 0
        tbox_xpos.Visible = 0
        tbox_zpos.Visible = 0
        tbox_zpos.Enabled = 0
        lbl_xpos.Visible = 0
        lbl_zpos.Visible = 0
        lbl_dimension.Visible = 0
        dbox_dimensions.Visible = 0
        dbox_dimensions.Enabled = 0
        btn_dimensions.Visible = 0
        btn_dimensions.Enabled = 0
        btn_reload_map.Visible = 0
        btn_reload_map.Enabled = 0

        'enable all assets
        Text_Display_Gui.Enabled = 1
        lbl_creator_credits.Enabled = 1
        changelog_bbox.Enabled = 1
        changelog_text.Enabled = 1
        btn_credits.Enabled = 1
        btn_changelog.Enabled = 1
        tickbox_launcherstay.Enabled = 1
        btn_worldmap.Enabled = 1

        btn_Launch.Enabled = canlaunch

        'set the location for the browser, and orientation
        dynmap_browser.Location = New Point(Me.Width, 0)

        worldmapvisible = 0

    End Sub

    Private Sub playerfollowtype(sender As Object, e As EventArgs) Handles tbox_playername.TextChanged
        tbox_playername.Text = tbox_playername.Text.Replace(" ", "")
        tbox_playername.SelectionStart = tbox_playername.Text.Length
    End Sub

    Private Sub playerfollowtext(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If tbox_playername.Focused Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
                btn_set_playername_Click()
            End If
        End If
        If tbox_zpos.Focused Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
                btn_launchpos_Click()
            End If
        End If
    End Sub

    Private Async Sub btn_set_playername_Click() Handles btn_set_playername.Click

        Dim newaddress As String = ""

        If (tbox_playername.Text = "") Then
            newaddress = "http://infinitehorizons.apexmc.co:8123/?worldname=" + mapdimension + "&mapname=flat"

        Else
            newaddress = "http://infinitehorizons.apexmc.co:8123/?worldname=" + mapdimension + "&mapname=flat" + "&playername=" + tbox_playername.Text
        End If


        dynmap_browser.Source = New Uri(newaddress)
        dynmap_browser.Focus()
    End Sub

    Private Sub textboxx(sender As Object, e As EventArgs) Handles tbox_xpos.TextChanged
        Dim isneg As Boolean = False

        If tbox_xpos.Text.Contains("-") Then
            isneg = True
        End If

        If isneg Then
            tbox_xpos.Text = "-" + Regex.Replace(tbox_xpos.Text.Replace("-", ""), "[^0-9]", "")
        Else
            tbox_xpos.Text = Regex.Replace(tbox_xpos.Text.Replace("-", ""), "[^0-9]", "")
        End If

        tbox_xpos.SelectionStart = tbox_xpos.Text.Length
    End Sub

    Private Sub textboxz(sender As Object, e As EventArgs) Handles tbox_zpos.TextChanged
        Dim isneg As Boolean = False
        If tbox_zpos.Text.Contains("-") Then
            isneg = True
        End If

        If isneg Then
            tbox_zpos.Text = "-" + Regex.Replace(tbox_zpos.Text.Replace("-", ""), "[^0-9]", "")
        Else
            tbox_zpos.Text = Regex.Replace(tbox_zpos.Text.Replace("-", ""), "[^0-9]", "")
        End If

        tbox_zpos.SelectionStart = tbox_zpos.Text.Length
    End Sub

    Private Sub btn_launchpos_Click() Handles btn_launchpos.Click

        Dim newaddress As String = ""

        If tbox_xpos.Text.Length = 0 Then
            tbox_xpos.Text = "0"
        End If
        If tbox_zpos.Text.Length = 0 Then
            tbox_zpos.Text = "0"
        End If

        newaddress = "http://infinitehorizons.apexmc.co:8123/?worldname=" + mapdimension + "&mapname=flat" + "&x=" + tbox_xpos.Text + "&z=" + tbox_zpos.Text

        If Not dynmap_browser.Source = New Uri(newaddress) Then
            dynmap_browser.Source = New Uri(newaddress)
        Else
            dynmap_browser.Reload()
        End If

        dynmap_browser.Focus()

    End Sub

    Private Sub btn_dimensions_Click() Handles btn_dimensions.Click
        Select Case dbox_dimensions.Text
            Case "Overworld"
                mapdimension = "InfiniteHorizonsWorld"
            Case "Overworld Orbit"
                mapdimension = "ad_astra_earth_orbit"
            Case "The End"
                mapdimension = "DIM1"
            Case "The Nether"
                mapdimension = "DIM-1"
            Case "Create Moon"
                mapdimension = "creatingspace_the_moon"
            Case "Create Moon Orbit"
                mapdimension = "creatingspace_moon_orbit"
            Case "Create Earth Orbit"
                mapdimension = "creatingspace_earth_orbit"
            Case "Endor"
                mapdimension = "swplanets_endor"
            Case "Endor Orbit"
                mapdimension = "swplanets_endor_orbit"
            Case "Glacio"
                mapdimension = "ad_astra_glacio"
            Case "Glacio Orbit"
                mapdimension = "ad_astra_glacio_orbit"
            Case "Hot"
                mapdimension = "swplanets_hot"
            Case "Hot Orbit"
                mapdimension = "swplanets_hot_orbit"
            Case "Lost Cities"
                mapdimension = "lostcities_lostcity"
            Case "Mahou Reality Marble"
                mapdimension = "mahoutsukai_reality_marble"
            Case "Mandalore"
                mapdimension = "swplanets_mandalore"
            Case "Mandalore Orbit"
                mapdimension = "swplanets_mandalore_orbit"
            Case "Mars"
                mapdimension = "ad_astra_mars"
            Case "Mars Orbit"
                mapdimension = "ad_astra_mars_orbit"
            Case "Mercury"
                mapdimension = "ad_astra_mercury"
            Case "Mercury Orbit"
                mapdimension = "ad_astra_mercury_orbit"
            Case "Moon"
                mapdimension = "ad_astra_moon"
            Case "Moon Orbit"
                mapdimension = "ad_astra_moon_orbit"
            Case "Mustafar"
                mapdimension = "swplanets_mustafar"
            Case "Mustafar Orbit"
                mapdimension = "swplanets_mustafar_orbit"
            Case "Normal Planet"
                mapdimension = "ad_astra_proxima_plus_normalplanet"
            Case "Proxima Asteroid Belt"
                mapdimension = "ad_astra_proxima_plus_proxima_asteroid_belt"
            Case "Proxima Asteroid Belt Orbit"
                mapdimension = "ad_astra_proxima_plus_proxima_asteroid_belt_orbit"
            Case "Proxima B"
                mapdimension = "ad_astra_proxima_plus_proxima_b"
            Case "Proxima B Orbit"
                mapdimension = "ad_astra_proxima_plus_proxima_b_orbit"
            Case "Proxima C"
                mapdimension = "ad_astra_proxima_plus_proxima_c"
            Case "Proxima C Orbit"
                mapdimension = "ad_astra_proxima_plus_proxima_c_orbit"
            Case "Proxima D"
                mapdimension = "ad_astra_proxima_plus_proxima_d"
            Case "Proxima D Orbit"
                mapdimension = "ad_astra_proxima_plus_proxima_d_orbit"
            Case "Tattooine"
                mapdimension = "swplanets_tatooine"
            Case "Tattooine Orbit"
                mapdimension = "swplanets_tatooine_orbit"
            Case "Venus"
                mapdimension = "ad_astra_venus"
            Case "Venus Orbit"
                mapdimension = "ad_astra_venus_orbit"
            Case "Vicino"
                mapdimension = "ad_astra_proxima_plus_vicino"
            Case "Vicino Orbit"
                mapdimension = "ad_astra_proxima_plus_vicino_orbit"
        End Select

        Dim newaddress As String = "http://infinitehorizons.apexmc.co:8123/?worldname=" + mapdimension + "&mapname=flat"

        If Not dynmap_browser.Source = New Uri(newaddress) Then
            dynmap_browser.Source = New Uri(newaddress)
        Else
            dynmap_browser.Reload()
        End If

    End Sub

    Private Sub btn_reload_map_Click(sender As Object, e As EventArgs) Handles btn_reload_map.Click
        dynmap_browser.Reload()
    End Sub
End Class
