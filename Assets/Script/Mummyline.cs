using UnityEngine;

public class Mummyline : MonoBehaviour
{
    private GameObject[] gameObjects;
    public GameObject gameobject1;
    private LineRenderer linerenderer;
    void Start()
    {
        linerenderer = GetComponent<LineRenderer>();
        linerenderer.enabled = true;
        linerenderer.useWorldSpace = true;
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
    }
    
    void Update()
    {
        if (!gameobject1)
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Mummystatic"));
        }
        else
        {
            if (this.transform.position.x == gameobject1.transform.position.x)
            {
                Destroy(gameObject);
                Destroy(GameObject.FindGameObjectWithTag("Mummystatic"));
            }
            else
            {
                linerenderer.SetPosition(0, this.transform.position);
                linerenderer.SetPosition(1, gameobject1.transform.position);
                gameobject1.transform.position = Vector3.MoveTowards(gameobject1.transform.position, this.transform.position, 8f * Time.deltaTime);
                if ((gameobject1.transform.position - this.transform.position).magnitude < 0.5f)
                    gameobject1.transform.position = this.transform.position;
            }
        }
    }
}
