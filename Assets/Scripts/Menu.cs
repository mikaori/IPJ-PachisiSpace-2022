using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Menu : MonoBehaviour
{
    [SerializeField] private string nextScene;

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        SoundManager.startPlayerAudioSource.Play();
        SceneManager.LoadScene(nextScene);
    }

    public void Sair()
    {
        Application.Quit();
    }
}