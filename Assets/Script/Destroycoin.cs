using UnityEngine;

public class Destroycoin : MonoBehaviour
{
    void OnMouseDown()
    {
        Gamemanager.currentScore += 1;
        Objectpooler.Instance.SpawnFromPool("Coinaudio", this.transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
        Objectpooler.Instance.poolDictionary["Coin"].Enqueue(this.gameObject);
    }
}
