using UnityEngine;
using System.Collections;

public class BallCollision : MonoBehaviour {

    public GameObject collisionEffect;
    public ParticleSystem exploisionEffect;
    public Animator cameraShakeAnim;

    private LevelManager levelManager;
    private UIManager uiManager;
    private Rigidbody2D rb;
    private int collisionCpt;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        collisionCpt = levelManager.GetCollisionCounter();

        uiManager = FindObjectOfType<UIManager>();
        uiManager.UpdateCollisionCpt(collisionCpt);

        rb = GetComponent<Rigidbody2D>();
    }

    private void HideBall()
    {
        rb.velocity = Vector2.zero;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;
    }

    private void PlayCollisionEffect()
    {
        GameObject effect = Instantiate(collisionEffect, transform.position, Quaternion.identity);
        effect.SetActive(true);
        Destroy(effect, 0.5f);
    }

    private void PlayExploisionEffect()
    {
        HideBall();
        exploisionEffect.Play();
        //Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string colliderTag = collision.collider.tag;

        if (colliderTag == "Wall")
        {
            if (collisionCpt == 0)
            {
                GameOver();
            }
                

            else
            {
                
                PlayCollisionEffect();
                ShakeCamera(collision.collider);
                UpdateCollisionCpt();
            }


        }

        else if (colliderTag == "Obstacle")
        {
            GameOver();
        }


        else if (colliderTag == "Goal")
        {
            rb.velocity = Vector2.zero;
            levelManager.PlayWinEffect();
            StartCoroutine("BallDesable"); //hide the ball
        }
    }

    private void UpdateCollisionCpt()
    {
        collisionCpt--;
        uiManager.UpdateCollisionCpt(collisionCpt);
    }

    private void GameOver()
    {
        FindObjectOfType<Rewind>().StopRecording(); //Stop the recording
        PlayExploisionEffect();

        //Must wait for 2 second Until exploision end or do something else
        FindObjectOfType<UIManager>().SetGameOver(true);
        FindObjectOfType<ObstacleController>().SetCanUndo(true);
        }

    private IEnumerator BallDesable()
    {
        yield return new WaitForSeconds(4.8f);
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void ShakeCamera(Collider2D collider)
    {
        if ((collider.name.Equals("Wall_Left"))||(collider.name.Equals("Wall_Right")))
            cameraShakeAnim.SetTrigger("XShake");
        else
            cameraShakeAnim.SetTrigger("YShake");

    }
}
