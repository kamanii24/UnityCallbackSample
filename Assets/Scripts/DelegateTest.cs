// =================================
//
//	DelegateTest.cs
//	Created by Takuya Himeji
//
// =================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// delegate
/// 引数付きのコールバックを実装したいときはこれ。
/// 自分で引数付きの型を作り、その型を使ってコールバック用の変数を宣言する。
/// 引数は複数登録可。
/// </summary>
public class DelegateTest : MonoBehaviour
{
	// ========
	#region メンバフィールド

	/// <summary>
	/// delegate型を宣言
	/// </summary>
	private delegate void OnComplete (string text);

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
		DelegateMethod (DelegateCallbackMethod);

		// ラムダ式delegate
		DelegateMethod ((string text) => {
			Debug.Log ("ラムダ式delegate実行完了 : " + text);
		});
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
	/// delegateを使ったコールバックメソッド。
	/// URLからテキストデータを取得し、呼び出し元に返す処理。
	/// このメソッドを介さなくても呼び出し元から直接StartCoroutineでDownloadを呼び出しても結果は同じ。
	/// </summary>
	private void DelegateMethod (OnComplete callback) {
		// テキストデータのURL
		string url = "https://dl.dropboxusercontent.com/u/91930162/text.txt";
		// ダウンロード開始 アクセス先のURLとコールバック変数を渡す
		StartCoroutine (Download(url, callback));
	}

	/// <summary>
	/// ダウンロードを実行する。
	/// OnComplete型の変数を引数に持たせる。
	/// </summary>
	private IEnumerator Download (string url, OnComplete callback) {
		// WWWでサーバー上のデータを取得する
		WWW www = new WWW(url);
		// 取得が終わるまで待つ (yield returnは値がnullの間は処理が中断される)
		yield return www;

		// コールバック実行
		// WWWで取得したテキスト情報を返す
		callback (www.text);

		// wwwを解放する (忘れずに)
		www.Dispose ();
	}

	/// <summary>
	/// delegateのコールバックで呼び出されるメソッド。
	/// </summary>
	public void DelegateCallbackMethod (string text) {
		Debug.Log ("delegate実行完了 : "+text);
	}

	#endregion
}