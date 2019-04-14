using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class extendo : MonoBehaviour, ITrackableEventHandler  {
    public TrackableBehaviour theTrackable;
    public float DestroyTime;
    //
    private float extend_time;
    private float time_tracked;
    private bool tracking_on;
        void Start () {

        theTrackable = GetComponent<TrackableBehaviour>();
        if (theTrackable)
        {
            //Debug.Log("********************************** setting event handler");
            theTrackable.RegisterTrackableEventHandler(this);


        }


    }
    void LateUpdate()
    {
       if (tracking_on){
            // Debug.Log("********************************** we still tracking boys");
       }
       if (tracking_on && Time.time -  time_tracked >= DestroyTime){
        //    Destroy(cube);
        //    Debug.Log("********************************** cube deleted");
       }

    }


    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
        {
        // Debug.Log("********************************** state change");
            if (newStatus == TrackableBehaviour.Status.DETECTED){
                // Debug.Log("********************************** state change");
                tracking_on = false;
            }
            else if (newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED){
                // Debug.Log("********************************** extendeed tracking, we're doing good.");
                tracking_on = true;

                time_tracked = Time.time;
            }
            else if (newStatus == TrackableBehaviour.Status.TRACKED){
                // Debug.Log("********************************** we are tracking. good job sosa");
                tracking_on = false;
            }

            else
            {
                // Debug.Log("Nothing found, sorry Sosa");
            }
        }




    void Awake()
    {
        VuforiaARController.Instance.RegisterVuforiaInitializedCallback(OnVuforiaInitialized);
    }

    void OnVuforiaInitialized()
    {
    var deviceTracker = TrackerManager.Instance.InitTracker<PositionalDeviceTracker>();
    deviceTracker.Start();




    // ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
    // objectTracker.Stop();
    // objectTracker.ResetExtendedTracking();
    // objectTracker.Start();
    }
}