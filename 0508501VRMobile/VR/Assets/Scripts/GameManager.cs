using UnityEngine;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("燈光群組")]
    public GameObject groupLight;
    [Header("會動的寶箱")]
    public Transform chest;
    [Header("喇叭")]
    public AudioSource aud;
   
    [Header("會動的蠟燭")]
    public Transform chair;
    [Header("敲門聲")]
    public AudioClip soundKnock;
    [Header("開門聲")]
    public AudioClip soundOpenDoor;
    [Header("開門動畫控制器")]
    public Animator aniDoor;

    private int countDoor;

    public void LookDoor()
    {
        countDoor++;

        if (countDoor == 1)
        {
            aud.PlayOneShot(soundKnock, 3);
        }
        else if (countDoor == 2)
        {
            aud.PlayOneShot(soundOpenDoor, 1);
            aniDoor.SetTrigger("開門觸發器");
        }
    }

    public IEnumerator LightEffect()
    {
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        groupLight.SetActive(true);
        yield return new WaitForSeconds(0.43f);
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        groupLight.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        groupLight.SetActive(true);
        yield return new WaitForSeconds(0.9f);
    }

    public void StartMoveChest()
    {
        StartCoroutine(MoveChest());
    }

    public IEnumerator MoveChest()
    {
        chest.GetComponent<MeshCollider>().enabled = false;



        for (int i = 0; i < 25; i++)
        {
            chest.position += chest.up * 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void StartMoveChair()
    {
        StartCoroutine(MovetChair());
    }

    public IEnumerator MovetChair()
    {
        chair.GetComponent<MeshCollider>().enabled = false;

        

        for (int i = 0; i < 100; i++)
        {
            chair.position -= chair.position * 0.01f;
            yield return new WaitForSeconds(0.001f);
        }
    }

    private void Start()
    {
        //LightEffect();
        StartCoroutine(LightEffect());
    }
}
