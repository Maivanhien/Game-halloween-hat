using UnityEngine;

public class Animationmovement : Objectmovement
{
    [SerializeField] private GameObject dieAudio;
    void LateUpdate()
    {
        if (vectoequal(transform.position) == true)
        {
            if (gameObject.tag == "Pumpkin")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Pumpkin"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Crow")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Crow"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Crowlua")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Crowlua"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Ball")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Ball"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Monster")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Monster"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Supperman")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Supperman"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Supperman1")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Supperman1"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Supperlon")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Supperlon"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Kysi")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Kysi"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Kysicam")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Kysicam"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Kysido")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Kysido"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Kysivang")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Kysivang"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Kysixanh")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Kysixanh"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Ninja")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Ninja"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Ninja1")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Ninja1"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Thienthan")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Thienthan"].Enqueue(this.gameObject);
            }
            else Destroy(gameObject);
            Instantiate(dieAudio, this.transform.position, Quaternion.identity);
            Gamemanager.isGameOver = true;
        }
    }
}
