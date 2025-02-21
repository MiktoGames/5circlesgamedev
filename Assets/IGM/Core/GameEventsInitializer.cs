using UnityEngine;

namespace Kinemon
{
    public class GameEventsInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Initialize()
        {
            GameObject obj = new GameObject("Game Events");
            obj.AddComponent<GameEvents>();
            Object.DontDestroyOnLoad(obj);
        }
    }
}