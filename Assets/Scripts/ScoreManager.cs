using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText; // �ı������
    public GameObject Player;
    private float score = 0; // ��Ϸ�÷�
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

    // �����ı����еĵ÷�
    void UpdateScoreText()
    {
        scoreText.text = "Height: " + score.ToString("f0");
    }
}
