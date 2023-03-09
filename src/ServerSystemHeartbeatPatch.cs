using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using Vintagestory.Server;


namespace OfflineAdvertising
{
    [HarmonyPatch(typeof(ServerSystemHeartbeat))]
    class ServerSystemHeartbeatPatch
    {
        [HarmonyTranspiler]
        [HarmonyPatch("SendHeartbeat")]
        static IEnumerable<CodeInstruction> SendHeartbeatTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var instructionsArray = instructions.ToArray();
            if (instructionsArray[5].opcode != OpCodes.Ret)
                throw new UnsuitablePatchException();

            return instructionsArray.Skip(6);
        }
        
        [HarmonyTranspiler]
        [HarmonyPatch("SendRegister")]
        static IEnumerable<CodeInstruction> SendRegisterTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var instructionsArray = instructions.ToArray();
            if (!instructionsArray[6].OperandIs("VerifyPlayerAuth is off. Will not register to master server"))
                throw new UnsuitablePatchException();

            return instructionsArray.Skip(8);
        }
    }
}
