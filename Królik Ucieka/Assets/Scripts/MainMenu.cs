using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private GameObject menu;
    private GameObject mainMenu;
    private GameObject optionsMenu;

    private GameMenager gameMenager;
    private GameObject player;
    private GameObject spawner;
    private GameObject boss;

    public GameObject ui;

    bool isPrimaryOptions=true;

    private void Awake()
    {
        menu = GameObject.Find("Menu");
        mainMenu = GameObject.Find("MainMenu");
        optionsMenu = GameObject.Find("OptionsMenu");
    }

    private void Start()
    {
        gameMenager = FindObjectOfType<GameMenager>();
        player = gameMenager.player;
        spawner = gameMenager.spawner;
        boss = gameMenager.boss;
    }

    public void NewGame()
    {
        Vector3 playerStartPos = new Vector3(5f,0f,0f);
        GameObject newPlayer= Instantiate(player, playerStartPos, Quaternion.identity);
        gameMenager.SetPlayer(newPlayer);
        Vector3 spawnerStartPos = new Vector3(40f, 0, 0);
        Instantiate(spawner, spawnerStartPos, Quaternion.identity);
        Vector3 bossStartPos = new Vector3(-11f, 0, 0);
        GameObject newBoss = Instantiate(boss, bossStartPos, Quaternion.identity);
        CameraFollow myCamera = Camera.main.GetComponent<CameraFollow>();
        myCamera.enabled = true;
        myCamera.SetTarget(newBoss);

        ui = GameObject.Find("UI");

        isPrimaryOptions = false;
        menu.SetActive(false);
    }

    public void OptionsMenu()
    {
        isPrimaryOptions = menu.activeInHierarchy;
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void QuickOptions()
    {
        isPrimaryOptions = menu.activeInHierarchy;
        ui.SetActive(false);
        Time.timeScale = 0;
        menu.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back()
    {
        if (isPrimaryOptions)
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
        if(!isPrimaryOptions)
        {
            optionsMenu.SetActive(false);
            menu.SetActive(false);
            ui.SetActive(true);
            Time.timeScale = 1;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void FB()
    {
        Debug.Log("FB");
        //Application.OpenURL("");
    }
    public void YT()
    {
        Debug.Log("YT");
        //Application.OpenURL("");
    }
    public void GH()
    {
        Debug.Log("GH");
        //Application.OpenURL("");
    }
}
