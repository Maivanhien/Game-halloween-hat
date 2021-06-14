using UnityEngine;

public class Destroymonster : MonoBehaviour
{
    [SerializeField] private GameObject monsterCon,monsterCon1;
    private int rand;
    
    void OnMouseDown()
    {
        rand = Random.Range(1, 3);
        if (rand==1)
        {
            Instantiate(monsterCon, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
        }
        if(rand==2)
        {
            Instantiate(monsterCon1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        this.gameObject.SetActive(false);
        Objectpooler.Instance.poolDictionary["Monster"].Enqueue(this.gameObject);
    }
}
