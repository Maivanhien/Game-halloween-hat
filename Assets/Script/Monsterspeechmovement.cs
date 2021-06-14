using System.Collections;
using UnityEngine;

public class Monsterspeechmovement : MonoBehaviour
{
    [SerializeField] private GameObject dieAudio;
    private bool isObjectCreate, isMovement;
    private float speech,luot;
    void Start()
    {
        isObjectCreate = true;
        isMovement = false;
        speech = 4.5f;
        luot = 14.5f;
    }
    void Update()
    {
        if (isObjectCreate == true)
        {
            StartCoroutine(movementObject());
            isObjectCreate = false;
        }
        if(isMovement==false)
        {
            transform.Translate(new Vector3(0, -luot * Time.deltaTime, 0));
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 5), transform.position.z);
        }
        if (isMovement == true)
        {
            transform.Translate(new Vector3(0, -speech * Time.deltaTime, 0));
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 5), transform.position.z);
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
    IEnumerator movementObject()
    {
        yield return new WaitForSeconds(0.1f);
        isMovement = true;
    }
}
