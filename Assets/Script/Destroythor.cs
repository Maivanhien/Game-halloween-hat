using System.Collections;
using UnityEngine;

public class Destroythor : MonoBehaviour
{
    void Start()
    {
        if(this.gameObject.tag == "Thorsamset")
            StartCoroutine(destroyThorsamset());
        else
            StartCoroutine(destroyThor());
    }
    IEnumerator destroyThor()
    {
        yield return new WaitForSeconds(0.26f);
        Destroy(gameObject);
    }
    IEnumerator destroyThorsamset()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
