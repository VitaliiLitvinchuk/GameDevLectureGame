using System;
using System.Collections.Generic;

namespace Assets.Code.Data
{
    [Serializable]
    public class PlayerProgress
    {
        internal static PlayerProgress Empty = null;
        internal static PlayerProgress New() => new();
        public int Coins;
        public List<HatTypeId> OwnedHats = new();
        public HatTypeId SelectedHat = HatTypeId.Unknown;
    }
}