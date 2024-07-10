using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    private int _score;
    public TMP_Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(scoreText);
        // scoreText = GetComponent<TextMeshProUGUI>();
        // Debug.Log(scoreText);
        scoreText.SetText("Score: " + Score.Point);
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.Point != _score)
        {
            scoreText.SetText("Score: " + Score.Point);
        }
        _score = Score.Point;
    }
}
