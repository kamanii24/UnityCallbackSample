// =================================
//
//	UnityEventTest.cs
//	Created by Takuya Himeji
//
// =================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 追加
using UnityEngine.Events;

/// <summary>
/// UnityEvent
/// メソッドを複数登録できるので実行対象が多い場合に有効。
/// 登録したメソッドを呼び出すにはInvoke()を使う。
/// Invoke()を使うと登録したメソッドが一斉に実行される。 
/// Inspector上でも設定可。
/// </summary>
public class UnityEventTest : MonoBehaviour
{
	// ========
	#region インスペクタ設定用フィールド

	/// <summary>
	/// Inspector上でも設定できるようにSelializeField属性を付与
	/// </summary>
	[SerializeField]
	private UnityEvent unityEvent;

	#endregion


	// ========
	#region メンバフィールド

	/// <summary>
	/// UnityEventクラスをオーバーライドして引数を扱えるようにする
	/// </summary>
	public class UnityEventArg : UnityEvent<int> { }

	/// <summary>
	/// 整数型の引数を持てるUnityEvent
	/// </summary>
	private UnityEventArg unityEventArg;

	#endregion


	// ========
	#region MonoBehaviourメソッド

	/// <summary>
	/// 初期化処理
	/// </summary>
	void Awake () {
	}

	/// <summary>
	/// 開始処理
	/// </summary>
	void Start () {
		// UnityEvent
		// Invoke()で実行させるメソッドを登録する
		unityEvent.AddListener (UnityEventCallbackMethod_1);
		unityEvent.AddListener (UnityEventCallbackMethod_2);
		unityEvent.AddListener (UnityEventCallbackMethod_3);

		// Inspectorまたはスクリプト上で登録されたメソッドを一斉に実行する
		unityEvent.Invoke();


		// インスタンス生成
		if (unityEventArg == null)
			unityEventArg = new UnityEventArg ();

		// 引数付きのメソッドを登録する
		unityEventArg.AddListener (UnityEventArgCallbackMethod);

		// 登録されているメソッドに 100 を渡す
		unityEventArg.Invoke (100);
	}
	
	/// <summary>
	/// 更新処理
	/// </summary>
	void Update () {
		
	}

	#endregion


	// ========
	#region メンバメソッド

	/// <summary>
	/// UnityEventで実行されるメソッド1
	/// </summary>
	private void UnityEventCallbackMethod_1 () {
		Debug.Log ("UnityEvent実行完了 その1");
	}


	/// <summary>
	/// UnityEventで実行されるメソッド2
	/// </summary>
	private void UnityEventCallbackMethod_2 () {
		Debug.Log ("UnityEvent実行完了 その2");
	}


	/// <summary>
	/// UnityEventで実行されるメソッド3
	/// </summary>
	private void UnityEventCallbackMethod_3 () {
		Debug.Log ("UnityEvent実行完了 その3");
	}


	/// <summary>
	/// UnityEventで実行される引数付きメソッド
	/// </summary>
	private void UnityEventArgCallbackMethod (int val) {
		Debug.Log ("UnityEventArg実行完了 : "+ val);
	}

	#endregion
}