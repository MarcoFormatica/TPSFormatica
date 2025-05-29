using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour 
{
    public int handType; //0 left, 1 right
    public float radius;
    public float strength;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Punch()
    {
        foreach (Collider c in Physics.OverlapSphere(transform.position, radius))
        {

            Character character = c.GetComponent<Character>();
            if (character != null)
            {
                if (character != GetComponentInParent<Character>())
                {
                    character.RPC_SetHp(character.Hp - Random.Range(5, 20));
                }

                Zombie zombie = c.GetComponentInParent<Zombie>();
                if (zombie != null)
                {
                    foreach (Rigidbody r in zombie.GetComponentsInChildren<Rigidbody>())
                    {
                        r.isKinematic = false;
                    }
                    StartCoroutine(DelayedKillZombie(zombie));

                }
                Rigidbody rigidbody = c.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    rigidbody.AddExplosionForce(strength, transform.position, radius);
                }
            }
        }
    }

    IEnumerator DelayedKillZombie(Zombie zombie)
    {
        yield return new WaitForEndOfFrame();
        foreach (Rigidbody r in zombie.GetComponentsInChildren<Rigidbody>())
        {
            r.AddExplosionForce(strength*8, transform.position, 1);
        }
    }


}
