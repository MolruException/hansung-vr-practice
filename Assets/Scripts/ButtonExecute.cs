using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonExecute : MonoBehaviour
{
    public float timeToSelect = 2.0f;
    private float countDown;
    private GameObject currentButton;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitButton = null;
        PointerEventData data = new PointerEventData(EventSystem.current);
        if (Physics.Raycast (ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Button")
            {
                hitButton = hit.transform.parent.gameObject;
            }
        }
        if (currentButton != hitButton)
        {
            if (currentButton != null) { 
                ExecuteEvents.Execute<IPointerExitHandler>
                    (currentButton, data, ExecuteEvents.pointerExitHandler);                            
            }
            currentButton = hitButton;
            if (currentButton != null) { 
                ExecuteEvents.Execute<IPointerEnterHandler>
                    (currentButton, data, ExecuteEvents.pointerEnterHandler);
                countDown = timeToSelect;
            }
        }
        if (currentButton != null)
        {
            countDown -= Time.deltaTime;
            if (countDown < 0.0f)
            {
                ExecuteEvents.Execute<IPointerClickHandler>
                    (currentButton, data, ExecuteEvents.pointerClickHandler);
                countDown = timeToSelect;
            }
        }
    }
}