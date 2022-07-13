using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAudio : MonoBehaviour
{
    public AudioSource S_Utopia;
    public AudioSource S_Distopia;
    private bool ButtonPressed = true;

    public void SwapSound()
    {
        if (ButtonPressed)
        {
            ButtonPressed = false;
            S_Distopia.mute = true;
            S_Utopia.Play();
        }

        else
        {
            ButtonPressed = true;
            S_Distopia.mute = false;
            S_Utopia.Pause();
        }
    }
}
