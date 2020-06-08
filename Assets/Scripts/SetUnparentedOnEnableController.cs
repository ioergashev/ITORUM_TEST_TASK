using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUnparentedOnEnableController : MonoBehaviour
{
    private void OnEnable()
    {
        transform.SetParent(null);
    }
}
