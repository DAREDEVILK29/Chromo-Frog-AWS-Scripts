using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOvercript : MonoBehaviour
{

    
    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
       
    }
    

    public void Restart()
    {   
        Time.timeScale = 1;
        EggScript.canPassIndex.Clear();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex);
      
        
    }

    public  void nextLevel()
    {    
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        switch (currentSceneIndex)
        {
            case 1:
                EggScript.canPassIndex.Clear();
                SceneManager.LoadSceneAsync(2);
                break;
            case 2:
                EggScript.canPassIndex.Clear();
                SceneManager.LoadSceneAsync(3);
                break;
            case 3:
                EggScript.canPassIndex.Clear();
                SceneManager.LoadSceneAsync(0);
                break;
          
        }
    }
}
