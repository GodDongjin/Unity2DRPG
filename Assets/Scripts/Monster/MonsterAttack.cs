using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
	[SerializeField] GameObject attackBox;

	public void AttackUpdate()
	{

	}

	public IEnumerator CorountineAttack(Animator animator)
	{
		animator.SetBool("isAttack", true);

		yield return null;
	}

	public void onAttackBox()
	{
		if (attackBox.activeSelf == false)
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
