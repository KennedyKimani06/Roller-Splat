using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPiece : MonoBehaviour
{
    public bool isColoured = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
        isColoured = true;

        GameManager.singleton.CheckComplete();
    }
}
