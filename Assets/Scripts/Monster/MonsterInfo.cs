using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo : MonoBehaviour
{
	//몬스터 정보 가져오기
	

	#region 변수 구역
	//private로 선언하여 다른 스크립트에서 직접적으로 값 변경을 못하도록 막기위해 사용
	//값 변경하고 싶으면 밑에 프로퍼티형식을 이용해서 값을 갑접적으로 변경.
	[SerializeField] private SpriteRenderer renderer;
	[SerializeField] private Animator animator;
	public MonsterData monsterData;
	public long currHp;
	#endregion 변수 구역 끝

	#region 정보 수정 하는 함수
	public void MonsterDataPush()
	{
		renderer.sprite = monsterData.p_sprite;
		animator.runtimeAnimatorController = monsterData.p_animatorController;
		currHp = monsterData.p_hp;
	}

	public void DamegeCount()
	{
		currHp -= PlayerInfo.Instance.p_damage;
		Debug.Log(currHp);
	}

	#endregion 정보 수정 함수 끝
}
