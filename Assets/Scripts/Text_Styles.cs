using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StyleIndex", menuName = "ScriptableObjects/StyleIndex", order = 1)]
public class Text_Styles : ScriptableObject

{
    public GameObject defaultStyle;
    public List<GameObject> aditionalStyles;
}