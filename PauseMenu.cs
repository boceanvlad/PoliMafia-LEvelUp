using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    //
    public GameObject PauseUI;
    public GameObject sunet;
    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update(){

        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }

    }
    public void Resume()
    {
        paused = false;
    }

    public void Sound()
    {
        if (sunet.activeInHierarchy)
        {
            sunet.SetActive(false);
        }
        else
        {
            sunet.SetActive(true);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
