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
                // Maybe instance already has been added on scene
                T[] instances = Resources.FindObjectsOfTypeAll<T>();
                if (instances.Length > 0)
                {
                    _instance = instances[0];
                }
                else
                {
                    GameObject gameObject = new GameObject(typeof(T).Name);
                    _instance = gameObject.AddComponent<T>();
                }
            }
            return _instance;
        }
        //--------------------------------------------------------------------------
    }
}
