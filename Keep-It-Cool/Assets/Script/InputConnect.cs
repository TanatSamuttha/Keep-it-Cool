using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputConnect : MonoBehaviour
{
    public OutputConnect outputConnect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.color = (outputConnect.IsUnityNull())?Color.red:Color.green;
    }
}
