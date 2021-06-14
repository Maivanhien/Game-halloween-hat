using UnityEngine;

public class Destroymummy : MonoBehaviour
{
    private GameObject[] gameObjects;
    public GameObject gameobject1;
    [SerializeField] private GameObject mumMyStatic, mumMyline;
    void OnMouseDown()
    {
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
        if(!gameobject1)
        {
            Destroy(gameObject);
        }
        else
        {
            Instantiate(mumMyStatic, transform.position, Quaternion.identity);
            Instantiate(mumMyline, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
