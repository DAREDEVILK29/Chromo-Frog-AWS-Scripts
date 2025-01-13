using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public GameObject levelMenu;
    public GameObject tutorialMenu;
   

    public void Play()
   {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
    }

   public void Levels()
    {
        levelMenu.SetActive(true);

    }
   public void Exit()
   {
        Application.Quit();
   }

   public void Tutorial()
   {
        tutorialMenu.SetActive(true);
   }

  
}
