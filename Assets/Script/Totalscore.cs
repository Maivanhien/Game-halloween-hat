using UnityEngine;
using UnityEngine.UI;

public class Totalscore : MonoBehaviour
{
    private int totalscore;
    public Text texttotalScore;
    void Start()
    {
        totalscore = PlayerPrefs.GetInt("totalScore");
        texttotalScore.text = totalscore.ToString();
    }
    
    void Update()
    {
        if(PlayerPrefs.GetInt("totalScore") != totalscore)
        {
            totalscore = PlayerPrefs.GetInt("totalScore");
            texttotalScore.text = totalscore.ToString();
        }
    }
}
