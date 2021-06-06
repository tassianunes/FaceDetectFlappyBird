using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
   
    FaceDetector faceDetector;
    [SerializeField] float speed;
    float lastY = 0;
    // Start is called before the first frame update
    void Start()
    {
       
        faceDetector = (FaceDetector)FindObjectOfType(typeof(FaceDetector));
        

    }

    // Update is called once per frame
    void Update()
    {
        //float step = speed * Time.deltaTime;
        //float norm = Mathf.Clamp(faceDetector.faceY - lastY, -1, 1);

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + norm, transform.position.z), step);

        //transform.position = new Vector3(0, faceDetector.faceY + norm, 0)* step;
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, faceDetector.faceY , transform.position.z), step);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -faceDetector.faceY, transform.position.z), step);

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -faceDetector.faceY - norm, transform.position.z), step);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -transform.position.y + norm, transform.position.z), step);

        Vector3 movement = new Vector3(transform.position.x, -faceDetector.faceY/30f + 3, 0f);
        transform.position = Vector3.MoveTowards(transform.position, movement, speed * Time.deltaTime);
        

    }


}


