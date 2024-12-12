using System;

namespace Assets.Code.Data
{
    [Serializable]
    public class PlayerProgress
    {
        internal static PlayerProgress Empty = null;
        internal static PlayerProgress New() => new();
        public int Coins;
    }
}