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
    int index = 13;
  
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[index].transform.position;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log("updated");
    // }
    public void MoveToObject(){
        
        Debug.Log("Hello");
    }
    public void Move(int steps, int waypointIndex){
        if(index+steps!=waypointIndex) return;
        if(index+steps>26 || index+steps<1) index = 13;
        else index+=steps;
     
        transform.position = Vector2.MoveTowards(this.transform.position,
        waypoints[index].transform.position,
        speed*Time.deltaTime);
       
    
     
    }
}
