using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableDisable : MonoBehaviour
{
    public GameObject ObjectOnOff;
    public bool isEnabled = true;
    public void ButtonClicked()
    {
        isEnabled = !isEnabled;
        ObjectOnOff.SetActive(isEnabled);


    }

}
