using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Appear : MonoBehaviour, ITrackableEventHandler {

    public List<Animator> anim_list;
    public TrackableBehaviour theTrackable;


    // Use this for initialization
    void Start () {
        //anim = GetComponent<Animator>();
        theTrackable = GetComponent<TrackableBehaviour>();

        if (theTrackable)
        {
            //Debug.Log("********************************** setting event handler");
            theTrackable.RegisterTrackableEventHandler(this);
        }


        foreach (Animator anim in anim_list){
            anim.SetBool("Reco", false);
        }
    }

    // Update is called once per frame
    void Update () {

	}
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
           newStatus == TrackableBehaviour.Status.TRACKED ||
           newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Debug.Log("playing opening animation");
            // Play open animation
            // anim.SetBool("Reco", true);
            foreach (Animator anim in anim_list){
                anim.SetBool("Reco", true);
        }
        
        }
        else
        {
            // image target lost
            // anim.SetBool("Reco", false);
            foreach (Animator anim in anim_list){
                anim.SetBool("Reco", false);
            }
        }
    }

}
