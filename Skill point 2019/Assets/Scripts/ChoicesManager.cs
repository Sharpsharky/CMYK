using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesManager : MonoBehaviour
{

    public GameObject[] player1 = new GameObject[4];
    public GameObject[] player2 = new GameObject[4];

    public GameObject[] characters = new GameObject[4];

    public GameObject player1Character, player2Character;

    int currentCharacterP1 = 0;
    int currentCharacterP2 = 0;
    bool isInChoosingScreen = true;
    bool canChangePosition1 = true, canChangePosition2 = true;
    int countOfApprovedCharacters = 0;

    bool isAccepted1=false, isAccepted2=false;
    // Start is called before the first frame update
    void Start()
    {
        player1[0].SetActive(true);
        player2[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInChoosingScreen == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (isAccepted1 == false)
                {
                    isAccepted1 = true;
                    Accept1();
                }
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (isAccepted2 == false)
                {
                    isAccepted1 = true;

                    Accept2();
                }
            }
        }


        if (canChangePosition1 == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                player1[currentCharacterP1].SetActive(false);
                currentCharacterP1 -= 2;

                Check();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                player1[currentCharacterP1].SetActive(false);
                currentCharacterP1 += 2;
                Check();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                player1[currentCharacterP1].SetActive(false);
                currentCharacterP1 += 1;
                Check();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                player1[currentCharacterP1].SetActive(false);
                currentCharacterP1 -= 1;

                Check();
            }
        }
        if (canChangePosition2 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player2[currentCharacterP2].SetActive(false);
                currentCharacterP2 -= 2;

                Check();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                player2[currentCharacterP2].SetActive(false);
                currentCharacterP2 += 2;

                Check();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player2[currentCharacterP2].SetActive(false);
                currentCharacterP2 += 1;

                Check();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player2[currentCharacterP2].SetActive(false);
                currentCharacterP2 -= 1;

                Check();
            }
        }

    }
    void Check()
    {
        
            if (currentCharacterP1 == -1)
            {
                currentCharacterP1 = 3;
            }
            if (currentCharacterP1 == -2)
            {
                currentCharacterP1 = 2;
            }
            if (currentCharacterP1 == 4)
            {
                currentCharacterP1 = 0;
            }
            if (currentCharacterP1 == 5)
            {
                currentCharacterP1 = 1;
            }
        
            if (currentCharacterP2 == -1)
            {
                currentCharacterP2 = 3;
            }
            if (currentCharacterP2 == -2)
            {
                currentCharacterP2 = 2;
            }
            if (currentCharacterP2 == 4)
            {
                currentCharacterP2 = 0;
            }
            if (currentCharacterP2 == 5)
            {
                currentCharacterP2 = 1;
            }


            Change();
        }
    


    void Change()
    {
        player1[currentCharacterP1].SetActive(true);
        player2[currentCharacterP2].SetActive(true);
    }


    void Accept1()
    {
        canChangePosition1 = false;
        InstantiateCharacter(1);
    }

    void Accept2()
    {
        canChangePosition2 = false;
        InstantiateCharacter(2);
    }

    void InstantiateCharacter(int player)
    {
        
        GameObject character1, character2; 
        if (player == 1)
        {
            character1 = Instantiate(characters[currentCharacterP1], new Vector3(-7.5f, 0, -2f), Quaternion.identity);
            character1.GetComponent<CharacterControler>().isPlayer1 = true;
            character1.GetComponent<CharacterControler>().canBeMovedByUI = false;
            countOfApprovedCharacters++;
            player1Character = character1;

        }
        else
        {
            character2 = Instantiate(characters[currentCharacterP2], new Vector3(7.5f, 0, -2f), Quaternion.identity);
            character2.transform.localScale = new Vector3(-0.2f, 0.2f, 0);
            character2.GetComponent<CharacterControler>().isPlayer1 = false;
            character2.GetComponent<CharacterControler>().canBeMovedByUI = false;
            countOfApprovedCharacters++;
            player2Character = character2;
        }


        Approve(player1Character, player2Character);
        
    }

    void Approve(GameObject character1, GameObject character2)
    {
        Debug.Log(countOfApprovedCharacters);
        
        if (countOfApprovedCharacters == 2)
        {
            isInChoosingScreen = false;
            character1.GetComponent<CharacterControler>().canBeMovedByUI = true;
            character2.GetComponent<CharacterControler>().canBeMovedByUI = true;
            for (int i = 0; i < transform.childCount; i++)
            {
                
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }


}
