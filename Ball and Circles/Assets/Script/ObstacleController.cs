using UnityEngine;

public class ObstacleController : MonoBehaviour {


    public GameObject[] obstacles;

    private bool canUndo = true; //to disable rewind when Ball is launched

    private static int cptObstacleStoped = 0;


    private void Awake()
    {
        cptObstacleStoped = 0;
    }
    private void CheckObstaclesNumber()
    {
        cptObstacleStoped++; //number of stoped Obstacle
        if (cptObstacleStoped == obstacles.Length) //All colliders are stopped
        {
            FindObjectOfType<UIManager>().DesableStopButton();
            FindObjectOfType<LevelManager>().GrennLights();
        }
            
    }


    public void StopObstacle()
    {
        obstacles[cptObstacleStoped].GetComponent<CircleRotation>().enabled = false;
        CheckObstaclesNumber();
    }

    public void Undo()
    {
            if ((cptObstacleStoped > 0)&&(canUndo))
            {

                if (cptObstacleStoped == obstacles.Length)
                {
                    FindObjectOfType<UIManager>().EnableStopButton();
                    FindObjectOfType<LevelManager>().RedLights();
                }
                cptObstacleStoped--;
                obstacles[cptObstacleStoped].GetComponent<CircleRotation>().enabled = true;
                
            }

            else
                FindObjectOfType<UIManager>().UndoShake();
    }


    public void SetCanUndo(bool x)
    {
        canUndo = x;
    }

}
