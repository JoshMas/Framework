using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This triggers only when the button has been deselected
        //Good if you don't want it updating every frame
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.Deselect
        };
        entry.callback.AddListener(data => OnDeselected());
        trigger.triggers.Add(entry);
    }

    public void OnDeselected()
    {
        //Type code here
        
        //For actions after deselection
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
