using Unity.VisualScripting;
using UnityEngine;

public class RopeGeneretor : MonoBehaviour
{
    public GameObject ropeObject;
    public GameObject ropeHanger;
    [SerializeField] private GameObject[] ropeSegment;
    private Rigidbody2D rb;
    private Rigidbody2D ropeRb;
    private HingeJoint2D ropeHingeJoint;
    [Range(1, 10)] public int segmentsAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ropeSegment = new GameObject[segmentsAmount];

        for (int i = 0; i < segmentsAmount; i++)
        {
            ropeSegment[i] = Instantiate(ropeObject, transform);
            ropeHingeJoint = ropeSegment[i].GetComponent<HingeJoint2D>();
            ropeRb = ropeSegment[i].GetComponent<Rigidbody2D>();

            if (i != 0)
            {
                ropeSegment[i].transform.SetParent(ropeSegment[i - 1].transform);
                ropeSegment[i].transform.localPosition = new Vector3(0, -1.3f, 0);
                ropeHingeJoint.connectedBody = ropeSegment[i-1].GetComponent<Rigidbody2D>();
            }
            if (i == segmentsAmount-2)
            {
                ropeObject = ropeHanger;
            }
            else if (i == 0)
            {
                ropeHingeJoint.connectedBody = rb;
            }


        }

    }











    /*
     public GameObject ropeSegmentObject;
     public GameObject[] ropeSegments;
     [Range(1, 10)] public int segmentsNumber;
     private Vector3 startPosition;
     private Rigidbody2D rb;

     public HingeJoint2D joint;
     private void Start()
     {
         startPosition = transform.position;
         joint = GetComponent<HingeJoint2D>();
         rb = GetComponent<Rigidbody2D>();

         ropeSegments = new GameObject[segmentsNumber];

         for (int i = 0; i < segmentsNumber; i++)
         {

             if (i == 0)
             {
                 GameObject newSegment = Instantiate(ropeSegmentObject, transform.position, Quaternion.identity);
                 ropeSegments[i] = newSegment;

                 HingeJoint2D newSegmentJoint = newSegment.AddComponent<HingeJoint2D>();
                 Rigidbody2D segmentRb = newSegment.AddComponent<Rigidbody2D>();

                 newSegment.transform.SetParent(transform);
                 newSegmentJoint.connectedAnchor = newSegment.transform.localPosition;
                 newSegmentJoint.connectedBody = rb;

             }
             else
             {
                 GameObject newSegment = Instantiate(ropeSegmentObject, ropeSegments[i - 1].transform.localPosition + new Vector3(0, 3f, 0), Quaternion.identity);

                 HingeJoint2D newSegmentJoint = newSegment.AddComponent<HingeJoint2D>();
                 Rigidbody2D segmentRb = newSegment.AddComponent<Rigidbody2D>();

                 newSegment.transform.SetParent(transform);
                 newSegmentJoint.connectedAnchor = newSegment.transform.localPosition;
                 newSegmentJoint.connectedBody = ropeSegments[i - 1].GetComponent<Rigidbody2D>();
                 newSegmentJoint.anchor = ropeSegments[i - 1].transform.localPosition - new Vector3(0,1.46f,0);

                 ropeSegments[i] = newSegment;
             }

         }
     }
    */

}
