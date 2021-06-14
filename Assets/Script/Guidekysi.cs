using UnityEngine;

public class Guidekysi : MonoBehaviour
{
    [SerializeField] private GameObject gameplay;
    private GameObject gamePlay;
    private GameObject hat;
    void Start()
    {
        hat = GameObject.FindGameObjectWithTag("Hat");
        hat.gameObject.SetActive(false);
        gamePlay = Instantiate(gameplay, hat.transform.position, Quaternion.identity);
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hat.gameObject.SetActive(true);
            Hatoveride hatoveride = hat.GetComponent<Hatoveride>();
            hatoveride.silence = false;
            Destroy(gamePlay);
            Destroy(gameObject);
        }
    }
}
