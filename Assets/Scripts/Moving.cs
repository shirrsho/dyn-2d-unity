using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;
    [SerializeField]
    float speed = 2f;
    int index = 0;
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

    public void Move(int steps){
        Debug.Log("initial positon: "+transform.position);
        Debug.Log("initial waypoint positon: "+waypoints[index].transform.position);
        transform.position = Vector2.MoveTowards(this.transform.position,
        waypoints[index+steps].transform.position,
        speed*Time.deltaTime);
        index=index+steps;
        Debug.Log("position after moving: "+transform.position);
        Debug.Log("final waypoint positon: "+waypoints[index].transform.position);
        // Debug.Log("way transform.position: "+waypoints[index].transform.position);
        // if(transform.position==waypoints[index].transform.position){
        //     index += 1;
        // // Debug.Log("index: "+index);
        // }
        // if(index==waypoints.Length){
        //     index = 0;
        // }
    }
}
