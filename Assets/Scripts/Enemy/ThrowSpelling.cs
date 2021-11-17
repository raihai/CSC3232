using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpelling : MonoBehaviour
{
    public GameObject spell;
    public Transform spellPoint;

    public AudioSource attackSound;

    public void casting()
    {

        attackSound.Play();
        Rigidbody rb = Instantiate(spell, spellPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
        rb.AddForce(transform.up * 7, ForceMode.Impulse);



    }
}
