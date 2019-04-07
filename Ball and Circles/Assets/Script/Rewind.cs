using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour {

    /*IMPORTANT POINT
     *MAKE SURE TO ENABLE REWINDE ONLY OF PLAYER HAS ENOUGH COINS TO OFFERD IT
     *TO NOT DICREASE GAME PERFORMANCE
     *DO NOT FORGET TO STOP REWIND AFTER WINNIG LEVEL
     *DO NOT FORGET TO RESET THE COLLIDER COUNTER AFTER REWIND
     */ 

    public bool isRewinding = false;
    public bool isRecording = false;

    private List<Vector3> positions;


	void Start () {
        positions = new List<Vector3>();
        positions.Insert(0, new Vector2(0f, -5.5f));
	}



    private void FixedUpdate()
    {
        if (isRewinding)
            RewindIt();
        else if(isRecording)
            RecordIt();
    }

    private void RewindIt()
    {
        if (positions.Count == 0) //End of Rewind
        {
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<TrailRenderer>().enabled = true;
            GetComponent<GuideLine>().enabled = true;
            FindObjectOfType<UIManager>().SetRaycastAllowed(true);
            StopRewind();
            /*RESET THE COLLIDER COUNTER AFTER REWIND*/
        }
        else
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
                   
    }

    private void RecordIt()
    {
        positions.Insert(0, transform.position);
        Debug.Log(transform.position); /************************/
        }

        public void StartRewind()
    {
        Time.timeScale *= 2;
        GetComponent<SpriteRenderer>().enabled = true; //make ball visible again
        isRewinding = true;
    }

    public void StopRewind()
    {
        Time.timeScale /= 2;
        isRewinding = false;
    }


    public void StartRecording()
    {
        isRecording = true;
    }

    public void StopRecording()
    {
        isRecording = false;
    }

}
