using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class inputforclick : MonoBehaviour
{
    public float BestScore = 2f;
    public float timer = 0;
    public bool IsGreen;
    public float Delay = 0;
    public Color Color = Color.green;
    public SpriteRenderer SR;
    public float Score_Var;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI BestTime;

    void Start()
    {
        StartCoroutine(allumeToi());
        IsGreen = false;

    }
    private void Update()
    {
        if (IsGreen == true)
        { timer += Time.deltaTime; }

        /////////////////////////////////////////////////////////////

        if (IsGreen == true && Input.GetKeyDown(KeyCode.Space))
        {
            Score_Var += 100;
            if (BestScore > timer)
            { BestScore = timer; }
        }
        //////////////////////////////////////////////////////////////
        Score.text = "Score :" + Score_Var;
        Text.text = timer.ToString();
        BestTime.text = BestScore.ToString();
    }
    IEnumerator allumeToi()
    {
        Delay = Delay - Delay;
        Delay += UnityEngine.Random.Range(1f, 5f);
        yield return new WaitForSeconds(Delay);
        IsGreen = true;
        SR.color = Color;
        yield return new WaitForSeconds(2);
        SR.color=Color.white;
        IsGreen = false; 
        timer = 0f;
        StartCoroutine(allumeToi());
    }

   

    
    
}

//SR.color = color;
