using UnityEngine;

public class Slash : MonoBehaviour
{
    private AudioSource audiosource;
    void Start()
    {
        audiosource = this.GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Audiosource", 1) == 1)
            audiosource.enabled = true;
        else audiosource.enabled = false;
    }
    
    void Update()
    {
        if (PlayerPrefs.GetInt("Audiosource", 1) == 1)
            audiosource.enabled = true;
        else audiosource.enabled = false;
    }
}
