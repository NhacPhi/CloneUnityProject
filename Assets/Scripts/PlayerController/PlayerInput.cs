using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private bool isActiveCursor;
    // Start is called before the first frame update
    void Start()
    {
        Screen.lockCursor = true;
        isActiveCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isActiveCursor = !isActiveCursor;
            Screen.lockCursor = isActiveCursor;
        }

    }
}
