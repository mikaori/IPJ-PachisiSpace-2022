using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVermelho3_Script : MonoBehaviour
{
	public static string PlayerVermelho3_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks")
		{
			PlayerVermelho3_ColName = col.gameObject.name;
			//if (col.gameObject.name.Contains("Safe House"))
			//{
			//SoundManager.safeHouseAudioSource.Play();
			//}
		}
	}

	void Start()
	{
		PlayerVermelho3_ColName = "none";
	}
}
