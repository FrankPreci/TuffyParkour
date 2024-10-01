using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {//Cursor will not be visible or movable while gamOverUI is inactive
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {//when you die gameOverUI becomes active and so makes MOUSE usable again
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
    public void GameOverUI()
    {
        gameOverUI.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    
}
