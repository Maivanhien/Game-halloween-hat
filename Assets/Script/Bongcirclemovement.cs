using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bongcirclemovement : MonoBehaviour
{
    public GameObject dieAudio;
    private GameObject[] gameObjects;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
        if (this.transform.position.y == -4.4f)
        {
            gameObjects = GameObject.FindGameObjectsWithTag("BongBlue");
            foreach (GameObject gameobject in gameObjects)
            {
                Objectpooler.Instance.SpawnFromPool("BongBlueExploded", gameobject.transform.position, Quaternion.identity);
                if (gameobject.name == "BongBlue(Clone)")
                {
                    gameobject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["BongBlue"].Enqueue(gameobject);
                }
                else if (gameobject.name == "BongBlue 7(Clone)")
                {
                    gameobject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["BongBlue7"].Enqueue(gameobject);
                }
                else Destroy(gameobject);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("BongGreen");
            foreach (GameObject gameobject in gameObjects)
            {
                Objectpooler.Instance.SpawnFromPool("BongGreenExploded", gameobject.transform.position, Quaternion.identity);
                if (gameobject.name == "BongGreen(Clone)")
                {
                    gameobject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["BongGreen"].Enqueue(gameobject);
                }
                else if (gameobject.name == "BongGreen 6(Clone)")
                {
                    gameobject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["BongGreen6"].Enqueue(gameobject);
                }
                else Destroy(gameobject);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("BongRed");
            foreach (GameObject gameobject in gameObjects)
            {
                Objectpooler.Instance.SpawnFromPool("BongRedExploded", gameobject.transform.position, Quaternion.identity);
                if (gameobject.name == "BongRed(Clone)")
                {
                    gameobject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["BongRed"].Enqueue(gameobject);
                }
                else if (gameobject.name == "BongRed 6(Clone)")
                {
                    gameobject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["BongRed6"].Enqueue(gameobject);
                }
                else Destroy(gameobject);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("BongYellow");
            foreach (GameObject gameobject in gameObjects)
            {
                Objectpooler.Instance.SpawnFromPool("BongYellowExploded", gameobject.transform.position, Quaternion.identity);
                if (gameobject.name == "BongYellow(Clone)")
                {
                    gameobject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["BongYellow"].Enqueue(gameobject);
                }
                else if (gameobject.name == "BongYellow 3(Clone)")
                {
                    gameobject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["BongYellow3"].Enqueue(gameobject);
                }
                else if (gameobject.name == "BongYellow 6(Clone)")
                {
                    gameobject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["BongYellow6"].Enqueue(gameobject);
                }
                else Destroy(gameobject);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("BongPumkin");
            foreach (GameObject gameobject in gameObjects)
            {
                Objectpooler.Instance.SpawnFromPool("BongBlueExplodedLon", gameobject.transform.position, Quaternion.identity);
                Destroy(gameobject);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("BongCrow");
            foreach (GameObject gameobject in gameObjects)
            {
                Objectpooler.Instance.SpawnFromPool("BongRedExplodedLon", gameobject.transform.position, Quaternion.identity);
                Destroy(gameobject);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("BongBall");
            foreach (GameObject gameobject in gameObjects)
            {
                Objectpooler.Instance.SpawnFromPool("BongGreenExplodedLon", gameobject.transform.position, Quaternion.identity);
                Destroy(gameobject);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("BongThor");
            foreach (GameObject gameobject in gameObjects)
            {
                Objectpooler.Instance.SpawnFromPool("BongYellowExplodedLon", gameobject.transform.position, Quaternion.identity);
                Destroy(gameobject);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("BongSupperman");
            foreach (GameObject gameobject in gameObjects)
            {
                Objectpooler.Instance.SpawnFromPool("BongYellowExplodedLon", gameobject.transform.position, Quaternion.identity);
                Destroy(gameobject);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("BongHiepsi");
            foreach (GameObject gameobject in gameObjects)
            {
                Objectpooler.Instance.SpawnFromPool("BongBlueExplodedLon", gameobject.transform.position, Quaternion.identity);
                Destroy(gameobject);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("Bongphanra");
            foreach (GameObject gameobject in gameObjects)
            {
                Objectpooler.Instance.SpawnFromPool("BongphanraExploded", gameobject.transform.position, Quaternion.identity);
                Destroy(gameobject);
            }
            Instantiate(dieAudio, this.transform.position, Quaternion.identity);
            Gamemanager.isGameOver = true;
            if (gameObject.name == "BongBlue(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongBlue"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongGreen(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongGreen"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongRed(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongRed"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongYellow(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongYellow"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongYellow 3(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongYellow3"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongBlue 7(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongBlue7"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongGreen 6(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongGreen6"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongRed 6(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongRed6"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongYellow 6(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongYellow6"].Enqueue(this.gameObject);
            }
            else Destroy(gameObject);
        }
    }
}
