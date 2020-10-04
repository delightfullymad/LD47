using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public UI ui;
    public bool isDead;
    public TextMeshPro face;
    public int health = 3;
    public Transform leg1Pos1;
    public Transform leg1Pos2;
    public Transform leg2Pos1;
    public Transform leg2Pos2;
    public LineRenderer legLine;

    public Transform arm1Pos1;
    public Transform arm1Pos2;
    public Transform arm1Pos3;
    public Transform arm2Pos1;
    public Transform arm2Pos2;
    public Transform arm2Pos3;
    public LineRenderer armLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 3)
        {
            face.text = "OwO";
        }
        else if(health == 2)
        {
            face.text = "O_O";
        }
        else if (health == 1)
        {
            face.text = ";_;";
        }
        else if (health <= 0)
        {
            face.text = "X.X";
            isDead = true;
            GetComponent<Animator>().SetTrigger("dead");

        }


        legLine.SetPosition(0, leg1Pos2.position);
        legLine.SetPosition(1, leg1Pos1.position);
        legLine.SetPosition(2, legLine.transform.position);
        legLine.SetPosition(3, leg2Pos1.position);
        legLine.SetPosition(4, leg2Pos2.position);

        armLine.SetPosition(0, arm1Pos1.position);
        armLine.SetPosition(1, arm1Pos2.position);
        armLine.SetPosition(2, arm1Pos3.position);
        armLine.SetPosition(3, armLine.transform.position);
        armLine.SetPosition(4, arm2Pos3.transform.position);
        armLine.SetPosition(5, arm2Pos1.position);
        armLine.SetPosition(6, arm2Pos2.position);  
    }

    public void DoTrick(Beat beat)
    {
        switch(beat.trick)
        {
            case 0:
                GetComponent<Animator>().SetTrigger("spin");
                break;

            case 1:
                GetComponent<Animator>().SetTrigger("roll");
                break;

            case 2:
                GetComponent<Animator>().SetTrigger("hop");
                break;

            case 3:
                GetComponent<Animator>().SetTrigger("jump");
                break;




        }
    }

    public void GameOver()
    {
        ui.gameOverScreen.SetActive(true);
    }
}
