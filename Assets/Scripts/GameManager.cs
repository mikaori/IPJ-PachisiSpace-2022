using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	// identifica o jogador que deve jogar
	public Text JogadorText;

	// identifica qual � o jogador da vez ("que est� jogando agora") 
	public int JogadorVez=0;

	// list com a cor de cada jogador
	//private List<string> jogadorEscolheu = MenuColor.jogadorEscolheu;
	private List<string> jogadorEscolheu = gambiList();

	public Vector3 PlayerVermelho1Pos, PlayerVermelho2Pos, PlayerVermelho3Pos, PlayerVermelho4Pos;
	public int PlayerVermelho1Index = 0, PlayerVermelho2Index = 0, PlayerVermelho3Index = 0, PlayerVermelho4Index = 0;
	public int PlayerAmarelo1Index = 0, PlayerAmarelo2Index = 0, PlayerAmarelo3Index = 0, PlayerAmarelo4Index = 0;
	public int PlayerVerde1Index = 0, PlayerVerde2Index = 0, PlayerVerde3Index = 0, PlayerVerde4Index = 0;
	public int PlayerAzul1Index = 0, PlayerAzul2Index = 0, PlayerAzul3Index = 0, PlayerAzul4Index = 0;

	public bool PlayerVermelho1moveAllowed;

	// Controle do movimento dos jogadores
	public static GameObject PlayerVermelho1, PlayerVermelho2, PlayerVermelho3, PlayerVermelho4;
    public static GameObject PlayerVerde1, PlayerVerde2, PlayerVerde3, PlayerVerde4;
    public static GameObject PlayerAzul1, PlayerAzul2, PlayerAzul3, PlayerAzul4;
    public static GameObject PlayerAmarelo1, PlayerAmarelo2, PlayerAmarelo3, PlayerAmarelo4;

    // Tracking dos steps dos jogadores, aonde eles est�o no mapa

    //public List<GameObject> MovimentacaoVermelhoBloco = new List<GameObject>();
    //public List<GameObject> MovimentacaoVerdeBloco = new List<GameObject>();
    //public List<GameObject> MovimentacaoAzulBloco = new List<GameObject>();
    //public List<GameObject> MovimentacaoAmareloBloco = new List<GameObject>();

	public List<GameObject> CasasStars = new List<GameObject>();

	public Transform dado;

    public Button ButtonDado;

    public int selectDadoAnimacao=0;

	public GameObject Dados1Animacao;
	public GameObject Dados2Animacao;
	public GameObject Dados3Animacao;
	public GameObject Dados4Animacao;
	public GameObject Dados5Animacao;
	public GameObject Dados6Animacao;

	// Random generation of dice numbers...
	private System.Random randomNo;

	private static GameManager instance = null;

	public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
				instance = GameObject.Find("GameManager").GetComponent<GameManager>();
            }
			return instance;
        }
    }

	public static List<string> gambiList()
    {
		List<string> list = new List<string>();
		list.Add("vermelho");
		list.Add("verde");
		list.Add("amarelo");
		list.Add("azul");
		return list;
    }

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

	//Verifica se o dado foi jogado.
	//Um exemplo de aplica��o � permitir escolher o jogador apenas depois de rodar o dado.
	public bool VerificaSeDadoFoiJogado()
    {
		return !ButtonDado.interactable;
	}

	// Click on Roll Button on Dice UI
	public void DiceRoll()
	{
		// Desativa o bot�o do dado
		ButtonDado.interactable = false;

		Debug.Log("Rodando o dado");
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


		if (selectDadoAnimacao != 6)
		{
			Debug.Log("Dado diferente de 6");
			switch (CorJogadorVez())
			{
				case "vermelho":
					AtualizaJogador(
						VerificaPersonagemForaDaBase(
							PlayerVermelho1,
							PlayerVermelho2,
							PlayerVermelho3,
							PlayerVermelho4
						)
					);
					Debug.Log("Dado diferente de 6 - caso vermelho");
					break;
				case "verde":
					AtualizaJogador(
						VerificaPersonagemForaDaBase(
							PlayerVerde1,
							PlayerVerde2,
							PlayerVerde3,
							PlayerVerde4
						)
					);
					Debug.Log("Dado diferente de 6 - caso verde");
					break;
				case "azul":
					AtualizaJogador(
						VerificaPersonagemForaDaBase(
							PlayerAzul1,
							PlayerAzul2,
							PlayerAzul3,
							PlayerAzul4
						)
					);
					Debug.Log("Dado diferente de 6 - caso azul");
					break;
				case "amarelo":
					AtualizaJogador(
						VerificaPersonagemForaDaBase(
							PlayerAmarelo1,
							PlayerAmarelo2,
							PlayerAmarelo3,
							PlayerAmarelo4
						)
					);
					Debug.Log("Dado diferente de 6 - caso amarelo");
					break;
			}
		} 
	}

	private bool VerificaPersonagemForaDaBase(GameObject Player1, GameObject Player2, GameObject Player3, GameObject Player4)
    {
		Debug.Log("verifica se tem personagem fora da base");
		if (!Player1.GetComponent<PlayerScript>().Escolhido &&
			!Player2.GetComponent<PlayerScript>().Escolhido &&
			!Player3.GetComponent<PlayerScript>().Escolhido &&
			!Player4.GetComponent<PlayerScript>().Escolhido)
		{
			ButtonDado.interactable = true;
		}
		return true;
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
		PlayerVermelho2 = GameObject.Find("Vermelho-2");
		PlayerVermelho3 = GameObject.Find("Vermelho-3");
		PlayerVermelho4 = GameObject.Find("Vermelho-4");
		PlayerAmarelo1 = GameObject.Find("Amarelo-1");
		PlayerAmarelo2 = GameObject.Find("Amarelo-2");
		PlayerAmarelo3 = GameObject.Find("Amarelo-3");
		PlayerAmarelo4 = GameObject.Find("Amarelo-4");
		PlayerVerde1 = GameObject.Find("Verde-1");
		PlayerVerde2 = GameObject.Find("Verde-2");
		PlayerVerde3 = GameObject.Find("Verde-3");
		PlayerVerde4 = GameObject.Find("Verde-4");
		PlayerAzul1 = GameObject.Find("Azul-1");
		PlayerAzul2 = GameObject.Find("Azul-2");
		PlayerAzul3 = GameObject.Find("Azul-3");
		PlayerAzul4 = GameObject.Find("Azul-4");

		PlayerVermelho1.GetComponent<Button>().onClick.AddListener(() => PlayerVermelho1.GetComponent<PlayerScript>().FoiClicado());
		PlayerVermelho2.GetComponent<Button>().onClick.AddListener(() => PlayerVermelho2.GetComponent<PlayerScript>().FoiClicado());
		PlayerVermelho3.GetComponent<Button>().onClick.AddListener(() => PlayerVermelho3.GetComponent<PlayerScript>().FoiClicado());
		PlayerVermelho4.GetComponent<Button>().onClick.AddListener(() => PlayerVermelho4.GetComponent<PlayerScript>().FoiClicado());
		PlayerVerde1.GetComponent<Button>().onClick.AddListener(() => PlayerVerde1.GetComponent<PlayerScript>().FoiClicado());
		PlayerVerde2.GetComponent<Button>().onClick.AddListener(() => PlayerVerde2.GetComponent<PlayerScript>().FoiClicado());
		PlayerVerde3.GetComponent<Button>().onClick.AddListener(() => PlayerVerde3.GetComponent<PlayerScript>().FoiClicado());
		PlayerVerde4.GetComponent<Button>().onClick.AddListener(() => PlayerVerde4.GetComponent<PlayerScript>().FoiClicado());
		PlayerAmarelo1.GetComponent<Button>().onClick.AddListener(() => PlayerAmarelo1.GetComponent<PlayerScript>().FoiClicado());
		PlayerAmarelo2.GetComponent<Button>().onClick.AddListener(() => PlayerAmarelo2.GetComponent<PlayerScript>().FoiClicado());
		PlayerAmarelo3.GetComponent<Button>().onClick.AddListener(() => PlayerAmarelo3.GetComponent<PlayerScript>().FoiClicado());
		PlayerAmarelo4.GetComponent<Button>().onClick.AddListener(() => PlayerAmarelo4.GetComponent<PlayerScript>().FoiClicado());
		PlayerAzul1.GetComponent<Button>().onClick.AddListener(() => PlayerAzul1.GetComponent<PlayerScript>().FoiClicado());
		PlayerAzul2.GetComponent<Button>().onClick.AddListener(() => PlayerAzul2.GetComponent<PlayerScript>().FoiClicado());
		PlayerAzul3.GetComponent<Button>().onClick.AddListener(() => PlayerAzul3.GetComponent<PlayerScript>().FoiClicado());
		PlayerAzul4.GetComponent<Button>().onClick.AddListener(() => PlayerAzul4.GetComponent<PlayerScript>().FoiClicado());

		AtualizaJogador(false);
	}

	private void VerificaLimiteMovimento(GameObject Player, ref int PlayerIndex)
    {
		

		if (!Player.GetComponent<PlayerScript>().Escolhido ) return;
		
		if (Player.GetComponent<PlayerScript>().caminhoIndex >
		   PlayerIndex + selectDadoAnimacao - 1)
		{		
			Player.GetComponent<PlayerScript>().moveAllowed = false;
			PlayerIndex = Player.GetComponent<PlayerScript>().caminhoIndex - 1;

			ButtonDado.interactable = true;

            if (selectDadoAnimacao != 0)
            {
                AtualizaJogador(true);
            }
            Debug.Log("Verificando o limite de movimento do personagem");
			Debug.Log("PlayerIndex " + PlayerIndex);
			Debug.Log("PlayerIndex " + Player.GetComponent<PlayerScript>().Escolhido);
		}

		
	}

	private void Update()
    {

		VerificaLimiteMovimento(PlayerVermelho1, ref PlayerVermelho1Index);
		VerificaLimiteMovimento(PlayerVermelho2, ref PlayerVermelho2Index);
		VerificaLimiteMovimento(PlayerVermelho3, ref PlayerVermelho3Index);
		VerificaLimiteMovimento(PlayerVermelho4, ref PlayerVermelho4Index);

		VerificaLimiteMovimento(PlayerAmarelo1, ref PlayerAmarelo1Index);
		VerificaLimiteMovimento(PlayerAmarelo2, ref PlayerAmarelo2Index);
		VerificaLimiteMovimento(PlayerAmarelo3, ref PlayerAmarelo3Index);
		VerificaLimiteMovimento(PlayerAmarelo4, ref PlayerAmarelo4Index);

		VerificaLimiteMovimento(PlayerVerde1, ref PlayerVerde1Index);
		VerificaLimiteMovimento(PlayerVerde2, ref PlayerVerde2Index);
		VerificaLimiteMovimento(PlayerVerde3, ref PlayerVerde3Index);
		VerificaLimiteMovimento(PlayerVerde4, ref PlayerVerde4Index);

		VerificaLimiteMovimento(PlayerAzul1, ref PlayerAzul1Index);
		VerificaLimiteMovimento(PlayerAzul2, ref PlayerAzul2Index);
		VerificaLimiteMovimento(PlayerAzul3, ref PlayerAzul3Index);
		VerificaLimiteMovimento(PlayerAzul4, ref PlayerAzul4Index);

	}

	public static void MovePlayer(GameObject player)
	{
		player.GetComponent<PlayerScript>().IniciaMovimento();	
	}

	public void AtualizaJogador(bool passaVez)
    {
        if (passaVez)
        {
			JogadorVez = (JogadorVez + 1) % 4;
		}

		JogadorText.text = (JogadorVez+1).ToString();

		Debug.Log("AtualizaJogador " + JogadorVez);
	}

	public string CorJogadorVez()
    {
		return jogadorEscolheu[JogadorVez];
    }
	
}
