using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
	public void MoveUpdate()
	{
		
		if (PlayerInfo.Instance.p_move_speed > 0)
		{
			Vector3 moveVelocity = Vector3.left;
			this.transform.position += moveVelocity * Time.deltaTime* (PlayerInfo.Instance.p_move_speed + 1.5f);
		}
		else if(PlayerInfo.Instance.p_move_speed == 0)
		{
			Vector3 moveVelocity = Vector3.left;
			this.transform.position += moveVelocity * (PlayerInfo.Instance.p_move_speed + 1.0f) * Time.deltaTime;
		}
	}

	public IEnumerator CoroutineMove(Animator animator)
	{
		animator.SetBool("isMove", true);

		animator.SetFloat("moveSpeed", 1.2f);

		yield return null;
	}
}
