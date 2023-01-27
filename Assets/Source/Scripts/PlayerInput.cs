using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Move => move;

    private float sensitivity = 20;
    private bool touched = false;
    private Vector3 touchPos;
    private float move = 0;

    private void Start()
    {
        touchPos = Input.mousePosition;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touched = true;
            touchPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
            touched = false;

        if (touched)
        {
            move = (touchPos.x - Input.mousePosition.x) / (Screen.width / sensitivity);
            touchPos = Input.mousePosition;
        }
        else
            move = 0;
    }
}
