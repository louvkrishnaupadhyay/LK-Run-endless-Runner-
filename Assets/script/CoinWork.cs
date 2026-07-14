using UnityEngine;
using System.Collections;

public class CoinWork : MonoBehaviour
{
    [SerializeField] bool collectedCoin;
    [SerializeField] AudioSource coinDing;
    void Update()
    {
        transform.Rotate(0, 2, 0, Space.World);
        if(collectedCoin == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 6, Space.World);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        collectedCoin = true;
        StatControl.coinCount++;
        coinDing.Play();
        this.gameObject.GetComponent<Animator>().Play("Shrink");
        StartCoroutine(DeleteCoin());
    }

    IEnumerator DeleteCoin()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
