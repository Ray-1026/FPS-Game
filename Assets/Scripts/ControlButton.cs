using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    public RawImage img;

    // Start is called before the first frame update

    public void StartGame()
    {
        if (img.gameObject.active != false)
        {
            img.gameObject.SetActive(false);
        }
        else
        {
            img.gameObject.SetActive(true);  
        }
    }

}
