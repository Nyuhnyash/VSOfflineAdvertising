using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.Server;


namespace OfflineAdvertising
{
    public class OfflineAdvertiseMod : ModSystem
    {
        private Harmony _harmony;

        public override void StartServerSide(ICoreServerAPI sapi)
        {
            if (((ServerConfig)sapi.Server.Config).VerifyPlayerAuth)
            {
                Mod.Logger.Debug("No need to patch. Ignoring");
                return;
            }

            _harmony = new Harmony(Mod.Info.ModID);
            try
            {
                _harmony.CreateClassProcessor(typeof(ServerSystemHeartbeatPatch)).Patch();
            }
            catch (HarmonyException e)
            {
                Mod.Logger.Error(e.GetBaseException().Message);
                return;
            }
            
            Mod.Logger.Notification("Successfully applied 2 Harmony patches");
        }

        public override bool AllowRuntimeReload
        {
            get { return true; }
        }

        public override void Dispose()
        {
            base.Dispose();
            
            _harmony.UnpatchAll(Mod.Info.ModID);
        }

        public override bool ShouldLoad(EnumAppSide side)
        {
            return side.IsServer();
        }
    }
}
