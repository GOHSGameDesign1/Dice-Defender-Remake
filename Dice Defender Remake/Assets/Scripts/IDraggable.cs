using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggable 
{
    void OnClick();

    void OnEndClick(); // TODO: Only have the currently dragged dice register what slot it has to go to.
}
