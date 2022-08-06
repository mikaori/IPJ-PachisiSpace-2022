using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVermelho2_Script : MonoBehaviour
{
	public static string PlayerVermelho2_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks")
		{
			PlayerVermelho2_ColName = col.gameObject.name;
			//if (col.gameObject.name.Contains("Safe House"))
			//{
			//SoundManager.safeHouseAudioSource.Play();
			//}
		}
	}

	void Start()
	{
		PlayerVermelho2_ColName = "none";
	}
}
