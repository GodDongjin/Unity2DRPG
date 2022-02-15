using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : Singleton<PlayerInfo>
{
	#region 변수 구역
	//private로 선언하여 다른 스크립트에서 직접적으로 값 변경을 못하도록 막기위해 사용
	//값 변경하고 싶으면 밑에 프로퍼티형식을 이용해서 값을 갑접적으로 변경.
	private long hp; // 플레이어 HP
	private long current_hp; // 플레이어 현재 HP

	private long damage; // 플레이어 최종 대미지 

	private float attack_speed; // 플레이어 공격 속도
	private float move_speed;	// 이동 속도

	private float attack_distance;    //공격 범위
	private float attack_delay;      //공격후 딜레이
	#endregion 변수 구역 끝

	#region 프로퍼티 구역
	//프로퍼티 이용(변수 이름앞에 무조건 p_붙여야 합니다.)
	public long p_hp { get { return hp; } set { hp = value; } }
	public long p_current_hp { get { return current_hp; } set { current_hp = value; } }
	public long p_damage { get { return damage; } set { damage = value; } }
	public float p_attack_speed { get { return attack_speed; } set { attack_speed = value; } }
	public float p_move_speed { get { return move_speed; } set { move_speed = value; } }
	public float p_attack_distance { get { return attack_distance; } set { attack_distance = value; } }
	public float p_attack_delay { get { return attack_delay; } set { attack_delay = value; } }
	#endregion 프로퍼티 구역 끝

}
