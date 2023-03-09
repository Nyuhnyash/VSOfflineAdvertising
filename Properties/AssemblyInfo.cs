using System.Runtime.InteropServices;
using Vintagestory.API.Common;

[assembly: ComVisible(false)]

[assembly: ModInfo( "OfflineAdvertising", "offlineadvertising",
    Version = "1.0.0",
    Description = "Allows master-server advertising in offline-mode",
    Side = "server",
    Authors = new[] { "Nyuhnyash" })]

 [assembly: ModDependency("game", "1.15.0")]
