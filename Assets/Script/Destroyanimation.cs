using UnityEngine;

public class Destroyanimation : MonoBehaviour
{
    [SerializeField] private GameObject hiepSiDissolve;
    void OnMouseDown()
    {
        if (gameObject.tag == "Pumpkin")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Pumpkin"].Enqueue(this.gameObject);
        }
        else if (gameObject.tag == "Crowlua")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Crowlua"].Enqueue(this.gameObject);
        }
        else if (gameObject.tag == "Supperman1")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Supperman1"].Enqueue(this.gameObject);
        }
        else if (gameObject.tag == "Kysi")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Kysi"].Enqueue(this.gameObject);
        }
        else if (gameObject.tag == "Ninja1")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Ninja1"].Enqueue(this.gameObject);
        }
        else if (gameObject.tag == "Thanchet")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Thanchet"].Enqueue(this.gameObject);
            Thanchetmovement thanchet = gameObject.GetComponent<Thanchetmovement>();
            thanchet.isObjectCreate = true;
        }
        else if (gameObject.tag == "Ballchilrent1")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Ballchilrent1"].Enqueue(this.gameObject);
            Ballmovement ball1 = GetComponent<Ballmovement>();
            ball1.right = false;
            ball1.left = true;
        }
        else if (gameObject.tag == "Ballchilrent2")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Ballchilrent2"].Enqueue(this.gameObject);
            Ball2movement ball2 = GetComponent<Ball2movement>();
            ball2.right = true;
            ball2.left = false;
        }
        else if (gameObject.tag == "Ballnhanh")
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Ballnhanh"].Enqueue(this.gameObject);
        }
        else
        {
            if (gameObject.tag == "Hiepsi")
                Instantiate(hiepSiDissolve, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
