using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSprite : MonoBehaviour
{
    public GameObject GO;
    private void kill()
    {
        Destroy(GO);
    }


}
