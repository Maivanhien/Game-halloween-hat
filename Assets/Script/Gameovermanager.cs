using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Gameovermanager : MonoBehaviour
{
    string GooglePlay_ID = "3769269";
    bool TestMode = true;
    public Text textHighScore;
    public Text textYourScore;
    private float gameplay1, gameplay2;
    private void Start()
    {
        Advertisement.Initialize(GooglePlay_ID, TestMode);
        PlayerPrefs.SetInt("Unityads", PlayerPrefs.GetInt("Loadads", 0));
        if(PlayerPrefs.GetInt("Unityads", 0) == 3 && Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
            PlayerPrefs.SetInt("Unityads", 0);
        }
        int yourScore = PlayerPrefs.GetInt("textScore");
        int TotalScore = PlayerPrefs.GetInt("totalScore");
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "GameOver")
        {
            gameplay1 = PlayerPrefs.GetFloat("Gameplay1", 0);
            if (gameplay1 >= 880)
                gameplay1 = 880;
            else if (gameplay1 >= 720)
                gameplay1 = 720;
            else if (gameplay1 >= 680)
                gameplay1 = 680;
            else if (gameplay1 >= 520)
                gameplay1 = 520;
            else if (gameplay1 >= 480)
                gameplay1 = 480;
            else if (gameplay1 >= 320)
                gameplay1 = 320;
            else if (gameplay1 >= 160)
                gameplay1 = 160;
            else gameplay1 = 0;
            PlayerPrefs.SetFloat("Gameplay1", gameplay1);
        }
        if (scene.name == "GameOver2")
        {
            gameplay2 = PlayerPrefs.GetFloat("Gameplay2", 0);
            if (gameplay2 >= 384)
                gameplay2 = 384;
            else if (gameplay2 >= 256)
                gameplay2 = 256;
            else if (gameplay2 >= 128)
                gameplay2 = 128;
            else gameplay2 = 0;
            PlayerPrefs.SetFloat("Gameplay2", gameplay2);
        }
        //TotalScore = 130;
        textYourScore.text = yourScore.ToString();
        textHighScore.text = TotalScore.ToString();
        PlayerPrefs.SetInt("Total", TotalScore);
    }
}
