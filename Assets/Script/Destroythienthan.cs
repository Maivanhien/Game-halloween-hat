using UnityEngine;

public class Destroythienthan : MonoBehaviour
{
    [SerializeField] private GameObject pumpkinbattu, crowbattu, ballbattu, ninjabattu, mummybattu;
    private GameObject[] gameObjects;
    public GameObject gameobject1;
    private int i;

    void OnMouseDown()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Pumpkin");
        foreach (GameObject gameobject in gameObjects)
        {
            if (!gameobject1)
            {
                gameobject1 = gameobject;
                i = 1;
            }
            else
            {
                if (gameobject.transform.position.y > gameobject1.transform.position.y)
                {
                    gameobject1 = gameobject;
                    i = 1;
                }
            }
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Crow");
        foreach (GameObject gameobject in gameObjects)
        {
            if (!gameobject1)
            {
                gameobject1 = gameobject;
                i = 2;
            }
            else
            {
                if (gameobject.transform.position.y > gameobject1.transform.position.y)
                {
                    gameobject1 = gameobject;
                    i = 2;
                }
            }
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject gameobject in gameObjects)
        {
            if (!gameobject1)
            {
                gameobject1 = gameobject;
                i = 3;
            }
            else
            {
                if (gameobject.transform.position.y > gameobject1.transform.position.y)
                {
                    gameobject1 = gameobject;
                    i = 3;
                }
            }
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Ninja");
        foreach (GameObject gameobject in gameObjects)
        {
            if (!gameobject1)
            {
                gameobject1 = gameobject;
                i = 4;
            }
            else
            {
                if (gameobject.transform.position.y > gameobject1.transform.position.y)
                {
                    gameobject1 = gameobject;
                    i = 4;
                }
            }
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Mummy");
        foreach (GameObject gameobject in gameObjects)
        {
            if (!gameobject1)
            {
                gameobject1 = gameobject;
                i = 5;
            }
            else
            {
                if (gameobject.transform.position.y > gameobject1.transform.position.y)
                {
                    gameobject1 = gameobject;
                    i = 5;
                }
            }
        }
        if (!gameobject1)
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Thienthan"].Enqueue(this.gameObject);
            gameobject1 = null;
        }
        else
        {
            Objectpooler.Instance.SpawnFromPool("Thienthanstatic", transform.position, Quaternion.identity);
            switch(i)
            {
                case 1:
                    gameObjects = GameObject.FindGameObjectsWithTag("Pumpkin");
                    foreach (GameObject gameobject in gameObjects)
                    {
                        if(gameobject1.transform.position == gameobject.transform.position)
                        {
                            gameobject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Pumpkin"].Enqueue(gameobject);
                            Instantiate(pumpkinbattu, gameobject.transform.position, Quaternion.identity);
                        }
                    }
                    break;
                case 2:
                    gameObjects = GameObject.FindGameObjectsWithTag("Crow");
                    foreach (GameObject gameobject in gameObjects)
                    {
                        if (gameobject1.transform.position == gameobject.transform.position)
                        {
                            gameobject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Crow"].Enqueue(gameobject);
                            Instantiate(crowbattu, gameobject.transform.position, Quaternion.identity);
                        }
                    }
                    break;
                case 3:
                    gameObjects = GameObject.FindGameObjectsWithTag("Ball");
                    foreach (GameObject gameobject in gameObjects)
                    {
                        if (gameobject1.transform.position == gameobject.transform.position)
                        {
                            gameobject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Ball"].Enqueue(gameobject);
                            Instantiate(ballbattu, gameobject.transform.position, Quaternion.identity);
                        }
                    }
                    break;
                case 4:
                    gameObjects = GameObject.FindGameObjectsWithTag("Ninja");
                    foreach (GameObject gameobject in gameObjects)
                    {
                        if (gameobject1.transform.position == gameobject.transform.position)
                        {
                            gameobject.SetActive(false);
                            Objectpooler.Instance.poolDictionary["Ninja"].Enqueue(gameobject);
                            Instantiate(ninjabattu, gameobject.transform.position, Quaternion.identity);
                        }
                    }
                    break;
                case 5:
                    gameObjects = GameObject.FindGameObjectsWithTag("Mummy");
                    foreach (GameObject gameobject in gameObjects)
                    {
                        if (gameobject1.transform.position == gameobject.transform.position)
                        {
                            Destroy(gameobject);
                            Instantiate(mummybattu, gameobject.transform.position, Quaternion.identity);
                        }
                    }
                    break;
            }
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Thienthan"].Enqueue(this.gameObject);
            gameobject1 = null;
        }
    }
}
