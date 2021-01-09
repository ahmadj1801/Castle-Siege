using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public void Play_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

    public void Quit_Game()
    {
        Application.Quit();
    }

    public void Load_How_To_Play()
    {
        //Code
        SceneManager.LoadScene("How_To_Play");
    }

    public void Load_Main_Menu()
    {
        //Code
        SceneManager.LoadScene("Main_Menu");
    }
}
