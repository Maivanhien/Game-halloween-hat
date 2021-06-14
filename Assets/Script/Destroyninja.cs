using UnityEngine;

public class Destroyninja : MonoBehaviour
{
    [SerializeField] private GameObject ninjaPhitieu, phiTieu;
    private void OnMouseDown()
    {
        Instantiate(ninjaPhitieu, transform.position, Quaternion.identity);
        Instantiate(phiTieu, transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
        Objectpooler.Instance.poolDictionary["Ninja"].Enqueue(this.gameObject);
    }
}
