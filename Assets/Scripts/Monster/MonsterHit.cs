using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour
{
    [SerializeField] MonsterCtrl monsterCtrl;

    public IEnumerator Hit()
	{
		monsterCtrl.renderer.color = new Color(1, 0, 0);

		yield return new WaitForSeconds(0.1f);
		monsterCtrl.renderer.color = new Color(1, 1, 1);
	}
}
