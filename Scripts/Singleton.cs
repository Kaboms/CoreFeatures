using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreFeatures.Singleton
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;

		//--------------------------------------------------------------------------

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
