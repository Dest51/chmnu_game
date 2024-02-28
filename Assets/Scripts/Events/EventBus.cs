using System;
using System.Collections.Generic;
using UI;

namespace Events
{
    public static class EventBus
    {
        public static Dictionary<PotionType, Action<object[]>> dictEvent = new Dictionary<PotionType, Action<object[]>>();

        public static void BroadCast(PotionType potionType, params object[] arg)
        {
            if (dictEvent.ContainsKey(potionType))
                dictEvent[potionType]?.Invoke(arg);
        }

        public static void SubScribe(PotionType potionType, Action<object[]> callBack)
        {

            if (dictEvent.ContainsKey(potionType))
            {
                dictEvent[potionType] += callBack;
            }
            else
            {
                dictEvent.Add(potionType, callBack);
            }
        }

        public static void UnSubscribe(PotionType potionType, Action<object[]> callBack)
        {
            if (dictEvent.ContainsKey(potionType))
            {
                dictEvent[potionType] -= callBack;
            }
        }

    }
}