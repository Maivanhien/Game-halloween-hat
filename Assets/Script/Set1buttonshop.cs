using UnityEngine;

public class Set1buttonshop : MonoBehaviour
{
    [HideInInspector] public static int i;
    public GameObject buttonBuy, buttonUse, buttonUsing;
    public void clickbuttonBuy()
    {
        if (buttonBuy.name == "Buttonbuy1" && PlayerPrefs.GetInt("totalScore", 0) >= 80)
        {
            buttonBuy.SetActive(false);
            buttonUse.SetActive(true);
            PlayerPrefs.SetInt("buttonSlash1", 0);
            PlayerPrefs.SetInt("shopScore", PlayerPrefs.GetInt("totalScore", 0));
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("shopScore", 0) - 80);
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("totalScore", 0));
        }
        if (buttonBuy.name == "Buttonbuy2" && PlayerPrefs.GetInt("totalScore", 0) >= 80)
        {
            buttonBuy.SetActive(false);
            buttonUse.SetActive(true);
            PlayerPrefs.SetInt("buttonSlash2", 0);
            PlayerPrefs.SetInt("shopScore", PlayerPrefs.GetInt("totalScore", 0));
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("shopScore", 0) - 80);
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("totalScore", 0));
        }
        if (buttonBuy.name == "Buttonbuy3" && PlayerPrefs.GetInt("totalScore", 0) >= 80)
        {
            buttonBuy.SetActive(false);
            buttonUse.SetActive(true);
            PlayerPrefs.SetInt("buttonSlash3", 0);
            PlayerPrefs.SetInt("shopScore", PlayerPrefs.GetInt("totalScore", 0));
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("shopScore", 0) - 80);
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("totalScore", 0));
        }
        if (buttonBuy.name == "Buttonbuy4" && PlayerPrefs.GetInt("totalScore", 0) >= 100)
        {
            buttonBuy.SetActive(false);
            buttonUse.SetActive(true);
            PlayerPrefs.SetInt("buttonSlash4", 0);
            PlayerPrefs.SetInt("shopScore", PlayerPrefs.GetInt("totalScore", 0));
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("shopScore", 0) - 100);
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("totalScore", 0));
        }
        if (buttonBuy.name == "Buttonbuy5" && PlayerPrefs.GetInt("totalScore", 0) >= 100)
        {
            buttonBuy.SetActive(false);
            buttonUse.SetActive(true);
            PlayerPrefs.SetInt("buttonSlash5", 0);
            PlayerPrefs.SetInt("shopScore", PlayerPrefs.GetInt("totalScore", 0));
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("shopScore", 0) - 100);
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("totalScore", 0));
        }
    }
    public void clickbuttonUse()
    {
        buttonUse.SetActive(false);
        buttonUsing.SetActive(true);
        if (buttonUse.name == "Buttonuse")
        {
            PlayerPrefs.SetInt("buttonSlash", 1);
            i = 0;
        }
        if (buttonUse.name == "Buttonuse1")
        {
            PlayerPrefs.SetInt("buttonSlash1", 1);
            i = 1;
        }
        if (buttonUse.name == "Buttonuse2")
        {
            PlayerPrefs.SetInt("buttonSlash2", 1);
            i = 2;
        }
        if (buttonUse.name == "Buttonuse3")
        {
            PlayerPrefs.SetInt("buttonSlash3", 1);
            i = 3;
        }
        if (buttonUse.name == "Buttonuse4")
        {
            PlayerPrefs.SetInt("buttonSlash4", 1);
            i = 4;
        }
        if (buttonUse.name == "Buttonuse5")
        {
            PlayerPrefs.SetInt("buttonSlash5", 1);
            i = 5;
        }
    }
}
