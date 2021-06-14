using System.Collections;
using UnityEngine;

public class Hatoveride2 : MonoBehaviour
{
    public GameObject heart, bongBlue1, bongBlue2, bongBlue3, bongBlue4, bongBlue5, bongBlue6, bongGreen1, bongGreen2, bongGreen3, bongGreen4, bongGreen5, egdeRotation, egdeRotation1, bongPhanra, bomeRang, savelevel, snow, fallLeaves, trailSnow, trailLeaves, trailStart, trailbad, trailsword,
        bongRed1, bongRed2, bongRed3, bongRed4, bongRed5, bongRed7, bongYellow1, bongYellow2, bongYellow4, bongYellow5, bongYellow7, bongPumkin, bongBall, bongCrow, bongCrow1, bongThor, bongHiepsi, bongSupperman, circleRotation, addRotation, circleRotation1, circleRotation2, panel;
    private GameObject gameobject;
    private float timeDelay;
    [HideInInspector] public static float time;
    private bool isObjectCreate, silence, voice;
    private float speech,move;
    private bool right, left, isMaybay, issavelevel;
    private int rand, rand1, loop;
    private Animator animator;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        timeDelay = 1.8f;
        //time = 0f;
        time = PlayerPrefs.GetFloat("Gameplay2", 0);
        isObjectCreate = true;
        silence = false;
        voice = true;
        speech = 7.5f;
        move = 3f;
        right = true;
        left = false;
        isMaybay = false;
        issavelevel = true;
        rand1 = 0;
        StartCoroutine(changeAnimation());
        if (PlayerPrefs.GetInt("buttonSlash1", -1) == 1)
            Objectpooler.Instance.pools[20].prefab = trailSnow;
        else if (PlayerPrefs.GetInt("buttonSlash2", -1) == 1)
            Objectpooler.Instance.pools[20].prefab = trailStart;
        else if (PlayerPrefs.GetInt("buttonSlash3", -1) == 1)
            Objectpooler.Instance.pools[20].prefab = trailLeaves;
        else if (PlayerPrefs.GetInt("buttonSlash4", -1) == 1)
            Objectpooler.Instance.pools[20].prefab = trailbad;
        else if (PlayerPrefs.GetInt("buttonSlash5", -1) == 1)
            Objectpooler.Instance.pools[20].prefab = trailsword;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, move * Time.deltaTime, 0));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 7f), transform.position.z);
        if(transform.position.y==7f)
        {
            if (right == true)
            {
                transform.Translate(new Vector3(speech * Time.deltaTime, 0, 0));
            }
            if (left == true)
                transform.Translate(new Vector3(-speech * Time.deltaTime, 0, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2f, 2.25f), transform.position.y, transform.position.z);
            if (transform.position.x == 2.25f)
            {
                right = false;
                left = true;
            }
            if (transform.position.x == -2f)
            {
                right = true;
                left = false;
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameobject = Objectpooler.Instance.SpawnFromPool("Linear", new Vector3(pos.x, pos.y, 90), Quaternion.identity);
        }
        if(Input.GetMouseButtonUp(0))
        {
            CircleCollider2D circle = gameobject.GetComponent<CircleCollider2D>();
            ParticleSystem particle = gameobject.GetComponent<ParticleSystem>();
            circle.enabled = false;
            ParticleSystem.EmissionModule particle1 = particle.emission;
            particle1.enabled = false;
            gameobject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Linear"].Enqueue(gameobject);
        }
    }

    void LateUpdate()
    {
        if (voice == true)
        {
            if (time == 0)
            {
                StartCoroutine(objectSilence());
                voice = false;
            }
            else if (time == 128)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level = 5;
                voice = false;
            }
            else if (time == 256)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level = 9;
                voice = false;
            }
            else if (time == 384)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level = 13;
                voice = false;
            }
            else if(time % 32 == 0)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level += 1;
                voice = false;
            }
        }
        if (time >= 96 && time < 128)
        {
            timeDelay = 2f;
        }
        if (time >= 128)
        {
            timeDelay = 2.65f;
            if (isMaybay == true)
            {
                timeDelay = 3.52f;
                isMaybay = false;
            }
        }
        if (issavelevel == true)
        {
            if (time == 127)
            {
                StartCoroutine(clonesavelevel());
                issavelevel = false;
            }
            if (time == 255)
            {
                StartCoroutine(clonesavelevel());
                issavelevel = false;
            }
            if (time == 383)
            {
                StartCoroutine(clonesavelevel());
                issavelevel = false;
            }
        }
        if (time % 32 == 1)
        {
            voice = true;
        }
        if (silence == false)
        {
            if (isObjectCreate == true)
            {
                StartCoroutine(cloneObject());
                isObjectCreate = false;
            }
        }
    }

    IEnumerator changeAnimation()
    {
        yield return new WaitForSeconds(0f);
        if (PlayerPrefs.GetInt("buttonHat", 1) == 1)
            animator.Play("HatAnimation", 0);
        else if (PlayerPrefs.GetInt("buttonHat1", -1) == 1)
            animator.Play("Hat1Animation", 0);
        else if (PlayerPrefs.GetInt("buttonHat2", -1) == 1)
            animator.Play("Hat2Animation", 0);
        else if (PlayerPrefs.GetInt("buttonHat3", -1) == 1)
            animator.Play("Hat3Animation", 0);
        else if (PlayerPrefs.GetInt("buttonHat4", -1) == 1)
            animator.Play("Hat4Animation", 0);
        else if (PlayerPrefs.GetInt("buttonHat5", -1) == 1)
        {
            animator.Play("Hat5Animation", 0);
            Instantiate(snow);
        }
        else
        {
            animator.Play("Hat6Animation", 0);
            Instantiate(fallLeaves);
        }
    }

    IEnumerator objectSilence()
    {
        silence = true;
        yield return new WaitForSeconds(2f);
        silence = false;
    }

    IEnumerator cloneObject()
    {
        yield return new WaitForSeconds(timeDelay);
        time += 1;
        //Man 1
        if (time <= 32)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1://Hinh tron
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = {new Vector3(-1.356f, 5.353f, 95), new Vector3(-1.99f, 7.23f, 95), new Vector3(-0.317f, 6.07f, 95) };
                            objectswitch(3, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-1.99f, 5.54f, 95), new Vector3(-1.356f, 7.47f, 95), new Vector3(-0.721f, 5.54f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-2.423f, 6.06f, 95), new Vector3(-0.74f, 7.23f, 95) };
                            objectswitch(2, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-2.423f, 6.72f, 95), new Vector3(-0.317f, 6.72f, 95) };
                            objectswitch(2, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(1.356f, 5.353f, 95), new Vector3(1.99f, 7.23f, 95), new Vector3(0.317f, 6.07f, 95) };
                            objectswitch(3, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(1.99f, 5.54f, 95), new Vector3(1.356f, 7.47f, 95), new Vector3(0.721f, 5.54f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(2.423f, 6.06f, 95), new Vector3(0.74f, 7.23f, 95) };
                            objectswitch(2, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(2.423f, 6.72f, 95), new Vector3(0.317f, 6.72f, 95) };
                            objectswitch(2, vectorYellow2, "Yellow");
                        }
                        break;
                    case 2:
                        Instantiate(bongPumkin, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 3://Hinh tam giac
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-2.42f, 5.3f, 95), new Vector3(-1.01f, 6.5f, 95) };
                            objectswitch(2, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-2.14f, 5.92f, 95), new Vector3(-0.68f, 5.92f, 95), new Vector3(-1.73f, 5.3f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-1.81f, 6.5f, 95), new Vector3(-0.39f, 5.3f, 95) };
                            objectswitch(2, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-1.39f, 7.04f, 95), new Vector3(-1.05f, 5.3f, 95) };
                            objectswitch(2, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(2.42f, 5.3f, 95), new Vector3(1.01f, 6.5f, 95) };
                            objectswitch(2, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(2.14f, 5.92f, 95), new Vector3(0.68f, 5.92f, 95), new Vector3(1.73f, 5.3f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(1.81f, 6.5f, 95), new Vector3(0.39f, 5.3f, 95) };
                            objectswitch(2, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(1.39f, 7.04f, 95), new Vector3(1.05f, 5.3f, 95) };
                            objectswitch(2, vectorYellow2, "Yellow");
                        }
                        break;
                    case 4://Hinh vuong
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-2.37f, 5.36f, 95), new Vector3(-1.74f, 7.32f, 95), new Vector3(-0.44f, 6.01f, 95) };
                            objectswitch(3, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-2.37f, 6.01f, 95), new Vector3(-1.09f, 7.32f, 95), new Vector3(-0.44f, 5.36f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-2.37f, 6.66f, 95), new Vector3(-0.44f, 7.32f, 95), new Vector3(-1.08f, 5.36f, 95) };
                            objectswitch(3, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-2.37f, 7.32f, 95), new Vector3(-0.44f, 6.66f, 95), new Vector3(-1.72f, 5.36f, 95) };
                            objectswitch(3, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(2.37f, 5.36f, 95), new Vector3(1.74f, 7.32f, 95), new Vector3(0.44f, 6.01f, 95) };
                            objectswitch(3, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(2.37f, 6.01f, 95), new Vector3(1.09f, 7.32f, 95), new Vector3(0.44f, 5.36f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(2.37f, 6.66f, 95), new Vector3(0.44f, 7.32f, 95), new Vector3(1.08f, 5.36f, 95) };
                            objectswitch(3, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(2.37f, 7.32f, 95), new Vector3(0.44f, 6.66f, 95), new Vector3(1.72f, 5.36f, 95) };
                            objectswitch(3, vectorYellow2, "Yellow");
                        }
                        break;
                    case 5:
                        Instantiate(bongCrow, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 6://Hinh ngu giac
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-0.56f, 5.37f, 95), new Vector3(-2.39f, 6.58f, 95), new Vector3(-0.06f, 6.58f, 95) };
                            objectswitch(3, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-1.21f, 5.37f, 95), new Vector3(-1.81f, 6.94f, 95), new Vector3(-0.31f, 5.98f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-1.85f, 5.37f, 95), new Vector3(-1.21f, 7.24f, 95) };
                            objectswitch(2, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-2.11f, 5.98f, 95), new Vector3(-0.62f, 6.94f, 95) };
                            objectswitch(2, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(0.56f, 5.37f, 95), new Vector3(2.39f, 6.58f, 95), new Vector3(0.06f, 6.58f, 95) };
                            objectswitch(3, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(1.21f, 5.37f, 95), new Vector3(1.81f, 6.94f, 95), new Vector3(0.31f, 5.98f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(1.85f, 5.37f, 95), new Vector3(1.21f, 7.24f, 95) };
                            objectswitch(2, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(2.11f, 5.98f, 95), new Vector3(0.62f, 6.94f, 95) };
                            objectswitch(2, vectorYellow2, "Yellow");
                        }
                        break;
                    case 7:
                        //Ngoi sao
                        Vector3[] vectorBlue = { new Vector3(-0.29f, 7.57f, 95), new Vector3(0.79f, 6.02f, 95), new Vector3(-1.11f, 6.57f, 95), new Vector3(-0.94f, 5.4f, 95) };
                        objectswitch(4, vectorBlue, "Blue");
                        Vector3[] vectorGreen = { new Vector3(0.36f, 7.57f, 95), new Vector3(0.37f, 5.53f, 95), new Vector3(-0.75f, 7.1f, 95), new Vector3(1.47f, 7.17f, 95) };
                        objectswitch(4, vectorGreen, "Green");
                        Vector3[] vectorRed = { new Vector3(0.82f, 7.1f, 95), new Vector3(-0.3f, 5.53f, 95), new Vector3(0.04f, 8.15f, 95), new Vector3(-1.4f, 7.18f, 95) };
                        objectswitch(4, vectorRed, "Red");
                        Vector3[] vectorYellow = { new Vector3(1.18f, 6.57f, 95), new Vector3(-0.72f, 6.02f, 95), new Vector3(1.01f, 5.39f, 95) };
                        objectswitch(3, vectorYellow, "Yellow");
                        break;
                }
            }
        }
        //Man 2
        else if (time <= 64)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1://so 7
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(-2.05f, 7.707f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(-1.22f, 6.51f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(-1.4f, 7.707f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(-1.45f, 5.91f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongRed", new Vector3(-0.75f, 7.707f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongRed", new Vector3(-1.639f, 5.302f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongYellow", new Vector3(-0.97f, 7.11f, 95), Quaternion.identity);
                        }
                        else
                        {
                            Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(0.75f, 7.707f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(1.58f, 6.51f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(1.4f, 7.707f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(1.35f, 5.91f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongRed", new Vector3(2.05f, 7.707f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongRed", new Vector3(1.161f, 5.302f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongYellow", new Vector3(1.83f, 7.11f, 95), Quaternion.identity);
                        }
                        break;
                    case 2://so 2
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-2.19f, 7.468f, 95), new Vector3(-0.785f, 6.821f, 95), new Vector3(-1.36f, 5.29f, 95) };
                            objectswitch(3, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-1.685f, 7.886f, 95), new Vector3(-1.242f, 6.327f, 95), new Vector3(-0.72f, 5.29f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-1.04f, 7.861f, 95), new Vector3(-1.717f, 5.873f, 95) };
                            objectswitch(2, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-0.55f, 7.438f, 95), new Vector3(-1.996f, 5.29f, 95) };
                            objectswitch(2, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(0.55f, 7.468f, 95), new Vector3(1.955f, 6.821f, 95), new Vector3(1.38f, 5.29f, 95) };
                            objectswitch(3, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(1.055f, 7.886f, 95), new Vector3(1.498f, 6.327f, 95), new Vector3(2.02f, 5.29f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(1.7f, 7.861f, 95), new Vector3(1.023f, 5.873f, 95) };
                            objectswitch(2, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(2.19f, 7.438f, 95), new Vector3(0.744f, 5.29f, 95) };
                            objectswitch(2, vectorYellow2, "Yellow");
                        }
                        break;
                    case 3://bong Pumkin
                        Instantiate(bongPumkin, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 4://so 8
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-1.06f, 6.68f, 95), new Vector3(-1.38f, 8.03f, 95), new Vector3(-1.38f, 5.32f, 95) };
                            objectswitch(3, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-1.7f, 6.68f, 95), new Vector3(-0.74f, 7.79f, 95), new Vector3(-0.74f, 5.53f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-2.16f, 7.16f, 95), new Vector3(-0.62f, 7.16f, 95), new Vector3(-1.99f, 5.58f, 95) };
                            objectswitch(3, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-1.99f, 7.79f, 95), new Vector3(-2.16f, 6.21f, 95), new Vector3(-0.62f, 6.17f, 95) };
                            objectswitch(3, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(1.72f, 6.68f, 95), new Vector3(1.4f, 8.03f, 95), new Vector3(1.4f, 5.32f, 95) };
                            objectswitch(3, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(1.08f, 6.68f, 95), new Vector3(2.04f, 7.79f, 95), new Vector3(2.04f, 5.53f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(0.62f, 7.16f, 95), new Vector3(2.16f, 7.16f, 95), new Vector3(0.79f, 5.58f, 95) };
                            objectswitch(3, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(0.79f, 7.79f, 95), new Vector3(0.62f, 6.21f, 95), new Vector3(2.16f, 6.17f, 95) };
                            objectswitch(3, vectorYellow2, "Yellow");
                        }
                        break;
                    case 5://so 3
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-1.328f, 6.7f, 95), new Vector3(-1.968f, 8.09f, 95), new Vector3(-1.97f, 5.31f, 95) };
                            objectswitch(3, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-1.968f, 6.7f, 95), new Vector3(-1.328f, 8.09f, 95), new Vector3(-1.328f, 5.31f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-0.788f, 7.09f, 95), new Vector3(-0.788f, 6.31f, 95) };
                            objectswitch(2, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-0.788f, 7.74f, 95), new Vector3(-0.788f, 5.665f, 95) };
                            objectswitch(2, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(1.43f, 6.7f, 95), new Vector3(0.79f, 8.09f, 95), new Vector3(0.788f, 5.31f, 95) };
                            objectswitch(3, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(0.79f, 6.7f, 95), new Vector3(1.43f, 8.09f, 95), new Vector3(1.43f, 5.31f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(1.97f, 7.09f, 95), new Vector3(1.97f, 6.31f, 95) };
                            objectswitch(2, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(1.97f, 7.74f, 95), new Vector3(1.97f, 5.665f, 95) };
                            objectswitch(2, vectorYellow2, "Yellow");
                        }
                        break;
                    case 6://so 5
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-1.29f, 5.35f, 95), new Vector3(-1.93f, 6.83f, 95), new Vector3(-1.4f, 8.11f, 95) };
                            objectswitch(3, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-1.93f, 5.35f, 95), new Vector3(-1.29f, 6.83f, 95), new Vector3(-0.786f, 8.1f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-0.786f, 5.767f, 95), new Vector3(-2.07f, 7.469f, 95) };
                            objectswitch(2, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-0.786f, 6.42f, 95), new Vector3(-2.01f, 8.11f, 95) };
                            objectswitch(2, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(1.566f, 5.35f, 95), new Vector3(0.926f, 6.83f, 95), new Vector3(1.456f, 8.11f, 95) };
                            objectswitch(3, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(0.926f, 5.35f, 95), new Vector3(1.566f, 6.83f, 95), new Vector3(2.07f, 8.1f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(2.07f, 5.767f, 95), new Vector3(0.786f, 7.469f, 95) };
                            objectswitch(2, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(2.07f, 6.42f, 95), new Vector3(0.846f, 8.11f, 95) };
                            objectswitch(2, vectorYellow2, "Yellow");
                        }
                        break;
                    case 7:// bong Ball
                        Instantiate(bongBall, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8://so 9
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-1.18f, 6.81f, 95), new Vector3(-1.82f, 8.38f, 95), new Vector3(-0.54f, 6.81f, 95), new Vector3(-1.83f, 5.325f, 95) };
                            objectswitch(4, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-1.82f, 6.81f, 95), new Vector3(-1.18f, 8.37f, 95), new Vector3(-0.54f, 6.16f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-2.28f, 7.29f, 95), new Vector3(-0.57f, 8.1f, 95), new Vector3(-0.56f, 5.51f, 95) };
                            objectswitch(3, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-2.28f, 7.94f, 95), new Vector3(-0.54f, 7.44f, 95), new Vector3(-1.17f, 5.3f, 95) };
                            objectswitch(3, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(1.64f, 6.81f, 95), new Vector3(1f, 8.38f, 95), new Vector3(2.28f, 6.81f, 95), new Vector3(0.99f, 5.325f, 95) };
                            objectswitch(4, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(1f, 6.81f, 95), new Vector3(1.64f, 8.37f, 95), new Vector3(2.28f, 6.16f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(0.54f, 7.29f, 95), new Vector3(2.25f, 8.1f, 95), new Vector3(2.26f, 5.51f, 95) };
                            objectswitch(3, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(0.54f, 7.94f, 95), new Vector3(2.28f, 7.44f, 95), new Vector3(1.65f, 5.3f, 95) };
                            objectswitch(3, vectorYellow2, "Yellow");
                        }
                        break;
                }
            }
        }
        //Man 3
        else if (time <= 96)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1://chu R
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-2.2f, 8f, 95), new Vector3(-2.2f, 5.37f, 95), new Vector3(-0.961f, 7.768f, 95) };
                            objectswitch(3, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-2.2f, 7.34f, 95), new Vector3(-1.648f, 6.34f, 95), new Vector3(-1.556f, 8f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-2.2f, 6.68f, 95), new Vector3(-1.251f, 5.823f, 95), new Vector3(-0.776f, 7.141f, 95) };
                            objectswitch(3, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-2.2f, 6.02f, 95), new Vector3(-1.05f, 6.557f, 95), new Vector3(-0.832f, 5.325f, 95) };
                            objectswitch(3, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(0.776f, 8f, 95), new Vector3(0.776f, 5.37f, 95), new Vector3(2.015f, 7.768f, 95) };
                            objectswitch(3, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(0.776f, 7.34f, 95), new Vector3(1.328f, 6.34f, 95), new Vector3(1.42f, 8f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(0.776f, 6.68f, 95), new Vector3(1.725f, 5.823f, 95), new Vector3(2.2f, 7.141f, 95) };
                            objectswitch(3, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(0.776f, 6.02f, 95), new Vector3(1.926f, 6.557f, 95), new Vector3(2.144f, 5.325f, 95) };
                            objectswitch(3, vectorYellow2, "Yellow");
                        }
                        break;
                    case 2://chu S
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-0.69f, 7.657f, 95), new Vector3(-2.129f, 7.178f, 95), new Vector3(-1.279f, 5.365f, 95) };
                            objectswitch(3, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-1.16f, 8.1f, 95), new Vector3(-1.594f, 6.797f, 95), new Vector3(-1.909f, 5.386f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-1.81f, 8.17f, 95), new Vector3(-1.058f, 6.425f, 95), new Vector3(-2.358f, 5.859f, 95) };
                            objectswitch(3, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-2.36f, 7.8f, 95), new Vector3(-0.789f, 5.827f, 95) };
                            objectswitch(2, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(2.36f, 7.657f, 95), new Vector3(0.921f, 7.178f, 95), new Vector3(1.771f, 5.365f, 95) };
                            objectswitch(3, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(1.89f, 8.1f, 95), new Vector3(1.456f, 6.797f, 95), new Vector3(1.141f, 5.386f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(1.24f, 8.17f, 95), new Vector3(1.992f, 6.425f, 95), new Vector3(0.692f, 5.859f, 95) };
                            objectswitch(3, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(0.69f, 7.8f, 95), new Vector3(2.261f, 5.827f, 95) };
                            objectswitch(2, vectorYellow2, "Yellow");
                        }
                        break;
                    case 3://chu D
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-2.14f, 7.33f, 95), new Vector3(-1.5f, 5.35f, 95) };
                            objectswitch(2, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-2.14f, 6.67f, 95), new Vector3(-1.49f, 7.33f, 95), new Vector3(-0.93f, 5.71f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-2.14f, 6.01f, 95), new Vector3(-0.93f, 6.98f, 95) };
                            objectswitch(2, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-2.14f, 5.35f, 95), new Vector3(-0.75f, 6.34f, 95) };
                            objectswitch(2, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(0.75f, 7.33f, 95), new Vector3(1.39f, 5.35f, 95) };
                            objectswitch(2, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(0.75f, 6.67f, 95), new Vector3(1.4f, 7.33f, 95), new Vector3(1.96f, 5.71f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(0.75f, 6.01f, 95), new Vector3(1.96f, 6.98f, 95) };
                            objectswitch(2, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(0.75f, 5.35f, 95), new Vector3(2.14f, 6.34f, 95) };
                            objectswitch(2, vectorYellow2, "Yellow");
                        }
                        break;
                    case 4://chu L
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(-2.15f, 7.33f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(-1.51f, 5.35f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(-2.15f, 6.67f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(-0.865f, 5.35f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongRed", new Vector3(-2.15f, 6.01f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongYellow", new Vector3(-2.15f, 5.35f, 95), Quaternion.identity);
                        }
                        else
                        {
                            Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(0.865f, 7.33f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(1.505f, 5.35f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(0.865f, 6.67f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(2.15f, 5.35f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongRed", new Vector3(0.865f, 6.01f, 95), Quaternion.identity);
                            Objectpooler.Instance.SpawnFromPool("BongYellow", new Vector3(0.865f, 5.35f, 95), Quaternion.identity);
                        }
                        break;
                    case 5://chu A
                        Vector3[] vectorBlue = { new Vector3(-1.335f, 5.315f, 95), new Vector3(-0.013f, 7.58f, 95), new Vector3(1.385f, 5.315f, 95) };
                        objectswitch(3, vectorBlue, "Blue");
                        Vector3[] vectorGreen = { new Vector3(-1.01f, 5.882f, 95), new Vector3(0.385f, 7.03f, 95), new Vector3(0.313f, 5.982f, 95) };
                        objectswitch(3, vectorGreen, "Green");
                        Vector3[] vectorRed = { new Vector3(-0.708f, 6.468f, 95), new Vector3(0.735f, 6.468f, 95) };
                        objectswitch(2, vectorRed, "Red");
                        Vector3[] vectorYellow = { new Vector3(-0.37f, 7.03f, 95), new Vector3(1.035f, 5.882f, 95), new Vector3(-0.309f, 5.966f, 95) };
                        objectswitch(3, vectorYellow, "Yellow");
                        break;
                    case 6:// bong Ball
                        Instantiate(bongBall, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 7://chu K
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-2.18f, 7.98f, 95), new Vector3(-2.18f, 5.35f, 95), new Vector3(-1.155f, 7.441f, 95) };
                            objectswitch(3, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-2.18f, 7.32f, 95), new Vector3(-1.604f, 6.32f, 95), new Vector3(-0.729f, 7.942f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-2.18f, 6.66f, 95), new Vector3(-1.155f, 5.829f, 95) };
                            objectswitch(2, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-2.18f, 6f, 95), new Vector3(-1.604f, 6.975f, 95), new Vector3(-0.701f, 5.357f, 95) };
                            objectswitch(3, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(0.701f, 7.98f, 95), new Vector3(0.701f, 5.35f, 95), new Vector3(1.726f, 7.441f, 95) };
                            objectswitch(3, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(0.701f, 7.32f, 95), new Vector3(1.277f, 6.32f, 95), new Vector3(2.152f, 7.942f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(0.701f, 6.66f, 95), new Vector3(1.726f, 5.829f, 95) };
                            objectswitch(2, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(0.701f, 6f, 95), new Vector3(1.277f, 6.975f, 95), new Vector3(2.18f, 5.357f, 95) };
                            objectswitch(3, vectorYellow2, "Yellow");
                        }
                        break;
                    case 8://chu W
                        Vector3[] vectorBlue3 = { new Vector3(-1.6f, 7.15f, 95), new Vector3(-0.575f, 5.895f, 95), new Vector3(0.577f, 5.88f, 95), new Vector3(1.657f, 7.11f, 95) };
                        objectswitch(4, vectorBlue3, "Blue");
                        Vector3[] vectorGreen3 = { new Vector3(-1.44f, 6.52f, 95), new Vector3(-0.305f, 6.465f, 95), new Vector3(0.91f, 5.32f, 95) };
                        objectswitch(3, vectorGreen3, "Green");
                        Vector3[] vectorRed3 = { new Vector3(-1.2f, 5.9f, 95), new Vector3(-0.013f, 7.03f, 95), new Vector3(1.217f, 5.88f, 95) };
                        objectswitch(3, vectorRed3, "Red");
                        Vector3[] vectorYellow3 = { new Vector3(-0.91f, 5.32f, 95), new Vector3(0.32f, 6.48f, 95), new Vector3(1.442f, 6.498f, 95) };
                        objectswitch(3, vectorYellow3, "Yellow");
                        break;
                }
            }
        }
        //Man 4
        else if (time <= 128)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1://Hinh hop chu nhat
                        Vector3[] vectorBlue = { new Vector3(0.37f, 5.36f, 95), new Vector3(-1.57f, 6.02f, 95), new Vector3(-0.27f, 7.32f, 95), new Vector3(-1.255f, 7.892f, 95), new Vector3(1.071f, 8.436f, 95), new Vector3(1.516f, 6.715f, 95) };
                        objectswitch(6, vectorBlue, "Blue");
                        Vector3[] vectorGreen = { new Vector3(-0.27f, 5.36f, 95), new Vector3(-1.57f, 6.67f, 95), new Vector3(0.37f, 7.32f, 95), new Vector3(-0.9f, 8.436f, 95), new Vector3(1.558f, 8f, 95), new Vector3(1.504f, 6.067f, 95) };
                        objectswitch(6, vectorGreen, "Green");
                        Vector3[] vectorRed = { new Vector3(-0.91f, 5.36f, 95), new Vector3(-1.57f, 7.32f, 95), new Vector3(0.37f, 6.67f, 95), new Vector3(-0.24f, 8.436f, 95), new Vector3(0.743f, 7.867f, 95), new Vector3(0.936f, 5.713f, 95) };
                        objectswitch(6, vectorRed, "Red");
                        Vector3[] vectorYellow = { new Vector3(-1.57f, 5.36f, 95), new Vector3(-0.91f, 7.32f, 95), new Vector3(0.37f, 6.02f, 95), new Vector3(0.41f, 8.436f, 95), new Vector3(1.528f, 7.353f, 95) };
                        objectswitch(5, vectorYellow, "Yellow");
                        break;
                    case 2://Cay nam
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(0.097f, 6.518f, 95), new Vector3(-2.493f, 6.518f, 95), new Vector3(-1.518f, 5.308f, 95), new Vector3(-0.906f, 7.974f, 95) };
                            objectswitch(4, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-0.543f, 6.518f, 95), new Vector3(-2.493f, 7.161f, 95), new Vector3(0.097f, 7.166f, 95) };
                            objectswitch(3, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-1.193f, 6.518f, 95), new Vector3(-2.171f, 7.743f, 95), new Vector3(-0.859f, 5.952f, 95), new Vector3(-0.291f, 7.707f, 95) };
                            objectswitch(4, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-1.843f, 6.518f, 95), new Vector3(-1.56f, 7.98f, 95), new Vector3(-1.518f, 5.952f, 95), new Vector3(-0.859f, 5.308f, 95) };
                            objectswitch(4, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(-0.097f, 6.518f, 95), new Vector3(2.493f, 6.518f, 95), new Vector3(1.518f, 5.308f, 95), new Vector3(0.906f, 7.974f, 95) };
                            objectswitch(4, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(0.543f, 6.518f, 95), new Vector3(2.493f, 7.161f, 95), new Vector3(-0.097f, 7.166f, 95) };
                            objectswitch(3, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(1.193f, 6.518f, 95), new Vector3(2.171f, 7.743f, 95), new Vector3(0.859f, 5.952f, 95), new Vector3(0.291f, 7.707f, 95) };
                            objectswitch(4, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(1.843f, 6.518f, 95), new Vector3(1.56f, 7.98f, 95), new Vector3(1.518f, 5.952f, 95), new Vector3(0.859f, 5.308f, 95) };
                            objectswitch(4, vectorYellow2, "Yellow");
                        }
                        break;
                    case 3://Hinh chop tu giac
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-0.778f, 5.344f, 95), new Vector3(-1.212f, 7.958f, 95) };
                            objectswitch(2, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-1.378f, 5.604f, 95), new Vector3(-0.288f, 5.784f, 95), new Vector3(-0.882f, 6.016f, 95), new Vector3(-1.723f, 7.439f, 95), new Vector3(-0.557f, 7.641f, 95) };
                            objectswitch(5, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-1.968f, 5.924f, 95), new Vector3(0.112f, 6.304f, 95), new Vector3(-0.996f, 6.662f, 95), new Vector3(-2.092f, 6.855f, 95), new Vector3(-0.003f, 7.197f, 95) };
                            objectswitch(5, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-2.518f, 6.304f, 95), new Vector3(0.55f, 6.79f, 95), new Vector3(-1.103f, 7.311f, 95) };
                            objectswitch(3, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(0.778f, 5.344f, 95), new Vector3(1.212f, 7.958f, 95) };
                            objectswitch(2, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(1.378f, 5.604f, 95), new Vector3(0.288f, 5.784f, 95), new Vector3(0.882f, 6.016f, 95), new Vector3(1.723f, 7.439f, 95), new Vector3(0.557f, 7.641f, 95) };
                            objectswitch(5, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(1.968f, 5.924f, 95), new Vector3(-0.112f, 6.304f, 95), new Vector3(0.996f, 6.662f, 95), new Vector3(2.092f, 6.855f, 95), new Vector3(0.003f, 7.197f, 95) };
                            objectswitch(5, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(2.518f, 6.304f, 95), new Vector3(-0.55f, 6.79f, 95), new Vector3(1.103f, 7.311f, 95) };
                            objectswitch(3, vectorYellow2, "Yellow");
                        }
                        break;
                    case 4://Phi tieu
                        Vector3[] vectorBlue3 = { new Vector3(0.025f, 8.957f, 95), new Vector3(-1.753f, 7.127f, 95), new Vector3(1.726f, 7.138f, 95), new Vector3(0.015f, 5.38f, 95) };
                        objectswitch(4, vectorBlue3, "Blue");
                        Vector3[] vectorGreen3 = { new Vector3(-0.32f, 8.381f, 95), new Vector3(0.365f, 8.381f, 95), new Vector3(-1.177f, 7.479f, 95), new Vector3(-1.211f, 6.735f, 95), new Vector3(1.222f, 6.735f, 95), new Vector3(1.175f, 7.479f, 95) };
                        objectswitch(6, vectorGreen3, "Green");
                        Vector3[] vectorRed3 = { new Vector3(-0.587f, 7.768f, 95), new Vector3(0.595f, 7.768f, 95), new Vector3(-0.587f, 6.544f, 95), new Vector3(0.595f, 6.544f, 95) };
                        objectswitch(4, vectorRed3, "Red");
                        Vector3[] vectorYellow3 = { new Vector3(0.01f, 7.479f, 95), new Vector3(0.01f, 6.83f, 95), new Vector3(-0.32f, 5.94f, 95), new Vector3(0.365f, 5.93f, 95) };
                        objectswitch(4, vectorYellow3, "Yellow");
                        break;
                    case 5://Hinh tru
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-2.5f, 5.95f, 95), new Vector3(-2.5f, 8.56f, 95), new Vector3(-0.23f, 5.95f, 95), new Vector3(-0.23f, 8.56f, 95), new Vector3(-0.801f, 6.27f, 95), new Vector3(-1.95f, 6.27f, 95) };
                            objectswitch(6, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-2.5f, 6.6f, 95), new Vector3(-0.23f, 6.6f, 95), new Vector3(-2.02f, 9.008f, 95), new Vector3(-1.93f, 8.242f, 95), new Vector3(-2.02f, 5.496f, 95) };
                            objectswitch(5, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-2.5f, 7.25f, 95), new Vector3(-0.23f, 7.25f, 95), new Vector3(-1.365f, 9.146f, 95), new Vector3(-1.358f, 8.036f, 95), new Vector3(-1.365f, 5.34f, 95), new Vector3(-1.379f, 6.527f, 95) };
                            objectswitch(6, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-2.5f, 7.91f, 95), new Vector3(-0.23f, 7.91f, 95), new Vector3(-0.71f, 9.016f, 95), new Vector3(-0.786f, 8.242f, 95), new Vector3(-0.71f, 5.496f, 95) };
                            objectswitch(5, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(2.5f, 5.95f, 95), new Vector3(2.5f, 8.56f, 95), new Vector3(0.23f, 5.95f, 95), new Vector3(0.23f, 8.56f, 95), new Vector3(0.801f, 6.27f, 95), new Vector3(1.95f, 6.27f, 95) };
                            objectswitch(6, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(2.5f, 6.6f, 95), new Vector3(0.23f, 6.6f, 95), new Vector3(2.02f, 9.008f, 95), new Vector3(1.93f, 8.242f, 95), new Vector3(2.02f, 5.496f, 95) };
                            objectswitch(5, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(2.5f, 7.25f, 95), new Vector3(0.23f, 7.25f, 95), new Vector3(1.365f, 9.146f, 95), new Vector3(1.358f, 8.036f, 95), new Vector3(1.365f, 5.34f, 95), new Vector3(1.379f, 6.527f, 95) };
                            objectswitch(6, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(2.5f, 7.91f, 95), new Vector3(0.23f, 7.91f, 95), new Vector3(0.71f, 9.016f, 95), new Vector3(0.786f, 8.242f, 95), new Vector3(0.71f, 5.496f, 95) };
                            objectswitch(5, vectorYellow2, "Yellow");
                        }
                        break;
                    case 6:// bong Ball
                        Instantiate(bongBall, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 7://Binh ho lo
                        loop = Random.Range(1, 3);
                        if (loop == 1)
                        {
                            Vector3[] vectorBlue1 = { new Vector3(-0.1f, 7.56f, 95), new Vector3(-1.78f, 8.15f, 95), new Vector3(-0.43f, 6.99f, 95), new Vector3(-1.42f, 6.41f, 95), new Vector3(-0.41f, 5.87f, 95), new Vector3(-2.481f, 5.92f, 95) };
                            objectswitch(6, vectorBlue1, "Blue");
                            Vector3[] vectorGreen1 = { new Vector3(-0.74f, 7.56f, 95), new Vector3(-1.46f, 8.72f, 95), new Vector3(-0.41f, 8.13f, 95), new Vector3(-0.07f, 6.43f, 95), new Vector3(-1.79f, 5.87f, 95), new Vector3(-0.02f, 5.33f, 95) };
                            objectswitch(6, vectorGreen1, "Green");
                            Vector3[] vectorRed1 = { new Vector3(-1.38f, 7.56f, 95), new Vector3(-1.1f, 9.26f, 95), new Vector3(-2.09f, 6.45f, 95), new Vector3(-2.18f, 5.32f, 95), new Vector3(-0.769f, 5.329f, 95), new Vector3(0.32f, 5.9f, 95) };
                            objectswitch(6, vectorRed1, "Red");
                            Vector3[] vectorYellow1 = { new Vector3(-2.04f, 7.56f, 95), new Vector3(-0.75f, 8.7f, 95), new Vector3(-1.71f, 6.99f, 95), new Vector3(-0.76f, 6.42f, 95), new Vector3(-1.45f, 5.31f, 95) };
                            objectswitch(5, vectorYellow1, "Yellow");
                        }
                        else
                        {
                            Vector3[] vectorBlue2 = { new Vector3(0.1f, 7.56f, 95), new Vector3(1.78f, 8.15f, 95), new Vector3(0.43f, 6.99f, 95), new Vector3(1.42f, 6.41f, 95), new Vector3(0.41f, 5.87f, 95), new Vector3(2.481f, 5.92f, 95) };
                            objectswitch(6, vectorBlue2, "Blue");
                            Vector3[] vectorGreen2 = { new Vector3(0.74f, 7.56f, 95), new Vector3(1.46f, 8.72f, 95), new Vector3(0.41f, 8.13f, 95), new Vector3(0.07f, 6.43f, 95), new Vector3(1.79f, 5.87f, 95), new Vector3(0.02f, 5.33f, 95) };
                            objectswitch(6, vectorGreen2, "Green");
                            Vector3[] vectorRed2 = { new Vector3(1.38f, 7.56f, 95), new Vector3(1.1f, 9.26f, 95), new Vector3(2.09f, 6.45f, 95), new Vector3(2.18f, 5.32f, 95), new Vector3(0.769f, 5.329f, 95), new Vector3(-0.32f, 5.9f, 95) };
                            objectswitch(6, vectorRed2, "Red");
                            Vector3[] vectorYellow2 = { new Vector3(2.04f, 7.56f, 95), new Vector3(0.75f, 8.7f, 95), new Vector3(1.71f, 6.99f, 95), new Vector3(0.76f, 6.42f, 95), new Vector3(1.45f, 5.31f, 95) };
                            objectswitch(5, vectorYellow2, "Yellow");
                        }
                        break;
                    case 8://Buom Buom
                        Vector3[] vectorBlue4 = { new Vector3(0.5f, 6.63f, 95), new Vector3(-1.33f, 7.76f, 95), new Vector3(-1.31f, 5.61f, 95), new Vector3(1.75f, 7.3f, 95), new Vector3(1.7f, 6.11f, 95), new Vector3(-0.01f, 6.19f, 95) };
                        objectswitch(6, vectorBlue4, "Blue");
                        Vector3[] vectorGreen4 = { new Vector3(-0.5f, 6.64f, 95), new Vector3(0.63f, 5.99f, 95), new Vector3(0.63f, 7.27f, 95), new Vector3(-1.75f, 7.32f, 95), new Vector3(-1.68f, 6.11f, 95), new Vector3(1.33f, 5.63f, 95) };
                        objectswitch(6, vectorGreen4, "Green");
                        Vector3[] vectorRed4 = { new Vector3(-0.62f, 7.27f, 95), new Vector3(0.76f, 7.92f, 95), new Vector3(-0.62f, 5.99f, 95), new Vector3(0.76f, 5.35f, 95), new Vector3(-1.17f, 7f, 95), new Vector3(-1.09f, 6.38f, 95) };
                        objectswitch(6, vectorRed4, "Red");
                        Vector3[] vectorYellow4 = { new Vector3(-0.75f, 7.92f, 95), new Vector3(-0.75f, 5.35f, 95), new Vector3(1.11f, 6.37f, 95), new Vector3(1.17f, 6.98f, 95), new Vector3(1.33f, 7.72f, 95), new Vector3(0.01f, 7.06f, 95) };
                        objectswitch(6, vectorYellow4, "Yellow");
                        break;
                }
            }
        }
        //Man 5
        else if (time <= 160)
        {
            if(time%8==0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        //Di chuyen cheo
                        StartCoroutine(cloneBong1());
                        break;
                    case 2:
                        //Bong pumpkin and crow
                        StartCoroutine(clonePumpkinandcrow());
                        break;
                    case 3:
                        // Di chuyen hinh sin
                        StartCoroutine(cloneBong2());
                        break;
                    case 4:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                    case 5:
                        //Da(nhieu) bong
                        Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(0.78f, 5.33f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(-1.57f, 8.35f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(-1.85f, 6.02f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(2.31f, 10.34f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongRed", new Vector3(1.83f, 6.68f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongRed", new Vector3(0.06f, 9.56f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow", new Vector3(-0.47f, 7.16f, 95), Quaternion.identity);
                        Instantiate(bongCrow, new Vector3(1.18f, 8.2f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(-2.33f, 10.15f, 95), Quaternion.identity);
                        break;
                    case 6:
                        // Quay hinh tron
                        int i = Random.Range(1, 3);
                        if (i == 1) Instantiate(circleRotation, new Vector3(-1.2f, 6.7f, 95f), Quaternion.identity);
                        else Instantiate(circleRotation, new Vector3(1.2f, 6.7f, 95f), Quaternion.identity);
                        break;
                    case 7:
                        //Bong crow
                        Instantiate(bongCrow, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                }
            }
        }
        //Man 6
        else if (time <= 192)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        //Di chuyen cheo
                        StartCoroutine(cloneBong1());
                        break;
                    case 2:
                        // Di chuyen hinh sin
                        StartCoroutine(cloneBong2());
                        break;
                    case 3:
                        // bong pumkin and crow
                        StartCoroutine(clonePumpkinandcrow());
                        break;
                    case 4:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                    case 5:
                        // Quay hinh tron
                        int i = Random.Range(1, 3);
                        if (i == 1) Instantiate(circleRotation, new Vector3(-1.2f, 6.7f, 95f), Quaternion.identity);
                        else Instantiate(circleRotation, new Vector3(1.2f, 6.7f, 95f), Quaternion.identity);
                        break;
                    case 6:
                        //nhung duong vet chem
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-1.14f, 5.88f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-0.628f, 5.482f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(0.62f, 5.482f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(1.13f, 5.88f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(0.004f, 5.331f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(0.18f, 8.38f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(0.692f, 7.982f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(1.94f, 7.982f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(2.45f, 8.38f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(1.324f, 7.831f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-2.47f, 10.88f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-1.958f, 10.482f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-0.71f, 10.482f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-0.2f, 10.88f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-1.326f, 10.331f, 95), Quaternion.identity);
                        break;
                    case 7:
                        // bong crow
                        Instantiate(bongCrow, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8:
                        //Di chuyen nua duong tron
                        StartCoroutine(cloneBong7vang());
                        break;
                }
            }
        }
        //Man 7
        else if (time <= 224)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        //Quay 1 canh o goc
                        Instantiate(egdeRotation1, new Vector3(2.5f, 5.3f, 95f), Quaternion.identity);
                        Instantiate(egdeRotation1, new Vector3(-2.5f, 5.3f, 95f), Quaternion.identity);
                        break;
                    case 2:
                        // Di chuyen hinh sin
                        StartCoroutine(cloneBong2());
                        break;
                    case 3:
                        // bong ball
                        Instantiate(bongBall, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 4:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                    case 5:
                        // Quay dau cong
                        Instantiate(addRotation, new Vector3(0f, 6.4f, 95f), Quaternion.identity);
                        break;
                    case 6:
                        //Di chuyen nhieu huong
                        StartCoroutine(cloneBongxanh());
                        break;
                    case 7:
                        // bong crow
                        Instantiate(bongCrow, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8:
                        //Di chuyen nua duong tron
                        StartCoroutine(cloneBong7vang());
                        break;
                }
            }
        }
        //Man 8
        else if (time <= 256)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        //Quay 1 canh o goc
                        Instantiate(egdeRotation1, new Vector3(2.5f, 5.3f, 95f), Quaternion.identity);
                        Instantiate(egdeRotation1, new Vector3(-2.5f, 5.3f, 95f), Quaternion.identity);
                        break;
                    case 2:
                        // Di chuyen hinh sin
                        StartCoroutine(cloneBong2());
                        break;
                    case 3:
                        // bong ball
                        Instantiate(bongBall, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 4:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                    case 5:
                        // Quay dau cong
                        Instantiate(addRotation, new Vector3(0f, 6.4f, 95f), Quaternion.identity);
                        break;
                    case 6:
                        //Bong phan ra
                        Instantiate(bongPhanra, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 7:
                        // bong crow
                        Instantiate(bongCrow, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8:
                        //Di chuyen nua duong tron
                        StartCoroutine(cloneBong7vang());
                        break;
                }
            }
        }
        //Man 9
        else if (time <= 288)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        // Di chuyen hinh sin
                        StartCoroutine(cloneBong2());
                        break;
                    case 2:
                        // Di chuyen cheo xuyen khong
                        StartCoroutine(cloneBongGreen());
                        break;
                    case 3:
                        // bong Thor
                        Instantiate(bongThor, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 4:
                        //Di chuyen ngang xuyen khong
                        StartCoroutine(cloneBongRed());
                        break;
                    case 5:
                        // Quay 1 canh
                        Instantiate(egdeRotation, new Vector3(0f, 5.3f, 95f), Quaternion.identity);
                        break;
                    case 6:
                        //Da(nhieu) bong
                        Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(0.78f, 5.33f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(-1.57f, 8.35f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(-1.85f, 6.02f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongGreen", new Vector3(2.31f, 10.34f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongRed", new Vector3(1.83f, 6.68f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongRed", new Vector3(0.06f, 9.56f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow", new Vector3(-0.47f, 7.16f, 95), Quaternion.identity);
                        Instantiate(bongCrow, new Vector3(1.18f, 8.2f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongBlue", new Vector3(-2.33f, 10.15f, 95), Quaternion.identity);
                        break;
                    case 7:
                        // bong crow
                        Instantiate(bongCrow, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                }
            }
        }
        //Man 10
        else if (time <= 320)
        {
            if (time == 299 || time == 310)
            {
                isMaybay = true;
                //May bay
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-0.052f, 5.303f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-1.067f, 7.137f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(1.019f, 7.137f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-0.937f, 9.467f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(0.939f, 9.489f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(1.82f, 6.517f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.682f, 5.44f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.575f, 5.44f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.764f, 7.719f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.759f, 7.719f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.309f, 9.532f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.32f, 9.538f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.176f, 5.868f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(1.07f, 5.868f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-0.397f, 8.271f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(0.425f, 8.28f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.88f, 6.47f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.731f, 7.093f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(1.699f, 7.143f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-1.245f, 6.506f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(1.181f, 6.506f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-0.666f, 8.862f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(0.699f, 8.876f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-2.384f, 6.926f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(2.329f, 6.983f, 95), Quaternion.identity);
                Instantiate(bongCrow1, new Vector3(-0.031f, 6.543f, 95), Quaternion.identity);
            }
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        // Di chuyen hinh sin
                        StartCoroutine(cloneBong2());
                        break;
                    case 2:
                        // Di chuyen cheo xuyen khong
                        StartCoroutine(cloneBongGreen());
                        break;
                    case 3:
                        // bong Hiep si
                        Instantiate(bongHiepsi, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 4:
                        //Di chuyen ngang xuyen khong
                        StartCoroutine(cloneBongRed());
                        break;
                    case 5:
                        // Quay 1 canh
                        Instantiate(egdeRotation, new Vector3(0f, 5.3f, 95f), Quaternion.identity);
                        break;
                    case 6:
                        //nhung duong vet chem
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-1.14f, 5.88f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-0.628f, 5.482f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(0.62f, 5.482f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(1.13f, 5.88f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(0.004f, 5.331f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(0.18f, 8.38f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(0.692f, 7.982f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(1.94f, 7.982f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(2.45f, 8.38f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(1.324f, 7.831f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-2.47f, 10.88f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-1.958f, 10.482f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-0.71f, 10.482f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-0.2f, 10.88f, 95), Quaternion.identity);
                        Objectpooler.Instance.SpawnFromPool("BongYellow3", new Vector3(-1.326f, 10.331f, 95), Quaternion.identity);
                        break;
                    case 7:
                        // bong crow
                        Instantiate(bongCrow, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                }
            }
        }
        //Man 11
        else if (time <= 352)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        // Di chuyen hinh bac 3
                        StartCoroutine(cloneBong7red());
                        break;
                    case 2:
                        //Di chuyen ngang xuyen khong
                        StartCoroutine(cloneBongRed());
                        break;
                    case 3:
                        // bong Ball
                        Instantiate(bongBall, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 4:
                        //Bomerang
                        Instantiate(bomeRang, new Vector3(1.9f, 5.9f, 95f), Quaternion.identity);
                        break;
                    case 5:
                        // Quay 1 canh
                        Instantiate(egdeRotation, new Vector3(0f, 5.3f, 95f), Quaternion.identity);
                        break;
                    case 6:
                        //Di chuyen nhieu huong
                        StartCoroutine(cloneBongxanh());
                        break;
                    case 7:
                        // bong Thor
                        Instantiate(bongThor, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                }
            }
        }
        //Man 12
        else if (time <= 384)
        {
            if (time == 363 || time == 374)
            {
                isMaybay = true;
                //May bay
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-0.052f, 5.303f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-1.067f, 7.137f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(1.019f, 7.137f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-0.937f, 9.467f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(0.939f, 9.489f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(1.82f, 6.517f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.682f, 5.44f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.575f, 5.44f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.764f, 7.719f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.759f, 7.719f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.309f, 9.532f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.32f, 9.538f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.176f, 5.868f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(1.07f, 5.868f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-0.397f, 8.271f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(0.425f, 8.28f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.88f, 6.47f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.731f, 7.093f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(1.699f, 7.143f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-1.245f, 6.506f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(1.181f, 6.506f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-0.666f, 8.862f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(0.699f, 8.876f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-2.384f, 6.926f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(2.329f, 6.983f, 95), Quaternion.identity);
                Instantiate(bongCrow1, new Vector3(-0.031f, 6.543f, 95), Quaternion.identity);
            }
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        // Di chuyen hinh bac 3
                        StartCoroutine(cloneBong7red());
                        break;
                    case 2:
                        //Di chuyen ngang xuyen khong
                        StartCoroutine(cloneBongRed());
                        break;
                    case 3:
                        // bong Ball
                        Instantiate(bongBall, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 4:
                        //Bomerang
                        Instantiate(bomeRang, new Vector3(1.9f, 5.9f, 95f), Quaternion.identity);
                        break;
                    case 5:
                        // Quay 1 canh
                        Instantiate(egdeRotation, new Vector3(0f, 5.3f, 95f), Quaternion.identity);
                        break;
                    case 6:
                        //Bong phan ra
                        Instantiate(bongPhanra, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 7:
                        // bong Hiep si
                        Instantiate(bongHiepsi, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                }
            }
        }
        //Man 13
        else if (time <= 416)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        // Di chuyen hinh bac 3
                        StartCoroutine(cloneBong7red());
                        break;
                    case 2:
                        //Quay 1 canh o goc
                        Instantiate(egdeRotation1, new Vector3(2.5f, 5.3f, 95f), Quaternion.identity);
                        Instantiate(egdeRotation1, new Vector3(-2.5f, 5.3f, 95f), Quaternion.identity);
                        break;
                    case 3:
                        // bong Hiep si
                        Instantiate(bongHiepsi, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 4:
                        //Di chuyen nua duong tron
                        StartCoroutine(cloneBong7vang());
                        break;
                    case 5:
                        // Quay 2 hinh tron
                        Instantiate(circleRotation1, new Vector3(0f, 6.8f, 95f), Quaternion.identity);
                        Instantiate(circleRotation2, new Vector3(0f, 6.8f, 95f), Quaternion.identity);
                        break;
                    case 6:
                        //Bomerang
                        Instantiate(bomeRang, new Vector3(1.9f, 5.9f, 95f), Quaternion.identity);
                        break;
                    case 7:
                        // bong Thor
                        Instantiate(bongThor, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                }
            }
        }
        //Man 14
        else if (time <= 448)
        {
            if (time == 427 || time == 438)
            {
                isMaybay = true;
                //May bay
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-0.052f, 5.303f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-1.067f, 7.137f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(1.019f, 7.137f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-0.937f, 9.467f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(0.939f, 9.489f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(1.82f, 6.517f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.682f, 5.44f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.575f, 5.44f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.764f, 7.719f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.759f, 7.719f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.309f, 9.532f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.32f, 9.538f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.176f, 5.868f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(1.07f, 5.868f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-0.397f, 8.271f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(0.425f, 8.28f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.88f, 6.47f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.731f, 7.093f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(1.699f, 7.143f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-1.245f, 6.506f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(1.181f, 6.506f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-0.666f, 8.862f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(0.699f, 8.876f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-2.384f, 6.926f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(2.329f, 6.983f, 95), Quaternion.identity);
                Instantiate(bongCrow1, new Vector3(-0.031f, 6.543f, 95), Quaternion.identity);
            }
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        // Di chuyen hinh bac 3
                        StartCoroutine(cloneBong7red());
                        break;
                    case 2:
                        //Quay 1 canh o goc
                        Instantiate(egdeRotation1, new Vector3(2.5f, 5.3f, 95f), Quaternion.identity);
                        Instantiate(egdeRotation1, new Vector3(-2.5f, 5.3f, 95f), Quaternion.identity);
                        break;
                    case 3:
                        // bong Ball
                        Instantiate(bongBall, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 4:
                        //Di chuyen nua duong tron
                        StartCoroutine(cloneBong7vang());
                        break;
                    case 5:
                        // Quay 2 hinh tron
                        Instantiate(circleRotation1, new Vector3(0f, 6.8f, 95f), Quaternion.identity);
                        Instantiate(circleRotation2, new Vector3(0f, 6.8f, 95f), Quaternion.identity);
                        break;
                    case 6:
                        //Di chuyen hinh xoan oc
                        int i = Random.Range(1, 3);
                        if (i == 1) StartCoroutine(cloneBongBlue());
                        else StartCoroutine(cloneBongBlue1());
                        break;
                    case 7:
                        // bong supperman
                        Instantiate(bongSupperman, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                }
            }
        }
        //Man 15
        else if (time <= 480)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        // Di chuyen hinh bac 3
                        StartCoroutine(cloneBong7red());
                        break;
                    case 2:
                        //Quay 1 canh o goc
                        Instantiate(egdeRotation1, new Vector3(2.5f, 5.3f, 95f), Quaternion.identity);
                        Instantiate(egdeRotation1, new Vector3(-2.5f, 5.3f, 95f), Quaternion.identity);
                        break;
                    case 3:
                        // bong Thor
                        Instantiate(bongThor, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 4:
                        //Di chuyen nua duong tron
                        StartCoroutine(cloneBong7vang());
                        break;
                    case 5:
                        // Quay 2 hinh tron
                        Instantiate(circleRotation1, new Vector3(0f, 6.8f, 95f), Quaternion.identity);
                        Instantiate(circleRotation2, new Vector3(0f, 6.8f, 95f), Quaternion.identity);
                        break;
                    case 6:
                        //co, gian khoi hinh vuong
                        Instantiate(bongBlue5, new Vector3(0.96f, 7.271f, 95), Quaternion.identity);
                        Instantiate(bongBlue5, new Vector3(0.316f, 7.271f, 95), Quaternion.identity);
                        Instantiate(bongBlue5, new Vector3(-0.329f, 7.271f, 95), Quaternion.identity);
                        Instantiate(bongBlue5, new Vector3(-0.959f, 7.271f, 95), Quaternion.identity);
                        Instantiate(bongGreen5, new Vector3(0.96f, 6.621f, 95), Quaternion.identity);
                        Instantiate(bongGreen5, new Vector3(0.316f, 6.621f, 95), Quaternion.identity);
                        Instantiate(bongGreen5, new Vector3(-0.329f, 6.621f, 95), Quaternion.identity);
                        Instantiate(bongGreen5, new Vector3(-0.959f, 6.621f, 95), Quaternion.identity);
                        Instantiate(bongRed5, new Vector3(0.96f, 5.974f, 95), Quaternion.identity);
                        Instantiate(bongRed5, new Vector3(0.316f, 5.974f, 95), Quaternion.identity);
                        Instantiate(bongRed5, new Vector3(-0.329f, 5.974f, 95), Quaternion.identity);
                        Instantiate(bongRed5, new Vector3(-0.959f, 5.974f, 95), Quaternion.identity);
                        Instantiate(bongYellow5, new Vector3(0.96f, 5.321f, 95), Quaternion.identity);
                        Instantiate(bongYellow5, new Vector3(0.316f, 5.321f, 95), Quaternion.identity);
                        Instantiate(bongYellow5, new Vector3(-0.329f, 5.321f, 95), Quaternion.identity);
                        Instantiate(bongYellow5, new Vector3(-0.959f, 5.321f, 95), Quaternion.identity);
                        break;
                    case 7:
                        // bong supperman
                        Instantiate(bongSupperman, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                }
            }
        }
        //Man 16
        else if (time <= 512)
        {
            if (time == 491 || time == 502)
            {
                isMaybay = true;
                //May bay
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-0.052f, 5.303f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-1.067f, 7.137f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(1.019f, 7.137f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(-0.937f, 9.467f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(0.939f, 9.489f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongBlue7", new Vector3(1.82f, 6.517f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.682f, 5.44f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.575f, 5.44f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.764f, 7.719f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.759f, 7.719f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(-0.309f, 9.532f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongGreen6", new Vector3(0.32f, 9.538f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.176f, 5.868f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(1.07f, 5.868f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-0.397f, 8.271f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(0.425f, 8.28f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.88f, 6.47f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(-1.731f, 7.093f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongRed6", new Vector3(1.699f, 7.143f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-1.245f, 6.506f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(1.181f, 6.506f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-0.666f, 8.862f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(0.699f, 8.876f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(-2.384f, 6.926f, 95), Quaternion.identity);
                Objectpooler.Instance.SpawnFromPool("BongYellow6", new Vector3(2.329f, 6.983f, 95), Quaternion.identity);
                Instantiate(bongCrow1, new Vector3(-0.031f, 6.543f, 95), Quaternion.identity);
            }
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 9);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1:
                        // Di chuyen hinh bac 3
                        StartCoroutine(cloneBong7red());
                        break;
                    case 2:
                        //Quay 1 canh o goc
                        Instantiate(egdeRotation1, new Vector3(2.5f, 5.3f, 95f), Quaternion.identity);
                        Instantiate(egdeRotation1, new Vector3(-2.5f, 5.3f, 95f), Quaternion.identity);
                        break;
                    case 3:
                        // bong Thor
                        Instantiate(bongThor, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 4:
                        //Di chuyen nua duong tron
                        StartCoroutine(cloneBong7vang());
                        break;
                    case 5:
                        // Quay 2 hinh tron
                        Instantiate(circleRotation1, new Vector3(0f, 6.8f, 95f), Quaternion.identity);
                        Instantiate(circleRotation2, new Vector3(0f, 6.8f, 95f), Quaternion.identity);
                        break;
                    case 6:
                        //sau 1 khoang thoi gian thi tan ra
                        Instantiate(bongBlue4, new Vector3(0.33f, 5.94f, 95), Quaternion.identity);
                        Instantiate(bongBlue4, new Vector3(0.004f, 5.355f, 95), Quaternion.identity);
                        Instantiate(bongBlue4, new Vector3(0.293f, 7.094f, 95), Quaternion.identity);
                        Instantiate(bongGreen4, new Vector3(0.953f, 7.095f, 95), Quaternion.identity);
                        Instantiate(bongGreen4, new Vector3(-0.033f, 7.673f, 95), Quaternion.identity);
                        Instantiate(bongGreen4, new Vector3(-0.329f, 5.93f, 95), Quaternion.identity);
                        Instantiate(bongRed4, new Vector3(0.618f, 6.52f, 95), Quaternion.identity);
                        Instantiate(bongRed4, new Vector3(-1.005f, 7.11f, 95), Quaternion.identity);
                        Instantiate(bongRed4, new Vector3(-0.703f, 6.511f, 95), Quaternion.identity);
                        Instantiate(bongYellow4, new Vector3(-0.35f, 7.087f, 95), Quaternion.identity);
                        Instantiate(bongYellow4, new Vector3(0.984f, 5.967f, 95), Quaternion.identity);
                        Instantiate(bongYellow4, new Vector3(-0.983f, 5.915f, 95), Quaternion.identity);
                        break;
                    case 7:
                        // bong supperman
                        Instantiate(bongSupperman, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 8:
                        //Di chuyen hinh parapol y = x^2
                        StartCoroutine(cloneBong2Binhphuong());
                        break;
                }
            }
        }
        else
        {
            panel.SetActive(true);
            this.gameObject.SetActive(false);
        }
        rand1 = rand;
        isObjectCreate = true;
    }
    private void objectswitch(int n, Vector3[] vetors, string t)
    {
        if(t == "Blue")
        {
            for(int i=0;i<n;i++)
            {
                Objectpooler.Instance.SpawnFromPool("BongBlue", vetors[i], Quaternion.identity);
            }
        }
        else if (t == "Green")
        {
            for (int i = 0; i < n; i++)
            {
                Objectpooler.Instance.SpawnFromPool("BongGreen", vetors[i], Quaternion.identity);
            }
        }
        else if (t == "Red")
        {
            for (int i = 0; i < n; i++)
            {
                Objectpooler.Instance.SpawnFromPool("BongRed", vetors[i], Quaternion.identity);
            }
        }
        else if (t == "Yellow")
        {
            for (int i = 0; i < n; i++)
            {
                Objectpooler.Instance.SpawnFromPool("BongYellow", vetors[i], Quaternion.identity);
            }
        }
    }
    IEnumerator clonesavelevel()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(savelevel, new Vector3(-3.5f, 3.2f, transform.position.z + 5), Quaternion.identity);
        yield return new WaitForSeconds(1.2f);
        issavelevel = true;
    }
    IEnumerator clonePumpkinandcrow()
    {
        Instantiate(bongPumkin, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(bongCrow, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), Quaternion.identity);
    }
    IEnumerator cloneBong1()//Di chuyen cheo
    {
        Instantiate(bongBlue1, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongGreen1, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongRed1, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongYellow1, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        Instantiate(bongBlue1, new Vector3(2.4f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongGreen1, new Vector3(2.4f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongRed1, new Vector3(2.4f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongYellow1, new Vector3(2.4f, 5.33f, 95), Quaternion.identity);
    }
    IEnumerator cloneBong2()//Di chuyen hinh sin
    {
        Instantiate(bongBlue2, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.07f);
        Instantiate(bongGreen2, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.07f);
        Instantiate(bongRed2, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.07f);
        Instantiate(bongYellow2, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.75f);
        Instantiate(bongBlue2, new Vector3(2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.07f);
        Instantiate(bongGreen2, new Vector3(2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.07f);
        Instantiate(bongRed2, new Vector3(2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.07f);
        Instantiate(bongYellow2, new Vector3(2.5f, 5.33f, 95), Quaternion.identity);
    }
    IEnumerator cloneBong2Binhphuong()//Di chuyen hinh parapol y = x^2
    {
        Instantiate(bongBlue2, new Vector3(0.1f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.08f);
        Instantiate(bongGreen2, new Vector3(0.1f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.08f);
        Instantiate(bongRed2, new Vector3(0.1f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.08f);
        Instantiate(bongYellow2, new Vector3(0.1f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(bongBlue2, new Vector3(-0.1f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.08f);
        Instantiate(bongGreen2, new Vector3(-0.1f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.08f);
        Instantiate(bongRed2, new Vector3(-0.1f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.08f);
        Instantiate(bongYellow2, new Vector3(-0.1f, 5.33f, 95), Quaternion.identity);
    }
    IEnumerator cloneBongxanh()//Di chuyen nhieu huong
    {
        Instantiate(bongBlue3, new Vector3(0f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue3, new Vector3(0.1f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue3, new Vector3(-0.1f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue3, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue3, new Vector3(2.5f, 5.33f, 95), Quaternion.identity);
    }
    IEnumerator cloneBongGreen()//Di chuyen cheo xuyen khong
    {
        Instantiate(bongGreen3, new Vector3(2.45f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongGreen3, new Vector3(2.45f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongGreen3, new Vector3(2.45f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongGreen3, new Vector3(2.45f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        Instantiate(bongGreen3, new Vector3(-2.45f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongGreen3, new Vector3(-2.45f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongGreen3, new Vector3(-2.45f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongGreen3, new Vector3(-2.45f, 5.33f, 95), Quaternion.identity);
    }
    IEnumerator cloneBongRed()//Di chuyen ngang xuyen khong
    {
        Instantiate(bongRed3, new Vector3(2.5f, 4.65f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongRed3, new Vector3(2.5f, 4.65f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongRed3, new Vector3(2.5f, 4.65f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongRed3, new Vector3(2.5f, 4.65f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        Instantiate(bongRed3, new Vector3(-2.5f, 4.65f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongRed3, new Vector3(-2.5f, 4.65f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongRed3, new Vector3(-2.5f, 4.65f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.058f);
        Instantiate(bongRed3, new Vector3(-2.5f, 4.65f, 95), Quaternion.identity);
    }
    IEnumerator cloneBongBlue()//Di chuyen cac qua bong theo hinh tron va dich xuong
    {
        Instantiate(bongBlue6, new Vector3(-2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(-2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(-2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(-2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(-2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(-2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(-2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.245f);
        Instantiate(bongBlue6, new Vector3(-2.3f, 5.33f, 95), Quaternion.identity);
    }
    IEnumerator cloneBongBlue1()//Di chuyen cac qua bong theo hinh tron va dich xuong
    {
        Instantiate(bongBlue6, new Vector3(2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        Instantiate(bongBlue6, new Vector3(2.3f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.245f);
        Instantiate(bongBlue6, new Vector3(2.3f, 5.33f, 95), Quaternion.identity);
    }
    IEnumerator cloneBong7vang()//Di chuyen nua duong tron
    {
        Instantiate(bongYellow7, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.087f);
        Instantiate(bongYellow7, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.087f);
        Instantiate(bongYellow7, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.087f);
        Instantiate(bongYellow7, new Vector3(-2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.09f);
        Instantiate(bongYellow7, new Vector3(2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.087f);
        Instantiate(bongYellow7, new Vector3(2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.087f);
        Instantiate(bongYellow7, new Vector3(2.5f, 5.33f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.087f);
        Instantiate(bongYellow7, new Vector3(2.5f, 5.33f, 95), Quaternion.identity);
    }
    IEnumerator cloneBong7red()//Di chuyen hinh bac 3
    {
        Instantiate(bongRed7, new Vector3(-2.75f, 5.7f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.095f);
        Instantiate(bongRed7, new Vector3(-2.75f, 5.7f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.095f);
        Instantiate(bongRed7, new Vector3(-2.75f, 5.7f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.095f);
        Instantiate(bongRed7, new Vector3(-2.75f, 5.7f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.6f);
        Instantiate(bongRed7, new Vector3(2.75f, 5.7f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.095f);
        Instantiate(bongRed7, new Vector3(2.75f, 5.7f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.095f);
        Instantiate(bongRed7, new Vector3(2.75f, 5.7f, 95), Quaternion.identity);
        yield return new WaitForSeconds(0.095f);
        Instantiate(bongRed7, new Vector3(2.75f, 5.7f, 95), Quaternion.identity);
    }
}
