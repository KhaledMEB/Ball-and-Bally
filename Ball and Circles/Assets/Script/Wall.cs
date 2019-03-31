using UnityEngine;

public class Wall : MonoBehaviour {

    public Camera mainCamera;

    public Transform topWall;
    public Transform bottomWall;
    public Transform rightWall;
    public Transform leftWall;

    void Start () {
        topWall.position = new Vector2(0f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y - 0.05f);
        bottomWall.position = -topWall.position;

        rightWall.position = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x - 0.05f, 0f);
        leftWall.position = -rightWall.position;

        Destroy(this);
    }

}
