namespace MCPForUnity.Editor.Constants
{
    /// <summary>
    /// Centralized list of EditorPrefs keys used by the MCP for Unity package.
    /// Keeping them in one place avoids typos and simplifies migrations.
    /// </summary>
    internal static class EditorPrefKeys
    {
        // PATCH (per-project): EditorPrefs is shared by every Unity project of the OS user, so port/server
        // keys are suffixed with a hash of the project root. This lets several projects run MCP servers
        // side by side. Directory.GetCurrentDirectory() is thread-safe (Application.dataPath is not).
        internal static readonly string ProjectSuffix = ComputeProjectSuffix();

        private static string ComputeProjectSuffix()
        {
            try
            {
                string root = System.IO.Directory.GetCurrentDirectory().Replace('\\', '/').TrimEnd('/').ToLowerInvariant();
                using (var sha = System.Security.Cryptography.SHA1.Create())
                {
                    byte[] h = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(root));
                    return "." + System.BitConverter.ToString(h, 0, 4).Replace("-", "").ToLowerInvariant();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        internal const string UseHttpTransport = "MCPForUnity.UseHttpTransport";
        internal const string HttpTransportScope = "MCPForUnity.HttpTransportScope"; // "local" | "remote"
        internal static readonly string LastLocalHttpServerPid = "MCPForUnity.LocalHttpServer.LastPid" + ProjectSuffix;
        internal static readonly string LastLocalHttpServerPort = "MCPForUnity.LocalHttpServer.LastPort" + ProjectSuffix;
        internal static readonly string LastLocalHttpServerStartedUtc = "MCPForUnity.LocalHttpServer.LastStartedUtc" + ProjectSuffix;
        internal static readonly string LastLocalHttpServerPidArgsHash = "MCPForUnity.LocalHttpServer.LastPidArgsHash" + ProjectSuffix;
        internal static readonly string LastLocalHttpServerPidFilePath = "MCPForUnity.LocalHttpServer.LastPidFilePath" + ProjectSuffix;
        internal static readonly string LastLocalHttpServerInstanceToken = "MCPForUnity.LocalHttpServer.LastInstanceToken" + ProjectSuffix;
        internal const string DebugLogs = "MCPForUnity.DebugLogs";
        internal const string ValidationLevel = "MCPForUnity.ValidationLevel";
        internal static readonly string UnitySocketPort = "MCPForUnity.UnitySocketPort" + ProjectSuffix;
        internal const string ResumeStdioAfterReload = "MCPForUnity.ResumeStdioAfterReload";

        internal const string UvxPathOverride = "MCPForUnity.UvxPath";
        internal const string ClaudeCliPathOverride = "MCPForUnity.ClaudeCliPath";
        internal const string ClientProjectDirOverride = "MCPForUnity.ClientProjectDir";

        internal static readonly string HttpBaseUrl = "MCPForUnity.HttpUrl" + ProjectSuffix;
        internal const string HttpRemoteBaseUrl = "MCPForUnity.HttpRemoteUrl";
        internal const string SessionId = "MCPForUnity.SessionId";
        internal const string WebSocketUrlOverride = "MCPForUnity.WebSocketUrl";
        internal const string GitUrlOverride = "MCPForUnity.GitUrlOverride";
        internal const string DevModeForceServerRefresh = "MCPForUnity.DevModeForceServerRefresh";
        internal const string ProjectScopedToolsLocalHttp = "MCPForUnity.ProjectScopedTools.LocalHttp";
        internal const string AllowLanHttpBind = "MCPForUnity.Security.AllowLanHttpBind";
        internal const string AllowInsecureRemoteHttp = "MCPForUnity.Security.AllowInsecureRemoteHttp";

        internal const string PackageDeploySourcePath = "MCPForUnity.PackageDeploy.SourcePath";
        internal const string PackageDeployLastBackupPath = "MCPForUnity.PackageDeploy.LastBackupPath";
        internal const string PackageDeployLastTargetPath = "MCPForUnity.PackageDeploy.LastTargetPath";
        internal const string PackageDeployLastSourcePath = "MCPForUnity.PackageDeploy.LastSourcePath";

        internal const string ServerSrc = "MCPForUnity.ServerSrc";
        internal const string UseEmbeddedServer = "MCPForUnity.UseEmbeddedServer";
        internal const string LockCursorConfig = "MCPForUnity.LockCursorConfig";
        internal const string AutoRegisterEnabled = "MCPForUnity.AutoRegisterEnabled";
        internal const string ToolEnabledPrefix = "MCPForUnity.ToolEnabled.";
        internal const string ToolFoldoutStatePrefix = "MCPForUnity.ToolFoldout.";
        internal const string ResourceEnabledPrefix = "MCPForUnity.ResourceEnabled.";
        internal const string ResourceFoldoutStatePrefix = "MCPForUnity.ResourceFoldout.";
        internal const string EditorWindowActivePanel = "MCPForUnity.EditorWindow.ActivePanel";
        internal const string LastSelectedClientId = "MCPForUnity.LastSelectedClientId";
        internal const string ClientDetailsFoldoutOpen = "MCPForUnity.ClientConfig.DetailsFoldoutOpen";

        internal const string SetupCompleted = "MCPForUnity.SetupCompleted";
        internal const string SetupDismissed = "MCPForUnity.SetupDismissed";

        internal const string CustomToolRegistrationEnabled = "MCPForUnity.CustomToolRegistrationEnabled";

        internal const string LastUpdateCheck = "MCPForUnity.LastUpdateCheck";
        internal const string LatestKnownVersion = "MCPForUnity.LatestKnownVersion";
        internal const string LastAssetStoreUpdateCheck = "MCPForUnity.LastAssetStoreUpdateCheck";
        internal const string LatestKnownAssetStoreVersion = "MCPForUnity.LatestKnownAssetStoreVersion";
        internal const string LastStdIoUpgradeVersion = "MCPForUnity.LastStdIoUpgradeVersion";

        internal const string TelemetryDisabled = "MCPForUnity.TelemetryDisabled";
        internal const string CustomerUuid = "MCPForUnity.CustomerUUID";

        internal const string ApiKey = "MCPForUnity.ApiKey";

        internal const string AutoStartOnLoad = "MCPForUnity.AutoStartOnLoad";
        internal const string HttpServerLaunchConfirmed = "MCPForUnity.HttpServerLaunchConfirmed";
        internal const string BatchExecuteMaxCommands = "MCPForUnity.BatchExecute.MaxCommands";
        internal const string LogRecordEnabled = "MCPForUnity.LogRecordEnabled";

        internal const string ExecuteCodeCompiler = "MCPForUnity.ExecuteCode.Compiler";

        // AI Asset Generation — NON-SECRET config only. Provider API keys live in the OS
        // secure store (MCPForUnity.Editor.Security.SecureKeyStore), never in EditorPrefs.
        internal const string AssetGenSelectedModelProvider = "MCPForUnity.AssetGen.ModelProvider";
        internal const string AssetGenSelectedImageProvider = "MCPForUnity.AssetGen.ImageProvider";
        internal const string AssetGenSelectedAudioProvider = "MCPForUnity.AssetGen.AudioProvider";
        // Selected model id per (kind, provider): key = prefix + "<kind>.<provider>". Empty => use
        // the catalog default. Per-provider (not per-type) so e.g. the Tripo and Meshy 3D dropdowns
        // — which have disjoint model lists — never clobber each other's selection.
        internal const string AssetGenSelectedModelPrefix = "MCPForUnity.AssetGen.Model.";
        internal const string AssetGenDefaultFormat = "MCPForUnity.AssetGen.Format";
        internal const string AssetGenOutputRoot = "MCPForUnity.AssetGen.OutputRoot";
        internal const string AssetGenAutoNormalize = "MCPForUnity.AssetGen.AutoNormalize";
        internal const string AssetGenProviderEnabledPrefix = "MCPForUnity.AssetGen.Enabled.";

        // Blender Bridge (Asset Gen tab). Machine-specific, non-secret. An empty ForkPath means the
        // addon sync / update-check features are not configured; import and screenshot still work.
        internal const string BlenderHost = "MCPForUnity.Blender.Host";
        internal const string BlenderPort = "MCPForUnity.Blender.Port";
        internal const string BlenderForkPath = "MCPForUnity.Blender.ForkPath";
        internal const string BlenderAddonsDir = "MCPForUnity.Blender.AddonsDir";
    }
}
