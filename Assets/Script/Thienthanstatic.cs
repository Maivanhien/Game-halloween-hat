using System.Collections;
using UnityEngine;

public class Thienthanstatic : MonoBehaviour
{
    public GameObject mummy;
    private bool thienthanstatic;
    void Start()
    {
        thienthanstatic = true;
    }
    void Update()
    {
        if(thienthanstatic == true)
        {
            StartCoroutine(Destroythienthanstatic());
            thienthanstatic = false;
        }
    }
    IEnumerator Destroythienthanstatic()
    {
        yield return new WaitForSeconds(0.65f);
        thienthanstatic = true;
        if(gameObject.tag == "Thienthanstatic")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Thienthanstatic"].Enqueue(this.gameObject);
        }
        else
        {
            if (gameObject.tag == "Pumpkinbattu")
                Objectpooler.Instance.SpawnFromPool("Pumpkin", transform.position, Quaternion.identity);
            if (gameObject.tag == "Crowbattu")
                Objectpooler.Instance.SpawnFromPool("Crow", transform.position, Quaternion.identity);
            if (gameObject.tag == "Ballbattu")
                Objectpooler.Instance.SpawnFromPool("Ball", transform.position, Quaternion.identity);
            if (gameObject.tag == "Ninjabattu")
                Objectpooler.Instance.SpawnFromPool("Ninja", transform.position, Quaternion.identity);
            if (gameObject.tag == "Mummybattu")
                Instantiate(mummy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
