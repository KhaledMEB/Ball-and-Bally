using UnityEngine;

public class CircleRotation : MonoBehaviour {

    [Range(-1, 1)]
    public int direction;
    public float speedRotation;


	void Update () {
        transform.Rotate(Vector3.forward, speedRotation * direction *Time.deltaTime);
	}
}
