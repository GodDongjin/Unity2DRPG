using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] PlayerCtrl playerCtrl;
	[SerializeField] MonsterSpwner[] monsterSpwners;

	
	public void GameReset()
	{
		for (int i = 0; i < monsterSpwners.Length; i++)
		{
			monsterSpwners[i].MonsterAllRetrunToPool();
		}
		StartCoroutine(Test());
		playerCtrl.gameObject.SetActive(false);
		
		
	}

	public IEnumerator Test()
	{
		yield return new WaitForSeconds(1.0f);

		for (int i = 0; i < monsterSpwners.Length; i++)
		{
			monsterSpwners[i].MonsterSpown();
		}
		playerCtrl.gameObject.SetActive(true);
	}
}
