using System.Collections;
using UnityEngine;

public class Thorbua : MonoBehaviour
{
    public GameObject thorBua1, dieAudio;
    private float speech, movement;
    private bool right, left;
    private int rand;
    void Start()
    {
        movement = Random.Range(0f,4.5f);
        speech = 7.5f;
        rand = Random.Range(1, 3);
        if(rand==1)
        {
            right = true;
            left = false;
        }
        else
        {
            right = false;
            left = true;
        }
        StartCoroutine(Destroybua());
    }
    void Update()
    {
        if (right == true)
            transform.Translate(new Vector3(movement * Time.deltaTime, -speech * Time.deltaTime, 0));
        if (left == true)
            transform.Translate(new Vector3(-movement * Time.deltaTime, -speech * Time.deltaTime, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.4f, 2.4f), Mathf.Clamp(transform.position.y, -4.4f, 5), transform.position.z);
        if (transform.position.x == 2.4f)
        {
            right = false;
            left = true;
        }
        if (transform.position.x == -2.4f)
        {
            right = true;
            left = false;
        }
    }
    void LateUpdate()
    {
        if (this.transform.position.y == -4.4f)
        {
            Destroy(gameObject);
            Instantiate(dieAudio, this.transform.position, Quaternion.identity);
            Gamemanager.isGameOver = true;
        }
    }
    IEnumerator Destroybua()
    {
        yield return new WaitForSeconds(0.26f);
        Destroy(gameObject);
        Instantiate(thorBua1, this.transform.position, Quaternion.identity);
    }
}
