using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Monster Data", menuName = "Scriptable Object/Monster Data", order = int.MaxValue)]
public class MonsterData : ScriptableObject
{
	#region ���� ����
	//private�� �����Ͽ� �ٸ� ��ũ��Ʈ���� ���������� �� ������ ���ϵ��� �������� ���
	//�� �����ϰ� ������ �ؿ� ������Ƽ������ �̿��ؼ� ���� ���������� ����.
	[SerializeField]
	private string name;
	[SerializeField]
	private Sprite sprite;
	[SerializeField]
	//private  animator;
	private RuntimeAnimatorController animatorController;
	[SerializeField]
	private long hp; // �÷��̾� HP
	[SerializeField]
	private long damage; // �÷��̾� ���� ����� 
	[SerializeField]
	private float attack_speed; // �÷��̾� ���� �ӵ�

	[SerializeField]
	private float attack_distance;    //���� ����
	[SerializeField]
	private float attack_delay;      //������ ������
	#endregion ���� ���� ��

	#region ������Ƽ ����
	//������Ƽ �̿�(���� �̸��տ� ������ p_�ٿ��� �մϴ�.)
	public string p_name { get { return name; } }
	public Sprite p_sprite { get { return sprite; } }
	public RuntimeAnimatorController p_animatorController { get { return animatorController; } }
	public long p_hp { get { return hp; } }
	public long p_damage { get { return damage; } }
	public float p_attack_speed { get { return attack_speed; } }
	public float p_attack_distance { get { return attack_distance; } }
	public float p_attack_delay { get { return attack_delay; } }
	#endregion ������Ƽ ���� ��
}
