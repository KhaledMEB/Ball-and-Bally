using UnityEngine;

public class PlayerMoves : MonoBehaviour {

    
    public float speed;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void LaunchBall(Vector2 direction)
    {
        StartRecording();
        FindObjectOfType<ObstacleController>().SetCanUndo(false);
        rb.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void StartRecording()
    {
        FindObjectOfType<Rewind>().StartRecording();
    }


}
