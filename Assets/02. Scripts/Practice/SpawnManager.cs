using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters;

    [SerializeField] private GameObject[] items;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            int randomIndex = Random.Range(0, monsters.Length);
            float randomX = Random.Range(-8, 9);
            float randomY = Random.Range(-3, 5);

            Vector3 createPos = new Vector3(randomX, randomY, 0);

            Instantiate(monsters[randomIndex], createPos, Quaternion.identity);
        }
    }

    public void DropCoin(Vector3 dropPos)
    {
        int randomIndex = Random.Range(0, items.Length);

        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb.AddForceY(5f, ForceMode2D.Impulse);

        float ranPower = Random.Range(-1f, 1f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }
}
