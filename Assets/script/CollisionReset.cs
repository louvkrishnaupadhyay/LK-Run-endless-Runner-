using UnityEngine;
using System.Collections;

public class CollisionReset : MonoBehaviour
{
    [SerializeField] GameObject theCamera;
    [SerializeField] GameObject theCube;
    [SerializeField] GameObject charAnim;
    [SerializeField] AudioSource crashFX;

    void OnTriggerEnter()
    {
        theCamera.GetComponent<CamFollow>().enabled = false;
        theCube.GetComponent<PlayerMove>().enabled = false;
        charAnim.GetComponent<Animator>().Play("Falling Back Death");
        crashFX.Play();

        StartCoroutine(GameOverDelay());
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2f);  
        GameManager.Instance.GameOver();
    }
}