using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour//пауза
{
    [SerializeField]
    GameObject pause;
    void Start()
    {
        pause.SetActive(false);//изначально пауза не активна
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //пауза активируется клавишей Escape
        {
            pause.SetActive(true);
            Time.timeScale = 0;

        }
        if (Input.GetKeyDown(KeyCode.C)) //продолжить - "С"
        {
            PauseOff();
        }
        if (Input.GetKeyDown(KeyCode.M))//меню - "М"
        {
            Menu();
        }
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);//подгружается сцена меню
        Time.timeScale = 1;

    }
}
