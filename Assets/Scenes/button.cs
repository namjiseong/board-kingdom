using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    private Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    // 다이스 변화
    private SpriteRenderer rend;
    public GameObject[] objs = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        
        
        GameObject obj1 = GameObject.Find("dice");
        GameObject obj2 = GameObject.Find("dice2");
        GameObject obj3 = GameObject.Find("dice3");
        GameObject obj4 = GameObject.Find("dice4");
        GameObject obj5 = GameObject.Find("dice5");
        objs[0] = obj1;
        objs[1] = obj2;
        objs[2] = obj3;
        objs[3] = obj4;
        objs[4] = obj5;
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }
    private void OnMouseDown()
    {
        
        // 비동기 구현 필요
        
        StartCoroutine("RollTheDice", objs);
        
            
        
    }

    public IEnumerator RollTheDice(GameObject[] dice)
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        for(int index = 0; index < 5; index++){
            rend = dice[index].GetComponent<SpriteRenderer>();
            int randomDiceSide = 0;
            //rend = dice.GetComponent<SpriteRenderer>();
            // Final side or value that dice reads in the end of coroutine
            int finalSide = 0;

            // Loop to switch dice sides ramdomly
            // before final side appears. 20 itterations here.
            // 20번 반복문
            for (int i = 0; i <= 20; i++)
            {
                // Pick up random value from 0 to 5 (All inclusive)
                // 0~5번 이미지 랜덤 출력
                randomDiceSide = Random.Range(0, 5);

                // Set sprite to upper face of dice from array according to random value
                // 값 저장
                rend.sprite = diceSides[randomDiceSide];

                // Pause before next itteration
                //화면에 출력하고 0.05초 정지
                yield return new WaitForSeconds(0.05f);
            }

            // Assigning final side so you can use this value later in your game
            // for player movement for example
            // 값 반환
            finalSide = randomDiceSide + 1;

            // Show final dice value in Console
            Debug.Log(finalSide);
        }
        
    }
    
}
