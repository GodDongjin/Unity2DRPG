using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDie : MonoBehaviour
{
	[SerializeField] BoxCollider2D hitBox;
	[SerializeField] MonsterCtrl monsterCtrl;
	
	

	public void DieUpdate()
	{
		if (PlayerInfo.Instance.p_move_speed > 0)
		{
			Vector3 moveVelocity = Vector3.left;
			this.transform.position += moveVelocity * Time.deltaTime * (PlayerInfo.Instance.p_move_speed);
		}
		else if (PlayerInfo.Instance.p_move_speed == 0)
		{
			Vector3 moveVelocity = Vector3.left;
			this.transform.position += moveVelocity * (PlayerInfo.Instance.p_move_speed) * Time.deltaTime;
		}

	}

	public IEnumerator CorountineDie(Animator animator, MonsterSpwner spwner)
	{
		animator.SetBool("isDie", true);
		hitBox.enabled = false;

		yield return new WaitForSeconds(2.5f);
		spwner.MonsterRetrunToPool(this.gameObject);
		spwner.MonsterSpown();
		yield return null;
	}

	public IEnumerator FullGlowDissolveFade()
	{

		//Set fade value to zero at start.
		//monsterCtrl.fadeValue = 1.0f;

		while (monsterCtrl.fadeValue > 0f)
		{
			//Increase fade value over time.
			monsterCtrl.fadeValue -= Time.deltaTime;

			//Update value in material.
			monsterCtrl.material.SetFloat(monsterCtrl.fadePropertyID, monsterCtrl.fadeValue);
			yield return new WaitForSeconds(0.005f);
		}

		
		yield return null;
	}
}
