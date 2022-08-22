using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Transform[] caminho;

    [SerializeField]
    private float moveSpeed = 50f;

    [HideInInspector]
    public int caminhoIndex = 0;

    public bool moveAllowed = false;

    public bool Escolhido = false;

    public string Cor;

    // Use this for initialization
    private void Start()
    {
    
    }

    private bool PodeMover()
    {
        return Escolhido;
    }

    // Update is called once per frame
    private void Update()
    {
        if (moveAllowed)
            Move();
    }

    private void Move()
    {
        if (caminhoIndex <= caminho.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            caminho[caminhoIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == caminho[caminhoIndex].transform.position)
            {
                caminhoIndex += 1;
            }
        }
    }

    public void LiberaPersonagem()
    {
        Escolhido = true;
        moveAllowed = true;
    }

    public void FoiClicado()
    {
        if (GameManager.Instance.CorJogadorVez() == Cor 
            && GameManager.Instance.VerificaSeDadoFoiJogado()) 
        {
            LiberaPersonagem();
        }

        //Atualiza jogador da vez
    }

    public void IniciaMovimento()
    {
        
        if(Escolhido == true)
        {
            moveAllowed = true;
        }

    }


}
