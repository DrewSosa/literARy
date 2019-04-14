using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ReviewLoader;



// code inspiration by https://docs.unity3d.com/Manual/InstantiatingPrefabs.html
public class generateReview : MonoBehaviour
{

    private static int howmany_reviews;
    // our generated prefab for our review object.

    public GameObject review_prefab;

    public GameObject extended_prefab;
    private ReviewLoader reviewloader;
    public bool spawn_random;
    public int spawn_radius;


    // Our desired target image
    public GameObject parent;
    private ArrayList inst_objects;
    private static int review_height = 3;

    private static  List<GameObject> review_obj_list;
    private static  List<GameObject> extendedObjList;
    public float w = 21.0f; //  radians/sec

    // turn the reviews on and off.
    public static bool reviews_on;
    public static bool extendedReviewsOn;

    private static int reviewcounter;


    // Start is called before the first frame update
    void Start()
    {
        // Load up our reviews to use, do some debugging.
        this.reviewloader = new ReviewLoader();
        this.reviewloader.setReviews("BlastlandM.json");
        howmany_reviews = this.reviewloader.allReviews.Length;
        load_into_scene(howmany_reviews, spawn_radius);
        reviews_on = true;
        extendedReviewsOn = false;




    }



    // switches the seleection of given objects
    public static void switchselection(){
    if (reviewcounter == howmany_reviews){
        reviewcounter = 0;
    }
    review_obj_list[reviewcounter].GetComponent<attach_Review>().review.selected = true;

    reviewcounter += 1;
    //
    }


    public static void displayExtendedReview(){
        extendedReviewsOn = !extendedReviewsOn;

        foreach (GameObject extended_review in extendedObjList){
            extended_review.SetActive(extendedReviewsOn);
        }
    }

    public static void displayReviews(){
            reviews_on = !reviews_on;
            foreach (GameObject review in review_obj_list){
                review.SetActive(reviews_on);
            }
    }

    public void load_into_scene(int how_many, int spawn_radius)
    {

        float angle_incr = 360 / 3;
        float x;
        float z;

        review_obj_list = new List<GameObject>();
        extendedObjList = new List<GameObject>();
        for (int i = 0; i < howmany_reviews; i++)
        {
            x = spawn_radius * Mathf.Cos(Mathf.Deg2Rad * angle_incr * i);
            z = spawn_radius * Mathf.Sin(Mathf.Deg2Rad * angle_incr * i);
            // Debug.Log("review #" + i.ToString());
            //maybe introduce a constant?, Can't figure out the rotqation?
            review_obj_list.Add(Instantiate(review_prefab, new Vector3(x, review_height, z), Quaternion.Euler(-65, 0, 0)
            , parent.transform) as GameObject);
            // maybe have it come from its original position
            extendedObjList.Add(Instantiate(extended_prefab, new Vector3(x, review_height, z), Quaternion.Euler(-65, 0, 0)
            , parent.transform) as GameObject);

        }

            //#TODO
            // center object for reviews to focus rotation points on---- TODO
            Debug.Log("Is this object getting created?");
            Debug.Log(extendedObjList.Count);
            GameObject localrotate = new GameObject("localRotate");
            localrotate.transform.SetParent(parent.transform);
            localrotate.transform.localPosition  = new Vector3(0,review_height,0);
            Debug.Log(localrotate.name);


            for (int i = 0; i < howmany_reviews; i++)
            {
                    //go through all the templates, get their review object, and

                review_obj_list[i].GetComponent<attach_Review>().review = this.reviewloader.allReviews[i];

                extendedObjList[i].GetComponent<attach_ExtendedReview>().review = this.reviewloader.allReviews[i];

                extendedObjList[i].SetActive(false);

            }

        }





    // Update is called once per frame, keeps the reviews rotating around.
    void Update()
    {
        float incr_angle = w * Time.deltaTime * Mathf.Deg2Rad; //in Radians
                                                               //first checks if the main review sequence is on
        // if (reviews_on)
        // {
        //     //checks if the the object exists, and if the first element in object arr is active.
        //     //if  not active, set it to active,
        //     if (review_obj_list[0] && !review_obj_list[0].activeSelf)
        //     {
        //         foreach (GameObject review_prefab in review_obj_list)
        //         {
        //             if (!review_prefab.activeSelf)
        //             {
        //                 review_prefab.SetActive(true);
        //             }
        //             review_prefab.transform.RotateAround(parent.transform.position, parent.transform.up, w * Time.deltaTime);
        //         }
        //     }

        // }

        // foreach (GameObject cube_obj in inst_objects){
        //     if (cube_obj){
        //          cube_obj.transform.RotateAround(parent.transform.position, parent.transform.up, w *Time.deltaTime);
        //     }

        // }

    }
}


