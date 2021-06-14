using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gamemanager : MonoBehaviour
{
    [HideInInspector] public static int currentScore;
    [HideInInspector] public static int level;
    [HideInInspector] public static bool isGameOver;
    [HideInInspector] public static int heart, changeTime;
    public Text textCurrentScore,textLevel;
    [SerializeField]private GameObject audioSource;
    private int sum;
    void Start()
    {
        heart = 3;
        level = 1;
        currentScore = 0;
        isGameOver = false;
        changeTime = 0;
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("Audiosource", 1) == 0)
            audioSource.SetActive(false);
        else audioSource.SetActive(true);
    }

    void Update()
    {
        textCurrentScore.text = currentScore.ToString();
        textLevel.text = level.ToString();
        if(isGameOver==true)
        {
            heart -= 1;
            isGameOver = false;
        }
        if (heart == 2)
            Destroy(GameObject.FindWithTag("Heart"));
        if (heart == 1)
            Destroy(GameObject.FindWithTag("Heart1"));
        if (heart == 0)
            StartCoroutine(loadGameOver());
        if (changeTime == 1) StartCoroutine(fastGameObject());
        if (changeTime == 2) StartCoroutine(slowGameObject());
        if (changeTime == 3) StartCoroutine(stopGameObject());
    }

    IEnumerator loadGameOver()
    {
        yield return new WaitForSeconds(0.5f);
        int ads = PlayerPrefs.GetInt("Unityads", 0) + 1;
        PlayerPrefs.SetInt("Loadads", ads);
        Scene scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt("textScore", currentScore);
        int total = PlayerPrefs.GetInt("Total", 0);
        sum = total + currentScore;
        PlayerPrefs.SetInt("totalScore", sum);
        if (scene.name == "Gameplay")
        {
            PlayerPrefs.SetFloat("Gameplay1", Hatoveride.time);
            SceneManager.LoadSceneAsync("GameOver");
        }
        if (scene.name == "Gameplay2")
        {
            PlayerPrefs.SetFloat("Gameplay2", Hatoveride2.time);
            SceneManager.LoadSceneAsync("GameOver2");
        }
    }
    IEnumerator fastGameObject()
    {
        changeTime = 0;
        Time.timeScale = 1.25f;
        yield return new WaitForSeconds(4f);
        Time.timeScale = 1f;
    }
    IEnumerator slowGameObject()
    {
        changeTime = 0;
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(2f);
        Time.timeScale = 1f;
    }
    IEnumerator stopGameObject()
    {
        changeTime = 0;
        Time.timeScale = 0.001f;
        yield return new WaitForSeconds(0.002f);
        Time.timeScale = 1f;
    }
}
