using UnityEngine;
/// <summary>
/// Singleton design pattern, used when one class needs to have just one instance of it
/// </summary>
/// <typeparam name="T">class</typeparam>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    static T instance;
    /// <summary>
    /// checks whether instance exists
    /// </summary>
    public static bool InstanceExists => instance!=null;
    /// <summary>
    /// returns instance of the current class
    /// </summary>
    public static T Instance => instance;


    protected void Awake() {
        if(InstanceExists){
            Destroy(this.gameObject);
        }
        instance=(T)this;
    }
    protected void OnDestroy()
    {
        if(instance==this){
            instance=null;
        }
    }
}
