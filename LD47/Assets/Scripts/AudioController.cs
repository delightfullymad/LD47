using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    public static AudioClip currentMusic;
    public AudioSource audioSource;
    public AudioSource music;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    public float clipLoudness;
    private float[] clipSampleData;

    public GameObject cube;
    public float sizeFactor = 1;

    public float minSize = 0;
    public float maxSize = 500;
    public BeatSpawner beatSpawner;
    public float delay;
    // Use this for initialization
    private void Awake()
    {
        if (currentMusic)
        {
            audioSource.clip = currentMusic;
            music.clip = currentMusic;
        }
        clipSampleData = new float[sampleDataLength];
        music.PlayDelayed(delay);
    }

    // Update is called once per frame
    private void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for

            clipLoudness *= sizeFactor;
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
            //cube.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
            Debug.Log(clipLoudness);

            if(clipLoudness > 0.5f && clipLoudness <= 0.7f)
            {
                beatSpawner.spawnBeat(0);
            }
            if (clipLoudness > 0.7f && clipLoudness <= 0.8f)
            {
                beatSpawner.spawnBeat(1);
            }
            if (clipLoudness > 0.8f && clipLoudness <= 0.9f)
            {
                beatSpawner.spawnBeat(2);
            }
            if (clipLoudness > 0.9f && clipLoudness <= 1.0f)
            {
                beatSpawner.spawnBeat(3);
            }
        }
    }
}
