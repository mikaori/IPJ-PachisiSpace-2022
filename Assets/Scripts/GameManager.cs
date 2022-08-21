using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	// identifica o jogador que deve jogar
	public Text JogadorText;

	// identifica qual é o jogador da vez ("que está jogando agora") 
	private int JogadorVez=0;

	// list com a cor de cada jogador
	private List<string> jogadorEscolheu = MenuColor.jogadorEscolheu; 

	public Vector3 PlayerVermelho1Pos, PlayerVermelho2Pos, PlayerVermelho3Pos, PlayerVermelho4Pos;
	public int PlayerVermelho1Index = 0;
	public bool PlayerVermelho1moveAllowed;

	// Controle do movimento dos jogadores
	public static GameObject PlayerVermelho1, PlayerVermelho2, PlayerVermelho3, PlayerVermelho4;
    public GameObject PlayerVerde1, PlayerVerde2, PlayerVerde3, PlayerVerde4;
    public GameObject PlayerAzul1, PlayerAzul2, PlayerAzul3, PlayerAzul4;
    public GameObject PlayerAmarelo1, PlayerAmarelo2, PlayerAmarelo, PlayerAmarelo4;

    // Tracking dos steps dos jogadores, aonde eles estão no mapa

    public List<GameObject> MovimentacaoVermelhoBloco = new List<GameObject>();
    public List<GameObject> MovimentacaoVerdeBloco = new List<GameObject>();
    public List<GameObject> MovimentacaoAzulBloco = new List<GameObject>();
    public List<GameObject> MovimentacaoAmareloBloco = new List<GameObject>();

	public List<GameObject> CasasStars = new List<GameObject>();

	public Transform dado;

    public Button ButtonDado;

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
		ButtonDado.interactable = true;

		Dados1Animacao.SetActive(false);
		Dados2Animacao.SetActive(false);
		Dados3Animacao.SetActive(false);
		Dados4Animacao.SetActive(false);
		Dados5Animacao.SetActive(false);
		Dados6Animacao.SetActive(false);

	}

	// Click on Roll Button on Dice UI
	public void DiceRoll()
	{
		// Desativa o botão do dado
		ButtonDado.interactable = false;

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

		GameObject player = PlayerVermelho1;
		MovePlayer(player);
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

		PlayerVermelho1 = GameObject.Find("Vermelho-1");

		AlteraJogadorText();

		PlayerVermelho1moveAllowed = false;

		// Players initial positions.....
		PlayerVermelho1Pos = MovimentacaoVermelhoBloco[PlayerVermelho1Index].transform.position;
		//PlayerVermelho2Pos = PlayerVermelho2.transform.position;
		//PlayerVermelho3Pos = PlayerVermelho3.transform.position;
		//PlayerVermelho4Pos = PlayerVermelho4.transform.position;
	}

	private void Update()
    {
		if (PlayerVermelho1.GetComponent<PlayerScript>().caminhoIndex >
		   PlayerVermelho1Index + selectDadoAnimacao)
		{
			PlayerVermelho1.GetComponent<PlayerScript>().moveAllowed = false;
			PlayerVermelho1Index = PlayerVermelho1.GetComponent<PlayerScript>().caminhoIndex - 1;

			// Ativa o botão do dado
			ButtonDado.interactable = true;
		}
	}

	public static void MovePlayer(GameObject player)
	{
		player.GetComponent<PlayerScript>().moveAllowed = true;	
	}

	private void AlteraJogadorText()
    {
		JogadorText.text = "Jogador " + (JogadorVez+1).ToString();
	}

}
