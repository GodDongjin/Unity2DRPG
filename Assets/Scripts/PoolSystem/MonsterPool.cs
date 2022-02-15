using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterPool : MonoBehaviour
{
	[Serializable]
	public class Pool
	{
		public string name;
		public GameObject prefab;
		public int size;
	}

	[SerializeField]
	Pool pool;

	[SerializeField]
	Queue<GameObject> poolQueue = new Queue<GameObject>();

	public void PoolInstantiate()
	{
		for(int i = 0; i < pool.size; i++)
		{
			GameObject obj = Instantiate(pool.prefab);
			obj.SetActive(false);
			obj.transform.SetParent(this.transform, false);
			poolQueue.Enqueue(obj);
		}
	}

	public GameObject SpawnFromPool(Vector3 position, MonsterData monsterData)
	{
		if (poolQueue.Count == 0)
		{
			return null;
		}
		
		GameObject obj = poolQueue.Dequeue();
		obj.GetComponent<MonsterInfo>().monsterData = monsterData;
		obj.GetComponent<MonsterInfo>().MonsterDataPush();
		obj.SetActive(true);
		obj.GetComponent<MonsterCtrl>().AilveOn();
		obj.transform.position = position;
		
		return obj;
	}

	public void ReturnToPool(GameObject obj)
	{
		if (poolQueue == null)
		{
			Debug.LogError("풀에 오브젝트가 없다.");
			return;
		}
		
		obj.SetActive(false);
		obj.transform.position = Vector3.zero;
		poolQueue.Enqueue(obj);
	}
	public void AllReturnToPool(Queue<GameObject> obj)
	{
		poolQueue.Clear();

		while(obj.Count > 0)
		{
			GameObject monster = obj.Dequeue();
			monster.SetActive(false);
			monster.transform.position = Vector3.zero;
			poolQueue.Enqueue(monster);
		}


		Debug.Log("끝");
	}

		//public void PoolObjectDictory()
		//{
		//    for (int i = 0; i < MainManager.Instance.stageManager.monster.Count; i++)
		//    {
		//        Destroy(MainManager.Instance.stageManager.monster[i]);
		//    }
		//    MainManager.Instance.stageManager.monster.Clear();
		//
		//    poolDictionary.Clear();
		//}

	}
