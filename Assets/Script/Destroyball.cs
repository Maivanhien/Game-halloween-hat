using UnityEngine;

public class Destroyball : MonoBehaviour
{
    private int rand;

    void OnMouseDown()
    {
        rand = Random.Range(1, 3);
        if (rand == 1)
        {
            Objectpooler.Instance.SpawnFromPool("Ballexploded", transform.position, Quaternion.identity);
            Objectpooler.Instance.SpawnFromPool("Ballchilrent1", new Vector3(transform.position.x - 0.09f, transform.position.y - 0.03f, transform.position.z), Quaternion.identity);
            Objectpooler.Instance.SpawnFromPool("Ballchilrent2", new Vector3(transform.position.x + 0.09f, transform.position.y - 0.03f, transform.position.z), Quaternion.identity);
        }
        if(rand==2)
        {
            Objectpooler.Instance.SpawnFromPool("Ballexploded", transform.position, Quaternion.identity);
            Objectpooler.Instance.SpawnFromPool("Ballnhanh", transform.position, Quaternion.identity);
        }
        if(this.gameObject.tag == "VBall")
        {
            Destroy(gameObject);
        }
        else
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Ball"].Enqueue(this.gameObject);
        }
    }
}
