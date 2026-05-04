Imports System.IO
Imports Microsoft.VisualBasic.ApplicationServices
Public Class MainForm
#If DEBUG Then
    Private Calls As Long = 0
#End If
    Private ReadOnly AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Private ReadOnly CommonAppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
    Private ReadOnly CurrentUserFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
    Private ReadOnly DocumentsFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    Private ReadOnly LocalAppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
    Private ReadOnly WindowsFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.Windows)
    Private ReadOnly Root As String = Path.GetPathRoot(WindowsFolder)
    Private ReadOnly UsersFolder As String = Root & "Users"
    Private ReadOnly PublicUserFolder As String = UsersFolder & "\Public"

    Private ReadOnly Language As String = Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName
    Private TotalSize As Long = 0
    Private SelectedSize As Long = 0
    Private LastFileCount As Long = 0
    Private SelectedFileCount As Long = 0
    Private ActiveList As ListView = WindowsList

    Private IsAdmin As Boolean = My.User.IsInRole(BuiltInRole.Administrator)
    Private ProgressDialog As New ProgressForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Visible = False

        If GitHubUpdater.Check Then
            GitHubUpdater.Download()
        End If

        ProgressDialog.ProgressBar.Value = 0
        ProgressDialog.ProgressBar.Maximum = 961

        If Language = "de" Then
            ProgressDialog.Text = "Datenträgerbereinigung X"
            ProgressDialog.ProgressDescriptionLabel.Text = "Es wird berechnet, wie viel Speicherplatz freigegeben werden kann. Dieser Vorgang kann einen Moment dauern."
            ProgressDialog.TypeLabel.Text = "Scanvorgang:"
            ProgressDialog.QuitButton.Text = "Abbrechen"
        Else
            ProgressDialog.Text = Text
            ProgressDialog.ProgressDescriptionLabel.Text = "The system calculates how much storage space can be cleaned. This process may take a moment."
            ProgressDialog.TypeLabel.Text = "Scanning:"
            ProgressDialog.QuitButton.Text = "Cancel"
        End If

        ProgressDialog.Show()

        If IsAdmin Then
            'AdminModePanel.Visible = True
            'AdminModeLabel.Visible = True
            Logo.Image = My.Resources.DriveLogo
        End If

        Application.DoEvents()
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'WINDOWS BUILT-IN - ROOT
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Drive Root Logs", "\", Folder.Root, WindowsList, False, "*.log")
        AddItem("Drive Root Temporary Files", "\", Folder.Root, WindowsList, False, "*.tmp")
        AddItem("Performance Logs", "\PerfLogs", Folder.Root, WindowsList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'WINDOWS BUILT-IN - PUBLIC USER
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Public Account Pictures", "\AccountPictures", Folder.PublicUser, WindowsList)
        AddItem("Public Desktop", "\Desktop", Folder.PublicUser, WindowsList)
        AddItem("Public Documents", "\Documents", Folder.PublicUser, WindowsList)
        AddItem("Public Downloads", "\Downloads", Folder.PublicUser, WindowsList)
        AddItem("Public Music", "\Music", Folder.PublicUser, WindowsList)
        AddItem("Public Pictures", "\Pictures", Folder.PublicUser, WindowsList)
        AddItem("Public Videos", "\Videos", Folder.PublicUser, WindowsList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'WINDOWS BUILT-IN - LOCAL APP DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Cached User Files", "\cache", Folder.LocalAppData, WindowsList)
        AddItem("User Crash Dumps", "\CrashDumps", Folder.LocalAppData, WindowsList)
        AddItem("User Crash Reports", "\CrashReportClient", Folder.LocalAppData, WindowsList)
        AddItem("DirectX Shader Cache", "\D3DSCache", Folder.LocalAppData, WindowsList)
        AddItem("Downloaded Installations", "\Downloaded Installations", Folder.LocalAppData, WindowsList)
        AddItem("Font Config Cache", "\fontconfig\cache", Folder.LocalAppData, WindowsList)
        AddItem("Game Analytics", "\GameAnalytics", Folder.LocalAppData, WindowsList)
        AddItem("Microsoft Edge Crashpad Metrics", "\Microsoft\Edge\User Data", Folder.LocalAppData, WindowsList, False, "CrashpadMetrics-active.pma")
        AddItem("Microsoft Edge Component Cache", "\Microsoft\Edge\User Data\component_crx_cache", Folder.LocalAppData, WindowsList)
        AddItem("Microsoft Edge Crashpad Data", "\Microsoft\Edge\User Data\Crashpad", Folder.LocalAppData, WindowsList)
        AddItem("Microsoft Edge Cache", "\Microsoft\Edge\User Data\Default\Cache", Folder.LocalAppData, WindowsList)
        AddItem("Microsoft Edge Local Storage", "\Microsoft\Edge\User Data\Default\Local Storage", Folder.LocalAppData, WindowsList)
        AddItem("Microsoft Edge Session Storage", "\Microsoft\Edge\User Data\Default\Session Storage", Folder.LocalAppData, WindowsList)
        AddItem("Microsoft Edge Sessions", "\Microsoft\Edge\User Data\Default\Sessions", Folder.LocalAppData, WindowsList)
        AddItem("Microsoft Edge Web Storage", "\Microsoft\Edge\User Data\Default\WebStorage", Folder.LocalAppData, WindowsList)
        AddItem("Microsoft Edge Extensions Cache", "\Microsoft\Edge\User Data\extensions_crx_cache", Folder.LocalAppData, WindowsList)
        AddItem("Microsoft Edge Graphite Cache", "\Microsoft\Edge\User Data\GraphiteDawnCache", Folder.LocalAppData, WindowsList)
        AddItem("Microsoft Edge Graphite Shader Cache", "\Microsoft\Edge\User Data\GrShaderCache", Folder.LocalAppData, WindowsList)
        AddItem("Microsoft Edge Shader Cache", "\Microsoft\Edge\User Data\ShaderCache", Folder.LocalAppData, WindowsList)
        AddItem("Icon Cache", "\Microsoft\Windows\Explorer", Folder.LocalAppData, WindowsList, False, "iconcache_*.db")
        AddItem("Thumbnail Cache", "\Microsoft\Windows\Explorer", Folder.LocalAppData, WindowsList, False, "thumbcache_*.db")
        AddItem("Temporary Internet Files", "\Microsoft\Windows\INetCache", Folder.LocalAppData, WindowsList)
        AddItem("OneDrive Cache Files", "\OneDrive\cache", Folder.LocalAppData, WindowsList)
        AddItem("Installer Cache Files", "\setup\cache", Folder.LocalAppData, WindowsList)
        If IsAdmin Then
            For Each TempFolder As String In Directory.EnumerateDirectories(UsersFolder, "*.*", SearchOption.TopDirectoryOnly)
                If Not TempFolder.EndsWith("Default") AndAlso
               Not TempFolder.EndsWith("Default User") AndAlso
               Not TempFolder.EndsWith("Public") Then
                    AddItem("Temporary User Files (" & TempFolder.Replace(UsersFolder & "\", "") & ")", "\Temp", Folder.Custom, WindowsList, True, "*.*", TempFolder & "\AppData\Local")
                End If
            Next
        Else
            AddItem("Temporary User Files", "\Temp", Folder.LocalAppData, WindowsList)
        End If

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'WINDOWS BUILT-IN - PROGRAM DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("User Error Reports", "\Microsoft\Windows\WER\ReportArchive", Folder.CommonAppData, WindowsList)
        AddItem("User Error Queue", "\Microsoft\Windows\WER\ReportQueue", Folder.CommonAppData, WindowsList)
        AddItem("Diagnostic Logs", "\Microsoft\DiagnosticLogCSP", Folder.CommonAppData, WindowsList, True, "*.etl*")
        AddItem("Microsoft Edge Update Logs", "\Microsoft\EdgeUpdate\Log", Folder.CommonAppData, WindowsList)
        AddItem("Network Logs", "\Microsoft\Network\Downloader", Folder.CommonAppData, WindowsList, False, "*.log")
        AddItem("Microsoft Search Index Logs", "\Microsoft\Search\Data\Applications\Windows\GatherLogs\SystemIndex", Folder.CommonAppData, WindowsList)
        AddItem("Microsoft Defender Definition Update Backup", "\Microsoft\Windows Defender\Definition Updates\Backup", Folder.CommonAppData, WindowsList)
        AddItem("Microsoft Defender Protection History", "\Microsoft\Windows Defender\Scans\History", Folder.CommonAppData, WindowsList)
        AddItem("System Performance Analyzer Trace Files", "\USOShared\Logs\System", Folder.CommonAppData, WindowsList, False, "*.etl")
        AddItem("User Performance Analyzer Trace Files", "\USOShared\Logs\User", Folder.CommonAppData, WindowsList, False, "*.etl")

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'WINDOWS BUILT-IN - WINDOWS FOLDER
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Windows Root Logs", WindowsFolder, Folder.Windows, WindowsList, False, "*.log")
        AddItem("Windows Legacy Crash Dumps", "\%LOCALAPPDATA%\CrashDumps", Folder.Windows, WindowsList)
        AddItem("Windows Crash Dumps", "\CrashDumps", Folder.Windows, WindowsList)
        AddItem("Debug Logs", "\Debug", Folder.Windows, WindowsList, True, "*.log")
        AddItem("Diagnostic Telemetry Data", "\DiagTrack", Folder.Windows, WindowsList)
        AddItem("Downloaded Program Files", "\Downloaded Program Files", Folder.Windows, WindowsList)
        AddItem("Inbox Apps", "\InboxApps", Folder.Windows, WindowsList)
        AddItem("Live Kernel Reports", "\LiveKernelReports", Folder.Windows, WindowsList)
        AddItem("Windows Log Folder", "\Logs", Folder.Windows, WindowsList)
        AddItem("Mini Dumps", "\Minidump", Folder.Windows, WindowsList)
        AddItem("Modem Logs", "\ModemLogs", Folder.Windows, WindowsList)
        AddItem("Offline Web Pages", "\Offline Web Pages", Folder.Windows, WindowsList)
        AddItem("Panther Logs", "\Panther", Folder.Windows, WindowsList, True, "*.log")
        AddItem("Panther Performance Analyzer Trace Files", "\Panther", Folder.Windows, WindowsList, True, "*.etl")
        AddItem("WinSAT Logs", "\Performance\WinSAT", Folder.Windows, WindowsList, True, "*.log")
        AddItem("WinSAT Performance Analyzer Trace Files", "\Performance\WinSAT", Folder.Windows, WindowsList, True, "*.etl")
        AddItem("Prefetch", "\Prefetch", Folder.Windows, WindowsList, False, "*.pf")
        AddItem("Delivery Optimization Files", "\ServiceProfiles\NetworkService\AppData\Local\Microsoft\Windows\DeliveryOptimization", Folder.Windows, WindowsList)
        AddItem("Windows Update Logs", "\SoftwareDistribution", Folder.Windows, WindowsList, True, "*.log")
        AddItem("Windows Update Download Cache", "\SoftwareDistribution\Download", Folder.Windows, WindowsList)
        AddItem("Temporary Windows System Files", "\SystemTemp", Folder.Windows, WindowsList)
        AddItem("Temporary Windows Files", "\Temp", Folder.Windows, WindowsList)
        AddItem("Error Reports", "\WER", Folder.Windows, WindowsList)
        AddItem("Previous Windows Installation", ".old", Folder.Windows, WindowsList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'DEEP CLEAN - AMD
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("AMD Chipset Drivers Backup", "\AMD\Chipset_Software", Folder.Root, DeepCleanList)
        AddItem("AMD Ryzen Master Backup", "\AMD\RyzenMasterExtraction", Folder.Root, DeepCleanList)
        AddItem("AMD Ryzen Master Logs", "", Folder.CurrentUser, DeepCleanList, False, "AMD*.log")
        AddItem("AMD AutoUpdate Logs", "\AMD AutoUpdate", Folder.CommonAppData, DeepCleanList, False, "*.log")
        AddItem("AMD Chipset Drivers MSI Backup", "\AMD\Chipset_Software", Folder.AppData, DeepCleanList, True, "*.msi")
        AddItem("AMD DirectX Shader Cache", "\AMD\DxCache", Folder.LocalAppData, DeepCleanList)
        AddItem("AMD Compute Cache", "\AMD\DxcCache", Folder.LocalAppData, DeepCleanList)
        AddItem("AMD Ryzen Master Cache", "\AMD\Ryzen Master\cache", Folder.LocalAppData, DeepCleanList)
        AddItem("AMD Vulkan Shader Cache", "\AMD\VkCache", Folder.LocalAppData, DeepCleanList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'DEEP CLEAN - NVIDIA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("NVIDIA Drivers Backup", "\NVIDIA", Folder.Root, DeepCleanList)
        AddItem("NVIDIA OpenGL Shader Cache", "\NVIDIA\GLCache", Folder.LocalAppData, DeepCleanList)
        AddItem("NVIDIA GeForce Experience CEF Cache", "\NVIDIA Corporation\NVIDIA GeForce Experience\CefCache", Folder.LocalAppData, DeepCleanList)
        AddItem("NVIDIA Share CEF Cache", "\NVIDIA Corporation\NVIDIA Share\CefCache", Folder.LocalAppData, DeepCleanList)
        AddItem("NVIDIA Notification CEF Cache", "\NVIDIA Corporation\NVIDIA Notification\CefCache", Folder.LocalAppData, DeepCleanList)
        AddItem("NVIDIA DirectX Shader Cache", "Low\NVIDIA\PerDriverVersion\DXCache", Folder.LocalAppData, DeepCleanList)
        AddItem("NVIDIA Compute Cache", "\NVIDIA\ComputeCache", Folder.LocalAppData, DeepCleanList)
        AddItem("NVIDIA Driver Crash Dumps", "\NVIDIA Corporation\CrashDumps", Folder.CommonAppData, DeepCleanList)
        AddItem("NVIDIA Driver Telemetry Data", "\NVIDIA Corporation\DisplayDriverRAS\NvTelemetry", Folder.CommonAppData, DeepCleanList)
        AddItem("NVIDIA GameSession Telemetry Data", "\NVIDIA Corporation\GameSessionTelemetry", Folder.CommonAppData, DeepCleanList)
        AddItem("NVIDIA GeForce Experience Logs", "\NVIDIA Corporation\GeForce Experience\Logs", Folder.CommonAppData, DeepCleanList)
        AddItem("NVIDIA GeForce Experience Bridges Logs", "\NVIDIA Corporation\GfeBridges", Folder.CommonAppData, DeepCleanList, False)
        AddItem("NVIDIA GeForce Now Runtime SDK Logs", "\NVIDIA Corporation\GfnRuntimeSdk", Folder.CommonAppData, DeepCleanList, False)
        AddItem("NVIDIA GeForce Experience Legacy Logs", "\NVIDIA Corporation\NVIDIA GeForce Experience\Logs", Folder.CommonAppData, DeepCleanList)
        AddItem("NVIDIA Profile Updater Logs", "\NVIDIA Corporation\NvProfileUpdaterPlugin", Folder.CommonAppData, DeepCleanList, False)
        AddItem("NVIDIA Stream Service Logs", "\NVIDIA Corporation\nvstreamsvc", Folder.CommonAppData, DeepCleanList, False)
        AddItem("NVIDIA Telemetry Data", "\NVIDIA Corporation\NvTelemetry", Folder.CommonAppData, DeepCleanList)
        AddItem("NVIDIA TOPPS Logs", "\NVIDIA Corporation\nvtopps", Folder.CommonAppData, DeepCleanList, False, "*.log")
        AddItem("NVIDIA VAD Logs", "\NVIDIA Corporation\NvVAD", Folder.CommonAppData, DeepCleanList, False, "*.log")
        AddItem("NVIDIA ShadowPlay Cache & Logs", "\NVIDIA Corporation\ShadowPlay", Folder.CommonAppData, DeepCleanList)
        AddItem("NVIDIA UMD Logs", "\NVIDIA Corporation\umdlogs", Folder.CommonAppData, DeepCleanList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'DEEP CLEAN - ROOT
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Rookie Sideloader Temporary Files", "\RSL", Folder.Root, DeepCleanList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'DEEP CLEAN - PUBLIC USER
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("NinjaRipper Public Files", "\ninjaripper", Folder.PublicUser, DeepCleanList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'DEEP CLEAN - CURRENT USER
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem(".NET User Cache", "\.dotnet", Folder.CurrentUser, DeepCleanList, False, "*.dotnetUserLevelCache")
        AddItem(".NET Telemetry Data", "\.dotnet\TelemetryStorageService", Folder.CurrentUser, DeepCleanList, False, "*.trn")
        AddItem("Gradle Temporary Files", "\.gradle\.tmp", Folder.CurrentUser, DeepCleanList)
        AddItem("Blender Thumbnails", "\.thumbnails", Folder.CurrentUser, DeepCleanList)
        AddItem("Megascans Library", "\Documents\Megascans Library", Folder.CurrentUser, DeepCleanList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'DEEP CLEAN - LOCAL APP DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("User Icon Cache", "\", Folder.LocalAppData, DeepCleanList, False, "IconCache.db")
        AddItem("Adaware Cache", "\Adaware", Folder.LocalAppData, DeepCleanList)
        AddItem("Android SDK Download Cache Files", "\Android\Sdk\.downloadIntermediates", Folder.LocalAppData, DeepCleanList)
        AddItem("Android SDK Temporary Files", "\Android\Sdk\.temp", Folder.LocalAppData, DeepCleanList)
        AddItem("Audacity Crash Reports", "\audacity\crashreports", Folder.LocalAppData, DeepCleanList)
        AddItem("Battle.net Cache Database", "\Battle.net", Folder.LocalAppData, DeepCleanList, False, "CachedData.db")
        AddItem("Battle.net Account Cache", "\Battle.net\Account", Folder.LocalAppData, DeepCleanList)
        AddItem("Battle.net Browser Cache", "\Battle.net\BrowserCaches", Folder.LocalAppData, DeepCleanList)
        AddItem("Battle.net Cache", "\Battle.net\Cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Battle.net Logs", "\Battle.net\Logs", Folder.LocalAppData, DeepCleanList)
        AddItem("Blizzard Entertainment Telemetry Data", "\Blizzard Entertainment\Telemetry", Folder.LocalAppData, DeepCleanList)
        AddItem("Brave Browser Crashpad Metrics", "\BraveSoftware\Brave-Browser\User Data", Folder.LocalAppData, DeepCleanList, False, "CrashpadMetrics-active.pma")
        AddItem("Brave Browser Component Cache", "\BraveSoftware\Brave-Browser\User Data\component_crx_cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Brave Browser Crashpad Data", "\BraveSoftware\Brave-Browser\User Data\Crashpad", Folder.LocalAppData, DeepCleanList)
        AddItem("Brave Browser Cache", "\BraveSoftware\Brave-Browser\User Data\Default\Cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Brave Browser Local Storage", "\BraveSoftware\Brave-Browser\User Data\Default\Local Storage", Folder.LocalAppData, DeepCleanList)
        AddItem("Brave Browser Session Storage", "\BraveSoftware\Brave-Browser\User Data\Default\Session Storage", Folder.LocalAppData, DeepCleanList)
        AddItem("Brave Browser Sessions", "\BraveSoftware\Brave-Browser\User Data\Default\Sessions", Folder.LocalAppData, DeepCleanList)
        AddItem("Brave Browser Web Storage", "\BraveSoftware\Brave-Browser\User Data\Default\WebStorage", Folder.LocalAppData, DeepCleanList)
        AddItem("Brave Browser Extensions Cache", "\BraveSoftware\Brave-Browser\User Data\extensions_crx_cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Brave Browser Graphite Cache", "\BraveSoftware\Brave-Browser\User Data\GraphiteDawnCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Brave Browser Graphite Shader Cache", "\BraveSoftware\Brave-Browser\User Data\GrShaderCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Brave Browser Shader Cache", "\BraveSoftware\Brave-Browser\User Data\ShaderCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Cascadeur Samples", "\Cascadeur\samples", Folder.LocalAppData, DeepCleanList)
        AddItem("CEF Crashpad Metrics", "\CEF\User Data", Folder.LocalAppData, DeepCleanList, False, "*.pma")
        AddItem("Unistore Aggregate Cache", "\Comms\Unistore\data", Folder.LocalAppData, DeepCleanList, False, "AggregateCache.uca")
        AddItem("Connected Devices Platform Activity Cache", "\ConnectedDevicesPlatform", Folder.LocalAppData, DeepCleanList, True, "ActivitiesCache*")
        AddItem("Corsair Crash Reports", "\Corsair\CrashData", Folder.LocalAppData, DeepCleanList)
        AddItem("Corsair iCUE 5 Cache", "\Corsair\CUE5\cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Corsair iCUE 5 Logs", "\Corsair\CUE5\logs", Folder.LocalAppData, DeepCleanList)
        AddItem("Discord Updater Logs", "\Discord", Folder.LocalAppData, DeepCleanList, False, "*.log")
        AddItem("Electronic Arts App Cache", "\EADesktop\cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Electronic Arts Launch Helper Cache", "\EALaunchHelper\cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Electronic Arts App IGO Cache", "\Electronic Arts\EA Desktop\IGOCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Electronic Arts App Logs", "\Electronic Arts\EA Desktop\Logs", Folder.LocalAppData, DeepCleanList)
        AddItem("Electronic Arts App Offline Cache", "\Electronic Arts\EA Desktop\OfflineCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Epic Games Launcher Crash Dumps", "\EpicGamesLauncher\Saved\Crashes", Folder.LocalAppData, DeepCleanList)
        AddItem("Epic Games Launcher Logs", "\EpicGamesLauncher\Saved\Logs", Folder.LocalAppData, DeepCleanList)
        AddItem("Epic Online Services UI-Helper Legacy Logs", "\EpicOnlineServicesUIHelper\Saved\Logs", Folder.LocalAppData, DeepCleanList)
        AddItem("Epic Online Services Overlay", "\Epic Games\EOSOverlay", Folder.LocalAppData, DeepCleanList)
        AddItem("Epic Online Services Bootstrapper Logs", "\Epic Games\Epic Online Services\Bootstrapper\Logs", Folder.LocalAppData, DeepCleanList)
        AddItem("Epic Online Services Host Logs", "\Epic Games\Epic Online Services\EpicOnlineServicesHost\Logs", Folder.LocalAppData, DeepCleanList)
        AddItem("Epic Online Services UI-Helper Cache", "\Epic Games\Epic Online Services\UI Helper\Cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Epic Online Services UI-Helper Logs", "\Epic Games\Epic Online Services\UI Helper\Logs", Folder.LocalAppData, DeepCleanList)
        AddItem("Epic Online Services User-Helper Logs", "\Epic Games\Epic Online Services\UserHelper\Logs", Folder.LocalAppData, DeepCleanList)
        AddItem("Github Desktop Updater Logs", "\GitHubDesktop", Folder.LocalAppData, DeepCleanList, False, "*.log")
        AddItem("Android Studio 2022.2 Cache", "\Google\AndroidStudio2022.2\caches", Folder.LocalAppData, DeepCleanList)
        AddItem("Android Studio 2022.2 Logs", "\Google\AndroidStudio2022.2\log", Folder.LocalAppData, DeepCleanList)
        AddItem("Android Studio 2022.2 Temporary Files", "\Google\AndroidStudio2022.2\tmp", Folder.LocalAppData, DeepCleanList)
        AddItem("Google Chrome Crashpad Metrics", "\Google\Chrome\User Data", Folder.LocalAppData, DeepCleanList, False, "CrashpadMetrics-active.pma")
        AddItem("Google Chrome Component Cache", "\Google\Chrome\User Data\component_crx_cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Google Chrome Crashpad Data", "\Google\Chrome\User Data\Crashpad", Folder.LocalAppData, DeepCleanList)
        AddItem("Google Chrome Cache", "\Google\Chrome\User Data\Default\Cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Google Chrome Local Storage", "\Google\Chrome\User Data\Default\Local Storage", Folder.LocalAppData, DeepCleanList)
        AddItem("Google Chrome Session Storage", "\Google\Chrome\User Data\Default\Session Storage", Folder.LocalAppData, DeepCleanList)
        AddItem("Google Chrome Sessions", "\Google\Chrome\User Data\Default\Sessions", Folder.LocalAppData, DeepCleanList)
        AddItem("Google Chrome Web Storage", "\Google\Chrome\User Data\Default\WebStorage", Folder.LocalAppData, DeepCleanList)
        AddItem("Google Chrome Extensions Cache", "\Google\Chrome\User Data\extensions_crx_cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Google Chrome Graphite Cache", "\Google\Chrome\User Data\GraphiteDawnCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Google Chrome Graphite Shader Cache", "\Google\Chrome\User Data\GrShaderCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Google Chrome Shader Cache", "\Google\Chrome\User Data\ShaderCache", Folder.LocalAppData, DeepCleanList)
        AddItem("JDownloader 2 Logs", "\JDownloader 2.0\logs", Folder.LocalAppData, DeepCleanList)
        AddItem("Larian Studios Launcher Cache", "\Larian Studios\Launcher\Cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Larian Studios Launcher CEF Cache", "\Larian Studios\Launcher\CefCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Larian Studios Launcher Logs", "\Larian Studios\Launcher\Logs", Folder.LocalAppData, DeepCleanList)
        AddItem("Origin Avatar Cache", "\Origin\AvatarsCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Origin Image Cache", "\Origin\ImageCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Origin Web Cache", "\Origin\Web Cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Paint.Net App Cache", "\paint.net\AppCache", Folder.LocalAppData, DeepCleanList)
        AddItem("RED Launcher Logs", "\Programs\CD Projekt Red\REDlauncher\logs", Folder.LocalAppData, DeepCleanList)
        AddItem("qBitTorrent Cache", "\qBittorrent\cache", Folder.LocalAppData, DeepCleanList)
        AddItem("qBitTorrent Logs", "\qBittorrent\logs", Folder.LocalAppData, DeepCleanList)
        AddItem("RED Engine Report Queue", "\REDEngine\ReportQueue", Folder.LocalAppData, DeepCleanList)
        AddItem("Rockstar Launcher Crash Logs", "\Rockstar Games\Launcher\CrashLogs", Folder.LocalAppData, DeepCleanList)
        AddItem("Steam HTML Cache", "\Steam\htmlcache\Cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Steam HTML Code Cache", "\Steam\htmlcache\Code Cache", Folder.LocalAppData, DeepCleanList)
        AddItem("Steam HTML Dawn Cache", "\Steam\htmlcache\DawnCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Steam HTML GPU Cache", "\Steam\htmlcache\GPUCache", Folder.LocalAppData, DeepCleanList)
        AddItem("Squirrel Temporary Files", "\SquirrelTemp", Folder.LocalAppData, DeepCleanList)
        AddItem("Uni Compact View Cache Files", "\UniCompactView", Folder.LocalAppData, DeepCleanList)
        AddItem("UniSDK Crash Dumps", "\UniSDK\CrashDump", Folder.LocalAppData, DeepCleanList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'DEEP CLEAN - LOCAL LOW APP DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Oculus Dash Logs", "\Oculus\Dash\log", Folder.LocalLowAppData, DeepCleanList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'DEEP CLEAN - ROAMING APP DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Adobe Flash Player Native Cache", "\Adobe\Flash Player\NativeCache", Folder.AppData, DeepCleanList)
        AddItem("AnyDesk Cache", "\AnyDesk\cache", Folder.AppData, DeepCleanList)
        AddItem("Audacity Last Log", "\audacity", Folder.AppData, DeepCleanList, False, "lastlog.txt")
        AddItem("Quixel Bridge Plugin Log", "\Bridge-Bifrost", Folder.AppData, DeepCleanList, False, "*.log")
        AddItem("Discord Cache", "\discord\Cache", Folder.AppData, DeepCleanList)
        AddItem("Discord Crashpad Files", "\discord\Crashpad", Folder.AppData, DeepCleanList)
        AddItem("Discord Code Cache", "\discord\Code Cache", Folder.AppData, DeepCleanList)
        AddItem("Discord Dawn Cache", "\discord\DawnCache", Folder.AppData, DeepCleanList)
        AddItem("Discord Dawn Graphite Cache", "\discord\DawnGraphiteCache", Folder.AppData, DeepCleanList)
        AddItem("Discord Dawn WebGPU Cache", "\discord\DawnWebGPUCache", Folder.AppData, DeepCleanList)
        AddItem("Discord GPU Cache", "\discord\GPUCache", Folder.AppData, DeepCleanList)
        AddItem("Discord Logs", "\discord\logs", Folder.AppData, DeepCleanList)
        AddItem("EasyAntiCheat Logs", "\EasyAntiCheat", Folder.AppData, DeepCleanList, True, "*.log")
        AddItem("GIMP 2.10 Temporary Files", "\GIMP\2.10\tmp", Folder.AppData, DeepCleanList)
        AddItem("Github Desktop Cache", "\GitHub Desktop\Cache", Folder.AppData, DeepCleanList)
        AddItem("Github Desktop Code Cache", "\GitHub Desktop\Code Cache", Folder.AppData, DeepCleanList)
        AddItem("Github Desktop Dawn Cache", "\GitHub Desktop\DawnCache", Folder.AppData, DeepCleanList)
        AddItem("Github Desktop GPU Cache", "\GitHub Desktop\GPUCache", Folder.AppData, DeepCleanList)
        AddItem("Github Desktop Logs", "\GitHub Desktop\logs", Folder.AppData, DeepCleanList)
        AddItem("LibreOffice Cache", "\LibreOffice\4\cache", Folder.AppData, DeepCleanList)
        AddItem("LibreOffice Crash Dumps", "\LibreOffice\4\crash", Folder.AppData, DeepCleanList)
        AddItem("OBS-Studio Crashes", "\obs-studio\crashes", Folder.AppData, DeepCleanList)
        AddItem("OBS-Studio Logs", "\obs-studio\logs", Folder.AppData, DeepCleanList)
        AddItem("Oculus Client Error Logs", "\Oculus", Folder.AppData, DeepCleanList, False, "*OculusClientError*.txt")
        AddItem("Oculus Logs", "\Oculus\logs", Folder.AppData, DeepCleanList)
        AddItem("Oculus Sessions", "\Oculus\sessions", Folder.AppData, DeepCleanList)
        AddItem("Oculus Client Cache", "\OculusClient\Cache", Folder.AppData, DeepCleanList)
        AddItem("Oculus Client GPU Cache", "\OculusClient\GPUCache", Folder.AppData, DeepCleanList)
        AddItem("VLC Player Crash Dumps", "\vlc\crashdump", Folder.AppData, DeepCleanList)
        AddItem("Xemu Shader Cache", "\xemu\xemu\shaders", Folder.AppData, DeepCleanList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'DEEP CLEAN - PROGRAM DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("AnyDesk Common Cache", "\AnyDesk\cache", Folder.CommonAppData, DeepCleanList)
        AddItem("AnyDesk Connections Trace File", "\AnyDesk", Folder.CommonAppData, DeepCleanList, False, "connection_trace.txt")
        AddItem("AnyDesk Service Trace File", "\AnyDesk", Folder.CommonAppData, DeepCleanList, False, "ad_svc.trace")
        AddItem("ASUS Update Logs", "\ASUS\SCD", Folder.CommonAppData, DeepCleanList, False, "*.*")
        AddItem("Battle.net Agent Logs", "\Battle.net\Agent\Logs", Folder.CommonAppData, DeepCleanList)
        AddItem("Battle.net Setup Logs", "\Battle.net\Setup\bna_2\Logs", Folder.CommonAppData, DeepCleanList)
        AddItem("Battle.net Uninstaller Logs", "\Battle.net\Uninstaller\Logs", Folder.CommonAppData, DeepCleanList)
        AddItem("Battle.net Helper Service Logs", "\Battle.net_components\battlenet_helpersvc\Logs", Folder.CommonAppData, DeepCleanList)
        AddItem("Battle.net Common Cache", "\Blizzard Entertainment\Battle.net\Cache", Folder.CommonAppData, DeepCleanList)
        AddItem("Corsair ICUE 5 Update Logs", "\Corsair", Folder.CommonAppData, DeepCleanList, True, "*.log")
        AddItem("Electronic Arts App Common Logs", "\EA Desktop\Logs", Folder.CommonAppData, DeepCleanList)
        AddItem("Epic Games Launcher Content Cache", "\Epic\EpicGamesLauncher\Data\ContentCache", Folder.CommonAppData, DeepCleanList)
        AddItem("Epic Games Launcher Vault Cache", "\Epic\EpicGamesLauncher\VaultCache", Folder.CommonAppData, DeepCleanList)
        AddItem("Epic Online Services Installer Logs", "\Epic\EpicOnlineServices\EOSInstaller\Logs", Folder.CommonAppData, DeepCleanList)
        AddItem("Epic Online Services Host Common Logs", "\Epic\EpicOnlineServices\EpicOnlineServicesHost\Logs", Folder.CommonAppData, DeepCleanList)
        AddItem("Epic Online Services Install Helper Crash Dumps", "\Epic\EpicOnlineServices\InstallHelper\Saved\Crashes", Folder.CommonAppData, DeepCleanList)
        AddItem("Epic Online Services Install Helper Logs", "\Epic\EpicOnlineServices\InstallHelper\Saved\Logs", Folder.CommonAppData, DeepCleanList)
        AddItem("Epic Online Services Main Service Crash Dumps", "\Epic\EpicOnlineServices\MainService\Crashes", Folder.CommonAppData, DeepCleanList)
        AddItem("Epic Online Services Main Service Logs", "\Epic\EpicOnlineServices\MainService\Logs", Folder.CommonAppData, DeepCleanList)
        AddItem("GOG Galaxy Crash Dumps", "\GOG.com\Galaxy\crashdumps", Folder.CommonAppData, DeepCleanList)
        AddItem("GOG Galaxy Logs", "\GOG.com\Galaxy\logs", Folder.CommonAppData, DeepCleanList)
        AddItem("GOG Galaxy Web Cache", "\GOG.com\Galaxy\webcache", Folder.CommonAppData, DeepCleanList)
        AddItem("OBS-Studio Shader Cache", "\obs-studio\shader-cache", Folder.CommonAppData, DeepCleanList)
        AddItem("Oculus Performance Analyzer Trace Files", "\Oculus", Folder.CommonAppData, DeepCleanList, False, "*.etl")
        AddItem("Razer Installer Logs", "\Razer\Installer\Logs", Folder.CommonAppData, DeepCleanList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'DEEP CLEAN - DOCUMENTS
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Adobe Photoshop Logs", "\Adobe", Folder.Documents, DeepCleanList, False, "*.log")
        AddItem("Rockstar Games Social Club Logs", "\Rockstar Games\Social Club", Folder.Documents, DeepCleanList, False, "*.log")
        AddItem("Rockstar Games Social Club Cache", "\Rockstar Games\Social Club\Cache", Folder.Documents, DeepCleanList)
        AddItem("Rockstar Games Social Club Renderer Cache", "\Rockstar Games\Social Club\Renderer\Cache", Folder.Documents, DeepCleanList)
        AddItem("Rockstar Games Social Club Renderer Code Cache", "\Rockstar Games\Social Club\Renderer\Code Cache", Folder.Documents, DeepCleanList)
        AddItem("Rockstar Games Social Club Renderer Dawn Cache", "\Rockstar Games\Social Club\Renderer\DawnCache", Folder.Documents, DeepCleanList)
        AddItem("Rockstar Games Social Club Renderer GPU Cache", "\Rockstar Games\Social Club\Renderer\GPUCache", Folder.Documents, DeepCleanList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'JUNKWARE - PROGRAM DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("MNTemp", "\", Folder.CommonAppData, JunkwareList, False, "mntemp")

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'GAMES - LOCAL APP DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddUnrealEngineGame("Black Myth: Wukong", "b1")
        AddUnrealEngineGame("Baisu", "Baisu")
        AddItem("Baisu Generated Voice Files", "\Baisu\Saved\BouncedWavFiles", Folder.LocalAppData, GamesList)
        AddItem("Baisu Photos", "\Baisu\Saved\SaveGames\photos", Folder.LocalAppData, GamesList)
        AddItem("Baisu Thumbnails", "\Baisu\Saved\SaveGames\thumbs", Folder.LocalAppData, GamesList)
        AddItem("Call of Duty Crash Reports", "\Activision\Call of Duty\crash_reports", Folder.LocalAppData, GamesList)
        AddItem("Cyberpunk 2077 Crash Report", "\CD Projekt Red\Cyberpunk 2077", Folder.LocalAppData, GamesList, False, "CrashInfo.json")
        AddUnrealEngineGame("Cygni", "Cygni")
        AddUnrealEngineGame("The Finals", "Discovery")
        AddUnrealEngineGame("Drug Dealer Simulator", "DrugDealerSimulator")
        AddUnrealEngineGame("Drug Dealer Simulator 2", "DrugDealerSimulator2")
        AddItem("Drug Dealer Simulator 2 Settings", "\DrugDealerSimulator2\Saved\SaveGames", Folder.LocalAppData, GamesList, False, "UserSettings.sav")
        AddItem("FLiNG Trainer Files", "\FLiNGTrainer", Folder.LocalAppData, GamesList)
        AddUnrealEngineGame("Fortnite", "FortniteGame")
        AddItem("Fortnite Demos", "\FortniteGame\Saved\Demos", Folder.LocalAppData, GamesList)
        AddItem("Fortnite Download Cache", "\FortniteGame\Saved\PersistentDownloadDir", Folder.LocalAppData, GamesList)
        AddUnrealEngineGame("Sackboy", "Gingerbread")
        AddUnrealEngineGame("Still Wakes The Deep", "Habitat")
        AddUnrealEngineGame("Senua's Saga: Hellblade 2", "Hellblade2")
        AddUnrealEngineGame("Stray", "hk_project")
        AddUnrealEngineGame("Hogwarts Legacy", "Hogwarts Legacy")
        AddItem("DOOM Eternal File Cache", "\id Software\DOOMEternal\fileCache", Folder.LocalAppData, GamesList)
        AddItem("DOOM Eternal Temporary Files", "\id Software\DOOMEternal\generated\temp", Folder.LocalAppData, GamesList)
        AddUnrealEngineGame("It Takes Two", "ItTakesTwo")
        AddUnrealEngineGame("Hydroneer", "Mining")
        AddItem("Dark Souls: Prepare To Die Settings", "\NBGI\DarkSouls", Folder.LocalAppData, GamesList)
        AddItem("Dark Souls Remastered Settings", "\FromSoftware\NBGI\DarkSouls", Folder.LocalAppData, GamesList)
        AddItem("Forza Horizon 5 Shader Cache", "\Packages\Microsoft.624F8B84B80_8wekyb3d8bbwe\LocalCache", Folder.LocalAppData, GamesList)
        AddItem("Forza Horizon 5 Settings", "\Packages\Microsoft.624F8B84B80_8wekyb3d8bbwe\Settings", Folder.LocalAppData, GamesList)
        AddUnrealEngineGame("Palworld", "Pal")
        AddUnrealEngineGame("Poppy Playtime Chapter 3", "Playtime_Chapter3")
        AddItem("Poppy Playtime Launcher Logs", "\PlaytimeLauncher\Saved\Logs", Folder.LocalAppData, GamesList)
        AddItem("Alan Wake 2 Cache", "\Remedy\AlanWake2\cache", Folder.LocalAppData, GamesList)
        AddItem("Red Dead Redemption 2 Logs", "\Rockstar Games\Red Dead Redemption 2\CrashLogs", Folder.LocalAppData, GamesList)
        AddItem("Ryujinx Game Shader Data File", "\Ryujinx\games", Folder.LocalAppData, GamesList, True, "*.data")
        AddItem("Ryujinx Game Shader Table-Of-Contents", "\Ryujinx\games", Folder.LocalAppData, GamesList, True, "*.toc")
        AddUnrealEngineGame("Silent Hill 2", "SilentHill2")
        AddItem("Space Marines 2 Client Crash Dumps", "\Saber\Space Marine 2\client\crashes", Folder.LocalAppData, GamesList)
        AddItem("Space Marines 2 Client GPU Crash Dumps", "\Saber\Space Marine 2\client\gpu_crashdump", Folder.LocalAppData, GamesList)
        AddItem("Space Marines 2 Client Shader Cache", "\Saber\Space Marine 2\client\local_shader_cache", Folder.LocalAppData, GamesList)
        AddItem("Space Marines 2 Client Event Collector", "\Saber\Space Marine 2\client\prof_event_collector", Folder.LocalAppData, GamesList)
        AddItem("Space Marines 2 Server Crash Dumps", "\Saber\Space Marine 2\server\crashes", Folder.LocalAppData, GamesList)
        AddItem("Space Marines 2 Settings", "\Saber\Space Marine 2\storage", Folder.LocalAppData, GamesList, True, "*.cfg")
        AddItem("Split Fiction Local Settings", "\SplitFiction", Folder.LocalAppData, GamesList, False, "LocalSettings.Split")
        AddItem("Split Fiction Settings", "\SplitFiction", Folder.LocalAppData, GamesList, False, "Settings.Split")
        AddItem("Split Fiction Startup Info", "\SplitFiction", Folder.LocalAppData, GamesList, False, "StartupInfo.Split")
        AddItem("Final Fantasy XVI Demo Shader Cache", "\SquareEnix\FINAL FANTASY XVI DEMO", Folder.LocalAppData, GamesList, False, "*.psol")
        AddItem("Final Fantasy XVI Shader Cache", "\SquareEnix\FINAL FANTASY XVI", Folder.LocalAppData, GamesList, False, "*.psol")
        AddItem("Starfield Shader Cache", "\Starfield", Folder.LocalAppData, GamesList, False, "*.cache")
        AddItem("The Evil Within 2 Shader Cache", "\TangoGameworks\The Evil Within 2", Folder.LocalAppData, GamesList, False, "*.bin")
        AddUnrealEngineGame("The Ascent", "TheAscent")
        AddItem("zDOOM Pipeline Cache", "\zdoom\cache", Folder.LocalAppData, GamesList, False, "*.zdpc")

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'GAMES - LOCAL LOW APP DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("The Stanley Parable Ultra Deluxe Logs", "Low\Crows Crows Crows\The Stanley Parable_ Ultra Deluxe", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("Little Kitty, Big City Logs", "Low\Double Dagger Studio\Little Kitty, Big City", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("Little Kitty, Big City Settings", "Low\Double Dagger Studio\Little Kitty, Big City", Folder.LocalLowAppData, GamesList, False, "PlayerSettings.es3")
        AddItem("Anger Foot Logs", "Low\Free Lives\Anger Foot", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("House Flipper 2 Logs", "Low\Frozen District\House Flipper 2", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("Dinkum Logs", "Low\James Bendon\Dinkum", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("Fall Guys Logs", "Low\Mediatonic\FallGuys_client", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("Farm Together 2 Logs", "Low\Milkstone Studios\FarmTogether2", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("Arcade Paradise Logs", "Low\Nosebleed Interactive\Arcade Paradise", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("Biped Crash Dumps", "Low\PostmetaGamesLimited\Biped\Crashes", Folder.LocalLowAppData, GamesList)
        AddItem("Go-Go Town! Logs", "Low\Prideful Sloth\Go-Go Town!", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("Wobbly Life Logs", "Low\RubberBandGames\Wobbly Life", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("Crow Country Logs", "Low\SFB Games\Crow Country", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("Cat Quest 2 Logs", "Low\The Gentlebros Pte. Ltd_\Cat Quest II", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("Cat Quest 3 Logs", "Low\The Gentlebros Pte. Ltd_\Cat Quest III", Folder.LocalLowAppData, GamesList, False, "*.log")
        AddItem("The Outsiders Logs", "Low\TheOutsiders\Metal", Folder.LocalLowAppData, GamesList, False, "*.log")

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'GAMES - ROAMING APP DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Armored Core VI: Fires of Rubicon Settings", "\ArmoredCore6", Folder.AppData, GamesList, False, "GraphicsConfig.xml")
        AddItem("Once Human Logs", "\CC\logs\playersdk", Folder.AppData, GamesList, False, "*.log")
        AddItem("Dark Souls II Settings", "\DarkSoulsII", Folder.AppData, GamesList, False, "GraphicsConfig.xml")
        AddItem("Dark Souls II: Scholar of the First Sin Settings", "\DarkSoulsII", Folder.AppData, GamesList, False, "GraphicsConfig_SOFS.xml")
        AddItem("Dark Souls III Settings", "\DarkSoulsIII", Folder.AppData, GamesList, False, "GraphicsConfig.xml")
        AddItem("Elden Ring Settings", "\EldenRing", Folder.AppData, GamesList, False, "GraphicsConfig.xml")
        AddItem("Spider-Man Miles Morales Shader Cache", "\Insomniac Games\Marvel's Spider-Man Miles Morales", Folder.AppData, GamesList, False, "*.pso")
        AddItem("Sekiro: Shadows Die Twice Settings", "\Sekiro", Folder.AppData, GamesList, False, "GraphicsConfig.xml")
        AddItem("LEGO City Undercover Shader Cache", "\Warner Bros. Interactive Entertainment\LEGO City Undercover\CachedShaders", Folder.AppData, GamesList)
        AddItem("LEGO DC Super-Villains Shader Cache", "\Warner Bros. Interactive Entertainment\LEGO DC Super-villains\CACHEDSHADERS", Folder.AppData, GamesList)

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'GAMES - DOCUMENTS
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Generation Zero Shader Cache", "\Avalanche Studios\GenerationZero\Cache", Folder.Documents, GamesList)
        AddItem("Cat Quest 3 Crash Dumps", "\Cat Quest III\Crashes", Folder.Documents, GamesList)
        AddItem("Cyberpunk 2077 Benchmark Results", "\CD Projekt Red\Cyberpunk 2077\benchmarkResults", Folder.Documents, GamesList)
        AddItem("Dead Space Shader Cache", "\Dead Space (2023)\cache", Folder.Documents, GamesList)
        AddItem("Dead Space Crash Dumps", "\Dead Space (2023)\CrashDumps", Folder.Documents, GamesList)
        AddItem("Dead Space Screenshots", "\Dead Space (2023)\Screenshots", Folder.Documents, GamesList)
        AddItem("DuckStation Cache", "\DuckStation\cache", Folder.Documents, GamesList)
        AddItem("Die Sims 4 Custom Music", "\Electronic Arts\Die Sims 4\Custom Music", Folder.Documents, GamesList)
        AddItem("Die Sims 4 Online Thumbnail Cache", "\Electronic Arts\Die Sims 4\onlinethumbnailcache", Folder.Documents, GamesList)
        AddItem("Die Sims 4 Screenshots", "\Electronic Arts\Die Sims 4\Screenshots", Folder.Documents, GamesList)
        AddItem("Grand Theft Auto: San Andreas Screenshots", "\GTA San Andreas User Files\Gallery", Folder.Documents, GamesList)
        AddItem("Grand Theft Auto: San Andreas Custom Music", "\GTA San Andreas User Files\User Tracks", Folder.Documents, GamesList)
        AddItem("Immortals Fenyx Rising Cache", "\Immortals Fenyx Rising\cache", Folder.Documents, GamesList)
        AddItem("Divinity Original Sin 2 Level Cache", "\Larian Studios\Divinity Original Sin 2 Definitive Edition\LevelCache", Folder.Documents, GamesList)
        AddItem("Divinity Original Sin 2 Temporary Files", "\Larian Studios\Divinity Original Sin 2 Definitive Edition\Temp", Folder.Documents, GamesList)
        AddItem("Spider-Man Miles Morales Logs", "\Marvel's Spider-Man Miles Morales", Folder.Documents, GamesList, False, "*.log")
        AddItem("Spider-Man Miles Morales Memory Dumps", "\Marvel's Spider-Man Miles Morales", Folder.Documents, GamesList, False, "*.mdmp")
        AddItem("Spider-Man Miles Morales Screenshots", "\Marvel's Spider-Man Miles Morales\Screenshots", Folder.Documents, GamesList)
        AddItem("Mirrors Edge Catalyst Screenshots", "\Mirrors Edge Catalyst\Screenshots", Folder.Documents, GamesList)
        AddItem("A Plague Tale Requiem Shader Cache", "\My Games\A Plague Tale Requiem\cache", Folder.Documents, GamesList, True, "*.psocache")
        AddItem("Borderlands 3 Benchmark Results", "\My Games\Borderlands 3\Saved\BenchmarkData", Folder.Documents, GamesList)
        AddItem("Borderlands 3 Logs", "\My Games\Borderlands 3\Saved\Logs", Folder.Documents, GamesList)
        AddItem("Borderlands GOTY Launcher Logs", "\My Games\Borderlands Game of the Year\Launcher\Logs", Folder.Documents, GamesList)
        AddItem("Borderlands GOTY Logs", "\My Games\Borderlands Game of the Year\WillowGame\Logs", Folder.Documents, GamesList)
        AddItem("Borderlands GOTY Download Cache", "\My Games\Borderlands Game of the Year\WillowGame\PersistentDownloadDir", Folder.Documents, GamesList)
        AddItem("Borderlands The Pre-Sequel Launcher Logs", "\My Games\Borderlands The Pre-Sequel\Launcher\Logs", Folder.Documents, GamesList)
        AddItem("Borderlands The Pre-Sequel Logs", "\My Games\Borderlands The Pre-Sequel\WillowGame\Logs", Folder.Documents, GamesList)
        AddItem("Borderlands The Pre-Sequel Download Cache", "\My Games\Borderlands The Pre-Sequel\WillowGame\PersistentDownloadDir", Folder.Documents, GamesList)
        AddItem("Fallout 4 Script Extender Logs", "\My Games\Fallout4\F4SE", Folder.Documents, GamesList, True, "*.log")
        AddItem("Fallout 4 Logs", "\My Games\Fallout4\Logs", Folder.Documents, GamesList, True, "*.log")
        AddItem("Final Fantasy VXI Demo Screenshots", "\My Games\FINAL FANTASY XVI DEMO\Screenshots", Folder.Documents, GamesList)
        AddItem("Final Fantasy VXI Screenshots", "\My Games\FINAL FANTASY XVI\Screenshots", Folder.Documents, GamesList)
        AddItem("Starfield Screenshots", "\My Games\Starfield\Data\Textures\Photos", Folder.Documents, GamesList)
        AddItem("Starfield Script Extender Logs", "\My Games\Starfield\SFSE\Logs", Folder.Documents, GamesList)
        AddItem("The Division 2 Shader Byte Code", "\My Games\Tom Clancy's The Division 2\ShaderByteCode", Folder.Documents, GamesList)
        AddItem("The Division 2 Shader Cache", "\My Games\Tom Clancy's The Division 2\ShaderCache", Folder.Documents, GamesList)
        AddItem("The Division 2 Analytics Data", "\My Games\Tom Clancy's The Division 2", Folder.Documents, GamesList, False, "*_cicerodata")
        AddItem("Ratchet & Clank - Rift Apart Logs", "\Ratchet & Clank - Rift Apart", Folder.Documents, GamesList, False, "*.log")
        AddItem("Ratchet & Clank - Rift Apart Memory Dumps", "\Ratchet & Clank - Rift Apart", Folder.Documents, GamesList, False, "*.mdmp")
        AddItem("Ratchet & Clank - Rift Apart Screenshots", "\Ratchet & Clank - Rift Apart\Screenshots", Folder.Documents, GamesList)
        AddItem("Red Dead Redemption 2 Shader Cache", "\Rockstar Games\Red Dead Redemption 2\Settings", Folder.Documents, GamesList, False, "sga_*")
        AddItem("The Sims 4 Custom Music", "\Electronic Arts\The Sims 4\Custom Music", Folder.Documents, GamesList)
        AddItem("The Sims 4 Online Thumbnail Cache", "\Electronic Arts\The Sims 4\onlinethumbnailcache", Folder.Documents, GamesList)
        AddItem("The Sims 4 Screenshots", "\Electronic Arts\The Sims 4\Screenshots", Folder.Documents, GamesList)
        AddItem("Teenage Mutant Ninja Turtles Log", "\Tribute Games\TMNT", Folder.Documents, GamesList, False, "log.txt")

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'SAVEGAMES - LOCAL APP DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Baisu Savegames", "\Baisu\Saved\SaveGames", Folder.LocalAppData, SavegamesList, False, "*.sav")
        AddItem("Cygni Savegames", "\Cygni\Saved\SaveGames", Folder.LocalAppData, SavegamesList)
        AddItem("Drug Dealer Simulator Savegames", "\DrugDealerSimulator\Saved\SaveGames", Folder.LocalAppData, SavegamesList)
        If Directory.Exists(LocalAppDataFolder & "\DrugDealerSimulator2\Saved\SaveGames\Cartels") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(LocalAppDataFolder & "\DrugDealerSimulator2\Saved\SaveGames\Cartels")
                Dim ProfileID As String = ProfileDirectory.Replace(LocalAppDataFolder & "\DrugDealerSimulator2\Saved\SaveGames\Cartels\", "")
                AddItem("Drug Dealer Simulator 2 Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList)
                AddItem("Drug Dealer Simulator 2 Backups [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList, False, "*_backup_day*")
            Next
        End If
        AddItem("Sackboy Savegames", "\Gingerbread\Saved\SaveGames", Folder.LocalAppData, SavegamesList)
        AddItem("Still Wakes The Deep Savegames", "\Habitat\Saved\SaveGames", Folder.LocalAppData, SavegamesList)
        If Directory.Exists(LocalAppDataFolder & "\Hellblade2\Saved\SaveGames") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(LocalAppDataFolder & "\Hellblade2\Saved\SaveGames")
                Dim ProfileID As String = ProfileDirectory.Replace(LocalAppDataFolder & "\Hellblade2\Saved\SaveGames\", "").Replace("_", " ")
                AddItem("Senua's Saga: Hellblade 2 Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList, False, "*.sav")
            Next
        End If
        AddItem("Hogwarts Legacy Savegames", "\Hogwarts Legacy\Saved\SaveGames", Folder.LocalAppData, SavegamesList)
        If Directory.Exists(LocalAppDataFolder & "\Hk_project\Saved\SaveGames\Slots") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(LocalAppDataFolder & "\Hk_project\Saved\SaveGames\Slots")
                Dim ProfileID As String = ProfileDirectory.Replace(LocalAppDataFolder & "\Hk_project\Saved\SaveGames\Slots\", "").Replace("_", " ")
                AddItem("Stray Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList, False, "*.sav")
            Next
        End If
        AddItem("It Takes Two Savegame", "\ItTakesTwo", Folder.LocalAppData, SavegamesList, False, "SaveData.Nuts")
        If Directory.Exists(LocalAppDataFolder & "\Mining\Saved\SaveGames") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(LocalAppDataFolder & "\Mining\Saved\SaveGames")
                Dim ProfileID As String = ProfileDirectory.Replace(LocalAppDataFolder & "\Mining\Saved\SaveGames\", "")
                If ProfileID.Contains("_backup_1") Then
                    AddItem("Hydroneer Backup [" & ProfileID.Replace("_backup_1", "") & "]", ProfileDirectory, Folder.None, SavegamesList)
                Else
                    AddItem("Hydroneer Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList)
                End If
            Next
        End If
        AddItem("Forza Horizon 5 Savegame", "\Packages\Microsoft.624F8B84B80_8wekyb3d8bbwe\SystemAppData", Folder.LocalAppData, SavegamesList)
        If Directory.Exists(LocalAppDataFolder & "\Pal\Saved\SaveGames") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(LocalAppDataFolder & "\Pal\Saved\SaveGames")
                Dim ProfileID As String = ProfileDirectory.Replace(LocalAppDataFolder & "\Pal\Saved\SaveGames\", "")
                For Each InstanceDirectory As String In Directory.GetDirectories(ProfileDirectory)
                    AddItem("Palworld Backups [" & ProfileID & "]", InstanceDirectory & "\backup", Folder.None, SavegamesList)
                Next
            Next
        End If
        AddItem("Poppy Playtime Chapter 3 Savegame", "\Playtime_Chapter3\Saved\SaveGames", Folder.LocalAppData, SavegamesList, False, "*.sav")
        If Directory.Exists(LocalAppDataFolder & "\Remedy\AlanWake2") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(LocalAppDataFolder & "\Remedy\AlanWake2")
                If Not ProfileDirectory.EndsWith("cache") Then
                    AddItem("Alan Wake 2 Savegames", ProfileDirectory, Folder.None, SavegamesList)
                End If
            Next
        End If
        If Directory.Exists(LocalAppDataFolder & "\SilentHill2\Saved\SaveGames") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(LocalAppDataFolder & "\SilentHill2\Saved\SaveGames")
                Dim ProfileID As String = ProfileDirectory.Replace(LocalAppDataFolder & "\SilentHill2\Saved\SaveGames\", "").Replace("_", " ")
                AddItem("Silent Hill 2 Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList, False, "*.sav")
            Next
        End If
        AddItem("Split Fiction Savegame", "\SplitFiction", Folder.LocalAppData, SavegamesList, False, "SaveData.Split")
        AddItem("The Ascent Savegames", "\TheAscent\Saved\SaveGames", Folder.LocalAppData, SavegamesList, False, "SaveProfiles.sav")
        AddItem("The Ascent Backup", "\TheAscent\Saved\SaveGames", Folder.LocalAppData, SavegamesList, False, "SaveProfiles_Backup.sav")

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'SAVEGAMES - LOCAL LOW APP DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("The Stanley Parable Ultra Deluxe Savegame", "\Crows Crows Crows\The Stanley Parable_ Ultra Deluxe", Folder.LocalLowAppData, SavegamesList, False, "tspud-savedata.txt")
        AddItem("Little Kitty, Big City Savegames", "\Double Dagger Studio\Little Kitty, Big City", Folder.LocalLowAppData, SavegamesList, False, "SaveFile*")
        If Directory.Exists(LocalAppDataFolder & "Low\Endnight\SonsOfTheForest\Saves") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(LocalAppDataFolder & "Low\Endnight\SonsOfTheForest\Saves")
                Dim ProfileID As String = ProfileDirectory.Replace(LocalAppDataFolder & "Low\Endnight\SonsOfTheForest\Saves\", "")
                AddItem("Sons Of The Forest Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList)
            Next
        End If
        AddItem("Anger Foot Savegames", "\Free Lives\Anger Foot\Saves", Folder.LocalLowAppData, SavegamesList, False, "*.json")
        AddItem("House Flipper 2 Backups", "\Frozen District\House Flipper 2", Folder.LocalLowAppData, SavegamesList, False, "*.*backup*")
        If Directory.Exists(LocalAppDataFolder & "Low\Frozen District\House Flipper 2\Profiles") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(LocalAppDataFolder & "Low\Frozen District\House Flipper 2\Profiles")
                Dim ProfileID As String = ProfileDirectory.Replace(LocalAppDataFolder & "Low\Frozen District\House Flipper 2\Profiles\", "")
                If Not ProfileID = "Unity" Then AddItem("House Flipper 2 Savegame [Slot " & (CInt(ProfileID) + 1).ToString & "]", ProfileDirectory, Folder.None, SavegamesList)
            Next
        End If
        AddItem("Farm Together 2 Backups", "\Milkstone Studios\FarmTogether2\Backup", Folder.LocalLowAppData, SavegamesList)
        AddItem("Untitled Goose Game Savegames", "\House House\Untitled Goose Game", Folder.LocalLowAppData, SavegamesList, False, "*.save")
        If Directory.Exists(LocalAppDataFolder & "Low\James Bendon\Dinkum") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(LocalAppDataFolder & "Low\James Bendon\Dinkum")
                Dim ProfileID As String = ProfileDirectory.Replace(LocalAppDataFolder & "Low\James Bendon\Dinkum\", "").Replace("Slot", "")
                If Not ProfileID = "Unity" Then AddItem("Dinkum Savegame [Slot " & (CInt(ProfileID) + 1).ToString & "]", ProfileDirectory, Folder.None, SavegamesList)
            Next
        End If
        AddItem("Phasmophobia Savegames", "\Kinetic Games\Phasmophobia", Folder.LocalLowAppData, SavegamesList, False, "Save*.txt")
        AddItem("Travellers Rest Savegames", "\Louqou\TravellersRest\GameSaves", Folder.LocalLowAppData, SavegamesList, False, "*.save")
        AddItem("Arcade Paradise Savegame", "\Nosebleed Interactive\Arcade Paradise\Epic", Folder.LocalLowAppData, SavegamesList, False, "RATSaveData.dat")

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'SAVEGAMES - ROAMING APP DATA
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        If Directory.Exists(AppDataFolder & "\ArmoredCore6") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(AppDataFolder & "\ArmoredCore6")
                Dim ProfileID As String = ProfileDirectory.Replace(AppDataFolder & "\ArmoredCore6\", "")
                AddItem("Armored Core VI: Fires of Rubicon Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList, False, "AC6*.sl2")
            Next
        End If
        If Directory.Exists(AppDataFolder & "\DarkSoulsII") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(AppDataFolder & "\DarkSoulsII")
                Dim ProfileID As String = ProfileDirectory.Replace(AppDataFolder & "\DarkSoulsII\", "")
                AddItem("Dark Souls II Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList, False, "DARKSII*.sl2")
                AddItem("Dark Souls II: Scholar of the First Sin Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList, False, "DS2SOFS*.sl2")
            Next
        End If
        If Directory.Exists(AppDataFolder & "\DarkSoulsIII") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(AppDataFolder & "\DarkSoulsIII")
                Dim ProfileID As String = ProfileDirectory.Replace(AppDataFolder & "\DarkSoulsIII\", "")
                AddItem("Dark Souls III Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList, False, "DS3*.sl2")
            Next
        End If
        If Directory.Exists(AppDataFolder & "\EldenRing") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(AppDataFolder & "\EldenRing")
                Dim ProfileID As String = ProfileDirectory.Replace(AppDataFolder & "\EldenRing\", "")
                AddItem("Elden Ring Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList, False)
            Next
        End If
        If Directory.Exists(AppDataFolder & "\Sekiro") Then
            For Each ProfileDirectory As String In Directory.GetDirectories(AppDataFolder & "\Sekiro")
                Dim ProfileID As String = ProfileDirectory.Replace(AppDataFolder & "\Sekiro\", "")
                AddItem("Sekiro: Shadows Die Twice Savegame [" & ProfileID & "]", ProfileDirectory, Folder.None, SavegamesList, False, "S*.sl2")
            Next
        End If

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'SAVEGAMES - DOCUMENTS
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Cat Quest 2 Backups", "\Cat Quest II", Folder.Documents, SavegamesList, False, "*.bak")
        AddItem("Cat Quest 3 Backups", "\Cat Quest III", Folder.Documents, SavegamesList, False, "*.bak")
        AddItem("Spider-Man Miles Morales Backups", "\Marvel's Spider-Man Miles Morales", Folder.Documents, SavegamesList, True, "*.backup*")
        AddItem("Ratchet & Clank - Rift Apart Backups", "\Ratchet & Clank - Rift Apart", Folder.Documents, SavegamesList, True, "*.backup*")
        AddItem("Red Dead Redemption 2 Backups", "\Rockstar Games\Red Dead Redemption 2\Profiles", Folder.Documents, SavegamesList, True, "*.bak")

        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        'SAVEGAMES - CURRENT USER
        '####################################################################################################################################################################################################################################################################################################################################################
        '####################################################################################################################################################################################################################################################################################################################################################
        AddItem("Dark Souls: Prepare To Die Savegames", "\Documents\NBGI\DarkSouls", Folder.CurrentUser, SavegamesList)
        AddItem("Dark Souls Remastered Savegames", "\Documents\NBGI\DARK SOULS REMASTERED", Folder.CurrentUser, SavegamesList)

        '#########################################################################################################################################################
        '#########################################################################################################################################################
        'UNREAL ENGINE - LOCAL APP DATA
        '#########################################################################################################################################################
        '#########################################################################################################################################################
        AddItem("Unreal BuildTool Logs", "\UnrealBuildTool", Folder.LocalAppData, UnrealEngineList)
        For i = 4 To 6
            For i2 = 0 To 30
                AddItem("Unreal Engine %VER% Derived Data Cache".Replace("%VER%", i.ToString & "." & i2.ToString), "\UnrealEngine\%VER%\DerivedDataCache".Replace("%VER%", i.ToString & "." & i2.ToString), Folder.LocalAppData, UnrealEngineList)
                AddItem("Unreal Engine %VER% Intermediate Cache".Replace("%VER%", i.ToString & "." & i2.ToString), "\UnrealEngine\%VER%\Intermediate".Replace("%VER%", i.ToString & "." & i2.ToString), Folder.LocalAppData, UnrealEngineList)
                AddItem("Unreal Engine %VER% Crash Reports".Replace("%VER%", i.ToString & "." & i2.ToString), "\UnrealEngine\%VER%\Saved\crash-reports".Replace("%VER%", i.ToString & "." & i2.ToString), Folder.LocalAppData, UnrealEngineList)
                AddItem("Unreal Engine %VER% Logs".Replace("%VER%", i.ToString & "." & i2.ToString), "\UnrealEngine\%VER%\Saved\Logs".Replace("%VER%", i.ToString & "." & i2.ToString), Folder.LocalAppData, UnrealEngineList)
                AddItem("Unreal Engine %VER% Telemetry Data".Replace("%VER%", i.ToString & "." & i2.ToString), "\UnrealEngine\%VER%\Saved\Telemetry".Replace("%VER%", i.ToString & "." & i2.ToString), Folder.LocalAppData, UnrealEngineList)
            Next
        Next
        AddItem("Unreal Engine XML Config Cache", "\UnrealEngine", Folder.LocalAppData, UnrealEngineList, False, "*.bin")
        AddItem("Unreal Engine Analytics Data", "\UnrealEngine\Common\Analytics", Folder.LocalAppData, UnrealEngineList)
        AddItem("Unreal Engine Derived Data Cache", "\UnrealEngine\Common\DerivedDataCache", Folder.LocalAppData, UnrealEngineList)
        AddItem("Unreal Engine Trace Data", "\UnrealEngine\Common\UnrealTrace", Folder.LocalAppData, UnrealEngineList)
        AddItem("Unreal Engine Editor Layout Preferences", "\UnrealEngine\Editor", Folder.LocalAppData, UnrealEngineList)
        AddItem("Unreal Engine Intermediate Cache", "\UnrealEngine\Intermediate", Folder.LocalAppData, UnrealEngineList)
        AddItem("Unreal Engine Launcher Temporary Files", "\UnrealEngineLauncher\com", Folder.LocalAppData, UnrealEngineList, False, "*.tmp")
        AddItem("Unreal Engine AutomationTool Logs", "\Unreal Engine\AutomationTool\Logs", Folder.AppData, UnrealEngineList)

        SuperSecretEasterEgg()

        For Each Item As ListViewItem In WindowsList.Items
            Item.Checked = ListCheckedFilter(Item.Text)
            TotalSize += CLng(Item.SubItems(2).Text)
        Next

        For Each Item As ListViewItem In DeepCleanList.Items
            Item.Checked = ListCheckedFilter(Item.Text)
            TotalSize += CLng(Item.SubItems(2).Text)
        Next

        For Each Item As ListViewItem In JunkwareList.Items
            Item.Checked = True
            TotalSize += CLng(Item.SubItems(2).Text)
        Next

        For Each Item As ListViewItem In GamesList.Items
            Item.Checked = False
            TotalSize += CLng(Item.SubItems(2).Text)
        Next

        For Each Item As ListViewItem In SavegamesList.Items
            Item.Checked = False
            TotalSize += CLng(Item.SubItems(2).Text)
        Next

        For Each Item As ListViewItem In UnrealEngineList.Items
            Item.Checked = ListCheckedFilter(Item.Text)
            TotalSize += CLng(Item.SubItems(2).Text)
        Next

        If Language = "de" Then
            Text = "Datenträgerbereinigung X"
            TotalFreeLabel.Text = "Durch das Bereinigen des Datenträgers können bis zu %X% Speicherplatz freigegeben werden.".Replace("%X%", ConvertFolderSizeToSring(TotalSize))
            FilesToDeleteLabel.Text = "Zu löschende Dateien:"
            TotalAmountSavedDescriptionLabel.Text = "Speicherplatz der freigegeben wird:"
            QuitButton.Text = "Abbrechen"
            ShowFilesToolStripMenuItem.Text = "Dateien anzeigen..."
            MarkAllToolStripMenuItem.Text = "Alles markieren"
            CacheToolStripMenuItem.Text = "Zwischenspeicher"
            CrashDumpsToolStripMenuItem.Text = "Absturzabbilder"
            CrashReportsToolStripMenuItem.Text = "Absturzberichte"
            LogsToolStripMenuItem.Text = "Protokolldateien"
            TemporaryFilesToolStripMenuItem.Text = "Temporär"
            UnmarkAllToolStripMenuItem.Text = "Alles de-markieren"
            CacheToolStripMenuItem1.Text = CacheToolStripMenuItem.Text
            CrashDumpsToolStripMenuItem1.Text = CrashDumpsToolStripMenuItem.Text
            CrashReportsToolStripMenuItem1.Text = CrashReportsToolStripMenuItem.Text
            LogsToolStripMenuItem1.Text = LogsToolStripMenuItem.Text
            TemporaryFilesToolStripMenuItem1.Text = TemporaryFilesToolStripMenuItem.Text
            ResetToDefaultsToolStripMenuItem.Text = "Standard wiederherstellen"
            FinishingActionToolStripMenuItem.Text = "Abschlussaktion"
            CloseToolStripMenuItem.Text = "Beenden"
            RebootToolStripMenuItem.Text = "Neustarten"
            ShutdownToolStripMenuItem.Text = "Herunterfahren"
            PresetsToolStripMenuItem.Text = "Profile"
            DefaultToolStripMenuItem.Text = "Standard"
            ThoroughToolStripMenuItem.Text = "Gründlich"
            AggressiveToolStripMenuItem.Text = "Aggressiv"
            AllToolStripMenuItem.Text = "Alles"
            MainTabControl.TabPages(1).Text = "Tiefenreinigung"
            MainTabControl.TabPages(3).Text = "Spiele"
            MainTabControl.TabPages(4).Text = "Spielstände"
            'AdminModeLabel.Text = "ADMINISTRATOR MODUS"
        Else
            TotalFreeLabel.Text = "You can use Disk Cleanup X to free up to %X% of disk space.".Replace("%X%", ConvertFolderSizeToSring(TotalSize))
        End If

        For Each Argument As String In Environment.GetCommandLineArgs
            If Argument.Contains("-p:2") OrElse Argument.Contains("/p:2") OrElse Argument.Contains("--profile:2") Then
                Preset_Thorough()
            ElseIf Argument.Contains("-p:3") OrElse Argument.Contains("/p:3") OrElse Argument.Contains("--profile:3") Then
                Preset_Aggressive()
            ElseIf Argument.Contains("-p:4") OrElse Argument.Contains("/p:4") OrElse Argument.Contains("--profile:4") Then
                Preset_All()
            ElseIf Argument.Contains("-r") OrElse Argument.Contains("/r") OrElse Argument.Contains("--reboot") Then
                RebootToolStripMenuItem.Checked = True
                CloseToolStripMenuItem.Checked = False
                ShutdownToolStripMenuItem.Checked = False
            ElseIf Argument.Contains("-s") OrElse Argument.Contains("/s") OrElse Argument.Contains("--shutdown") Then
                ShutdownToolStripMenuItem.Checked = True
                CloseToolStripMenuItem.Checked = False
                RebootToolStripMenuItem.Checked = False
            End If
            If Not Argument.Contains("-m") OrElse Argument.Contains("/m") OrElse Not Argument.Contains("--minimal") Then
                SelectedFileCount = 0
                SelectedSize = 0
                For Each CheckedItem As ListViewItem In WindowsList.CheckedItems
                    SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
                    SelectedSize += CLng(CheckedItem.SubItems(2).Text)
                Next
                For Each CheckedItem As ListViewItem In DeepCleanList.CheckedItems
                    SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
                    SelectedSize += CLng(CheckedItem.SubItems(2).Text)
                Next
                For Each CheckedItem As ListViewItem In JunkwareList.CheckedItems
                    SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
                    SelectedSize += CLng(CheckedItem.SubItems(2).Text)
                Next
                For Each CheckedItem As ListViewItem In GamesList.CheckedItems
                    SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
                    SelectedSize += CLng(CheckedItem.SubItems(2).Text)
                Next
                For Each CheckedItem As ListViewItem In SavegamesList.CheckedItems
                    SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
                    SelectedSize += CLng(CheckedItem.SubItems(2).Text)
                Next
                For Each CheckedItem As ListViewItem In UnrealEngineList.CheckedItems
                    SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
                    SelectedSize += CLng(CheckedItem.SubItems(2).Text)
                Next
                FilesToDeleteValueLabel.Text = SelectedFileCount.ToString
                TotalAmountSavedValueLabel.Text = ConvertFolderSizeToSring(SelectedSize)

                AddHandler WindowsList.ItemChecked, AddressOf List_ItemChecked
                AddHandler DeepCleanList.ItemChecked, AddressOf List_ItemChecked
                AddHandler JunkwareList.ItemChecked, AddressOf List_ItemChecked
                AddHandler GamesList.ItemChecked, AddressOf List_ItemChecked
                AddHandler SavegamesList.ItemChecked, AddressOf List_ItemChecked
                AddHandler UnrealEngineList.ItemChecked, AddressOf List_ItemChecked

                ProgressDialog.Visible = False
                If Argument.Contains("-?") OrElse Argument.Contains("/?") OrElse Argument.Contains("--help") Then
                    Visible = False
                    HelpForm.ShowDialog()
                End If
                Visible = True
#If DEBUG Then
                MessageBox.Show("Calls to AddItemToList: " & Calls.ToString)
#End If
            Else
                ProgressDialog.Visible = False
                Start()
            End If
        Next
    End Sub
    Private Function GetFolderSize(Folder As String, Recursive As Boolean, SearchPattern As String) As Long
        Try
            Dim FileCount As Long = 0
            Dim FolderSize As Long = 0
            Dim FolderInfo = New DirectoryInfo(Folder)
            If Recursive Then
                For Each File In FolderInfo.GetFiles(SearchPattern, SearchOption.AllDirectories)
                    FileCount += 1
                    FolderSize += File.Length
                Next
                For Each SubFolderInfo In FolderInfo.GetDirectories
                    GetFolderSize(SubFolderInfo.FullName, True, SearchPattern)
                Next
            Else
                For Each File In FolderInfo.GetFiles(SearchPattern, SearchOption.TopDirectoryOnly)
                    FileCount += 1
                    FolderSize += File.Length
                Next
            End If
            LastFileCount = FileCount
            Return FolderSize
        Catch
            LastFileCount = 0
            Return 0
        End Try
    End Function
    Private Sub DeleteFolder(Folder As String, Recursive As Boolean, SearchPattern As String)
        Try
            Dim FolderInfo = New DirectoryInfo(Folder)
            If Recursive Then
                For Each File In FolderInfo.GetFiles(SearchPattern, SearchOption.AllDirectories)
                    Try
                        IO.File.Delete(File.FullName)
                    Catch
                    End Try
                Next
            Else
                For Each File In FolderInfo.GetFiles(SearchPattern, SearchOption.TopDirectoryOnly)
                    Try
                        IO.File.Delete(File.FullName)
                    Catch
                    End Try
                Next
            End If
            If Recursive Then
                For Each SubFolderInfo In FolderInfo.GetDirectories
                    DeleteFolder(SubFolderInfo.FullName, True, SearchPattern)
                Next
            End If
        Catch
        End Try
    End Sub
    Private Function ConvertFolderSizeToSring(Size As Long, Optional Decimals As Integer = 1) As String
        If Size >= 9223372036854775807 Then
            Return FormatNumber(Size / 1024 / 1024 / 1024 / 1024 / 1024 / 1024 / 1024, Decimals) & " ZB"
        ElseIf Size >= 1152921504606846976 Then
            Return FormatNumber(Size / 1024 / 1024 / 1024 / 1024 / 1024 / 1024, Decimals) & " EB"
        ElseIf Size >= 1125899906842624 Then
            Return FormatNumber(Size / 1024 / 1024 / 1024 / 1024 / 1024, Decimals) & " PB"
        ElseIf Size >= 1099511627776 Then
            Return FormatNumber(Size / 1024 / 1024 / 1024 / 1024, Decimals) & " TB"
        ElseIf Size >= 1073741824 Then
            Return FormatNumber(Size / 1024 / 1024 / 1024, Decimals) & " GB"
        ElseIf Size >= 1048576 Then
            Return FormatNumber(Size / 1024 / 1024, Decimals) & " MB"
        ElseIf Size >= 1024 Then
            Return FormatNumber(Size / 1024, Decimals) & " KB"
        Else
            Return FormatNumber(Size, 0) & " Bytes"
        End If
    End Function
    Private Enum Folder As Byte
        None = 255
        AppData = 0
        CommonAppData = 1
        CurrentUser = 2
        Documents = 3
        LocalAppData = 4
        LocalLowAppData = 5
        PublicUser = 6
        Root = 7
        Users = 8
        Windows = 9
        Custom = 10
    End Enum
    Private Sub AddItem(Name As String, Folder As String, BaseFolder As Folder, TargetList As ListView, Optional Recursive As Boolean = True, Optional SearchPattern As String = "*.*", Optional CustomFolder As String = "")
#If DEBUG Then
        Calls += 1
#End If
        Dim AssembledFolder As String = String.Empty
        Select Case BaseFolder
            Case MainForm.Folder.AppData
                AssembledFolder = AppDataFolder
            Case MainForm.Folder.CommonAppData
                AssembledFolder = CommonAppDataFolder
            Case MainForm.Folder.CurrentUser
                AssembledFolder = CurrentUserFolder
            Case MainForm.Folder.Documents
                AssembledFolder = DocumentsFolder
            Case MainForm.Folder.LocalAppData
                AssembledFolder = LocalAppDataFolder
            Case MainForm.Folder.LocalLowAppData
                AssembledFolder = LocalAppDataFolder & "Low"
            Case MainForm.Folder.PublicUser
                AssembledFolder = PublicUserFolder
            Case MainForm.Folder.Root
                AssembledFolder = Root
            Case MainForm.Folder.Users
                AssembledFolder = UsersFolder
            Case MainForm.Folder.Windows
                AssembledFolder = WindowsFolder
            Case MainForm.Folder.Custom
                AssembledFolder = CustomFolder
        End Select
        AssembledFolder &= Folder
        Dim TranslatedName As String = TranslateItemName(Name)
        If TranslatedName.Contains("%SEARCHPATTERN%") Then TranslatedName = TranslatedName.Replace("%SEARCHPATTERN%", SearchPattern)
        If ProgressDialog.Visible Then
            ProgressDialog.CurrentItemLabel.Text = TranslatedName
            Application.DoEvents()
        End If
        Try
            If Directory.Exists(AssembledFolder) Then
                LastFileCount = 0
                Dim FolderSize As Long = GetFolderSize(AssembledFolder, Recursive, SearchPattern)
                If FolderSize = 0 Then Exit Sub
                TargetList.Items.Add(TranslatedName).SubItems.AddRange({ConvertFolderSizeToSring(FolderSize), FolderSize.ToString, Recursive.ToString, SearchPattern, AssembledFolder, LastFileCount.ToString})
                If ListCheckedFilter(TranslatedName) AndAlso
                   TargetList IsNot GamesList AndAlso
                   TargetList IsNot SavegamesList Then TargetList.Items(TargetList.Items.Count - 1).Checked = True
            End If
        Catch
        End Try
        If ProgressDialog.Visible Then
            ProgressDialog.ProgressBar.Value += 1
            Application.DoEvents()
        End If
        LastFileCount = 0
    End Sub
    Private Sub AddUnrealEngineGame(Name As String, Folder As String)
        AddItem(Name & " Intermediate Cache", "\" & Folder & "\Intermediate", MainForm.Folder.LocalAppData, GamesList)
        AddItem(Name & " Crash Dumps", "\" & Folder & "\Saved\Crashes", MainForm.Folder.LocalAppData, GamesList)
        AddItem(Name & " Logs", "\" & Folder & "\Saved\Logs", MainForm.Folder.LocalAppData, GamesList)
        AddItem(Name & " Shader Cache", "\" & Folder & "\Saved", MainForm.Folder.LocalAppData, GamesList, False, "*.ushaderprecache")
        AddItem(Name & " Pipeline Cache", "\" & Folder & "\Saved", MainForm.Folder.LocalAppData, GamesList, False, "*.upipelinecache")
    End Sub
    Private Sub SuperSecretEasterEgg()
        If File.Exists(LocalAppDataFolder & "\ssee.clmgx") Then
            If File.ReadLines(LocalAppDataFolder & "\ssee.clmgx")(1) = "© Christian Gschaider" AndAlso
               File.ReadAllBytes(LocalAppDataFolder & "\ssee.clmgx").Length = 100 Then
                AddItem("◦ ◦ ◦ ◦ ◦ ◦ ◦ ◦ ◦ ◦ ◦ ◦ ▲ ▲ ▼ ▼ ◀ ▶ ◀ ▶ ◦ ◦ ◦ ◦ ◦ ◦ ◦ ◦ ◦ ◦ ◦ ◦", "", Folder.LocalAppData, DeepCleanList, False, "ssee.clmgx")
            End If
        End If
    End Sub
    Private Function TranslateItemName(Name As String) As String
        If Language = "de" Then
            Dim TranslatedName As String = Name
            TranslatedName = TranslatedName.Replace("Activity Cache", "Aktivitätenspeicher")
            TranslatedName = TranslatedName.Replace("Account Cache", "Kontospeicher")
            TranslatedName = TranslatedName.Replace("Analytics Data", "Analysedaten")
            TranslatedName = TranslatedName.Replace("Apps", "Anwendungen")
            TranslatedName = TranslatedName.Replace("Savegames", "Spielstände")
            TranslatedName = TranslatedName.Replace("Savegame", "Spielstand")
            TranslatedName = TranslatedName.Replace("Save Backups", "Spielstandsicherungen")
            TranslatedName = TranslatedName.Replace("Save Backup", "Spielstandsicherung")
            TranslatedName = TranslatedName.Replace("Backups", "Sicherungen")
            TranslatedName = TranslatedName.Replace("Backup", "Sicherung")
            TranslatedName = TranslatedName.Replace("Benchmark Results", "Benchmarkergebnisse")
            TranslatedName = TranslatedName.Replace("Cache Files", "Zwischenspeicher")
            TranslatedName = TranslatedName.Replace("Chipset", "Chipsatz")
            TranslatedName = TranslatedName.Replace("Config Cache", "Einstellungsspeicher")
            TranslatedName = TranslatedName.Replace("Connections Trace File", "Verbindungsprotokoll")
            TranslatedName = TranslatedName.Replace("Crash Dumps", "Absturzabbilder")
            TranslatedName = TranslatedName.Replace("Crash Dump", "Absturzabbild")
            TranslatedName = TranslatedName.Replace("Crash Reports", "Absturzberichte")
            TranslatedName = TranslatedName.Replace("Crash Report", "Absturzbericht")
            TranslatedName = TranslatedName.Replace("Custom Music", "Benutzerdefinierte Musik")
            TranslatedName = TranslatedName.Replace("Database", "Datenbank")
            TranslatedName = TranslatedName.Replace("Derived Data Cache", "Abgeleiteter Datenspeicher")
            TranslatedName = TranslatedName.Replace("Downloaded Installations", "Heruntergeladene Installationen")
            TranslatedName = TranslatedName.Replace("Drive Root", "Laufwerksstamm")
            TranslatedName = TranslatedName.Replace("Drivers", "Treiber")
            TranslatedName = TranslatedName.Replace("Driver", "Treiber")
            TranslatedName = TranslatedName.Replace("Diagnostic", "Diagnose")
            TranslatedName = TranslatedName.Replace("Epic Games Launcher Content Cache", "Epic Games Launcher Inhaltsspeicher")
            TranslatedName = TranslatedName.Replace("Epic Games Launcher Vault Cache", "Epic Games Launcher Downloadspeicher")
            TranslatedName = TranslatedName.Replace("Error Reports", "Fehlerberichte")
            TranslatedName = TranslatedName.Replace("Error Queue", "Fehlerwarteschlange")
            TranslatedName = TranslatedName.Replace("Folder", "Verzeichnis")
            TranslatedName = TranslatedName.Replace("Intermediate Cache", "Zwischenspeicher")
            TranslatedName = TranslatedName.Replace("Layout Preferences", "Layouteinstellungen")
            TranslatedName = TranslatedName.Replace("Library", "Bibliothek")
            TranslatedName = TranslatedName.Replace("Local Storage", "Lokaler Speicher")
            TranslatedName = TranslatedName.Replace("Memory Dumps", "Speicherabbilder")
            TranslatedName = TranslatedName.Replace("Memory Dump", "Speicherabbild")
            TranslatedName = TranslatedName.Replace("Metrics", "Metriken")
            TranslatedName = TranslatedName.Replace("Network", "Netzwerk")
            TranslatedName = TranslatedName.Replace("Performance Logs", "Leistungsprotokolle")
            TranslatedName = TranslatedName.Replace("Public Account Pictures", "Öffentliche Konto Bilder")
            TranslatedName = TranslatedName.Replace("Public Desktop", "Öffentlicher Desktop")
            TranslatedName = TranslatedName.Replace("Public Documents", "Öffentliche Dokumente")
            TranslatedName = TranslatedName.Replace("Public Downloads", "Öffentliche Downloads")
            TranslatedName = TranslatedName.Replace("Public Files", "Öffentliche Dateien")
            TranslatedName = TranslatedName.Replace("Public Music", "Öffentliche Musik")
            TranslatedName = TranslatedName.Replace("Public Pictures", "Öffentliche Bilder")
            TranslatedName = TranslatedName.Replace("Public Videos", "Öffentliche Videos")
            TranslatedName = TranslatedName.Replace("Public", "Öffentlich")
            TranslatedName = TranslatedName.Replace("Logs", "Protokolldateien")
            TranslatedName = TranslatedName.Replace("Log", "Protokolldatei")
            TranslatedName = TranslatedName.Replace("Root", "Stamm")
            TranslatedName = TranslatedName.Replace("Samples", "Beispiele")
            TranslatedName = TranslatedName.Replace("Search Index", "Suchindex")
            TranslatedName = TranslatedName.Replace("Service Trace File", "Dienstprotokoll")
            TranslatedName = TranslatedName.Replace("Session Storage", "Sitzungsspeicher")
            TranslatedName = TranslatedName.Replace("Sessions", "Sitzungen")
            TranslatedName = TranslatedName.Replace("Local Settings", "Lokale Einstellungen")
            TranslatedName = TranslatedName.Replace("Settings", "Einstellungen")
            TranslatedName = TranslatedName.Replace("Storage", "Speicher")
            TranslatedName = TranslatedName.Replace("Trace Data", "Ereignisdaten")

            TranslatedName = TranslatedName.Replace("Cached User Files", "Zwischengespeicherte Benutzerdateien")
            TranslatedName = TranslatedName.Replace("Connected Devices Platform", "Plattform für Verbundene Geräte")
            TranslatedName = TranslatedName.Replace("Delivery Optimization Files", "Dateien für die Übermittlungsoptimierung")
            TranslatedName = TranslatedName.Replace("Downloaded Program Files", "Heruntergeladene Programmdateien")
            TranslatedName = TranslatedName.Replace("Font Config Cache", "Zwischenspeicher für Schriftart-Einstellungen")
            TranslatedName = TranslatedName.Replace("Game Analytics", "Dateien für die Spieleanalyse")
            TranslatedName = TranslatedName.Replace("Icon Cache", "Symbole")
            TranslatedName = TranslatedName.Replace("Microsoft Defender Definition Update", "Microsoft Defender Definitions Update")
            TranslatedName = TranslatedName.Replace("Microsoft Defender Local Copies", "Microsoft Defender Lokale Kopien")
            TranslatedName = TranslatedName.Replace("Microsoft Defender Protection History", "Microsoft Defender Schutzverlauf")
            TranslatedName = TranslatedName.Replace("Microsoft Defender Quarantined Files", "Microsoft Defender Quarantäne")
            TranslatedName = TranslatedName.Replace("Offline Web Pages", "Offline Webseiten")
            TranslatedName = TranslatedName.Replace("Performance Analyzer Trace Files", "Leistungsanalysedateien")
            TranslatedName = TranslatedName.Replace("Previous Windows Installation", "Vorherige Windows Installation")
            TranslatedName = TranslatedName.Replace("Telemetry Data", "Telemetriedaten")
            TranslatedName = TranslatedName.Replace("Temporary Files", "Temporäre Dateien")
            TranslatedName = TranslatedName.Replace("Temporary Internet Files", "Temporäre Internetdateien")
            TranslatedName = TranslatedName.Replace("Temporary User Files", "Temporäre Benutzerdateien")
            TranslatedName = TranslatedName.Replace("Temporary Windows System Files", "Temporäre Systemdateien")
            TranslatedName = TranslatedName.Replace("Temporary Windows Files", "Temporäre Dateien")
            TranslatedName = TranslatedName.Replace("Thumbnail Cache", "Miniaturansichten")
            TranslatedName = TranslatedName.Replace("Thumbnails", "Miniaturansichten")

            TranslatedName = TranslatedName.Replace("Component Cache", "Komponentenspeicher")
            TranslatedName = TranslatedName.Replace("Data", "Daten")
            TranslatedName = TranslatedName.Replace("Extensions Cache", "Erweiterungsspeicher")
            TranslatedName = TranslatedName.Replace("History", "Verlauf")
            TranslatedName = TranslatedName.Replace("Photos", "Fotos")
            TranslatedName = TranslatedName.Replace("User", "Benutzer")
            Return TranslatedName
        Else
            Return Name
        End If
    End Function
    Private Function ListCheckedFilter(Name As String) As Boolean
        If Language = "de" Then
            If Not Name = "Benutzer Symbole" AndAlso
               Not Name = "Epic Games Launcher Inhaltsspeicher" AndAlso
               Not Name = "Epic Games Launcher Downloadspeicher" AndAlso
               Not Name = "Inbox Anwendungen" AndAlso
               Not Name = "Megascans Bibliothek" AndAlso
               Not Name = "Microsoft Defender Lokale Kopien" AndAlso
               Not Name = "Microsoft Defender Schutzverlauf" AndAlso
               Not Name = "Microsoft Defender Quarantäne" AndAlso
               Not Name = "Miniaturansichten" AndAlso
               Not Name = "Offline Webseiten" AndAlso
               Not Name = "Öffentliche Konto Bilder" AndAlso
               Not Name = "Öffentliche Bilder" AndAlso
               Not Name = "Öffentlicher Desktop" AndAlso
               Not Name = "Öffentliche Dokumente" AndAlso
               Not Name = "Öffentliche Downloads" AndAlso
               Not Name = "Öffentliche Musik" AndAlso
               Not Name = "Öffentliche Videos" AndAlso
               Not Name = "Prefetch" AndAlso
               Not Name = "Plattform für Verbundene Geräte Aktivitätenspeicher" AndAlso
               Not Name = "Symbole" AndAlso
               Not Name = "Xemu Shader Cache" AndAlso
               Not Name.Contains("Beispiele") AndAlso
               Not Name.Contains("Compute Cache") AndAlso
               Not Name.Contains("GeForce Experience") AndAlso
               Not Name.Contains("Kontospeicher") AndAlso
               Not Name.Contains("Lokaler Speicher") AndAlso
               Not Name.Contains("Shader Cache") AndAlso
               Not Name.Contains("Sicherung") AndAlso
               Not Name.Contains("Sitzungen") AndAlso
               Not Name.Contains("Sitzungsspeicher") AndAlso
               Not Name.Contains("Treiber") AndAlso
               Not Name.Contains("Web Speicher") AndAlso
               Not Name.StartsWith("Unreal ") Then
                Return True
            Else
                Return False
            End If
        Else
            If Not Name = "Connected Devices Platform" AndAlso
               Not Name = "Epic Games Launcher Content Cache" AndAlso
               Not Name = "Epic Games Launcher Vault Cache" AndAlso
               Not Name = "Icon Cache" AndAlso
               Not Name = "Inbox Apps" AndAlso
               Not Name = "Megascans Library" AndAlso
               Not Name = "Microsoft Defender Local Copies" AndAlso
               Not Name = "Microsoft Defender Protection History" AndAlso
               Not Name = "Microsoft Defender Quarantined Files" AndAlso
               Not Name = "Offline Web Pages" AndAlso
               Not Name = "Prefetch" AndAlso
               Not Name = "Public Account Pictures" AndAlso
               Not Name = "Public Desktop" AndAlso
               Not Name = "Public Documents" AndAlso
               Not Name = "Public Downloads" AndAlso
               Not Name = "Public Music" AndAlso
               Not Name = "Public Pictures" AndAlso
               Not Name = "Public Videos" AndAlso
               Not Name = "Thumbnail Cache" AndAlso
               Not Name = "User Icon Cache" AndAlso
               Not Name = "Xemu Shader Cache" AndAlso
               Not Name.Contains("Account Cache") AndAlso
               Not Name.Contains("Backup") AndAlso
               Not Name.Contains("Compute Cache") AndAlso
               Not Name.Contains("Drivers") AndAlso
               Not Name.Contains("GeForce Experience") AndAlso
               Not Name.Contains("Local Storage") AndAlso
               Not Name.Contains("Samples") AndAlso
               Not Name.Contains("Shader Cache") AndAlso
               Not Name.Contains("Session Storage") AndAlso
               Not Name.Contains("Sessions") AndAlso
               Not Name.Contains("Web Storage") AndAlso
               Not Name.StartsWith("Unreal ") Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Private Sub List_ItemChecked(sender As Object, e As ItemCheckedEventArgs)
        SelectedFileCount = 0
        SelectedSize = 0
        For Each CheckedItem As ListViewItem In WindowsList.CheckedItems
            SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
            SelectedSize += CLng(CheckedItem.SubItems(2).Text)
        Next
        For Each CheckedItem As ListViewItem In DeepCleanList.CheckedItems
            SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
            SelectedSize += CLng(CheckedItem.SubItems(2).Text)
        Next
        For Each CheckedItem As ListViewItem In JunkwareList.CheckedItems
            SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
            SelectedSize += CLng(CheckedItem.SubItems(2).Text)
        Next
        For Each CheckedItem As ListViewItem In GamesList.CheckedItems
            SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
            SelectedSize += CLng(CheckedItem.SubItems(2).Text)
        Next
        For Each CheckedItem As ListViewItem In SavegamesList.CheckedItems
            SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
            SelectedSize += CLng(CheckedItem.SubItems(2).Text)
        Next
        For Each CheckedItem As ListViewItem In UnrealEngineList.CheckedItems
            SelectedFileCount += CLng(CheckedItem.SubItems(6).Text)
            SelectedSize += CLng(CheckedItem.SubItems(2).Text)
        Next
        FilesToDeleteValueLabel.Text = SelectedFileCount.ToString
        TotalAmountSavedValueLabel.Text = ConvertFolderSizeToSring(SelectedSize)
    End Sub
    Private Sub WindowsList_Enter(sender As Object, e As EventArgs) Handles WindowsList.Enter
        ActiveList = WindowsList
    End Sub
    Private Sub DeepCleanList_Enter(sender As Object, e As EventArgs) Handles DeepCleanList.Enter
        ActiveList = DeepCleanList
    End Sub
    Private Sub JunkwareList_Enter(sender As Object, e As EventArgs) Handles JunkwareList.Enter
        ActiveList = JunkwareList
    End Sub
    Private Sub GamesList_Enter(sender As Object, e As EventArgs) Handles GamesList.Enter
        ActiveList = GamesList
    End Sub
    Private Sub SavegamesList_Enter(sender As Object, e As EventArgs) Handles SavegamesList.Enter
        ActiveList = SavegamesList
    End Sub
    Private Sub UnrealEngineList_Enter(sender As Object, e As EventArgs) Handles UnrealEngineList.Enter
        ActiveList = UnrealEngineList
    End Sub
    Private Sub ListContextMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ListContextMenu.Opening
        ShowFilesToolStripMenuItem.Enabled = ActiveList.SelectedItems.Count > 0
    End Sub
    Private Sub ShowFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowFilesToolStripMenuItem.Click
        Process.Start("explorer.exe", ActiveList.SelectedItems(0).SubItems(5).Text)
    End Sub
    Private Sub MarkAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarkAllToolStripMenuItem.Click
        For Each Item As ListViewItem In ActiveList.Items
            Item.Checked = True
        Next
        ListContextMenu.Close()
    End Sub
    Private Sub UnmarkAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnmarkAllToolStripMenuItem.Click
        For Each Item As ListViewItem In ActiveList.Items
            Item.Checked = False
        Next
        ListContextMenu.Close()
    End Sub
    Private Sub ResetToDefaultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToDefaultsToolStripMenuItem.Click
        If ActiveList IsNot GamesList AndAlso ActiveList IsNot SavegamesList Then
            For Each Item As ListViewItem In ActiveList.Items
                Item.Checked = ListCheckedFilter(Item.Text)
            Next
        Else
            For Each Item As ListViewItem In ActiveList.Items
                Item.Checked = False
            Next
        End If
    End Sub
    Private Sub LogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogsToolStripMenuItem.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Log") OrElse
               Item.Text.Contains("Protokolldatei") Then Item.Checked = True
        Next
    End Sub
    Private Sub PipelineCacheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PipelineCacheToolStripMenuItem.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Pipeline Cache") Then Item.Checked = True
        Next
    End Sub
    Private Sub ShaderCacheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShaderCacheToolStripMenuItem.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Shader Cache") Then Item.Checked = True
        Next
    End Sub
    Private Sub TemporaryFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TemporaryFilesToolStripMenuItem.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Temporary") OrElse
               Item.Text.Contains("Temporär") Then Item.Checked = True
        Next
    End Sub
    Private Sub CacheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CacheToolStripMenuItem.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Cache") OrElse
               Item.Text.Contains("Abgeleiteter Datenspeicher") OrElse
               Item.Text.Contains("Zwischenspeicher") Then Item.Checked = True
        Next
    End Sub
    Private Sub CrashDumpsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrashDumpsToolStripMenuItem.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Crash Dumps") OrElse
               Item.Text.Contains("Absturzabbilder") Then Item.Checked = True
        Next
    End Sub
    Private Sub CrashReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrashReportsToolStripMenuItem.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Crash Reports") OrElse
               Item.Text.Contains("Absturzberichte") Then Item.Checked = True
        Next
    End Sub
    Private Sub LogsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LogsToolStripMenuItem1.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Log") OrElse
               Item.Text.Contains("Protokolldatei") Then Item.Checked = False
        Next
    End Sub
    Private Sub PipelineCacheToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PipelineCacheToolStripMenuItem1.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Pipeline Cache") Then Item.Checked = False
        Next
    End Sub
    Private Sub ShaderCacheToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ShaderCacheToolStripMenuItem1.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Shader Cache") Then Item.Checked = False
        Next
    End Sub
    Private Sub TemporaryFilesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TemporaryFilesToolStripMenuItem1.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Temporary") OrElse
               Item.Text.Contains("Temporär") Then Item.Checked = False
        Next
    End Sub
    Private Sub CacheToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CacheToolStripMenuItem1.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Cache") OrElse
               Item.Text.Contains("Abgeleiteter Datenspeicher") OrElse
               Item.Text.Contains("Zwischenspeicher") Then Item.Checked = False
        Next
    End Sub
    Private Sub CrashDumpsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CrashDumpsToolStripMenuItem1.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Crash Dumps") OrElse
               Item.Text.Contains("Absturzabbilder") Then Item.Checked = False
        Next
    End Sub
    Private Sub CrashReportsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CrashReportsToolStripMenuItem1.Click
        For Each Item As ListViewItem In ActiveList.Items
            If Item.Text.Contains("Crash Reports") OrElse
               Item.Text.Contains("Absturzberichte") Then Item.Checked = False
        Next
    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        CloseToolStripMenuItem.Checked = True
        RebootToolStripMenuItem.Checked = False
        ShutdownToolStripMenuItem.Checked = False
    End Sub
    Private Sub RebootToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RebootToolStripMenuItem.Click
        RebootToolStripMenuItem.Checked = True
        CloseToolStripMenuItem.Checked = False
        ShutdownToolStripMenuItem.Checked = False
    End Sub
    Private Sub ShutdownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShutdownToolStripMenuItem.Click
        ShutdownToolStripMenuItem.Checked = True
        CloseToolStripMenuItem.Checked = False
        RebootToolStripMenuItem.Checked = False
    End Sub
    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultToolStripMenuItem.Click
        Preset_Default()
    End Sub
    Private Sub Preset_Default()
        For Each Item As ListViewItem In WindowsList.Items
            Item.Checked = ListCheckedFilter(Item.Text)
        Next
        For Each Item As ListViewItem In DeepCleanList.Items
            Item.Checked = ListCheckedFilter(Item.Text)
        Next
        For Each Item As ListViewItem In JunkwareList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In GamesList.Items
            Item.Checked = False
        Next
        For Each Item As ListViewItem In SavegamesList.Items
            Item.Checked = False
        Next
        For Each Item As ListViewItem In UnrealEngineList.Items
            Item.Checked = False
        Next
    End Sub
    Private Sub ThoroughToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThoroughToolStripMenuItem.Click
        Preset_Thorough()
    End Sub
    Private Sub Preset_Thorough()
        For Each Item As ListViewItem In WindowsList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In DeepCleanList.Items
            Item.Checked = ListCheckedFilter(Item.Text)
        Next
        For Each Item As ListViewItem In JunkwareList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In GamesList.Items
            Item.Checked = False
        Next
        For Each Item As ListViewItem In SavegamesList.Items
            Item.Checked = False
        Next
        For Each Item As ListViewItem In UnrealEngineList.Items
            Item.Checked = False
        Next
    End Sub
    Private Sub AggressiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggressiveToolStripMenuItem.Click
        Preset_Aggressive()
    End Sub
    Private Sub Preset_Aggressive()
        For Each Item As ListViewItem In WindowsList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In DeepCleanList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In JunkwareList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In GamesList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In SavegamesList.Items
            Item.Checked = False
        Next
        For Each Item As ListViewItem In UnrealEngineList.Items
            Item.Checked = False
        Next
    End Sub
    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        Preset_All()
    End Sub
    Private Sub Preset_All()
        For Each Item As ListViewItem In WindowsList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In DeepCleanList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In JunkwareList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In GamesList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In SavegamesList.Items
            Item.Checked = True
        Next
        For Each Item As ListViewItem In UnrealEngineList.Items
            Item.Checked = True
        Next
    End Sub
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Start()
    End Sub
    Private Sub Start()
        ProgressDialog.Text = Text
        ProgressDialog.ProgressBar.Value = 0
        ProgressDialog.ProgressBar.Maximum = WindowsList.CheckedItems.Count + DeepCleanList.CheckedItems.Count + JunkwareList.CheckedItems.Count + GamesList.CheckedItems.Count + UnrealEngineList.CheckedItems.Count
        If Language = "de" Then
            ProgressDialog.ProgressDescriptionLabel.Text = "Nicht mehr erforderliche Dateien werden vom Computer gelöscht."
            ProgressDialog.TypeLabel.Text = "Bereinigen:"
            ProgressDialog.QuitButton.Text = "Abbrechen"
        Else
            ProgressDialog.ProgressDescriptionLabel.Text = "Files that are no longer required are deleted from the computer."
            ProgressDialog.TypeLabel.Text = "Cleaning:"
            ProgressDialog.QuitButton.Text = "Cancel"
        End If
        Visible = False
        ProgressDialog.Visible = True
        Application.DoEvents()
        For Each CheckedItem As ListViewItem In WindowsList.CheckedItems
            ProgressDialog.CurrentItemLabel.Text = CheckedItem.Text
            Application.DoEvents()
            DeleteFolder(CheckedItem.SubItems(5).Text, CBool(CheckedItem.SubItems(3).Text), CheckedItem.SubItems(4).Text)
            ProgressDialog.ProgressBar.Value += 1
            Application.DoEvents()
        Next
        For Each CheckedItem As ListViewItem In DeepCleanList.CheckedItems
            ProgressDialog.CurrentItemLabel.Text = CheckedItem.Text
            Application.DoEvents()
            DeleteFolder(CheckedItem.SubItems(5).Text, CBool(CheckedItem.SubItems(3).Text), CheckedItem.SubItems(4).Text)
            ProgressDialog.ProgressBar.Value += 1
            Application.DoEvents()
        Next
        For Each CheckedItem As ListViewItem In JunkwareList.CheckedItems
            ProgressDialog.CurrentItemLabel.Text = CheckedItem.Text
            Application.DoEvents()
            DeleteFolder(CheckedItem.SubItems(5).Text, CBool(CheckedItem.SubItems(3).Text), CheckedItem.SubItems(4).Text)
            ProgressDialog.ProgressBar.Value += 1
            Application.DoEvents()
        Next
        For Each CheckedItem As ListViewItem In GamesList.CheckedItems
            ProgressDialog.CurrentItemLabel.Text = CheckedItem.Text
            Application.DoEvents()
            DeleteFolder(CheckedItem.SubItems(5).Text, CBool(CheckedItem.SubItems(3).Text), CheckedItem.SubItems(4).Text)
            ProgressDialog.ProgressBar.Value += 1
            Application.DoEvents()
        Next
        For Each CheckedItem As ListViewItem In SavegamesList.CheckedItems
            ProgressDialog.CurrentItemLabel.Text = CheckedItem.Text
            Application.DoEvents()
            DeleteFolder(CheckedItem.SubItems(5).Text, CBool(CheckedItem.SubItems(3).Text), CheckedItem.SubItems(4).Text)
            ProgressDialog.ProgressBar.Value += 1
            Application.DoEvents()
        Next
        For Each CheckedItem As ListViewItem In UnrealEngineList.CheckedItems
            ProgressDialog.CurrentItemLabel.Text = CheckedItem.Text
            Application.DoEvents()
            DeleteFolder(CheckedItem.SubItems(5).Text, CBool(CheckedItem.SubItems(3).Text), CheckedItem.SubItems(4).Text)
            ProgressDialog.ProgressBar.Value += 1
            Application.DoEvents()
        Next
        If RebootToolStripMenuItem.Checked Then
            Using RebootProcess As New Process
                RebootProcess.StartInfo.CreateNoWindow = True
                RebootProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                RebootProcess.StartInfo.Arguments = "/r /f /t 0"
                RebootProcess.StartInfo.FileName = "shutdown.exe"
                RebootProcess.Start()
            End Using
        ElseIf ShutdownToolStripMenuItem.Checked Then
            Using ShutdownProcess As New Process
                ShutdownProcess.StartInfo.CreateNoWindow = True
                ShutdownProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                ShutdownProcess.StartInfo.Arguments = "/s /f /t 0"
                ShutdownProcess.StartInfo.FileName = "shutdown.exe"
                ShutdownProcess.Start()
            End Using
        End If
        End
    End Sub
    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click
        End
    End Sub
End Class
