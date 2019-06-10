using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesLoad  {

    private static Dictionary<string, object> objects = new Dictionary<string, object>(); 

    public static Sprite LoadSprite(string name)
    {
        Sprite sprite;
        if (!objects.ContainsKey(name))
        {
            sprite= Resources.Load<Sprite>(name);
            objects.Add(name,sprite);
        }
        else
        {
            sprite = objects[name] as Sprite;
        }
        return sprite;
    }

    public static GameObject LoadObj(string name)
    {
        GameObject temp;
        if (!objects.ContainsKey(name))
        {
            temp = Resources.Load<GameObject>(name);
            objects.Add(name,temp);
        }
        else
        {
            temp = objects[name] as GameObject;
        }
        return temp;
    }
}
