using UnityEngine;

public class Bombno : MonoBehaviour
{
    [SerializeField] private GameObject Bombexploded;
    void OnMouseDown()
    {
        this.gameObject.SetActive(false);
        Objectpooler.Instance.poolDictionary["Bomb"].Enqueue(this.gameObject);
        Instantiate(Bombexploded, this.transform.position, Quaternion.identity);
        Gamemanager.isGameOver = true;
    }
}
