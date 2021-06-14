using UnityEngine;

public class Panelslash : MonoBehaviour
{
    [SerializeField] private GameObject buttonUse, buttonUsing, buttonBuy1, buttonUse1, buttonUsing1, buttonBuy2, buttonUse2, buttonUsing2,
        buttonBuy3, buttonUse3, buttonUsing3, buttonBuy4, buttonUse4, buttonUsing4, buttonBuy5, buttonUse5, buttonUsing5;
    void Start()
    {
        Set1buttonshop.i = 7;
        if (PlayerPrefs.GetInt("buttonSlash", 1) == 0)
        {
            buttonUse.SetActive(true);
            buttonUsing.SetActive(false);
        }
        else
        {
            buttonUse.SetActive(false);
            buttonUsing.SetActive(true);
        }
        if (PlayerPrefs.GetInt("buttonSlash1", -1) == -1)
        {
            buttonBuy1.SetActive(true);
            buttonUse1.SetActive(false);
            buttonUsing1.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("buttonSlash1", -1) == 0)
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
        if (PlayerPrefs.GetInt("buttonSlash2", -1) == -1)
        {
            buttonBuy2.SetActive(true);
            buttonUse2.SetActive(false);
            buttonUsing2.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("buttonSlash2", -1) == 0)
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
        if (PlayerPrefs.GetInt("buttonSlash3", -1) == -1)
        {
            buttonBuy3.SetActive(true);
            buttonUse3.SetActive(false);
            buttonUsing3.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("buttonSlash3", -1) == 0)
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
        if (PlayerPrefs.GetInt("buttonSlash4", -1) == -1)
        {
            buttonBuy4.SetActive(true);
            buttonUse4.SetActive(false);
            buttonUsing4.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("buttonSlash4", -1) == 0)
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
        if (PlayerPrefs.GetInt("buttonSlash5", -1) == -1)
        {
            buttonBuy5.SetActive(true);
            buttonUse5.SetActive(false);
            buttonUsing5.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("buttonSlash5", -1) == 0)
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
    }
    void Update()
    {
        if (Set1buttonshop.i != 7)
        {
            if (Set1buttonshop.i != 0 && PlayerPrefs.GetInt("buttonSlash", 1) == 1)
            {
                PlayerPrefs.SetInt("buttonSlash", 0);
                buttonUse.SetActive(true);
                buttonUsing.SetActive(false);
            }
            else if (Set1buttonshop.i != 1 && PlayerPrefs.GetInt("buttonSlash1", -1) == 1)
            {
                PlayerPrefs.SetInt("buttonSlash1", 0);
                buttonUse1.SetActive(true);
                buttonUsing1.SetActive(false);
            }
            else if (Set1buttonshop.i != 2 && PlayerPrefs.GetInt("buttonSlash2", -1) == 1)
            {
                PlayerPrefs.SetInt("buttonSlash2", 0);
                buttonUse2.SetActive(true);
                buttonUsing2.SetActive(false);
            }
            else if (Set1buttonshop.i != 3 && PlayerPrefs.GetInt("buttonSlash3", -1) == 1)
            {
                PlayerPrefs.SetInt("buttonSlash3", 0);
                buttonUse3.SetActive(true);
                buttonUsing3.SetActive(false);
            }
            else if (Set1buttonshop.i != 4 && PlayerPrefs.GetInt("buttonSlash4", -1) == 1)
            {
                PlayerPrefs.SetInt("buttonSlash4", 0);
                buttonUse4.SetActive(true);
                buttonUsing4.SetActive(false);
            }
            else
            {
                PlayerPrefs.SetInt("buttonSlash5", 0);
                buttonUse5.SetActive(true);
                buttonUsing5.SetActive(false);
            }
            Set1buttonshop.i = 7;
        }
    }
}
