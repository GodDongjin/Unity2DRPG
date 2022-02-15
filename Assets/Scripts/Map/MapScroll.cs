using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapScroll : MonoBehaviour
{

	public Transform[] background;

	float leftPosX = 0f;
	float rightPosX = 0f;
	float xScreenHalfSize;
	float yScreenHalfSize;

	private void Start()
	{
		yScreenHalfSize = Camera.main.orthographicSize;
		xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

		leftPosX = -(xScreenHalfSize * 2);
		rightPosX = xScreenHalfSize * 2 * background.Length;

		StartCoroutine(CorutinUpdate());
	}


	IEnumerator CorutinUpdate()
	{
		WaitForFixedUpdate updateTime = new WaitForFixedUpdate();

		while (true)
		{
			MapMove();
			yield return updateTime;
		}
	}

	void MapMove()
	{
		for(int i  = 0; i < background.Length; i++)
		{
			background[i].position += new Vector3(-PlayerInfo.Instance.p_move_speed, 0, 0) * Time.deltaTime;

			if(background[i].position.x < leftPosX)
			{
				Vector3 nextPos = background[i].position;
				nextPos = new Vector3(nextPos.x + rightPosX, nextPos.y, nextPos.z);
				background[i].position = nextPos;
			}
		}
	}


}


