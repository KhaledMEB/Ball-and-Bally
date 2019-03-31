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
        rb.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
    }


}
