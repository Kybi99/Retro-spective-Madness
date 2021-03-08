using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPoem : MonoBehaviour
{
    public GameObject canvas;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            var getCanvasGroup = canvas.GetComponent<CanvasGroup>();
            if (getCanvasGroup.alpha == 0)
            {
                getCanvasGroup.alpha = 1;

            }
            else
            {
                getCanvasGroup.alpha = 0;
            }

        }
    }
}
