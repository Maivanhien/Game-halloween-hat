using System.Collections;
using UnityEngine;

public class Hoden : MonoBehaviour
{
    private static bool isObjectCreate;
    private int rand;
    void Start()
    {
        isObjectCreate = true;
        rand = Random.Range(1, 3);
        StartCoroutine(hoDenCreate());
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(isObjectCreate==true)
        {
            if(this.transform.position.x==0f)
            {
                if (rand == 1)
                {
                    switch (collision.gameObject.tag)
                    {
                        case "Pumpkin":
                            isObjectCreate = false;
                            StartCoroutine(cloneObject());
                            collision.gameObject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Pumpkin"].Enqueue(collision.gameObject);
                            Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(2.1f, 1.5f, 85f), Quaternion.identity);
                            break;
                        case "Crow":
                            isObjectCreate = false;
                            StartCoroutine(cloneObject());
                            collision.gameObject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Crow"].Enqueue(collision.gameObject);
                            Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(2.1f, 1.5f, 85f), Quaternion.identity);
                            break;
                        case "Coin":
                            isObjectCreate = false;
                            StartCoroutine(cloneObject());
                            collision.gameObject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Coin"].Enqueue(collision.gameObject);
                            Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(2.1f, 1.5f, 85f), Quaternion.identity);
                            break;
                        case "Bomb":
                            isObjectCreate = false;
                            StartCoroutine(cloneObject());
                            collision.gameObject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Bomb"].Enqueue(collision.gameObject);
                            Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(2.1f, 1.5f, 85f), Quaternion.identity);
                            break;
                        case "Ball":
                            isObjectCreate = false;
                            StartCoroutine(cloneObject());
                            collision.gameObject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Ball"].Enqueue(collision.gameObject);
                            Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(2.1f, 1.5f, 85f), Quaternion.identity);
                            break;
                    }
                }
                else
                {
                    switch (collision.gameObject.tag)
                    {
                        case "Pumpkin":
                            isObjectCreate = false;
                            StartCoroutine(cloneObject());
                            collision.gameObject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Pumpkin"].Enqueue(collision.gameObject);
                            Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(-2.1f, 1.5f, 85f), Quaternion.identity);
                            break;
                        case "Crow":
                            isObjectCreate = false;
                            StartCoroutine(cloneObject());
                            collision.gameObject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Crow"].Enqueue(collision.gameObject);
                            Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(-2.1f, 1.5f, 85f), Quaternion.identity);
                            break;
                        case "Coin":
                            isObjectCreate = false;
                            StartCoroutine(cloneObject());
                            collision.gameObject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Coin"].Enqueue(collision.gameObject);
                            Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(-2.1f, 1.5f, 85f), Quaternion.identity);
                            break;
                        case "Bomb":
                            isObjectCreate = false;
                            StartCoroutine(cloneObject());
                            collision.gameObject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Bomb"].Enqueue(collision.gameObject);
                            Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(-2.1f, 1.5f, 85f), Quaternion.identity);
                            break;
                        case "Ball":
                            isObjectCreate = false;
                            StartCoroutine(cloneObject());
                            collision.gameObject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Ball"].Enqueue(collision.gameObject);
                            Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(-2.1f, 1.5f, 85f), Quaternion.identity);
                            break;
                    }
                }
            }
            else
            {
                switch (collision.gameObject.tag)
                {
                    case "Pumpkin":
                        isObjectCreate = false;
                        StartCoroutine(cloneObject());
                        collision.gameObject.SetActive(false);
                        Objectpooler.Instance.poolDictionary["Pumpkin"].Enqueue(collision.gameObject);
                        Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(0f, 2.2f, 85f), Quaternion.identity);
                        break;
                    case "Crow":
                        isObjectCreate = false;
                        StartCoroutine(cloneObject());
                        collision.gameObject.SetActive(false);
                        Objectpooler.Instance.poolDictionary["Crow"].Enqueue(collision.gameObject);
                        Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(0f, 2.2f, 85f), Quaternion.identity);
                        break;
                    case "Coin":
                        isObjectCreate = false;
                        StartCoroutine(cloneObject());
                        collision.gameObject.SetActive(false);
                        Objectpooler.Instance.poolDictionary["Coin"].Enqueue(collision.gameObject);
                        Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(0f, 2.2f, 85f), Quaternion.identity);
                        break;
                    case "Bomb":
                        isObjectCreate = false;
                        StartCoroutine(cloneObject());
                        collision.gameObject.SetActive(false);
                        Objectpooler.Instance.poolDictionary["Bomb"].Enqueue(collision.gameObject);
                        Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(0f, 2.2f, 85f), Quaternion.identity);
                        break;
                    case "Ball":
                        isObjectCreate = false;
                        StartCoroutine(cloneObject());
                        collision.gameObject.SetActive(false);
                        Objectpooler.Instance.poolDictionary["Ball"].Enqueue(collision.gameObject);
                        Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(0f, 2.2f, 85f), Quaternion.identity);
                        break;
                }
            }
        }
    }
    IEnumerator cloneObject()
    {
        rand = Random.Range(1, 3);
        yield return new WaitForSeconds(0.05f);
        isObjectCreate = true;
    }
    IEnumerator hoDenCreate()
    {
        yield return new WaitForSeconds(28.5f);
        Destroy(gameObject);
    }
}
