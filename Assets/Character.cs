using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPunching()
    {
        GetComponent<Animator>().SetBool("Punching", true);
        GetComponent<Animator>().SetLayerWeight(1, 1);
    }

    public void EndPunching()
    {
        GetComponent<Animator>().SetBool("Punching", false);
        GetComponent<Animator>().SetLayerWeight(1, 0);
    }

    public void GivePunch(int handType)
    {
        Hand punchingHand = GetComponentsInChildren<Hand>().ToList().Find(x=> x.handType == handType);
        punchingHand.Punch();
    }
}
