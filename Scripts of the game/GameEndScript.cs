using TMPro;
using UnityEngine;

public class GameEndScript : MonoBehaviour
{
    
    public GameObject GameEndMenu;
    public CameraScript CameraScript;
    public TimerScript TimerScript;
    public GameObject Timer;
    public TextMeshProUGUI Score;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();

        if (player != null )

        {
            if(collision.gameObject.CompareTag("Player"))
            {
                Time.timeScale = 0;
                GameEndMenu.SetActive(true);
                TimerScript.startTimer = false;
                Score.text = $"{Mathf.Ceil(TimerScript.Timer)}s";
                
                

            }
        }

       
    }
}
