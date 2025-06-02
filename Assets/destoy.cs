using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDT_DestroyAfterTime : MonoBehaviour
{
    public GameObject objectToDestroy;

    // Start is called before the first frame update
   
    void Start()
    {
    Destroy(objectToDestroy,3f);//Destroy a
    }
    

    // Update is called once per frame
    
    void Update()
    {
    }
}