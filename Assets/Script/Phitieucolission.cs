using UnityEngine;

public class Phitieucolission : MonoBehaviour
{
    public GameObject hiepSiDissolve, thor, bua, thorSamSet, Bombexploded;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            collision.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Bomb"].Enqueue(collision.gameObject);
            Instantiate(Bombexploded, collision.transform.position, Quaternion.identity);
            Gamemanager.isGameOver = true;
            Destroy(gameObject);
            GameObject gameobject = GameObject.FindGameObjectWithTag("NinjaPhitieu");
            Destroy(GameObject.FindGameObjectWithTag("NinjaPhitieu"));
            Objectpooler.Instance.SpawnFromPool("Ninja1", new Vector3(gameobject.transform.position.x, gameobject.transform.position.y - 0.05f, gameobject.transform.position.z), Quaternion.identity);
        }
        else
        {
            switch (collision.gameObject.tag)
            {
                case "Pumpkin":
                    collision.gameObject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["Pumpkin"].Enqueue(collision.gameObject);
                    break;
                case "Crow":
                    Objectpooler.Instance.SpawnFromPool("Crowlua", new Vector3(collision.transform.position.x, collision.transform.position.y + 0.2f, collision.transform.position.z), Quaternion.identity);
                    collision.gameObject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["Crow"].Enqueue(collision.gameObject);
                    break;
                case "Ball":
                    int rand = Random.Range(1, 3);
                    if (rand == 1)
                    {
                        Objectpooler.Instance.SpawnFromPool("Ballexploded", collision.transform.position, Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("Ballchilrent1", new Vector3(collision.transform.position.x - 0.09f, collision.transform.position.y - 0.03f, collision.transform.position.z), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("Ballchilrent2", new Vector3(collision.transform.position.x + 0.09f, collision.transform.position.y - 0.03f, collision.transform.position.z), Quaternion.identity);
                    }
                    if (rand == 2)
                    {
                        Objectpooler.Instance.SpawnFromPool("Ballexploded", collision.transform.position, Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("Ballnhanh", collision.transform.position, Quaternion.identity);
                    }
                    collision.gameObject.SetActive(false);
                    Objectpooler.Instance.poolDictionary["Ball"].Enqueue(collision.gameObject);
                    break;
                case "Hiepsi":
                    Instantiate(hiepSiDissolve, collision.transform.position, Quaternion.identity);
                    Destroy(collision.gameObject);
                    break;
                case "Thorbua":
                    int i = Random.Range(1, 3);
                    if (i == 1)
                    {
                        Instantiate(thor, collision.transform.position, Quaternion.identity);
                        Instantiate(bua, new Vector3(collision.transform.position.x, collision.transform.position.y - 0.2f, collision.transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        Objectpooler.Instance.SpawnFromPool("Samset", new Vector3(0f, 1.15f, 0f), Quaternion.identity);
                        Instantiate(thorSamSet, collision.transform.position, Quaternion.identity);
                    }
                    Destroy(collision.gameObject);
                    break;
            }
            Objectpooler.Instance.SpawnFromPool("Ninjaexploded", Vector3.Lerp(this.transform.position, collision.transform.position, 0.5f), Quaternion.identity);
            Destroy(gameObject);
            GameObject gameobject = GameObject.FindGameObjectWithTag("NinjaPhitieu");
            Destroy(GameObject.FindGameObjectWithTag("NinjaPhitieu"));
            Objectpooler.Instance.SpawnFromPool("Ninja1", new Vector3(gameobject.transform.position.x, gameobject.transform.position.y - 0.05f, gameobject.transform.position.z), Quaternion.identity);
        }
    }
}
