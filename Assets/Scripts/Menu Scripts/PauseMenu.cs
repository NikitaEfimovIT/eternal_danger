using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject mainCanvas;
    
    public void ContinueGame()
    {
        Debug.Log("Continue Game");
        GameObject pauseCanvas = GameObject.FindGameObjectWithTag("PauseMenu");
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1 ;
        mainCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        GameStateManager.Instance.ResumeGame();
    }

    public void QuitGame()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(0);
    }
}
