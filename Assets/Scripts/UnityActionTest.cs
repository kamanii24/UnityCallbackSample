// =================================
//
//	UnityActionTest.cs
//	Created by Takuya Himeji
//
// =================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 追加
using UnityEngine.Events;

/// <summary>
/// UnityAction
/// 引数は持てないがとてもシンプルにコールバックが実装できる。
/// </summary>
public class UnityActionTest : MonoBehaviour
{
	// ========
	#region メンバフィールド

	// 実行テスト用変数
	private int testVal = 0;

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
		// 処理を実行するメソッドにコールバックを受け取りたいメソッドを渡す
		ActionMethod (ActionCallbackMethod);

		// ラムダ式UnityAction
		ActionMethod (() => {
			Debug.Log("ラムダ式UnityAction実行完了 : "+testVal);
		});

		// コールバックを使わずそのまま実行
		ActionCallbackMethod ();
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
	/// UnityActionを使ったコールバックメソッド。
	/// </summary>
	private void ActionMethod (UnityAction callback) {
		// 数値の加算開始 コールバック変数を渡す
		StartCoroutine (WaitAdding (callback));
	}

	/// <summary>
	/// 数秒待機した後testValに 10 加算する。
	/// 加算後にコールバックで呼び出し元へ通知する。
	/// </summary>
	private IEnumerator WaitAdding (UnityAction callback) {
		// WaitForSecondsで数秒待機する
		yield return new WaitForSeconds (3f);

		// 10加算する
		testVal += 10;

		// コールバック実行
		// 上でtestValに10加算させた後に次の処理を実行させる
		callback ();
	}

	/// <summary>
	/// UnityActionのコールバックで呼び出されるメソッド。
	/// </summary>
	public void ActionCallbackMethod () {
		if (testVal == 0)
			Debug.Log ("コールバックを介してないよ！ : "+testVal);
		else
			Debug.Log ("UnityAction実行完了 : "+testVal);
	}

	#endregion
}