using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    
    public void  OnStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    
    public void  OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
