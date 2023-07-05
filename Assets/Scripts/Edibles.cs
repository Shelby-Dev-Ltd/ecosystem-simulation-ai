using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edibles : MonoBehaviour
{
    public Food food;

    public void DestroyFood()
    {
        Destroy(transform);
    }
}
