public class Bombmovement : Objectmovement
{
    void LateUpdate()
    {
        if (vectoequal(transform.position) == true)
        {
            if (gameObject.tag == "Coin")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Coin"].Enqueue(this.gameObject);
            }
            else if (gameObject.tag == "Bomb")
            {
                this.gameObject.SetActive(false);
                Objectpooler.Instance.poolDictionary["Bomb"].Enqueue(this.gameObject);
            }
            else Destroy(gameObject);
        }
    }
}
