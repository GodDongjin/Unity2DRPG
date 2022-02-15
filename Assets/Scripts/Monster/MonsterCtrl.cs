using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] MonsterMove monsterMove;
	[SerializeField] MonsterAttack monsterAttack;
	[SerializeField] MonsterColider monsterColider;
	[SerializeField] MonsterDie monsterDie;
	[SerializeField] public MonsterHit monsterHit;

	[SerializeField] public MonsterInfo info;

	[SerializeField] public SpriteRenderer renderer;
	public Material material;
	public int fadePropertyID;
	public float fadeValue;

	public bool isDie = false;

	EnumDB.MonsterState state;
	MonsterSpwner spwner;
	WaitForFixedUpdate updateTime = new WaitForFixedUpdate();

	public void AilveOn()
	{
		spwner = this.gameObject.transform.parent.GetComponent<MonsterSpwner>();
		material = renderer.material;
		fadePropertyID = Shader.PropertyToID("_FullGlowDissolveFade");
		isDie = false;
		fadeValue = 1.0f;
		monsterAttack.offAttackBox();
		material.SetFloat("_FullGlowDissolveFade", fadeValue);
		ChangeState(EnumDB.MonsterState.MOVE);
		StartCoroutine(CorutinUpdate());
	}

	IEnumerator CorutinUpdate()
	{
		while (true)
		{
			switch (state)
			{
				case EnumDB.MonsterState.IDEL: break;
				case EnumDB.MonsterState.MOVE: monsterMove.MoveUpdate(); monsterColider.RayCastCollision(); break;
				case EnumDB.MonsterState.ATTACK: monsterAttack.AttackUpdate(); monsterColider.RayCastCollision(); break;
				case EnumDB.MonsterState.DIE: monsterDie.DieUpdate(); break;
			}
			if (info.currHp <= 0 && isDie == false)
			{
				ChangeState(EnumDB.MonsterState.DIE);
				isDie = true;
			}
			yield return updateTime;
		}
	}

	public void ChangeState(EnumDB.MonsterState nextState)
	{
		state = nextState;

		animator.SetBool("isIdel", false);
		animator.SetBool("isMove", false);
		animator.SetBool("isAttack", false);
		animator.SetBool("isDie", false);

		StopCoroutine(monsterMove.CoroutineMove(animator));
		StopCoroutine(monsterAttack.CorountineAttack(animator));
		StopCoroutine(monsterDie.CorountineDie(animator, spwner));

		switch (state)
		{
			case EnumDB.MonsterState.IDEL: break;
			case EnumDB.MonsterState.MOVE: StartCoroutine(monsterMove.CoroutineMove(animator)); break;
			case EnumDB.MonsterState.ATTACK: StartCoroutine(monsterAttack.CorountineAttack(animator)); break;
			case EnumDB.MonsterState.DIE: StartCoroutine(monsterDie.CorountineDie(animator,spwner)); break;
		}
	}

	
}
