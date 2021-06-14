using System.Collections;
using UnityEngine;

public class Thanchetmovement : MonoBehaviour
{
    [SerializeField] private GameObject dieAudio;
    [HideInInspector] public bool isObjectCreate;
    private float speech;
    void Start()
    {
        isObjectCreate = true;
        speech = 5f;
    }
    void Update()
    {
        if(isObjectCreate == true)
        {
            StartCoroutine(movementObject());
            isObjectCreate = false;
        }
        else
        {
            transform.Translate(new Vector3(0, -speech * Time.deltaTime, 0));
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 5), transform.position.z);
        }
    }
    void LateUpdate()
    {
        if (this.transform.position.y == -4.4f)
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Thanchet"].Enqueue(this.gameObject);
            isObjectCreate = true;
            Instantiate(dieAudio, this.transform.position, Quaternion.identity);
            Gamemanager.isGameOver = true;
        }
    }
    IEnumerator movementObject()
    {
        transform.Translate(new Vector3(0, -speech * Time.deltaTime, 6));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 5), transform.position.z);
        yield return new WaitForSeconds(0.53f);
        transform.Translate(new Vector3(0, -speech * Time.deltaTime, -6));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 5), transform.position.z);
        yield return new WaitForSeconds(0.13f);
        isObjectCreate = true;
    }
}
