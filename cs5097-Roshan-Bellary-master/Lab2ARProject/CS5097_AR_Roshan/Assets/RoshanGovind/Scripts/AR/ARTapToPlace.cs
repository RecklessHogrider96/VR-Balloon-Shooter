using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    public GameObject m_objectToPlace;

    private GameObject m_spawnedObject;
    private ARRaycastManager m_aRRaycastManager;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Awake()
    {
        m_aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 m_touchPosition))
        {
            return;
        }

        if (m_aRRaycastManager.Raycast(m_touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            // Take the first hit pose.
            var hitPose = hits[0].pose;

            if (m_spawnedObject == null)
            {
                // Instantiate the obj at hits position.
                m_spawnedObject = Instantiate(m_objectToPlace, hitPose.position, hitPose.rotation);
            }
            else
            {
                // Update the objs position to hits position.
                m_spawnedObject.transform.position = hitPose.position;
            }
        }
    }

    // Fetch the screen touch. Touch works only for iOS and android.
    bool TryGetTouchPosition(out Vector2 m_touchPosition)
    {
        if (Input.touchCount > 0)
        {
            m_touchPosition = Input.GetTouch(0).position;
            return true;
        }

        m_touchPosition = default;
        return false;
    }
}