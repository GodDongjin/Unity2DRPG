using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] PlayerMove playerMove;
	[SerializeField] PlayerAttack playerAttack;
	[SerializeField] PlayerDie playerDie;
	[SerializeField] PlayerColider playerColider;
	[SerializeField] public GameManager gameManager;

	EnumDB.PlayerState state;

	public bool isDie = false;

	WaitForFixedUpdate updateTime = new WaitForFixedUpdate();

	private void OnEnable()
	{
		PlayerInfo.Instance.p_attack_distance = 1.3f;
		PlayerInfo.Instance.p_hp = 100;
		PlayerInfo.Instance.p_current_hp = 100;
		PlayerInfo.Instance.p_damage = 40;
		isDie = false;
		playerColider.lay = (-1) - (1 << LayerMask.NameToLayer("Player"));
		ChangeState(EnumDB.PlayerState.MOVE);
		StartCoroutine(CorutinUpdate());
	}

	IEnumerator CorutinUpdate()
	{
		while (true)
		{
			switch (state)
			{
				case EnumDB.PlayerState.IDEL: break;
				case EnumDB.PlayerState.MOVE: playerMove.MoveUpdate(); playerColider.RayCastCollision(); break;
				case EnumDB.PlayerState.ATTACK: playerAttack.AttackUpdate(); playerColider.RayCastCollision(); break;
			}

			if (PlayerInfo.Instance.p_current_hp <= 0 && isDie == false)
			{
				ChangeState(EnumDB.PlayerState.DIE);
				isDie = true;
			}

			yield return updateTime;
		}
	}

	public void ChangeState(EnumDB.PlayerState nextState)
	{
		state = nextState;

		animator.SetBool("isIdel", false);
		animator.SetBool("isMove", false);
		animator.SetBool("isAttack", false);
		animator.SetBool("isDie", false);

		StopCoroutine(playerMove.CorountineMove(animator));
		StopCoroutine(playerAttack.CoroutineAttack(animator));
		StopCoroutine(playerDie.CorountineDie(animator, gameManager));

		switch (state)
		{
			case EnumDB.PlayerState.IDEL: break;
			case EnumDB.PlayerState.MOVE: StartCoroutine(playerMove.CorountineMove(animator)); break;
			case EnumDB.PlayerState.ATTACK: StartCoroutine(playerAttack.CoroutineAttack(animator)); break;
			case EnumDB.PlayerState.DIE: StartCoroutine(playerDie.CorountineDie(animator, gameManager)); break;
		}
	}


	
}
