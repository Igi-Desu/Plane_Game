using UnityEngine;


/// <summary>
/// Defines behavious of objects that take damage
/// </summary>
public interface IDamagable  
{
    /// <summary>
    /// Defines what happens when objects takes damage
    /// </summary>
    /// <param name="amount">amount of damage</param>
    void TakeDamage(int amount);
}
