using UnityEngine;

public class Bongbong : MonoBehaviour
{
    public GameObject thor, hiepSi;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Linear")
        {
            switch (gameObject.tag)
            {
                case "BongBlue":
                    Objectpooler.Instance.SpawnFromPool("BongBlueExploded",transform.position,Quaternion.identity);
                    break;
                case "BongGreen":
                    Objectpooler.Instance.SpawnFromPool("BongGreenExploded", transform.position, Quaternion.identity);
                    break;
                case "BongRed":
                    Objectpooler.Instance.SpawnFromPool("BongRedExploded", transform.position, Quaternion.identity);
                    break;
                case "BongYellow":
                    Objectpooler.Instance.SpawnFromPool("BongYellowExploded", transform.position, Quaternion.identity);
                    break;
                case "BongPumkin":
                    Objectpooler.Instance.SpawnFromPool("BongBlueExplodedLon", transform.position, Quaternion.identity);
                    Objectpooler.Instance.SpawnFromPool("Pumpkin", transform.position, Quaternion.identity);
                    break;
                case "BongCrow":
                    Objectpooler.Instance.SpawnFromPool("BongRedExplodedLon", transform.position, Quaternion.identity);
                    Objectpooler.Instance.SpawnFromPool("Crow", transform.position, Quaternion.identity);
                    break;
                case "BongBall":
                    Objectpooler.Instance.SpawnFromPool("BongGreenExplodedLon", transform.position, Quaternion.identity);
                    Objectpooler.Instance.SpawnFromPool("Ball", transform.position, Quaternion.identity);
                    break;
                case "BongThor":
                    Objectpooler.Instance.SpawnFromPool("BongYellowExplodedLon", transform.position, Quaternion.identity);
                    Instantiate(thor, transform.position, Quaternion.identity);
                    break;
                case "BongSupperman":
                    Objectpooler.Instance.SpawnFromPool("BongYellowExplodedLon", transform.position, Quaternion.identity);
                    Objectpooler.Instance.SpawnFromPool("Supperman", transform.position, Quaternion.identity);
                    break;
                case "BongHiepsi":
                    Objectpooler.Instance.SpawnFromPool("BongBlueExplodedLon", transform.position, Quaternion.identity);
                    Instantiate(hiepSi, transform.position, Quaternion.identity);
                    break;
            }
            if(gameObject.name=="BongBlue(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongBlue"].Enqueue(this.gameObject);
            }
            else if(gameObject.name== "BongGreen(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongGreen"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongRed(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongRed"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongYellow(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongYellow"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongYellow 3(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongYellow3"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongBlue 7(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongBlue7"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongGreen 6(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongGreen6"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongRed 6(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongRed6"].Enqueue(this.gameObject);
            }
            else if (gameObject.name == "BongYellow 6(Clone)")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["BongYellow6"].Enqueue(this.gameObject);
            }
            else Destroy(gameObject);
        }
    }
}
