using UnityEngine;

public class ObstacleController : MonoBehaviour {


    public GameObject[] obstacles;

    private static int i = 0;


    private void Awake()
    {
        i = 0;
    }
    private void CheckObstaclesNumber()
    {
        i++;
        if (i == obstacles.Length) //All colliders are stopped
        {
            FindObjectOfType<UIManager>().DesableStopButton();
            FindObjectOfType<LevelManager>().SwitchLights();
        }
            
    }


    public void StopObstacle()
    {

        obstacles[i].GetComponent<CircleRotation>().enabled = false;
        CheckObstaclesNumber();
    }

    
}
