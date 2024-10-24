using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class roueForaine : MonoBehaviour
{

    public GameObject Triangle;
    public float Speed;
    public float Distance = 0f;

    public float Pos;
    public float Pos1;
    public float Pos2;
    public GameObject Vert;
    public TextMeshProUGUI Score;
    public float Score_var;

    void Start()
    {
        Speed = 1f;
        StartCoroutine(ZoneGood());
    }

    void Update()
    {
        Distance = Triangle.transform.localPosition.x;

        if (Distance < 0.5f)
        { Triangle.transform.localPosition += Vector3.right * Speed * Time.deltaTime; }

        else if (Distance > 0.5f)
        { Triangle.transform.localPosition = new Vector3(-0.5f, -1.55f, 0); }

        Vert.transform.localPosition = new Vector3(Pos, 0, 0.01f);

        if (Input.GetKeyDown(KeyCode.Space) && Triangle.transform.localPosition.x <= Pos2 && Triangle.transform.localPosition.x >= Pos1)
        {
            Score_var += 100;
        }
        Score.text = "Score :" + Score_var;
    }
    
    IEnumerator ZoneGood()
    {
        Pos = Random.Range(-0.4f, 0.4f);
        Pos1 = Pos - 0.05f;
        Pos2 = Pos + 0.05f;
        yield return new WaitForSeconds(2);
        
        StartCoroutine(ZoneGood());
    }


}






