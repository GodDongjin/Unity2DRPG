using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpwner : MonoBehaviour
{
    [SerializeField] MonsterPool monsterPool;
    [SerializeField] MonsterData[] datas;

	Queue<GameObject> monsterChacks = new Queue<GameObject>();

	private void Awake()
	{
		monsterPool.PoolInstantiate();
	}

	private void OnEnable()
	{
		MonsterSpown();
	}

	public void MonsterSpown()
	{
		GameObject obj = monsterPool.SpawnFromPool(this.transform.position, datas[0]);
		monsterChacks.Enqueue(obj);
	}

	public void MonsterRetrunToPool(GameObject obj)
	{
		monsterPool.ReturnToPool(obj);
		monsterChacks.Dequeue();
	}

	public void MonsterAllRetrunToPool()
	{
		monsterPool.AllReturnToPool(monsterChacks);
	}


}
