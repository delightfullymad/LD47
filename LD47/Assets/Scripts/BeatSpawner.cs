using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject beatPrefab;
    public Player player;
    public float speed;
    public float spawnRate = 2f;
    public List<GameObject> beats = new List<GameObject>();
    private float nextSpawn;
    private float lastSpeed = 5f;
    public bool isSpawning = false;
    public Transform loopGen;
    //public int beatNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        //nextSpawn = Time.time + spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isDead)
        {
            if (Time.time >= nextSpawn && isSpawning)
            {
                //spawnRate *= 0.9f;
                spawnRate = Mathf.Clamp(spawnRate, 0.5f, 2f);
                nextSpawn = Time.time + spawnRate;
                GameObject newBeat = Instantiate(beatPrefab, transform.position, Quaternion.identity, loopGen.transform);
                newBeat.GetComponent<Beat>().spawner = this;
                beats.Add(newBeat);
                //newBeat.GetComponent<Beat>().speed = lastSpeed + 0.1f;
                //lastSpeed = newBeat.GetComponent<Beat>().speed;

            }

            loopGen.transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
        
    }

    public void toggleSpawn()
    {
        isSpawning = !isSpawning;
    }

    public void spawnBeat(int type)
    {
        if (player.isDead) return;
        switch (type)
        {

            case 0:
                if (Time.time >= nextSpawn)
                {
                    //spawnRate *= 0.9f;
                    spawnRate = Mathf.Clamp(spawnRate, 0.5f, 2f);
                    nextSpawn = Time.time + spawnRate;
                    GameObject newBeat = Instantiate(beatPrefab, transform.position, Quaternion.identity, loopGen.transform);
                    newBeat.GetComponent<Beat>().spawner = this;
                    newBeat.GetComponent<Beat>().create(1);
                    beats.Add(newBeat);
                    //newBeat.GetComponent<Beat>().speed = lastSpeed + 0.1f;
                    //lastSpeed = newBeat.GetComponent<Beat>().speed;

                }
                break;
            case 1:
                if (Time.time >= nextSpawn)
                {
                    //spawnRate *= 0.9f;
                    spawnRate = Mathf.Clamp(spawnRate, 0.5f, 2f);
                    nextSpawn = Time.time + spawnRate;
                    GameObject newBeat = Instantiate(beatPrefab, transform.position, Quaternion.identity, loopGen.transform);
                    newBeat.GetComponent<Beat>().spawner = this;
                    newBeat.GetComponent<Beat>().create(2);
                    beats.Add(newBeat);
                    //newBeat.GetComponent<Beat>().speed = lastSpeed + 0.1f;
                    //lastSpeed = newBeat.GetComponent<Beat>().speed;

                }
                break;
            case 2:
                if (Time.time >= nextSpawn)
                {
                    //spawnRate *= 0.9f;
                    spawnRate = Mathf.Clamp(spawnRate, 0.5f, 2f);
                    nextSpawn = Time.time + spawnRate;
                    GameObject newBeat = Instantiate(beatPrefab, transform.position, Quaternion.identity, loopGen.transform);
                    newBeat.GetComponent<Beat>().spawner = this;
                    newBeat.GetComponent<Beat>().create(3);
                    beats.Add(newBeat);
                    //newBeat.GetComponent<Beat>().speed = lastSpeed + 0.1f;
                    //lastSpeed = newBeat.GetComponent<Beat>().speed;

                }
                break;
            case 3:
                if (Time.time >= nextSpawn)
                {
                    //spawnRate *= 0.9f;
                    spawnRate = Mathf.Clamp(spawnRate, 0.5f, 2f);
                    nextSpawn = Time.time + spawnRate;
                    GameObject newBeat = Instantiate(beatPrefab, transform.position, Quaternion.identity, loopGen.transform);
                    newBeat.GetComponent<Beat>().spawner = this;
                    newBeat.GetComponent<Beat>().create(4);
                    beats.Add(newBeat);
                    //newBeat.GetComponent<Beat>().speed = lastSpeed + 0.1f;
                    //lastSpeed = newBeat.GetComponent<Beat>().speed;

                }
                break;
            default:
                break;
        }
    }
}
