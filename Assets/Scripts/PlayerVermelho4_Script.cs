using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVermelho4_Script : MonoBehaviour
{
	public static string PlayerVermelho4_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks")
		{
			PlayerVermelho4_ColName = col.gameObject.name;
			//if (col.gameObject.name.Contains("Safe House"))
			//{
			//SoundManager.safeHouseAudioSource.Play();
			//}
		}
	}

	void Start()
	{
		PlayerVermelho4_ColName = "none";
	}
}
