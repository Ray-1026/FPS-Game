using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        int status = Player.level;
        SceneManager.LoadScene(status + 2);
    }
}
