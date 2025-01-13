using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{

    public GameObject GameOverScreen;

    public float Timer;
    public TextMeshProUGUI Timertext;
    [SerializeField] private CameraScript CameraScript;

    public bool startTimer;
  
    void Start()
    {
       Timertext = GetComponent<TextMeshProUGUI>();
        Time.timeScale = 1;


    }

    // Update is called once per frame
    void Update()
    {

       
        if (startTimer)
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                Timer = 0;
                Time.timeScale = 0;
                GameOver();
            }
           

            Timertext.text = $"{Mathf.Ceil(Timer)}s";
            
         
        }
    }


    private void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

   
}
