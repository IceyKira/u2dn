using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText; // 文本框对象
    public GameObject Player;
    private float score = 0; // 游戏得分
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score = Player.transform.position.y * 100;
        UpdateScoreText();
    }

    // 更新文本框中的得分
    void UpdateScoreText()
    {
        scoreText.text = "Height: " + score.ToString("f0");
    }
}
