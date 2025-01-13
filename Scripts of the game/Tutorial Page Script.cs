using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPageScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] tutorialPages; // Array to store tutorial pages
    private int currentPage = 0;       // Tracks the current page index

    public void ShowNextPage()
    {
        if (currentPage < tutorialPages.Length - 1)
        {
            tutorialPages[currentPage].SetActive(false); // Hide current page
            currentPage++;                              // Increment page index
            tutorialPages[currentPage].SetActive(true); // Show next page
        }
    }

    public void ShowPreviousPage()
    {
        if (currentPage > 0)
        {
            tutorialPages[currentPage].SetActive(false); // Hide current page
            currentPage--;                              // Decrement page index
            tutorialPages[currentPage].SetActive(true); // Show previous page
        }
    }


    [SerializeField] GameObject tutorialMenu;
   






    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Pause()
    {


        tutorialMenu?.SetActive(true);
       
       
        
    }

    public void Resume()
    {

        tutorialMenu?.SetActive(false);
       
       

    }

}
