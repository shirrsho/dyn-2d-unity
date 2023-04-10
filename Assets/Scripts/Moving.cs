using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    Text show;
    [SerializeField]
    Transform SHOW;
    [SerializeField]
    Transform reset;
    [SerializeField]
    Transform winplus;
    [SerializeField]
    Transform winminus;
    [SerializeField]
    Transform winreset;
    [SerializeField]
    Transform skull;
    [SerializeField]
    Transform wrong;
    [SerializeField]
    Transform finalmoveplus;
    [SerializeField]
    Transform finalmoveminus;
    public Text win;

    int index = 13;
    public float displayTime = 3f;
    private float timeRemaining = 0f;
  
    // Start is called before the first frame update
    public void Start()
    {
        transform.position = waypoints[index].transform.position;
        show.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
        winplus.gameObject.SetActive(false);
        winminus.gameObject.SetActive(false);
        winreset.gameObject.SetActive(false);
        skull.gameObject.SetActive(false);
        wrong.gameObject.SetActive(false);
        finalmoveplus.gameObject.SetActive(false);
        finalmoveminus.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            // If the display time has elapsed, hide the canvas
            if (timeRemaining <= 0)
            {
                SHOW.gameObject.SetActive(false);
            }
        }
        transform.position = Vector2.MoveTowards(this.transform.position,
        waypoints[index].transform.position,
        speed*Time.deltaTime);
        if(transform.position==waypoints[0].transform.position){
            winminus.gameObject.SetActive(true);
            winreset.gameObject.SetActive(true);
            // win.text += "Winner: - Player\nPush Reset";
        }
        if(transform.position==waypoints[26].transform.position){
            winplus.gameObject.SetActive(true);
            winreset.gameObject.SetActive(true);
            // win.text = "Winner: + Player\nPush Reset";
        }
    }
    public void MoveTo(){
        
        Debug.Log("Hello");
    }
    public void Move(int steps, int waypointIndex){
        int newindex = index+steps;
        if(steps<0){
            if(waypointIndex==19||waypointIndex==21||waypointIndex==23){
                SHOW.gameObject.SetActive(true);
                SHOW = skull;
                timeRemaining = displayTime;
                return;
            }
        }
        else {
            if(waypointIndex==3||waypointIndex==5||waypointIndex==7){
                SHOW.gameObject.SetActive(true);
                SHOW = skull;
                timeRemaining = displayTime;
                return;
            }
        }
        if(newindex>26){
            index = 26;
            SHOW.gameObject.SetActive(true);
            SHOW = finalmoveplus;
        }
        else if(newindex<0){
            index = 0;
            SHOW.gameObject.SetActive(true);
            SHOW = finalmoveminus;
        }
        else if(newindex!=waypointIndex){
            SHOW.gameObject.SetActive(true);
            SHOW = wrong;
            timeRemaining = displayTime;
            return;
        }
        
        else index+=steps;
     
    }
}
