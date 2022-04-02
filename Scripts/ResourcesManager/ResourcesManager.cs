using CoreFeatures.Singleton;
using System;
using System.Reflection;
using UnityEngine;

/// <summary>
/// Manages resource load
/// </summary>
public sealed class ResourcesManager : Singleton<ResourcesManager>
{
    /// <summary>
    /// Load all resources of the <paramref name="monoBehaviour"/> with <seealso cref="ResourceAttribute"/>
    /// </summary>
    /// <param name="monoBehaviour"></param>
    public void Load(MonoBehaviour monoBehaviour)
    {
        FieldInfo[] fieldInfos = monoBehaviour.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (FieldInfo field in fieldInfos)
        {
            if (!field.IsStatic && !field.IsInitOnly && !field.IsLiteral)
            {
                ResourceAttribute resourceAttribute = (ResourceAttribute)Attribute.GetCustomAttribute(field, typeof(ResourceAttribute), false);
                if (resourceAttribute != null)
                {
                    field.SetValue(monoBehaviour, Resources.Load(resourceAttribute.Path, field.FieldType));
                }
            }
        }
    }
}
