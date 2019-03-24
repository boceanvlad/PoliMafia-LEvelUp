using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //
    public GameObject StartMenu;
    public MovieTexture movieTexture;

    
    void Awake()
    {
        if (movieTexture != null)
        {
            movieTexture.Play();
        }
    }

    void Start()
    {
        StartMenu.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && movieTexture.isPlaying)
        {
            movieTexture.Stop();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    void OnGUI()
    {
        if (movieTexture != null && movieTexture.isPlaying)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movieTexture, ScaleMode.StretchToFill);
        }
    }
}
