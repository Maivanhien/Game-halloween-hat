using System.Collections;
using UnityEngine;

public class Savelevel : MonoBehaviour
{
    private float speech, movement;
    void Start()
    {
        movement = 3f;
        speech = 3.2f;
        StartCoroutine(Destroysavelevel());
    }
    
    void Update()
    {
        this.transform.Translate(new Vector3(movement * Time.deltaTime, -speech * Time.deltaTime, 0));
        this.transform.localScale += new Vector3(0.0015f, 0.0015f, 0.0015f);
    }
    IEnumerator Destroysavelevel()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
