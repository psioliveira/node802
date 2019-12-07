using System.Collections;
using UnityEngine;

public class AngleConverter:MonoBehaviour
{
    public float sideAngle = 90;
    public float multiplier_Ypos = 1f;
    public float multiplier_Yneg = 1f;

    internal float AngleTranslate(Vector2 axis)
    {
        multiplier_Ypos = sideAngle / 90;
        multiplier_Yneg = 90 / sideAngle;
        float result = Mathf.Rad2Deg * Mathf.Atan2(axis.y, axis.x);

        if (result < 90 && result > -90)
        {
            result *= multiplier_Ypos;
        }
        else if (result != 180)
        {
            if (result > 0)
            {
                result -= 90;
                result *= multiplier_Yneg;
                result += sideAngle;
            }
            if (result < 0)
            {
                result += 90;
                result *= multiplier_Yneg;
                result -= sideAngle;
            }

        }

        return result;
    }

}