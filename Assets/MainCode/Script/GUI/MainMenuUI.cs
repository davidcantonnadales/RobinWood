using UnityEngine;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour
{

    public GameObject levelPanel;
    public GameObject Environment;
    public Image SoundBut;
    public Image MusicBut;
    public Sprite SoundOn;
    public Sprite SoundOff;
    public Sprite MusicOn;
    public Sprite MusicOff;


    // Use this for initialization
    void Start()
    {
        //init state Music Button
        if (GlobalValue.isMusic)
        {
            MusicBut.sprite = MusicOn;

        }
        else
        {
            MusicBut.sprite = MusicOff;
        }

        //init state Sound button
        if (GlobalValue.isSound)
        {
            SoundBut.sprite = SoundOn;
        }
        else
        {
            SoundBut.sprite = SoundOff;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void Play()
    {
        levelPanel.SetActive(true);
        Environment.SetActive(false);
        gameObject.SetActive(false);
    }

    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }

    public void Sound()
    {
        GlobalValue.isSound = !GlobalValue.isSound;
        if (GlobalValue.isSound)
        {
            SoundManager.SoundVolume = 1f;
            SoundBut.sprite = SoundOn;
        }
        else
        {
            SoundManager.SoundVolume = 0f;
            SoundBut.sprite = SoundOff;
        }
    }

    public void Music()
    {
        GlobalValue.isMusic = !GlobalValue.isMusic;
        if (GlobalValue.isMusic)
        {
            MusicBut.sprite = MusicOn;
            SoundManager.MusicVolume = 1f;

        }
        else
        {
            MusicBut.sprite = MusicOff;
            SoundManager.MusicVolume = 0f;
        }
    }
}
