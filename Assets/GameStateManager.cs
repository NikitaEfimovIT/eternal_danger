using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool onPause = false;
    public GameObject pauseCanvas;

    
    public static GameStateManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Удаляем дублирующийся объект
            return;
        }

        Instance = this; // Сохраняем ссылку на текущий объект
        Time.timeScale = 1 ;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject mainCanvas = GameObject.FindGameObjectWithTag("Canvas");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape");
            Debug.Log(pauseCanvas);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0 ;
            mainCanvas.SetActive(false);
            pauseCanvas.SetActive(true);
            onPause = true;
        }
    }

    public void ResumeGame()
    {
        onPause = false;
    }

    public void PauseGame()
    {
        onPause = true;
    }
}
