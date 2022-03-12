using UnityEngine;

namespace CoreFeatures.Singleton
{
    /// <summary>
    /// Singleton pattern. Add new class instance or return one if exist.
    /// </summary>
    /// <typeparam name="T">Class which instance must be returned</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        //--------------------------------------------------------------------------

        /// <summary>
        /// Add new class instance or return one if exist.
        /// </summary>
        /// <returns>Class instance</returns>
        public static T GetInstance()
        {
            if (_instance == null)
            {
                GameObject gameObject = new GameObject();
                _instance = gameObject.AddComponent<T>();
                gameObject.name = _instance.GetType().Name;
            }
            return _instance;
        }
        //--------------------------------------------------------------------------
    }
}
