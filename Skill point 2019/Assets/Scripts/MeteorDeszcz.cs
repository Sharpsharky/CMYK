using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDeszcz : MonoBehaviour
{
    List<int> highlightedTiles;
    public GameObject meteor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChooseTiles()
    {
        highlightedTiles = new List<int>();
        for(int i = 0; i< transform.childCount; i++)
        {

            int random = Random.Range(0, 100);
            if (random <= 25)
            {
                transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
                highlightedTiles.Add(i);

            }

        }
        
        StartCoroutine(AttackMoFo());
    }




    IEnumerator AttackMoFo()
    {
        yield return new WaitForSeconds(2);
        foreach(int i in highlightedTiles)
        {
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Instantiate(meteor, new Vector3(transform.GetChild(i).gameObject.transform.position.x + 7, transform.GetChild(i).gameObject.transform.position.y + 4, -1), Quaternion.identity);
        }
        yield return new WaitForSeconds(0.4f);
        foreach (int i in highlightedTiles)
        {
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        yield return null;
    }




}
