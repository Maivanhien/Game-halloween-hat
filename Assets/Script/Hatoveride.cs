using System.Collections;
using UnityEngine;

public class Hatoveride : MonoBehaviour
{
    public GameObject doi,hoDen,thorBua,heart, ballGiaoThong, ballLua, hiepSi, mumMy, tuChanGia, savelevel, guidekysi, panel, fallLeaves, snow;
    private float timeDelay;
    [HideInInspector] public static float time;
    [HideInInspector] public bool silence;
    private bool isObjectCreate,voice,isHoDenCreate;
    private float speech;
    private bool right, left, isTuchangia, issavelevel;
    private int randKySi,rand,rand1;
    private Animator animator;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        timeDelay = 0.65f;
        //time = 0f;
        time = PlayerPrefs.GetFloat("Gameplay1", 0);
        isObjectCreate = true;
        silence = false;
        voice = true;
        isHoDenCreate = false;
        speech = 7.3f;
        right = true;
        left = false;
        isTuchangia = false;
        issavelevel = true;
        randKySi = Random.Range(1, 3);
        rand1 = 6;
        StartCoroutine(changeAnimation());
    }

    void Update()
    {
        if(right==true)
        {
            transform.Translate(new Vector3(speech*Time.deltaTime, 0, 0));
        }
        if (left == true)
            transform.Translate(new Vector3(-speech * Time.deltaTime, 0, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2f, 2.25f), transform.position.y, transform.position.z);
        if(transform.position.x==2.25f)
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

    void LateUpdate()
    {
        if(voice==true)
        {
            if (time == 0)
            {
                StartCoroutine(objectSilence());
                voice = false;
            }
            else if (time == 160)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level = 5;
                voice = false;
            }
            else if (time == 320)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level = 9;
                voice = false;
            }
            else if (time == 480)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level = 13;
                voice = false;
            }
            else if (time == 520)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level = 14;
                voice = false;
            }
            else if (time == 680)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level = 18;
                voice = false;
            }
            else if (time == 720)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level = 19;
                voice = false;
            }
            else if (time == 880)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level = 23;
                voice = false;
            }
            else if (time % 40 == 0)
            {
                StartCoroutine(objectSilence());
                Gamemanager.level += 1;
                voice = false;
                if (time == 280)
                    StartCoroutine(Guidekysi());
            }
        }
        if (time < 400f)
        {
            timeDelay = 0.65f;
        }
        else
        {
            timeDelay = 0.7f;
            if (isTuchangia == true)
            {
                timeDelay = 5.5f;
                isTuchangia = false;
            }
        }
        if(issavelevel == true)
        {
            if (time == 159)
            {
                StartCoroutine(clonesavelevel());
                issavelevel = false;
            }
            if (time == 319)
            {
                StartCoroutine(clonesavelevel());
                issavelevel = false;
            }
            if (time == 479)
            {
                StartCoroutine(clonesavelevel());
                issavelevel = false;
            }
            if (time == 519)
            {
                StartCoroutine(clonesavelevel());
                issavelevel = false;
            }
            if (time == 679)
            {
                StartCoroutine(clonesavelevel());
                issavelevel = false;
            }
            if (time == 719)
            {
                StartCoroutine(clonesavelevel());
                issavelevel = false;
            }
            if (time == 879)
            {
                StartCoroutine(clonesavelevel());
                issavelevel = false;
            }
        }
        if (time%40==1)
        {
            voice = true;
        }
        if (silence==false)
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
        else if(PlayerPrefs.GetInt("buttonHat1", -1) == 1)
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
        yield return new WaitForSeconds(2.5f);
        silence = false;
    }

    IEnumerator cloneObject()
    {
        yield return new WaitForSeconds(timeDelay);
        time += 1;
        //Man 1
        if(time<=40)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 7);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 2
        else if(time<=80)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 7);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 3
        else if(time<=120)
        {
            if(time==100) Instantiate(heart, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            else if(time==90) Instantiate(ballGiaoThong, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 7);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 4
        else if (time<=160)
        {
            if(time==140) Instantiate(ballGiaoThong, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Instantiate(thorBua, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 5
        else if (time <= 200)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Instantiate(hiepSi, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 6
        else if (time <= 240)
        {
            if (time == 220) Instantiate(ballGiaoThong, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Instantiate(mumMy, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 7
        else if (time <= 280)
        {
            if (time == 260) Instantiate(heart, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Ninja", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 8
        else if (time<=320)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
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
                        if (randKySi == 1)
                            Objectpooler.Instance.SpawnFromPool("Kysivang", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
                        if (randKySi == 2)
                            Objectpooler.Instance.SpawnFromPool("Kysixanh", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
                        randKySi = Random.Range(1, 3);
                        break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 9
        else if (time <= 360)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
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
                        int i = Random.Range(1, 4);
                        if (i == 1) Instantiate(ballLua, new Vector3(-2.3f, 5.62f, transform.position.z + 5f), Quaternion.identity);
                        else if (i == 2) Instantiate(ballLua, new Vector3(2.3f, 5.62f, transform.position.z + 5f), Quaternion.identity);
                        else Instantiate(ballLua, new Vector3(0f, 5.62f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 10
        else if (time <= 400)
        {
            if (time == 380) Instantiate(ballGiaoThong, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Thienthan", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 11
        else if (time <= 440)
        {
            if (isHoDenCreate == false)
            {
                Instantiate(hoDen, new Vector3(0f, 2.2f, 90f), Quaternion.identity);
                Instantiate(hoDen, new Vector3(2.1f, 1.4f, 90f), Quaternion.identity);
                Instantiate(hoDen, new Vector3(-2.1f, 1.4f, 90f), Quaternion.identity);
                isHoDenCreate = true;
            }
            if (time == 420)
            {
                Instantiate(heart, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 12
        else if (time<=480)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Ninja", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Instantiate(thorBua, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 13
        else if (time <= 520)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4:
                        isTuchangia = true;
                        Instantiate(tuChanGia, new Vector3(0f, 5.7f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 14
        else if (time <= 560)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Ninja", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Instantiate(hiepSi, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 15
        else if (time <= 600)
        {
            if (time == 580) Instantiate(heart, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Monster", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5:
                        int i = Random.Range(1, 4);
                        if (i == 1) Instantiate(ballLua, new Vector3(-2.3f, 5.62f, transform.position.z + 5f), Quaternion.identity);
                        else if (i == 2) Instantiate(ballLua, new Vector3(2.3f, 5.62f, transform.position.z + 5f), Quaternion.identity);
                        else Instantiate(ballLua, new Vector3(0f, 5.62f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 16
        else if (time <= 640)
        {
            if (time == 620)
            {
                Instantiate(ballGiaoThong, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Thienthan", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Instantiate(mumMy, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 17
        else if (time <= 680)
        {
            if (time == 660)
            {
                Instantiate(heart, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Monster", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5:
                        if (randKySi == 1)
                            Objectpooler.Instance.SpawnFromPool("Kysivang", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
                        if (randKySi == 2)
                            Objectpooler.Instance.SpawnFromPool("Kysixanh", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
                        randKySi = Random.Range(1, 3);
                        break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 18
        else if (time <= 720)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
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
                        isTuchangia = true;
                        Instantiate(tuChanGia, new Vector3(0f, 5.7f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5:
                        if (randKySi == 1)
                            Objectpooler.Instance.SpawnFromPool("Kysivang", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
                        if (randKySi == 2)
                            Objectpooler.Instance.SpawnFromPool("Kysixanh", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
                        randKySi = Random.Range(1, 3);
                        break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 19
        else if (time <= 760)
        {
            if (time == 740)
            {
                Instantiate(ballGiaoThong, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Thienthan", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Ninja", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 20
        else if (time <= 800)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Objectpooler.Instance.SpawnFromPool("Supperman", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Instantiate(hiepSi, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 21
        else if (time <= 840)
        {
            if (time == 820)
            {
                Instantiate(heart, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Instantiate(doi, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Monster", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 22
        else if (time <= 880)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
            }
            else
            {
                do
                {
                    rand = Random.Range(1, 8);
                } while (rand == rand1);
                switch (rand)
                {
                    case 1: Instantiate(doi, new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Supperman", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                }
            }
        }
        //Man 23
        else if (time <= 920)
        {
            if (time % 8 == 0)
            {
                Objectpooler.Instance.SpawnFromPool("Coin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity);
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
                        isTuchangia = true;
                        Instantiate(tuChanGia, new Vector3(0f, 5.7f, transform.position.z + 5f), Quaternion.identity);
                        break;
                    case 2: Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 3: Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 4: Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 5: Objectpooler.Instance.SpawnFromPool("Supperman", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
                    case 6: Objectpooler.Instance.SpawnFromPool("Thanchet", new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z + 5f), Quaternion.identity); break;
                    case 7: Objectpooler.Instance.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z + 5f), Quaternion.identity); break;
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
    IEnumerator clonesavelevel()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(savelevel, new Vector3(-3.5f, 3.2f, transform.position.z + 5), Quaternion.identity);
        yield return new WaitForSeconds(1.2f);
        issavelevel = true;
    }
    IEnumerator Guidekysi()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(guidekysi, new Vector3(0f, 1.15f, transform.position.z + 5), Quaternion.identity);
    }
}
