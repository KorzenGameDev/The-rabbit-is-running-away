using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{
    private GameObject menu;
    private GameObject mainMenu;
    private GameObject optionsMenu;
    private GameObject playerUI;

    public GameObject player;
    public GameObject spawner;
    public GameObject boss;

    public GameObject win;
    public GameObject lose;

    public AudioSource audioSource;


    private void Awake()
    {
        menu = GameObject.Find("Menu");
        mainMenu = GameObject.Find("MainMenu");
        optionsMenu = GameObject.Find("OptionsMenu");
        audioSource.GetComponent<AudioSource>();
    }

    private void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        win.SetActive(false);
        lose.SetActive(false);
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    public void Win()
    {
        win.SetActive(true);
        playerUI = FindObjectOfType<MainMenu>().ui;
        playerUI.SetActive(false);
    }
    public void Lose()
    {
        lose.SetActive(true);
        playerUI = FindObjectOfType<MainMenu>().ui;
        playerUI.SetActive(false);
    }

    public void EndButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
