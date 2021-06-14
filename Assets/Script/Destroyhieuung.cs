using System.Collections;
using UnityEngine;

public class Destroyhieuung : MonoBehaviour
{
    private bool hieuUngDestroy;
    private void Start()
    {
        hieuUngDestroy = true;
    }
    private void Update()
    {
        if (hieuUngDestroy == true)
        {
            StartCoroutine(destroyHieuUng());
            hieuUngDestroy = false;
        }
    }
    IEnumerator destroyHieuUng()
    {
        yield return new WaitForSeconds(2f);
        hieuUngDestroy = true;
        if(this.gameObject.tag == "Ballexploded")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Ballexploded"].Enqueue(this.gameObject);
        }
        else if (this.gameObject.tag == "Ninjaexploded")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Ninjaexploded"].Enqueue(this.gameObject);
        }
        else if (this.gameObject.tag == "Samset")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Samset"].Enqueue(this.gameObject);
        }
        else if (this.gameObject.tag == "Supperexploded")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Supperexploded"].Enqueue(this.gameObject);
        }
        else if (this.gameObject.tag == "Coinaudio")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Coinaudio"].Enqueue(this.gameObject);
        }
        else Destroy(gameObject);
    }
}
