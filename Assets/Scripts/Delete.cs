using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public Transform spawnPoint;
    private bool Active=false;

    private void Start()
    {
        gameObject.SetActive(Active);
    }


    public void InstantiateDelete()
    {
        Active = !Active;
        gameObject.SetActive(Active);
        gameObject.transform.position = spawnPoint.position;
        KinematicActive();
    }

    public void KinematicActive()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void KinematicDeactive()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Plant")
        {
            Destroy(collision.gameObject);
        }
    }
}
