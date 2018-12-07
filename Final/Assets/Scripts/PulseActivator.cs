using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PulseActivator : MonoBehaviour {

    public GameObject[] particles;
    public GameObject[] outliners;
    public bool isping;

	// Use this for initialization
	void Start ()
    {
        isping = true;
        foreach (GameObject pe in particles)
        {
            ParticleSystem effect = pe.GetComponent(typeof(ParticleSystem)) as ParticleSystem;
            effect.Stop();
        }
        foreach(GameObject outline in outliners)
        {
           outline.GetComponent<Outline>().enabled = false;
            
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (GameObject pe in particles)
        {
            ParticleSystem effect = pe.GetComponent(typeof(ParticleSystem)) as ParticleSystem;
            if (Input.GetKeyDown(KeyCode.Mouse0) && isping)
            {
                effect.Play();
                isping = !isping;
            }
            else if(Input.GetKeyDown(KeyCode.Mouse0) && !isping)
            {
                effect.Stop();
                isping = true;
            }
        }
        foreach (GameObject outline in outliners)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !outline.GetComponent<Outline>().enabled)
            {
                outline.GetComponent<Outline>().enabled = true;
            }
            else if(Input.GetKeyDown(KeyCode.Mouse0) && outline.GetComponent<Outline>().enabled)
            {
                outline.GetComponent<Outline>().enabled = false;
            }
        }

    }
}
