using UnityEngine;

public class Panelhat : MonoBehaviour
{
    [SerializeField] private GameObject buttonUse, buttonUsing, buttonBuy1, buttonUse1, buttonUsing1,
        buttonBuy2, buttonUse2, buttonUsing2, buttonBuy3, buttonUse3, buttonUsing3, buttonBuy4, buttonUse4, buttonUsing4,
        buttonBuy5, buttonUse5, buttonUsing5, buttonBuy6, buttonUse6, buttonUsing6;
    void Start()
    {
        Setbuttonshop.i = 7;
        if(PlayerPrefs.GetInt("buttonHat", 1) == 0)
        {
            buttonUse.SetActive(true);
            buttonUsing.SetActive(false);
        }
        else
        {
            buttonUse.SetActive(false);
            buttonUsing.SetActive(true);
        }
        if(PlayerPrefs.GetInt("buttonHat1", -1) == -1)
        {
            buttonBuy1.SetActive(true);
            buttonUse1.SetActive(false);
            buttonUsing1.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("buttonHat1", -1) == 0)
        {
            buttonBuy1.SetActive(false);
            buttonUse1.SetActive(true);
            buttonUsing1.SetActive(false);
        }
        else
        {
            buttonBuy1.SetActive(false);
            buttonUse1.SetActive(false);
            buttonUsing1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("buttonHat2", -1) == -1)
        {
            buttonBuy2.SetActive(true);
            buttonUse2.SetActive(false);
            buttonUsing2.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("buttonHat2", -1) == 0)
        {
            buttonBuy2.SetActive(false);
            buttonUse2.SetActive(true);
            buttonUsing2.SetActive(false);
        }
        else
        {
            buttonBuy2.SetActive(false);
            buttonUse2.SetActive(false);
            buttonUsing2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("buttonHat3", -1) == -1)
        {
            buttonBuy3.SetActive(true);
            buttonUse3.SetActive(false);
            buttonUsing3.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("buttonHat3", -1) == 0)
        {
            buttonBuy3.SetActive(false);
            buttonUse3.SetActive(true);
            buttonUsing3.SetActive(false);
        }
        else
        {
            buttonBuy3.SetActive(false);
            buttonUse3.SetActive(false);
            buttonUsing3.SetActive(true);
        }
        if (PlayerPrefs.GetInt("buttonHat4", -1) == -1)
        {
            buttonBuy4.SetActive(true);
            buttonUse4.SetActive(false);
            buttonUsing4.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("buttonHat4", -1) == 0)
        {
            buttonBuy4.SetActive(false);
            buttonUse4.SetActive(true);
            buttonUsing4.SetActive(false);
        }
        else
        {
            buttonBuy4.SetActive(false);
            buttonUse4.SetActive(false);
            buttonUsing4.SetActive(true);
        }
        if (PlayerPrefs.GetInt("buttonHat5", -1) == -1)
        {
            buttonBuy5.SetActive(true);
            buttonUse5.SetActive(false);
            buttonUsing5.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("buttonHat5", -1) == 0)
        {
            buttonBuy5.SetActive(false);
            buttonUse5.SetActive(true);
            buttonUsing5.SetActive(false);
        }
        else
        {
            buttonBuy5.SetActive(false);
            buttonUse5.SetActive(false);
            buttonUsing5.SetActive(true);
        }
        if (PlayerPrefs.GetInt("buttonHat6", -1) == -1)
        {
            buttonBuy6.SetActive(true);
            buttonUse6.SetActive(false);
            buttonUsing6.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("buttonHat6", -1) == 0)
        {
            buttonBuy6.SetActive(false);
            buttonUse6.SetActive(true);
            buttonUsing6.SetActive(false);
        }
        else
        {
            buttonBuy6.SetActive(false);
            buttonUse6.SetActive(false);
            buttonUsing6.SetActive(true);
        }
    }
    void Update()
    {
        if(Setbuttonshop.i != 7)
        {
            if(Setbuttonshop.i != 0 && PlayerPrefs.GetInt("buttonHat", 1) == 1)
            {
                PlayerPrefs.SetInt("buttonHat", 0);
                buttonUse.SetActive(true);
                buttonUsing.SetActive(false);
            }
            else if (Setbuttonshop.i != 1 && PlayerPrefs.GetInt("buttonHat1", -1) == 1)
            {
                PlayerPrefs.SetInt("buttonHat1", 0);
                buttonUse1.SetActive(true);
                buttonUsing1.SetActive(false);
            }
            else if (Setbuttonshop.i != 2 && PlayerPrefs.GetInt("buttonHat2", -1) == 1)
            {
                PlayerPrefs.SetInt("buttonHat2", 0);
                buttonUse2.SetActive(true);
                buttonUsing2.SetActive(false);
            }
            else if (Setbuttonshop.i != 3 && PlayerPrefs.GetInt("buttonHat3", -1) == 1)
            {
                PlayerPrefs.SetInt("buttonHat3", 0);
                buttonUse3.SetActive(true);
                buttonUsing3.SetActive(false);
            }
            else if (Setbuttonshop.i != 4 && PlayerPrefs.GetInt("buttonHat4", -1) == 1)
            {
                PlayerPrefs.SetInt("buttonHat4", 0);
                buttonUse4.SetActive(true);
                buttonUsing4.SetActive(false);
            }
            else if (Setbuttonshop.i != 5 && PlayerPrefs.GetInt("buttonHat5", -1) == 1)
            {
                PlayerPrefs.SetInt("buttonHat5", 0);
                buttonUse5.SetActive(true);
                buttonUsing5.SetActive(false);
            }
            else
            {
                PlayerPrefs.SetInt("buttonHat6", 0);
                buttonUse6.SetActive(true);
                buttonUsing6.SetActive(false);
            }
            Setbuttonshop.i = 7;
        }
    }
}
