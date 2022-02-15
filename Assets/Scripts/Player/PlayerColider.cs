using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColider : MonoBehaviour
{
	[SerializeField] PlayerCtrl playerCtrl;
	MonsterCtrl monsterInfo;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "MonsterAttackBox")
		{
			monsterInfo = collision.transform.parent.gameObject.GetComponent<MonsterCtrl>();
			PlayerInfo.Instance.p_current_hp -= monsterInfo.info.monsterData.p_damage;
			//Debug.Log(PlayerInfo.Instance.p_current_hp);
		}
	}

	public int lay;
	public void RayCastCollision() //RayCast충돌함수
	{
		Ray2D ray = new Ray2D(this.transform.position, this.transform.right);
		Debug.DrawRay(ray.origin, ray.direction * PlayerInfo.Instance.p_attack_distance, new Color(0, 1, 0));

		RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction, PlayerInfo.Instance.p_attack_distance, lay);

		if (hit2D.collider != null)
		{
			if (hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Monster"))
			{
				//Debug.Log("충돌");
				playerCtrl.ChangeState(EnumDB.PlayerState.ATTACK);

			}
		}
		else if (hit2D.collider == null)
		{
			playerCtrl.ChangeState(EnumDB.PlayerState.MOVE);
		}
	}
}
