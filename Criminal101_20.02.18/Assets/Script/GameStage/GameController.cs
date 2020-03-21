using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Camera Maincamera;
    public GameObject follower;
    public Image bar;
    public float barPercent = 0.0f;

    public bool isFollow = true;
 


    void Update()
    {
        if(follower != null)
            isFollow = followCheck(follower);
 
    }

    void FixedUpdate()
    {
        if (!isFollow)
        {
            barPercent += 0.001f;
        }

        bar.fillAmount = barPercent;
    }

    private bool followCheck(GameObject follower)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Maincamera);
        if (GeometryUtility.TestPlanesAABB(planes, follower.GetComponent<BoxCollider>().bounds))
            return true;
        else
            return false;
    }
}
