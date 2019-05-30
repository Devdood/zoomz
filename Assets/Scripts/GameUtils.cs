using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtils
{
    public static List<T> GetNearbyObjectsByType<T>(Vector3 position, float radius, bool returnOne = false, T ignoreObject = null) where T : MonoBehaviour
    {
        List<T> items = new List<T>();
        Collider[] colliders = Physics.OverlapSphere(position, radius);
        foreach (var col in colliders)
        {
            T component = col.GetComponent<T>();
            if (component != null && component != ignoreObject)
            {
                items.Add(component);

                if (returnOne)
                {
                    break;
                }
            }
        }

        return items;
    }

    public static T GetNearbyByType<T>(Vector3 position, float radius, T ignoreObject = null) where T : MonoBehaviour
    {
        List<T> listOfItems = GetNearbyObjectsByType<T>(position, radius, true, ignoreObject);

        if (listOfItems.Count > 0)
        {
            return listOfItems[0];
        }

        return null;
    }
}
