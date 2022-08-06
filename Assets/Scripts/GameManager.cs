using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int totalVermelhosFim, totalVerdeInicioFim, totalAzulInicioFim, totalAmareloInicioFim;

    public Vector3 PlayerVermelho1Pos, PlayerVermelho2Pos, PlayerVermelho3Pos, PlayerVermelho4Pos;
    public Vector3 PlayerVerde1Pos, PlayerVerde2Pos, PlayerVerde3Pos, PlayerVerde4Pos;
    public Vector3 PlayerAzul1Pos, PlayerAzul2Pos, PlayerAzul3Pos, PlayerAzul4Pos;
    public Vector3 PlayerAmarelo1Pos, PlayerAmarelo2Pos, PlayerAmarelo3Pos, PlayerAmarelo4Pos;

    //Controlar a saida de um player da sua casa inicial
    public Button PlayerVermelho1Botao, PlayerVermelho2Botao, PlayerVermelho3Botao, PlayerVermelho4Botao;
    public Button PlayerVerde1Botao, PlayerVerde2Botao, PlayerVerde3Botao, PlayerVerde4Botao;
    public Button PlayerAzul1Botao, PlayerAzul2Botao, PlayerAzul3Botao, PlayerAzul4Botao;
    public Button PlayerAmarelo1Botao, PlayerAmarelo2Botao, PlayerAmarelo3Botao, PlayerAmarelo4Botao;

    private string playerTurn = "Vermelho";
    private string currentPlayer = "none";
    private string currentPlayerName = "none";

    // Controle do movimento dos jogadores
    public GameObject PlayerVermelho1, PlayerVermelho2, PlayerVermelho3, PlayerVermelho4;
    public GameObject PlayerVerde1, PlayerVerde2, PlayerVerde3, PlayerVerde4;
    public GameObject PlayerAzul1, PlayerAzul2, PlayerAzul3, PlayerAzul4;
    public GameObject PlayerAmarelo1, PlayerAmarelo2, PlayerAmarelo, PlayerAmarelo4;

    // Tracking dos steps dos jogadores, aonde eles estão no mapa
    private int PlayerVermelho1Passos, PlayerVermelho2Passos, PlayerVermelho3Passos, PlayerVermelho4Passos;
    private int PlayerVerde1Passos, PlayerVerde2Passos, PlayerVerde3Passos, PlayerVerde4Passos;
    private int PlayerAzul1Passos, PlayerAzul2Passos, PlayerAzul3Passos, PlayerAzul4Passos;
    private int PlayerAmarelo1Passos, PlayerAmarelo2Passos, PlayerAmarelo3Passos, PlayerAmarelo4Passos;

    public List<GameObject> MovimentacaoVermelhoBloco = new List<GameObject>();
    public List<GameObject> MovimentacaoVerdeBloco = new List<GameObject>();
    public List<GameObject> MovimentacaoAzulBloco = new List<GameObject>();
    public List<GameObject> MovimentacaoAmareloBloco = new List<GameObject>();

    public Transform dado;

    public Button ButtonDado;

    private System.Random randNumber;

    private int selectDadoAnimacao;

	public GameObject Dados1Animacao;
	public GameObject Dados2Animacao;
	public GameObject Dados3Animacao;
	public GameObject Dados4Animacao;
	public GameObject Dados5Animacao;
	public GameObject Dados6Animacao;

	// Random generation of dice numbers...
	private System.Random randomNo;

	void InitializeDice()
	{
		//BotaoDado.interactable = true;

		Dados1Animacao.SetActive(false);
		Dados2Animacao.SetActive(false);
		Dados3Animacao.SetActive(false);
		Dados4Animacao.SetActive(false);
		Dados5Animacao.SetActive(false);
		Dados6Animacao.SetActive(false);

		//======== Getting currentPlayer VALUE=======
		if (currentPlayerName.Contains("PLAYER VERMELHO"))
		{
			if (currentPlayerName == "PLAYER VERMELHO 1")
			{
				Debug.Log("currentPlayerName = " + currentPlayerName);
				currentPlayer = PlayerVermelho1_Script.PlayerVermelho1_ColName;
			}
			if (currentPlayerName == "PLAYER VERMELHO 2")
			{
				Debug.Log("currentPlayerName = " + currentPlayerName);
				currentPlayer = PlayerVermelho2_Script.PlayerVermelho2_ColName;
			}
			if (currentPlayerName == "PLAYER VERMELHO 3")
			{
				Debug.Log("currentPlayerName = " + currentPlayerName);
				currentPlayer = PlayerVermelho3_Script.PlayerVermelho3_ColName;
			}
			if (currentPlayerName == "PLAYER VERMELHO 4")
			
				Debug.Log("currentPlayerName = " + currentPlayerName);
				currentPlayer = PlayerVermelho4_Script.PlayerVermelho4_ColName;
		}
	}

	// Click on Roll Button on Dice UI
	public void DiceRoll()
	{
		//SoundManagerScript.diceAudioSource.Play ();
		//BotaoDado.interactable = false;

		selectDadoAnimacao = randomNo.Next(1, 7);

		switch (selectDadoAnimacao)
		{
			case 1:
				Dados1Animacao.SetActive(true);
				Dados2Animacao.SetActive(false);
				Dados3Animacao.SetActive(false);
				Dados4Animacao.SetActive(false);
				Dados5Animacao.SetActive(false);
				Dados6Animacao.SetActive(false);
				break;

			case 2:
				Dados1Animacao.SetActive(false);
				Dados2Animacao.SetActive(true);
				Dados3Animacao.SetActive(false);
				Dados4Animacao.SetActive(false);
				Dados5Animacao.SetActive(false);
				Dados6Animacao.SetActive(false);
				break;

			case 3:
				Dados1Animacao.SetActive(false);
				Dados2Animacao.SetActive(false);
				Dados3Animacao.SetActive(true);
				Dados4Animacao.SetActive(false);
				Dados5Animacao.SetActive(false);
				Dados6Animacao.SetActive(false);
				break;

			case 4:
				Dados1Animacao.SetActive(false);
				Dados2Animacao.SetActive(false);
				Dados3Animacao.SetActive(false);
				Dados4Animacao.SetActive(true);
				Dados5Animacao.SetActive(false);
				Dados6Animacao.SetActive(false);
				break;

			case 5:
				Dados1Animacao.SetActive(false);
				Dados2Animacao.SetActive(false);
				Dados3Animacao.SetActive(false);
				Dados4Animacao.SetActive(false);
				Dados5Animacao.SetActive(true);
				Dados6Animacao.SetActive(false);
				break;

			case 6:
				Dados1Animacao.SetActive(false);
				Dados2Animacao.SetActive(false);
				Dados3Animacao.SetActive(false);
				Dados4Animacao.SetActive(false);
				Dados5Animacao.SetActive(false);
				Dados6Animacao.SetActive(true);
				break;
		}
	}

	private void Start()
	{
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = 30;

		randomNo = new System.Random();

		Dados1Animacao.SetActive(false);
		Dados2Animacao.SetActive(false);
		Dados3Animacao.SetActive(false);
		Dados4Animacao.SetActive(false);
		Dados5Animacao.SetActive(false);
		Dados6Animacao.SetActive(false);

		// Players initial positions.....
		PlayerVermelho1Pos = PlayerVermelho1.transform.position;
		PlayerVermelho2Pos = PlayerVermelho2.transform.position;
		PlayerVermelho3Pos = PlayerVermelho3.transform.position;
		PlayerVermelho4Pos = PlayerVermelho4.transform.position;

	}
}
