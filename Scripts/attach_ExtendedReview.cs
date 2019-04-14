using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class attach_ExtendedReview : MonoBehaviour, ITrackableEventHandler

{
    //textholders
    private GameObject reveiwText;
    private GameObject authorText;

    private GameObject author_text;

    private Transform rotator;
    public Review review ;
    // Start is called before the first frame update

    // attach the review object to this file and make the Review prefab.
    void Start()

    {
        if (review != null){

        // set the review text , set font ratio? Can't figure out how to get it working in game view

            reveiwText = transform.GetChild(0).gameObject;
            reveiwText.GetComponent<TextMesh>().text= review.review;
            reveiwText.GetComponent<TextMesh>().characterSize= 0.4f;


        //set the author text

            authorText = transform.GetChild(1).gameObject;
            authorText.GetComponent<TextMesh>().text = review.author;
            authorText.GetComponent<TextMesh>().characterSize = 0.5f;
            // Debug.Log(authorText.GetComponent<TextMesh>().text);

        // delete stars based on # of stars on review.
        if (review.stars < 4){
            for (int i = 0 ; i < 4 - review.stars; i++){
                // GameObject.Destroy(transform.GetChild(transform.childCount- 1).gameObject);
                GameObject.Destroy(transform.GetChild(transform.childCount-i-1).gameObject);
                Debug.Log("ChildCount: " + transform.childCount);
            }
        }

        }

    //     // #TODO start animation

    //    Transform rotator = GameObject.Find("localRotate").transform;
    //    //call the parent, get the appear script, set the animator and trackable variables



    //    transform.parent.GetComponent<Appear>().anim_list.Add(transform.GetComponent<Animator>());
    //    transform.parent.GetComponent<Appear>().theTrackable = transform.parent.gameObject.GetComponent<TrackableBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(rotator);
    }

     public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
    }
}
