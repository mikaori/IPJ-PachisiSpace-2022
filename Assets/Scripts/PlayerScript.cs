using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform[] caminho;

    [SerializeField]
    private float moveSpeed = 50f;

    [HideInInspector]
    public int caminhoIndex = 0;

    public bool moveAllowed = false;

    private bool Escolhido = false;

    // Use this for initialization
    private void Start()
    {

    }

    private bool PodeMover()
    {
        if (!Escolhido) return false;
        return moveAllowed;
    }

    // Update is called once per frame
    private void Update()
    {
        if (PodeMover())
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
}
