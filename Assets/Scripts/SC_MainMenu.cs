using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject HowToMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayButton()
    {
        StaticHolder.GAMEMODE = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelect");
    }

    public void MultiplayerButton()
    {
        StaticHolder.GAMEMODE = 2;
        UnityEngine.SceneManagement.SceneManager.LoadScene("prototyping");
    }

    public void CreditsButton()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void HowToButton()
    {
        MainMenu.SetActive(false);
        HowToMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
