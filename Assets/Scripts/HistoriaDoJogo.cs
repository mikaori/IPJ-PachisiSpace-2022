using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoriaDoJogo : MonoBehaviour
{
    public Text textWriter;
    public float delaywriter = 0.05f;
    string caixaDialogo = "Somos um grupo de astronautas e estamos participando de uma competição pela NASA para decidir a equipe que estará na próxima missão espacial, no qual o objetivo é explorar um planeta desconhecido, por isso a equipe que chegar ao objetivo final primeiro, vence!! Vamos nessa?!";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ShowText", caixaDialogo);
    }

    IEnumerator ShowText(string textType)
    {
        textWriter.text = "";
        for( int letter=0; letter < textType.Length; letter++)
        {
            textWriter.text=textWriter.text + textType[letter];
            yield return new WaitForSeconds(delaywriter);
        }
    }
}
