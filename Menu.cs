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
        SceneManager.LoadScene(0);//при нажатии кнопки "Play" запускается основная сцена
    }
    public void Quit()
    {
        Application.Quit();//выход из игры
    }
}
