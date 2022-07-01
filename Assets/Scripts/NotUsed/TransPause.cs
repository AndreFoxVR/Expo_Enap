using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransPause : MonoBehaviour
{
    private bool paused;
    

        // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(1))
        {
            paused = !paused;
            Time.timeScale = paused ? 0 : 1;

        }
    }
}
