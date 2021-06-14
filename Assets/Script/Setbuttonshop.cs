using UnityEngine;

public class Setbuttonshop : MonoBehaviour
{
    [HideInInspector] public static int i;
    public GameObject buttonBuy, buttonUse, buttonUsing;
    public void clickbuttonBuy()
    {
        if(buttonBuy.name == "Buttonbuy1" && PlayerPrefs.GetInt("totalScore", 0) >= 80)
        {
            buttonBuy.SetActive(false);
            buttonUse.SetActive(true);
            PlayerPrefs.SetInt("buttonHat1", 0);
            PlayerPrefs.SetInt("shopScore", PlayerPrefs.GetInt("totalScore", 0));
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("shopScore", 0) - 80);
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("totalScore", 0));
        }
        if (buttonBuy.name == "Buttonbuy2" && PlayerPrefs.GetInt("totalScore", 0) >= 80)
        {
            buttonBuy.SetActive(false);
            buttonUse.SetActive(true);
            PlayerPrefs.SetInt("buttonHat2", 0);
            PlayerPrefs.SetInt("shopScore", PlayerPrefs.GetInt("totalScore", 0));
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("shopScore", 0) - 80);
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("totalScore", 0));
        }
        if (buttonBuy.name == "Buttonbuy3" && PlayerPrefs.GetInt("totalScore", 0) >= 80)
        {
            buttonBuy.SetActive(false);
            buttonUse.SetActive(true);
            PlayerPrefs.SetInt("buttonHat3", 0);
            PlayerPrefs.SetInt("shopScore", PlayerPrefs.GetInt("totalScore", 0));
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("shopScore", 0) - 80);
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("totalScore", 0));
        }
        if (buttonBuy.name == "Buttonbuy4" && PlayerPrefs.GetInt("totalScore", 0) >= 100)
        {
            buttonBuy.SetActive(false);
            buttonUse.SetActive(true);
            PlayerPrefs.SetInt("buttonHat4", 0);
            PlayerPrefs.SetInt("shopScore", PlayerPrefs.GetInt("totalScore", 0));
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("shopScore", 0) - 100);
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("totalScore", 0));
        }
        if (buttonBuy.name == "Buttonbuy5" && PlayerPrefs.GetInt("totalScore", 0) >= 120)
        {
            buttonBuy.SetActive(false);
            buttonUse.SetActive(true);
            PlayerPrefs.SetInt("buttonHat5", 0);
            PlayerPrefs.SetInt("shopScore", PlayerPrefs.GetInt("totalScore", 0));
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("shopScore", 0) - 120);
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("totalScore", 0));
        }
        if (buttonBuy.name == "Buttonbuy6" && PlayerPrefs.GetInt("totalScore", 0) >= 120)
        {
            buttonBuy.SetActive(false);
            buttonUse.SetActive(true);
            PlayerPrefs.SetInt("buttonHat6", 0);
            PlayerPrefs.SetInt("shopScore", PlayerPrefs.GetInt("totalScore", 0));
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("shopScore", 0) - 120);
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("totalScore", 0));
        }
    }
    public void clickbuttonUse()
    {
        buttonUse.SetActive(false);
        buttonUsing.SetActive(true);
        if (buttonUse.name == "Buttonuse")
        {
            PlayerPrefs.SetInt("buttonHat", 1);
            i = 0;
        }
        if (buttonUse.name == "Buttonuse1")
        {
            PlayerPrefs.SetInt("buttonHat1", 1);
            i = 1;
        }
        if (buttonUse.name == "Buttonuse2")
        {
            PlayerPrefs.SetInt("buttonHat2", 1);
            i = 2;
        }
        if (buttonUse.name == "Buttonuse3")
        {
            PlayerPrefs.SetInt("buttonHat3", 1);
            i = 3;
        }
        if (buttonUse.name == "Buttonuse4")
        {
            PlayerPrefs.SetInt("buttonHat4", 1);
            i = 4;
        }
        if (buttonUse.name == "Buttonuse5")
        {
            PlayerPrefs.SetInt("buttonHat5", 1);
            i = 5;
        }
        if (buttonUse.name == "Buttonuse6")
        {
            PlayerPrefs.SetInt("buttonHat6", 1);
            i = 6;
        }
    }
}
