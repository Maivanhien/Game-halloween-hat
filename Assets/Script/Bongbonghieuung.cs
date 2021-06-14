using System.Collections;
using UnityEngine;

public class Bongbonghieuung : MonoBehaviour
{
    private bool hieuUngDestroy;
    private void Start()
    {
        hieuUngDestroy = true;
    }
    private void Update()
    {
        if(hieuUngDestroy==true)
        {
            StartCoroutine(destroyHieuUng());
            hieuUngDestroy = false;
        }
    }
    IEnumerator destroyHieuUng()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
        hieuUngDestroy = true;
        if(this.gameObject.tag=="BongBlueExploded")
        Objectpooler.Instance.poolDictionary["BongBlueExploded"].Enqueue(this.gameObject);
        if (this.gameObject.tag == "BongBlueExplodedLon")
            Objectpooler.Instance.poolDictionary["BongBlueExplodedLon"].Enqueue(this.gameObject);
        if (this.gameObject.tag == "BongGreenExploded")
            Objectpooler.Instance.poolDictionary["BongGreenExploded"].Enqueue(this.gameObject);
        if (this.gameObject.tag == "BongGreenExplodedLon")
            Objectpooler.Instance.poolDictionary["BongGreenExplodedLon"].Enqueue(this.gameObject);
        if (this.gameObject.tag == "BongRedExploded")
            Objectpooler.Instance.poolDictionary["BongRedExploded"].Enqueue(this.gameObject);
        if (this.gameObject.tag == "BongRedExplodedLon")
            Objectpooler.Instance.poolDictionary["BongRedExplodedLon"].Enqueue(this.gameObject);
        if (this.gameObject.tag == "BongYellowExploded")
            Objectpooler.Instance.poolDictionary["BongYellowExploded"].Enqueue(this.gameObject);
        if (this.gameObject.tag == "BongYellowExplodedLon")
            Objectpooler.Instance.poolDictionary["BongYellowExplodedLon"].Enqueue(this.gameObject);
        if (this.gameObject.tag == "BongphanraExploded")
            Objectpooler.Instance.poolDictionary["BongphanraExploded"].Enqueue(this.gameObject);
    }
}
