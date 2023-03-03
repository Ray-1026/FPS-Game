using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneIdx;
    public Button Deny;
    public void StartGame()
    {
        int status = Player.level;
        //Debug.Log(status+" "+ sceneIdx);
        if (status + 2 >= sceneIdx)
        {
            SceneManager.LoadScene(sceneIdx);
        }
        else
        {
            Deny.gameObject.SetActive(true);
            Invoke("SetFalse", 3);
        }
    }

    private void SetFalse()
    {
        Deny.gameObject.SetActive(false);
    }
}