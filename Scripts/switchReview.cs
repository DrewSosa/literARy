using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class switchReview : MonoBehaviour, IVirtualButtonEventHandler {
public GameObject switchReviewButt;
public GameObject target;
public GameObject ext_review;

void Start()
{
    switchReviewButt = GameObject.Find("OpenCloseButton");
    switchReviewButt.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
}
void Update(){

}



public void OnButtonPressed(VirtualButtonBehaviour vButt){
    generateReview.switchselection();
    Debug.Log("This switchReview button is working so well");


}

public void OnButtonReleased(VirtualButtonBehaviour vButt){

}
}

