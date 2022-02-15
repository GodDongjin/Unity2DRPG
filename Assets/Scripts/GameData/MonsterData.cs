using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Monster Data", menuName = "Scriptable Object/Monster Data", order = int.MaxValue)]
public class MonsterData : ScriptableObject
{
	#region 변수 구역
	//private로 선언하여 다른 스크립트에서 직접적으로 값 변경을 못하도록 막기위해 사용
	//값 변경하고 싶으면 밑에 프로퍼티형식을 이용해서 값을 갑접적으로 변경.
	[SerializeField]
	private string name;
	[SerializeField]
	private Sprite sprite;
	[SerializeField]
	//private  animator;
	private RuntimeAnimatorController animatorController;
	[SerializeField]
	private long hp; // 플레이어 HP
	[SerializeField]
	private long damage; // 플레이어 최종 대미지 
	[SerializeField]
	private float attack_speed; // 플레이어 공격 속도

	[SerializeField]
	private float attack_distance;    //공격 범위
	[SerializeField]
	private float attack_delay;      //공격후 딜레이
	#endregion 변수 구역 끝

	#region 프로퍼티 구역
	//프로퍼티 이용(변수 이름앞에 무조건 p_붙여야 합니다.)
	public string p_name { get { return name; } }
	public Sprite p_sprite { get { return sprite; } }
	public RuntimeAnimatorController p_animatorController { get { return animatorController; } }
	public long p_hp { get { return hp; } }
	public long p_damage { get { return damage; } }
	public float p_attack_speed { get { return attack_speed; } }
	public float p_attack_distance { get { return attack_distance; } }
	public float p_attack_delay { get { return attack_delay; } }
	#endregion 프로퍼티 구역 끝
}
