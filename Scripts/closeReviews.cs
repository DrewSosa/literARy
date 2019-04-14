using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class closeReviews : MonoBehaviour, IVirtualButtonEventHandler {
public GameObject openclosebutton;
public GameObject target;

public GameObject ext_review;

void Start()
{
    openclosebutton = GameObject.Find("OpenCloseButton");

    openclosebutton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);


}
void Update(){

}



public void OnButtonPressed(VirtualButtonBehaviour vButt){
    // GameObject.Destroy(GameObject.Find("review_template"));
    generateReview.displayReviews();
    generateReview.displayExtendedReview();
    //
    Debug.Log("This close book button is working well");


    foreach (Animator anim in transform.gameObject.GetComponent<Appear>().anim_list){
                if (!anim.GetBool("Reco") && generateReview.reviews_on){
                    anim.SetBool("Reco", true);
                }
                else{
                    anim.SetBool("Reco", false);
                }
        }
}
public void OnButtonReleased(VirtualButtonBehaviour vButt){

}
}

