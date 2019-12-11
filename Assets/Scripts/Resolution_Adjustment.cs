using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution_Adjustment : MonoBehaviour
{
    private float savedAspect;

    [SerializeField]
    RenderTexture UI;

    [SerializeField]
    Transform UI_Mesh;
    // Start is called before the first frame update
    private void Awake()
    {
        UpdateRatio();
        savedAspect = Camera.main.aspect;
    }

    void UpdateRatio()
    {
        // 5:4
        if (Camera.main.aspect >= 1.24)
        {
            UI_Mesh.localScale = new Vector3(0.704F, 1, 1);
        }
        // 4:3
        if (Camera.main.aspect >= 1.3)
        {
            UI_Mesh.localScale = new Vector3(0.75F, 1, 1);
        }
        // 3:2
        if (Camera.main.aspect >= 1.49)
        {
            UI_Mesh.localScale = new Vector3(0.8434407F, 1, 1);
        }
        // 16:10
        if (Camera.main.aspect >= 1.59)
        {
            UI_Mesh.localScale = new Vector3(0.9F, 1, 1);
        }
        // 16:9
        if (Camera.main.aspect >= 1.7)
        {
            UI_Mesh.localScale = new Vector3(1, 1, 1);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Camera.main.aspect != savedAspect)
        {
            UpdateRatio();
            savedAspect = Camera.main.aspect;
        }
    }
}
