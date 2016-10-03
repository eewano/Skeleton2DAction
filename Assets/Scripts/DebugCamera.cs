using UnityEngine;

public class DebugCamera : MonoBehaviour {

    private Vector3 cameraPos;
    [SerializeField]
    private float moveSpeed = 0.02f;

    void Start() {
        cameraPos = transform.localPosition;
    }

    void Update() {
        cameraPos.x += moveSpeed;
        transform.localPosition = cameraPos;
    }
}