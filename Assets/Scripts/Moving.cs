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
    //     Move();
    // }

    public void Move(int steps){
        Debug.Log("transform.position: "+waypoints[index+steps].transform.position);
        transform.position = Vector2.MoveTowards(this.transform.position,
        waypoints[index+steps].transform.position,
        speed*Time.deltaTime);
        index=index+steps;
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