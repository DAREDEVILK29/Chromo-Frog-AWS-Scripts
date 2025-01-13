using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
     [SerializeField] GameObject pauseMenu;
    public bool GamePaused = false;

    public void PauseResume()
    {
        if (!GamePaused)
        {

            Pause();
        }
        else
        {
            Resume();
        }
    }

    

    


    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Pause()
    {
       
        
            pauseMenu.SetActive(true);
            GamePaused = true;
            Time.timeScale = 0f;
        // Freezes the game
    }

    public void Resume()
    {  
        
            pauseMenu?.SetActive(false);
            GamePaused = false;
            Time.timeScale = 1f;
        
    }

}
