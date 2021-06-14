using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject panel, silence, voice;
    void Start()
    {
        if(PlayerPrefs.GetInt("Audiosource", 1) == 1)
        {
            voice.SetActive(true);
            silence.SetActive(false);
        }
        else
        {
            voice.SetActive(false);
            silence.SetActive(true);
        }
    }
    public void setting()
    {
        if (panel.activeInHierarchy == false)
            panel.SetActive(true);
        else panel.SetActive(false);
    }
    public void Exitgameobject()
    {
        Application.Quit();
    }
    public void Voice()
    {
        silence.SetActive(true);
        voice.SetActive(false);
        PlayerPrefs.SetInt("Audiosource", 0);
    }
    public void Silence()
    {
        silence.SetActive(false);
        voice.SetActive(true);
        PlayerPrefs.SetInt("Audiosource", 1);
    }
}
