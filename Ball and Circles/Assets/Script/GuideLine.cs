using UnityEngine;

public class GuideLine : MonoBehaviour {

    public LineRenderer guide; //the guide line
    public float rayDistance = 0f; //distance to check for Raycast collision
    public float minTouchPosition = -4.5f;

    private Vector2 origin = new Vector2(0, -5.5f);
    private Vector2 direction; //direction to shoot the ball with
    private int layer_mask;
    private int layer_mask2;
    private Vector2 reflectDir;


    private void Start()
    {
        layer_mask = LayerMask.GetMask("Wall", "Circle", "Collider", "InvisibleWall");
        layer_mask2 = LayerMask.GetMask("MidleWall", "InvisibleWall", "Circle");
    }

    private void Update()
    {
        
        if (Input.touchCount > 0)

        {            
            /*Get the position of the touch*/
            Touch touch = Input.GetTouch(0);            
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touchPosition.y >= minTouchPosition)
            {

                direction = touchPosition - origin;
                RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayDistance, layer_mask);

                /*Ad first point to guideLine*/
                guide.positionCount = 2;
                guide.SetPosition(1, hit.point);

                /*Check for collision with walls*/
                if (hit.collider.tag == "Wall")
                {
                    reflectDir = Vector2.Reflect(direction, hit.normal);
                    RaycastHit2D hit2;
                    hit2 = Physics2D.Raycast(hit.point, reflectDir, rayDistance, layer_mask2);

                    guide.positionCount = 3;
                    guide.SetPosition(2, hit2.point);
                }

                guide.enabled = true;

                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    OnTouchEnded();
                }
            }

            else
                guide.enabled = false;

        }
    }


    private void OnTouchEnded()
    {
        FindObjectOfType<PlayerMoves>().LaunchBall(direction.normalized);
        this.enabled = false;
        FindObjectOfType<UIManager>().SetRaycastAllowed(false);
        guide.enabled = false;

        //Hide lights
        FindObjectOfType<LevelManager>().HideLights();
    }

}
