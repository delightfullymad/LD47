using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SongObj : MonoBehaviour
{
    public AudioClip music;
    public string fileName;
    
    public TextMeshProUGUI fileNameText;
    public bool getFromFile = false;

    // Start is called before the first frame update
    void Start()
    {
        fileNameText.text = fileName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        AudioController.currentMusic = music;
        SceneManager.LoadScene("Main");
    }

    public void PlayClip()
    {
        Camera.main.GetComponent<AudioSource>().clip = music;
        Camera.main.GetComponent<AudioSource>().Play();
    }

    public void StopClip()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
    }
}
