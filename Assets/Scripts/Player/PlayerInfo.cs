using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : Singleton<PlayerInfo>
{
	#region ���� ����
	//private�� �����Ͽ� �ٸ� ��ũ��Ʈ���� ���������� �� ������ ���ϵ��� �������� ���
	//�� �����ϰ� ������ �ؿ� ������Ƽ������ �̿��ؼ� ���� ���������� ����.
	private long hp; // �÷��̾� HP
	private long current_hp; // �÷��̾� ���� HP

	private long damage; // �÷��̾� ���� ����� 

	private float attack_speed; // �÷��̾� ���� �ӵ�
	private float move_speed;	// �̵� �ӵ�

	private float attack_distance;    //���� ����
	private float attack_delay;      //������ ������
	#endregion ���� ���� ��

	#region ������Ƽ ����
	//������Ƽ �̿�(���� �̸��տ� ������ p_�ٿ��� �մϴ�.)
	public long p_hp { get { return hp; } set { hp = value; } }
	public long p_current_hp { get { return current_hp; } set { current_hp = value; } }
	public long p_damage { get { return damage; } set { damage = value; } }
	public float p_attack_speed { get { return attack_speed; } set { attack_speed = value; } }
	public float p_move_speed { get { return move_speed; } set { move_speed = value; } }
	public float p_attack_distance { get { return attack_distance; } set { attack_distance = value; } }
	public float p_attack_delay { get { return attack_delay; } set { attack_delay = value; } }
	#endregion ������Ƽ ���� ��

}
