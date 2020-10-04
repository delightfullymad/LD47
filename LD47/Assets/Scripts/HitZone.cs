using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    public UI uiObj;
    public Player player;
    public float redThreshold = 0.5f;
    public float yellowThreshold = 0.2f;
    //public float greenThreshold = 0.2f;
    public float beatDistance = -1f;
    public Beat currentBeat;
    public KeyCode lastKey;
    public AudioClip[] jumpSounds;
    public AudioClip[] hitSounds;
    public AudioClip perfect;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnGUI()
    {
        if (Event.current.isKey && Event.current.type == EventType.KeyDown)
        {
            lastKey = Event.current.keyCode;
            Debug.Log(Event.current.keyCode);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(currentBeat)
        {
            beatDistance = Mathf.Abs(transform.position.x - currentBeat.transform.position.x);
        }
        if (currentBeat && !currentBeat.has2Keys && Input.anyKeyDown)
        {
            if (currentBeat && currentBeat.used == false)
            {
                if (Input.GetKeyDown(currentBeat.keyToPress))
                {
                    ActivateBeat();  
                }
                else
                {
                    //currentBeat.GetComponent<Beat>().buttonText.color = Color.red;
                    uiObj.multiplier = 1;
                    player.GetComponent<Animator>().SetTrigger("ouch");
                    player.health--;
                    Camera.main.GetComponent<cameraShake>().shakeDuration = 0.7f;
                    GetComponent<AudioSource>().PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);
                }
                //lastKey = KeyCode.None;
                currentBeat.used = true;
                //beatTimer = 0f;
                //Destroy(collision.gameObject);
            }
        }
        else if(currentBeat && currentBeat.has2Keys)
        {
            if (currentBeat && currentBeat.used == false)
            {
                if (Input.GetKey(currentBeat.keyToPress) && Input.GetKey(currentBeat.keyToPress2))
                {
                    ActivateBeat();
                    currentBeat.used = true;
                }
            }
            

            
        }
    }

    public void ActivateBeat()
    {
        if (beatDistance > redThreshold)
        {
            //currentBeat.buttonText.color = Color.red;
            uiObj.multiplier = 1;
            player.GetComponent<Animator>().SetTrigger("ouch");
            player.health--;
            Camera.main.GetComponent<cameraShake>().shakeDuration = 0.7f;
            uiObj.ShowText("Miss");
            GetComponent<AudioSource>().PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);

        }
        else if (beatDistance <= redThreshold && beatDistance >= yellowThreshold)
        {
            //currentBeat.buttonText.color = Color.yellow;
            uiObj.score += 100 * uiObj.multiplier;
            uiObj.ShowText("Nice");
            GetComponent<AudioSource>().PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);

        }
        else if (beatDistance <= yellowThreshold)
        {
            //currentBeat.buttonText.color = new Color(0, 0.7f, 0);
            uiObj.multiplier++;
            uiObj.score += 250 * uiObj.multiplier;
            uiObj.ShowText("Perfect-o!");
            GetComponent<AudioSource>().PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);
            GetComponent<AudioSource>().PlayOneShot(perfect);
        }
        player.DoTrick(currentBeat);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Beat")
        {
            //beatTimer = 0f;
            currentBeat = collision.GetComponent<Beat>();
            //collision.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Beat"&& currentBeat.used == false)
        {
                //beatTimer += 1f * Time.deltaTime;
                //Debug.Log(beatTimer);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag =="Beat" && collision.GetComponent<Beat>().used == false)
        {
            //collision.GetComponent<Beat>().buttonText.color = Color.red;
            uiObj.multiplier = 1;
            player.GetComponent<Animator>().SetTrigger("ouch");
            player.health--;
            Camera.main.GetComponent<cameraShake>().shakeDuration = 0.7f;
            GetComponent<AudioSource>().PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);
            uiObj.ShowText("Miss!");
        }
    }
}
