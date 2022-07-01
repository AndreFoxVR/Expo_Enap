using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonImage : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;
    // Update is called once per frame
    public void ChangeImage()
    {
        button.image.sprite = newButtonImage;
    }
}
