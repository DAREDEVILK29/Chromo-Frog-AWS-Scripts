using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    bool pause;
    private PauseMenuScript script;
    
    private void Awake()
    {
        script = pauseMenu.GetComponent<PauseMenuScript>();
    }
       
    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
         
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!script.GamePaused)
            {

                Pause();
            }
            else
            {
                Resume();
            }
        }



    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        script.GamePaused = true;
        Time.timeScale = 0f;  // Freezes the game
    }

    public void Resume()
    {
        pauseMenu?.SetActive(false);
        script.GamePaused = false;
        Time.timeScale = 1f;  // Resumes normal game speed
    }

  
}


