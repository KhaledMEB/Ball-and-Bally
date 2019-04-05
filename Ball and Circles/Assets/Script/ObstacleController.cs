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
            FindObjectOfType<LevelManager>().GrennLights();
        }
            
    }


    public void StopObstacle()
    {
        obstacles[i].GetComponent<CircleRotation>().enabled = false;
        CheckObstaclesNumber();
    }

    public void Undo()
    {
            if (i > 0)
            {
                if (i == obstacles.Length)
                {
                    FindObjectOfType<UIManager>().EnableStopButton();
                    FindObjectOfType<LevelManager>().RedLights();
                }
                i--;
                obstacles[i].GetComponent<CircleRotation>().enabled = true;
            }

            else
                FindObjectOfType<UIManager>().UndoShake();
    }

}
