using System.Collections;
using UnityEngine;

public class Doimovement : MonoBehaviour
{
    [SerializeField] private GameObject dieAudio;
    private float speech, movement;
    private bool right, left, continute;
    int rand;
    void Start()
    {
        continute = true;
        movement = 4f;
        speech = 6.5f;
        rand = Random.Range(1, 3);
        if (rand == 1)
        {
            right = false;
            left = true;
        }
        if (rand == 2)
        {
            right = true;
            left = false;
        }
    }
    void Update()
    {
        if (continute == true)
        {
            StartCoroutine(objectrandom());
            continute = false;
        }
        if (right == true)
            transform.Translate(new Vector3(movement * Time.deltaTime, -speech * Time.deltaTime, 0));
        if (left == true)
            transform.Translate(new Vector3(-movement * Time.deltaTime, -speech * Time.deltaTime, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.2f, 2.2f), Mathf.Clamp(transform.position.y, -4.4f, 5), transform.position.z);
        if (transform.position.x == 2.2f)
        {
            right = false;
            left = true;
        }
        if (transform.position.x == -2.2f)
        {
            right = true;
            left = false;
        }
    }
    
    IEnumerator objectrandom()
    {
        yield return new WaitForSeconds(0.3f);
        rand = Random.Range(1, 3);
        if(rand==1)
        {
            right = false;
            left = true;
        }
        if (rand == 2)
        {
            right = true;
            left = false;
        }
        continute = true;
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
}
