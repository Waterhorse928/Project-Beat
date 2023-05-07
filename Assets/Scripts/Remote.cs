using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : MonoBehaviour

{   

    public Conductor conductor;
    public Bop bop;
    int beat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(beat!=Mathf.FloorToInt(conductor.songPositionInBeats)){
            beat = Mathf.FloorToInt(conductor.songPositionInBeats);
            print(beat);
        }

    }
}
