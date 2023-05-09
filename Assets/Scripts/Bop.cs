using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bop : MonoBehaviour
{
    public Conductor conductor;
    public KeyCode keyToPress;
    bool bop = false;
    bool drop = false;
    List<int> bopped = new List<int> ();
    List<int> success = new List<int> ();
    List<int> failed = new List<int> ();
    List<int> missed = new List<int> ();
    List<int> report = new List<int> ();
    int beat;
    public float punchTiming;
    public float missTiming = 1.5f;

    List<int> punchies = new List<int> {16,19,24,27,32,35,40,43,48,56,64,80,88,96,112,120,128,136,144,152,160,163,168,171,176,184,192,195,208,216,224,227,240,248,251,256,264,267,272,280,283,285,287,304,320,336,352,355,368,376,379,384,392,395,400,416,422,424,427,430,432,435,438,440,443,446,448,451,458,460,462,464,472,480,488,492,494,496,499,502,504,507,510,512,515,522,524,526,528,533,534,535,538,539,541,543,549,550,551,554,555,557,559};


    // Start is called before the first frame update
    void Start()
    {
        print(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        beat = Mathf.RoundToInt(conductor.songPositionInBeats);
        // On Beat 
        if (punchies.Contains(beat) && !bopped.Contains(beat) && Input.GetKeyDown(keyToPress)){
            if (conductor.songPositionInBeats > beat-punchTiming && conductor.songPositionInBeats < beat+punchTiming){
                bop = true;
                Debug.LogFormat($"{beat} Hit {conductor.songPositionInBeats}");
                bopped.Add(beat);
                success.Add(beat);
            }
            else{
                Debug.LogFormat($"{beat} Fail {conductor.songPositionInBeats}");
                bopped.Add(beat);
                failed.Add(beat);
            }
        }
        else if (Input.GetKeyDown(keyToPress)){
                Debug.LogFormat($"{beat} Fail {conductor.songPositionInBeats}");
                bopped.Add(beat);
                failed.Add(beat);
        }

        if (punchies.Contains(beat-1) && !bopped.Contains(beat-1)){
            Debug.LogFormat($"{beat-1} Miss");
            bopped.Add(beat-1);
            missed.Add(beat-1);
        }
        


        // beat = Mathf.FloorToInt(conductor.songPositionInBeats);
        // // if(Input.GetKeyDown(keyToPress) && !bop && !drop)
        // if (true)
        // {
        //     if(punchies.Contains(beat) && !bopped.Contains(beat)){
        //         bop = true;
        //         Debug.LogFormat($"Bop {beat}");
        //         bopped.Add(beat);
        //     }
        // }

        if (bop)
        {
            transform.Translate(Vector3.up * 3 * Time.deltaTime);
        }

        if (transform.position.y >= -0.4)
        {
            bop = false;
            drop = true;
        }

        if (drop)
        {
            transform.Translate(Vector3.down * 1 * Time.deltaTime);
        }

        if (transform.position.y <= -0.5)
        {
            drop = false;
        }
    }

    public void DoBop() {
        bop = true;

    }
}
