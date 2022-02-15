using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonobehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	static T _instance;

	public static T Instance
	{
		get
		{
			if(_instance == null)
			{
				T[] arr = FindObjectsOfType<T>();
				if(arr == null || arr.Length == 0)
				{
					GameObject newObject = new GameObject(typeof(T).Name);
					_instance = newObject.AddComponent<T>();
				}
				else if(arr.Length == 1)
				{
					_instance = arr[0];
				}
				else
				{
					throw new System.Exception("Too Many Instance");
				}
			}

			return _instance;
		}
	}
}

public class Singleton<T> where T : class, new()
{
	static T _instance;

	public static T Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = new T();
			}
			return _instance;
		}
	}
}
