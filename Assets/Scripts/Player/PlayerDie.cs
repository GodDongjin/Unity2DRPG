using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
	public IEnumerator CorountineDie(Animator animator, GameManager gameManager)
	{
		animator.SetBool("isDie", true);

		gameManager.GameReset();

		yield return null;
	}
}
