using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] GameObject attackBox;

	public void AttackUpdate()
	{

	}

	public IEnumerator CoroutineAttack(Animator animator)   //공격 상태
	{
		animator.SetBool("isAttack", true);
		PlayerInfo.Instance.p_move_speed = 0.0f;

		yield return null;
	}

	public void onAttackBox()
	{
		if(attackBox.activeSelf == false)
		{
			attackBox.SetActive(true);
		}
	}

	public void offAttackBox()
	{
		if (attackBox.activeSelf == true)
		{
			attackBox.SetActive(false);
		}
	}
}
