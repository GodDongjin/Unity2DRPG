using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainManager : MonobehaviourSingleton<MainManager>
{
	GameObject mapCtrlObj;

	public MapCtrl mapCtrl;

	private void OnEnable()
	{
		mapCtrlObj = GameObject.FindGameObjectWithTag("Map");

		mapCtrl = mapCtrlObj.GetComponent<MapCtrl>();
	}


}


