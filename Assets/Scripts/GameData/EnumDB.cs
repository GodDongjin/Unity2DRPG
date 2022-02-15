using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumDB
{
	#region Player class enum
	public enum PlayerClass
	{
		WARRIORS,
		PALADIN,
		WIZARD
	}
	#endregion Player class end

	#region Player state enum
	public enum PlayerState
	{
		IDEL,
		MOVE,
		ATTACK,
		DIE
	}
	#endregion Player state end

	#region Monster state enum
	public enum MonsterState
	{
		IDEL,
		MOVE,
		ATTACK,
		DIE
	}
	#endregion Monster State end
}
