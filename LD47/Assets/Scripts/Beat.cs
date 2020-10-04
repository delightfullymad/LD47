using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Beat : MonoBehaviour
{
    public BeatSpawner spawner;
    public bool used = false;
    public float speed = 3f;
    public bool has2Keys = false;
    public KeyCode keyToPress = KeyCode.UpArrow;
    public KeyCode keyToPress2 = KeyCode.Z;
    public Transform arrowSprite;
    public TextMeshPro buttonText;
    public int trick;
    public GameObject[] obstacles;
    public bool isRandom = false;

    // Start is called before the first frame update
    void Start()
    {

        
        if (isRandom)
        {
            create(Random.Range(1, 5));
        }
    }

    public void create(int type)
    {
        has2Keys = Random.value >= 0.75f ? true : false;
        if (!has2Keys)
        {
            switch (type)
            {
                case 1:
                    keyToPress = KeyCode.DownArrow;
                    buttonText.text = "↓";
                    trick = 0;
                    obstacles[0].SetActive(true);
                    break;

                case 2:
                    keyToPress = KeyCode.X;
                    buttonText.text = "X";
                    trick = 1;
                    obstacles[1].SetActive(true);
                    break;

                case 3:
                    keyToPress = KeyCode.Z;
                    buttonText.text = "Z";
                    trick = 2;
                    obstacles[2].SetActive(true);
                    break;

                case 4:
                    keyToPress = KeyCode.UpArrow;
                    buttonText.text = "↑";
                    trick = 3;
                    obstacles[3].SetActive(true);
                    break;
            }
        }

        if(has2Keys)
        {

            switch (type)
            {
                case 1:
                    keyToPress = KeyCode.DownArrow;
                    buttonText.text = "↓";
                    if (Random.value >= 0.5f)
                    {
                        keyToPress2 = KeyCode.X;
                        buttonText.text += " X";
                        trick = 0;
                        obstacles[4].SetActive(true);
                    }
                    else
                    {
                        keyToPress2 = KeyCode.Z;
                        buttonText.text += " Z";
                        trick = 0;
                        obstacles[5].SetActive(true);
                    }
                    
                    break;

                case 2:
                    buttonText.text = "X";
                    keyToPress = KeyCode.X;
                    if (Random.value >= 0.5f)
                    {
                        keyToPress2 = KeyCode.DownArrow;
                        buttonText.text += " ↓";
                        trick = 0;
                        obstacles[4].SetActive(true);
                    }
                    else
                    {
                        keyToPress2 = KeyCode.UpArrow;
                        buttonText.text += " ↑";
                        trick = 3;
                        obstacles[6].SetActive(true);
                    }
                    break;

                case 3:
                    buttonText.text = "Z";
                    keyToPress = KeyCode.Z;
                    if (Random.value >= 0.5f)
                    {
                        keyToPress2 = KeyCode.DownArrow;
                        buttonText.text += " ↓";
                        trick = 0;
                        obstacles[5].SetActive(true);
                    }
                    else
                    {
                        keyToPress2 = KeyCode.UpArrow;
                        buttonText.text += " ↑";
                        trick = 3;
                        obstacles[7].SetActive(true);
                    }
                    break;

                case 4:
                    buttonText.text = "↑";
                    keyToPress = KeyCode.UpArrow;
                    if (Random.value >= 0.5f)
                    {
                        keyToPress2 = KeyCode.X;
                        buttonText.text += " X";
                        trick = 3;
                        obstacles[6].SetActive(true);
                    }
                    else
                    {
                        keyToPress2 = KeyCode.Z;
                        buttonText.text += " Z";
                        trick = 3;
                        obstacles[7].SetActive(true);
                    }
                    break;
            }

        }
        transform.Rotate(0f, 0f, 45f);
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Clamp(speed, 3f, 10f);
        //transform.Translate(Vector3.left * Time.deltaTime*speed);

    }

    public void killSelf()
    {
        spawner.beats.Remove(gameObject);
        Destroy(gameObject);
    }
}
