using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterColider : MonoBehaviour
{
    BoxCollider2D hitBox;
	[SerializeField] MonsterCtrl monsterCtrl;
	private void OnTriggerEnter2D (Collider2D collision)
	{
		if(collision.gameObject.tag == "PlayerAttackBox")
		{
			if (monsterCtrl.info.currHp > 0)
			{
				StartCoroutine(monsterCtrl.monsterHit.Hit());
				monsterCtrl.info.DamegeCount();
			}
			
		}
	}

	int lay;
	public void RayCastCollision() //RayCast충돌함수
	{
		lay = (-1) - (1 << LayerMask.NameToLayer("Monster"));
		Ray2D ray = new Ray2D(this.transform.position, this.transform.right);
		Debug.DrawRay(ray.origin, -ray.direction * monsterCtrl.info.monsterData.p_attack_distance, new Color(0, 1, 0));

		RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, -ray.direction, monsterCtrl.info.monsterData.p_attack_distance, lay);

		if (hit2D.collider != null)
		{
			if (hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				monsterCtrl.ChangeState(EnumDB.MonsterState.ATTACK);
			}
		}
	}
}
