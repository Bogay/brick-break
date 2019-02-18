using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleEvents : MonoBehaviour
{
	public void showAnyKey()
	{
		GameObject anyKey = GameObject.Find("AnyKey");
		Animation anim = anyKey.GetComponent<Animation>();
		anim.Play();
	}
}