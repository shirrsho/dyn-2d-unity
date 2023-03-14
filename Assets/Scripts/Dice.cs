using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {


    [SerializeField] Transform[] waypoints;
    int finalSide = 0;
    int player = 1;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&finalSide!=0)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Waypoint"))
            {
                int waypointIndex = -1;
                for (int i = 0; i < waypoints.Length; i++)
                {
                    if (waypoints[i] == hit.collider.transform)
                    {
                        waypointIndex = i+1;
                        break;
                    }
                }

                Vector3 waypointPosition = hit.collider.transform.position;
                // Do whatever you want with the waypointPosition and the waypointIndex here
                Debug.Log("Waypoint Position: " + waypointPosition + " Waypoint Index: " + waypointIndex);
                if(player==1){
                    moving.Move(finalSide,waypointIndex-1);
                    player=-1;
                } else{
                    moving.Move(-1*finalSide,waypointIndex-1);
                    player=1;
                }
            }
        }
    }

    // Array of dice sides sprites to load from Resources folder
    
    private Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;
    Moving moving;
    [SerializeField]
    GameObject piece;
    

    private void Awake(){
        moving = piece.GetComponent<Moving>();
    }

	// Use this for initialization
	private void Start () {

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("Dice/");
	}
	
    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Final side or value that dice reads in the end of coroutine
        finalSide = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 5);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;
        if(finalSide==4) finalSide=8;

        // Show final dice value in Console
        Debug.Log(finalSide);
        // if(player==1){
        //     moving.Move(finalSide);
        //     player=-1;
        // } else{
        //     moving.Move(-1*finalSide);
        //     player=1;
        // }
    }
}
