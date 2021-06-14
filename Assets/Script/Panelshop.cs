using UnityEngine;

public class Panelshop : MonoBehaviour
{
    public GameObject panelslash, panelhat;
    public void effectSlash()
    {
        panelslash.SetActive(true);
        panelhat.SetActive(false);
    }
    public void hatHalloween()
    {
        panelslash.SetActive(false);
        panelhat.SetActive(true);
    }
}
