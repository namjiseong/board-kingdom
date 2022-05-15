using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    // Array of dice sides sprites to load from Resources folder
    // 폴더에 있는 이미지 로드
    private Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    // 다이스 변화
    private SpriteRenderer rend;

	// Use this for initialization
    // 초기화
	private void Start () {

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
	}
	
    // If you left click over the dice then RollTheDice coroutine is started
    // 클릭시 시작
    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

    // Coroutine that rolls the dice
    // 다이스 굴리기 함수
    public IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

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
