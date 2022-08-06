using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVermelho1_Script : MonoBehaviour
{
	public static string PlayerVermelho1_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks")
		{
			PlayerVermelho1_ColName = col.gameObject.name;
			//if (col.gameObject.name.Contains("Safe House"))
			//{
				//SoundManager.safeHouseAudioSource.Play();
			//}
		}
	}

	void Start()
	{
		PlayerVermelho1_ColName = "none";
	}
}
