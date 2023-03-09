using System;


namespace OfflineAdvertising
{
    class UnsuitablePatchException : Exception
    {
        public UnsuitablePatchException()
            : base("Patch is not suitable. Incompatible version of the game library") { }
    }
}
