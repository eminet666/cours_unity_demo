using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Transform target; //public Transform target = null;
    public GameObject clone;   
    public bool isFalling = false; // public pour le voir dans l'inspecteur
 
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (isFalling == false)
            {
                transform.LookAt(target);
            }
        }
    }

    void OnMouseDown()
    {
        clone = Instantiate(gameObject, transform.parent); // dans le parent de l'appelant
        clone.SetActive(false);
        
        target = null;  
        Rigidbody body = gameObject.AddComponent<Rigidbody>();
        body.angularDrag = 0.9f;
        isFalling = true;
        Debug.Log("i’m falliiiiiiiiiing");

        StartCoroutine(FallEnd());
    }
    
    IEnumerator FallEnd()
    {
        yield return new WaitForSeconds(4f); // c'est ici qu'on attends
        isFalling = false;
        Debug.Log("still alive");
        clone.SetActive(true);
    }

}
