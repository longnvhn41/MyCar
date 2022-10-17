using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PoliceMove : MonoBehaviour
{
   
    
    // Start is called before the first frame update
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        if (transform.position.y <= -5)
        {
            ScoreScript.scoreValue += 1;
            Destroy(gameObject);
        }
    }
}
