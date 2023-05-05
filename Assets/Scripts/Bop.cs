using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bop : MonoBehaviour
{
    public KeyCode keyToPress;
    bool bop = false;
    bool drop = false;
    // Start is called before the first frame update
    void Start()
    {
        print(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress) && !bop && !drop)
        {
            bop = true;
            print("Bop");
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
