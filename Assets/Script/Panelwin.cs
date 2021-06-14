using UnityEngine;
using UnityEngine.UI;
public class Panelwin : MonoBehaviour
{
    public Text texttotalscore;
    void Start()
    {
        int total = PlayerPrefs.GetInt("Total", 0);
        int sum = total + Gamemanager.currentScore;
        texttotalscore.text = sum.ToString();
        PlayerPrefs.SetInt("totalScore", sum);
    }
}
