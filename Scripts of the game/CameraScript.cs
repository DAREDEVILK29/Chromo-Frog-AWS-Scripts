using UnityEngine;
using Unity.Cinemachine;
using System.Collections;
using TMPro;

public class CameraScript : MonoBehaviour
{
    private CinemachineCamera mainCamera; // Reference to the Cinemachine camera
    private Vector3 originalPosition;           // Stores the original position
    public Transform ObjCamera;                 // Target position
    public float panSpeed = 2f;                 // Speed of the camera movement
    private bool movingToTarget = true;         // Starts by moving to the target
    private bool movingBack = false;
    public bool setTimer;
    public TextMeshProUGUI Timer;
    public TimerScript TimerScript;
    public GameObject timerPanel;


    void Start()
    {
        // Initialize references
        mainCamera = GetComponent<CinemachineCamera>();
        TimerScript = Timer.GetComponent<TimerScript>();

        // Save the original position of the camera's follow target
        if (mainCamera.Follow != null)
            originalPosition = mainCamera.Follow.position;
    }

    void Update()
    {
        timerPanel.SetActive(true);
        StartCoroutine(CameraPan());
           
    }

    private IEnumerator CameraPan()
    {
        yield return new WaitForSeconds(1f);

        if (movingToTarget)
        {
            // Smoothly move to the target position
            mainCamera.Follow.position = Vector3.Lerp(mainCamera.Follow.position, ObjCamera.position, panSpeed * Time.deltaTime);

            // Check if the camera has reached the target position
            if (Vector3.Distance(mainCamera.Follow.position, ObjCamera.position) < 0.1f)
            {
                movingToTarget = false; // Stop moving to the target
                movingBack = true;     // Start moving back
            }
        }
        else if (movingBack)
        {
            // Smoothly move back to the original position

            mainCamera.Follow.position = Vector3.Lerp(mainCamera.Follow.position, originalPosition, panSpeed * Time.deltaTime);
            mainCamera.Priority = 0;
            TimerScript.startTimer = true;
           

            // Check if the camera has returned to the original position
            if (Vector3.Distance(mainCamera.Follow.position, originalPosition) < 0.1f)
            {
                movingBack = false;
                // Stop moving back


            }
        }
      

    }
}
