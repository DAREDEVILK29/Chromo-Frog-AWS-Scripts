using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMangerScript : MonoBehaviour
{
    [SerializeField] GameObject LevelMenu;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void levelOne()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
    }
    public void levelTwo()
    {
        SceneManager.LoadSceneAsync(2);

        Time.timeScale = 1;
    }
    public void levelThree()
    {
        SceneManager.LoadSceneAsync(3);
        Time.timeScale = 1;
    }


    public void Resume()
    {

        LevelMenu?.SetActive(false);
       
        Time.timeScale = 1f;

    }
}
