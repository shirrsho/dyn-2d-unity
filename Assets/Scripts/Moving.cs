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
    Transform reset;
    public Text win;

    int index = 13;
    public float displayTime = 3f;
    private float timeRemaining = 0f;
  
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[index].transform.position;
        show.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
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
                show.gameObject.SetActive(false);
            }
        }
        transform.position = Vector2.MoveTowards(this.transform.position,
        waypoints[index].transform.position,
        speed*Time.deltaTime);
        if(transform.position==waypoints[0].transform.position){
            win.gameObject.SetActive(true);
            win.text += "Winner: - Player\nPush Reset";
        }
        if(transform.position==waypoints[26].transform.position){
            win.gameObject.SetActive(true);
            win.text = "Winner: + Player\nPush Reset";
        }
    }
    public void MoveTo(){
        
        Debug.Log("Hello");
    }
    public void Move(int steps, int waypointIndex){
        int newindex = index+steps;
        if(steps<0){
            if(waypointIndex==19||waypointIndex==21||waypointIndex==23){
                show.gameObject.SetActive(true);
                timeRemaining = displayTime;
                return;
            }
        }
        else {
            if(waypointIndex==3||waypointIndex==5||waypointIndex==7){
                show.gameObject.SetActive(true);
                timeRemaining = displayTime;
                return;
            }
        }
        if(newindex>26) index = 26;
        else if(newindex<0) index = 0;
        else if(newindex!=waypointIndex){
            show.gameObject.SetActive(true);
            timeRemaining = displayTime;
            return;
        }
        
        else index+=steps;
     
    }
}
