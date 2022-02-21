using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }
    }

    public void changeScore(int newScore){
        score+=100;
        text.text = "Gold: "+ score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
