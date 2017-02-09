// =================================
//
//	ExternalClass.cs
//	Created by Takuya Himeji
//
// =================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExternalClass : MonoBehaviour
{
	public void M1 () {
		Debug.Log ("UnityEventに登録されていた外部クラスのメソッド その1");
	}

	public void M2 () {
		Debug.Log ("UnityEventに登録されていた外部クラスのメソッド その2");
	}

	public void M3 () {
		Debug.Log ("UnityEventに登録されていた外部クラスのメソッド その3");
	}
}