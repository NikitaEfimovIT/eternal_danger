using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool onPause = false;
    public bool onInventory = false;
    public GameObject pauseCanvas;
    public GameObject inventoryCanvas;

    public GameObject mainCanvas;

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
        if (Input.GetKeyDown(KeyCode.Escape) && !onInventory)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0 ;
            mainCanvas.SetActive(false);
            pauseCanvas.SetActive(true);
            inventoryCanvas.SetActive(false);
            onPause = true;
            onInventory = false;
        }

        if (Input.GetKeyDown(KeyCode.I) && !onPause && !onInventory)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0 ;
            mainCanvas.SetActive(false);
            inventoryCanvas.SetActive(true);
            onInventory = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && onInventory &&!onPause)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1 ;
            mainCanvas.SetActive(true);
            inventoryCanvas.SetActive(false);
            onInventory = false;
        }
    }

    public void ResumeGame()
    {
        onPause = false;
        onInventory = false;
    }

    public void PauseGame()
    {
        onPause = true;
    }
}
