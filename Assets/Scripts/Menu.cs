using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Menu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            SoundManager.startPlayerAudioSource.Play();
            SceneManager.LoadScene("Ludo");
        }


    }
}