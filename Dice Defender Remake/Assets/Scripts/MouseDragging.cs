using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class MouseDragging : MonoBehaviour
{

    private IDraggable currentlyDraggingObject;

    public delegate void OnMouseUp();
    public static event OnMouseUp onMouseUp;

    private bool canSendRaycast;

    public Slot cannonSlot;
    public Slot addSlot1;
    public Slot addSlot2;
    public Slot minusSlot1;
    public Slot minusSlot2;

    enum MouseActions
    {
        LmB,
        RmB,
        ShiftLeft,
        ShiftRight
    }

    // Start is called before the first frame update
    void Start()
    {
        canSendRaycast = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                SendRaycast(MouseActions.ShiftLeft);
            }
            else
            {
                SendRaycast(MouseActions.LmB);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                SendRaycast(MouseActions.ShiftRight);
            }
            else
            {
                SendRaycast(MouseActions.RmB);
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }
    }

    void SendRaycast(MouseActions action)
    {
        if(!canSendRaycast)
        {
            Debug.LogWarning("Paused!");
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit)
        {
            if (hit.transform.TryGetComponent(out IDraggable draggable))
            {
                if (hit.transform.TryGetComponent(out DieNumber die)) // If its a die...
                {
                    switch (action)
                    {
                        case (MouseActions.LmB):
                            currentlyDraggingObject = draggable;
                            currentlyDraggingObject.OnClick();
                            break;
                        case (MouseActions.RmB):
                            if (cannonSlot.currentDie == null)
                            {
                                hit.transform.position = cannonSlot.transform.position;
                                draggable.OnEndClick();
                            }
                            break;
                        case (MouseActions.ShiftLeft):
                            if (addSlot1.currentDie == null)
                            {
                                hit.transform.position = addSlot1.transform.position;
                                draggable.OnEndClick();
                            }
                            else if (addSlot2.currentDie == null)
                            {
                                hit.transform.position = addSlot2.transform.position;
                                draggable.OnEndClick();
                            }

                            onMouseUp.Invoke();
                            break;
                        case (MouseActions.ShiftRight):
                            if (minusSlot1.currentDie == null)
                            {
                                hit.transform.position = minusSlot1.transform.position;
                                draggable.OnEndClick();
                            }
                            else if (minusSlot2.currentDie == null)
                            {
                                hit.transform.position = minusSlot2.transform.position;
                                draggable.OnEndClick();
                            }

                            onMouseUp.Invoke();
                            break;
                    }
                }

                switch (action) // If its a powerup...
                {
                    case MouseActions.LmB:
                        currentlyDraggingObject = draggable;
                        currentlyDraggingObject.OnClick();
                        break;
                    case MouseActions.RmB:
                        draggable.OnRightClick();
                        break;
                    default:
                        break;
                }

            }
        }
        
    }

    void StopDragging()
    {
        if (currentlyDraggingObject == null)
        {
            return;
        }
        currentlyDraggingObject.OnEndClick();
        currentlyDraggingObject = null;

        if (onMouseUp != null)
        {
            onMouseUp.Invoke();
        }

    }

    void DisableSendRaycast()
    {
        canSendRaycast = false;
    }

    void EnableSendRaycast()
    {
        canSendRaycast = true;
    }

    private void OnEnable()
    {
        GameManager.onPause += DisableSendRaycast;
        GameManager.onDeath += DisableSendRaycast;
        GameManager.onUnPause += EnableSendRaycast;
    }

    private void OnDisable()
    {
        GameManager.onPause -= DisableSendRaycast;
        GameManager.onUnPause -= EnableSendRaycast;
        GameManager.onDeath -= DisableSendRaycast;
    }
}
