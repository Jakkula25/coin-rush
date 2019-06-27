using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

 

//RequireComponent(typeof(AudioSource))]

 

public class coin : MonoBehaviour

{

    public float speed;

 

    int count;

    //private var collectSound : AudioClip;

 

   //public AudioSource impact;

    // Start is called before the first frame update

    void Start()

    {

        //impact = GetComponent<AudioSource>();

        count = 0;

    }

 

    // Update is called once per frame

    void Update()

    {

        transform.Rotate(0, 0, 10);

        

    }

    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Player"))

        {

            //impact.Play();

            //AudioSource.PlayClipAtPoint(impact, transform.position);

            //AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Destroy(this.gameObject);

            count = count + 1;

            //SetCountText();

        }

 

    }

}

 