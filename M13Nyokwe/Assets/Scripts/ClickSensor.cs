using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickSensor : MonoBehaviour
{
    [SerializeField, Tooltip("Game object that is currently hovered over")]
    private GameObject currentSelection;

    /// <summary>
    /// Events triggered when an object is selected or unselected
    /// </summary>
    public UnityEvent selectionUpdated, selectionCancelled;

    /// <summary>
    /// Get or set the current selection for the click sensor
    /// </summary>
    public GameObject CurrentSelection
    {
        get 
        {
            return currentSelection; 
        }
        set
        {
            if (value == currentSelection)
            {
                return;
            }

            Exiting();
            currentSelection = value;
            selectionUpdated?.Invoke(); 
            Hovering();
        }
    }
    
    /// <summary>
    /// Reaction when the user selection is cancelled
    /// </summary>
    public void CurrentSelectionCancelled()
    {
        Exiting();
        currentSelection = null;
        selectionCancelled?.Invoke();
    }

    /// <summary>
    /// Performs a click if the item is clickable
    /// </summary> 
    public void Click()
    {
        if (!currentSelection)
        {
            return;
        }

        IPointerClickHandler selection = currentSelection.GetComponent<IPointerClickHandler>();
        PointerEventData data = new PointerEventData(EventSystem.current);

        selection?.OnPointerClick(data);

    }

    /// <summary>
    /// Performs an on hover action if the user is currently hovering
    /// </summary>
    public void Hovering()
    {
        if (!currentSelection)
        {
            return;
        }

        IPointerEnterHandler selection = currentSelection.GetComponent<IPointerEnterHandler>();
        PointerEventData data = new PointerEventData(EventSystem.current);

        selection?.OnPointerEnter(data);
    }

    /// <summary>
    /// performs and Exiting if the user stopped hovering over an asset
    /// </summary>
    public void Exiting()
    {
        if (!currentSelection)
        {
            return;
        }

        IPointerExitHandler selection = currentSelection.GetComponent<IPointerExitHandler>();
        PointerEventData data = new PointerEventData(EventSystem.current);

        selection?.OnPointerExit(data);
    }
}
