using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour //главное меню
{
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene(1);//при нажатии кнопки "Play" запускается основная сцена
    }
    public void Lvl1()
    {
        SceneManager.LoadScene(1);
    }
    public void Lvl2()
    {
        SceneManager.LoadScene(2);
    }
    public void Lvl3()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();//выход из игры
    }
}
