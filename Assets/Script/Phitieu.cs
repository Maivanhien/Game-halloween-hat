using UnityEngine;

public class Phitieu : MonoBehaviour
{
    private GameObject[] gameObjects;
    public GameObject gameobject1;
    private float rotation;
    void Start()
    {
        rotation = 0;
        gameObjects = GameObject.FindGameObjectsWithTag("Pumpkin");
        foreach (GameObject gameobject in gameObjects)
        {
            if (!gameobject1)
                gameobject1 = gameobject;
            else
            {
                if (gameobject.transform.position.y > gameobject1.transform.position.y)
                    gameobject1 = gameobject;
            }
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Crow");
        foreach (GameObject gameobject in gameObjects)
        {
            if (!gameobject1)
                gameobject1 = gameobject;
            else
            {
                if (gameobject.transform.position.y > gameobject1.transform.position.y)
                    gameobject1 = gameobject;
            }
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject gameobject in gameObjects)
        {
            if (!gameobject1)
                gameobject1 = gameobject;
            else
            {
                if (gameobject.transform.position.y > gameobject1.transform.position.y)
                    gameobject1 = gameobject;
            }
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Hiepsi");
        foreach (GameObject gameobject in gameObjects)
        {
            if (!gameobject1)
                gameobject1 = gameobject;
            else
            {
                if (gameobject.transform.position.y > gameobject1.transform.position.y)
                    gameobject1 = gameobject;
            }
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Thorbua");
        foreach (GameObject gameobject in gameObjects)
        {
            if (!gameobject1)
                gameobject1 = gameobject;
            else
            {
                if (gameobject.transform.position.y > gameobject1.transform.position.y)
                    gameobject1 = gameobject;
            }
        }
    }

    void Update()
    {
        if (!gameobject1)
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("NinjaPhitieu"));
        }
        else
        {
            rotation -= 360 * Time.deltaTime;
            rotation = rotation % 360;
            this.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
            this.transform.position = Vector3.MoveTowards(this.transform.position, gameobject1.transform.position, 7f * Time.deltaTime);
            if ((gameobject1.transform.position - this.transform.position).magnitude < 0.5f)
                this.transform.position = gameobject1.transform.position;
        }
    }
}
