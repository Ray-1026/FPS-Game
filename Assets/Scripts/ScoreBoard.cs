using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    public int total;
    public static int score;

    public Text showscore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        showscore.text = "Killed : " + score.ToString() + " / " + total.ToString();
        if (score >= total || Input.GetKey("p"))
        {
            if (Player.level < 3 || SceneManager.GetActiveScene().buildIndex != 5)
            {
                Player.level = SceneManager.GetActiveScene().buildIndex - 1;
                SceneManager.LoadScene(6);
            }
            //Debug.Log(Player.level);
            else
            {
                SceneManager.LoadScene(9);
            }
        }
    }
}
