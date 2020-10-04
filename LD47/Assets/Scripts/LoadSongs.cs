using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class LoadSongs : MonoBehaviour
{
    public GameObject menuItemPrefab;
    public Transform contentList;
    public AudioSource source;
    public List<AudioClip> clips = new List<AudioClip>();
    public GameObject TitleMenu;
    public GameObject songMenu;
    [SerializeField] [HideInInspector] private int currentIndex = 0;

    private FileInfo[] soundFiles;
    private List<string> validExtensions = new List<string> { ".ogg", ".wav"};
    private string absolutePath = "./StreamingAssets"; 
    // Start is called before the first frame update
    void Start()
    {
        if (Application.isEditor) absolutePath = "Assets/StreamingAssets    ";
        else
        {
            //absolutePath = Application.dataPath + "/Music";
        }
        
        //if (source == null) source = gameObject.AddComponent<AudioSource>();

        ReloadSounds();
    }

    // Update is called once per frame
    void Update()
    {
        if(TitleMenu.activeInHierarchy == true && Input.anyKeyDown)
        {
            TitleMenu.SetActive(false);
            songMenu.SetActive(true);
            GetComponent<AudioSource>().Stop();
        }
    }

    bool IsValidFileType(string fileName)
    {
        return validExtensions.Contains(Path.GetExtension(fileName));
    }

    public static string GetFileLocation(string relativePath)
    {
        return "file://" + Path.Combine(Application.streamingAssetsPath, relativePath);
    }

    void ReloadSounds()
    {
        clips.Clear();
        var info = new DirectoryInfo(absolutePath);
        soundFiles = info.GetFiles()
            .Where(f => IsValidFileType(f.Name))
            .ToArray();

        foreach (var s in soundFiles)
            StartCoroutine(LoadFile(s.FullName));

        //CreateMenuItems();

    }

    IEnumerator LoadFile(string path)
    {
        WWW www = new WWW("file://" + path);
        print("loading " + path);

        AudioClip clip = www.GetAudioClip(false);
        while (!clip.isReadyToPlay)
            yield return www;

        print("done loading");
        clip.name = Path.GetFileName(path);
        clips.Add(clip);
        //CreateMenuItem(clip);

    }

    public void CreateMenuItem(AudioClip musicClip)
    {
        Debug.Log("Create Items");

            GameObject newItem = Instantiate(menuItemPrefab, contentList);
            newItem.GetComponent<SongObj>().music = musicClip;
            newItem.GetComponent<SongObj>().fileName = musicClip.name;
            newItem.GetComponent<SongObj>().fileNameText.text = newItem.GetComponent<SongObj>().fileName;

    }

    
}
