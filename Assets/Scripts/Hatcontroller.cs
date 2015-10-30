using UnityEngine;
using System.Collections;

public class Hatcontroller : MonoBehaviour
{

    public Camera cam;

    private float maxWidth;//Game area

    // Use this for initialization
    void Start()
    {
        if (cam == null)
        { cam = Camera.main; } //if no particular camera avilable,use the default mian camera
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);//Boundaries of screen
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float hatWidth = GetComponent<Renderer>().bounds.extents.x;//extents is half of the total width
        maxWidth = targetWidth.x-hatWidth;


    }

    // Update is called once per physics timestep
    void FixedUpdate() //FixedUpdate should be used instead of Update when dealing with Rigidbody. For example when adding a force to a rigidbody, you have to apply the force every fixed frame inside FixedUpdate instead of every frame inside Update.
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);//It is basicly an array of 3(Vector 3), Vector3 is usually used in 3d space for X,Y and Z values.
        Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
        float targetWidth = Mathf.Clamp(targetPosition.x,-maxWidth,maxWidth);//math for basic math functions
        targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
        GetComponent<Rigidbody2D>().MovePosition(targetPosition);

    }
}
