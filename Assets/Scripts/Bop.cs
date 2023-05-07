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
    int beat;

    List<int> punchies = new List<int> {16,19,24,27,32,35,40,43,48,56,64,80,88,96,112,120,128,136,144,152,160,163,168,171,176,184,192,195,208,216,224,227,240,248,251,256,264,267,272,280,283,285,287,304};


    // Start is called before the first frame update
    void Start()
    {
        print(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        beat = Mathf.FloorToInt(conductor.songPositionInBeats);
        // if(Input.GetKeyDown(keyToPress) && !bop && !drop)
        if (true)
        {
            if(punchies.Contains(beat) && !bopped.Contains(beat)){
                bop = true;
                print("Bop");
                bopped.Add(beat);
            }
        }

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
