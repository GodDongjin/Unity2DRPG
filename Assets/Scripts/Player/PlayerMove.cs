using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public void MoveUpdate()
	{

	}

	public IEnumerator CorountineMove(Animator animator)
	{
		animator.SetBool("isMove", true);

		PlayerInfo.Instance.p_move_speed = 5.0f;
		animator.SetFloat("MoveSpeed", (PlayerInfo.Instance.p_move_speed + 0.5f));

		yield return null;
	}
}
