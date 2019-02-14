using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyEvent : MonoBehaviour
{
	public void listenForStart()
	{
		StartCoroutine("listenAnyKey");
	}

	private IEnumerator listenAnyKey()
	{
		yield return new WaitUntil(() => Input.anyKey);
		SceneManager.LoadScene("Stage");
	}
}