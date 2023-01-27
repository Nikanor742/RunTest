using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool pause = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                pause = true;
                Time.timeScale = 0;
            }
            else
            {
                pause = false;
                Time.timeScale = 1;
            }
        }
    }
}
