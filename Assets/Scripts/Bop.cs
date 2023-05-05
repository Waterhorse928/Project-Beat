using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bop : MonoBehaviour
{
    public Conductor conductor;
    public KeyCode keyToPress;
    bool bop = false;
    bool drop = false;
    bool bopped = false;
    int beat;
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
            if(beat%4==0 && !bopped){
                bop = true;
                print("Bop");
                bopped = true;
            }
            else if(beat%4!=0){
                bopped = false;
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
            print(drop);
            print(transform.position);
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
