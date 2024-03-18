using UnityEngine;

namespace ParticleUI.Loader
{
    public class Loading
    {
        private static GameObject _obj;

        public static void Load()
        {
            _obj = new GameObject("Particle UI");
            _obj.AddComponent<Main>();
            GameObject.DontDestroyOnLoad(_obj);
        }
    }
}