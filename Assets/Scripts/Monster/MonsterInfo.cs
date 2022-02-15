using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo : MonoBehaviour
{
	//���� ���� ��������
	

	#region ���� ����
	//private�� �����Ͽ� �ٸ� ��ũ��Ʈ���� ���������� �� ������ ���ϵ��� �������� ���
	//�� �����ϰ� ������ �ؿ� ������Ƽ������ �̿��ؼ� ���� ���������� ����.
	[SerializeField] private SpriteRenderer renderer;
	[SerializeField] private Animator animator;
	public MonsterData monsterData;
	public long currHp;
	#endregion ���� ���� ��

	#region ���� ���� �ϴ� �Լ�
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

	#endregion ���� ���� �Լ� ��
}
