/// <summary>
/// Defines behavious of object that deal damage
/// </summary>
public interface IDamager 
{
    /// <summary>
    /// Defines what happens when object wants to deal damage to other
    /// </summary>
    /// <param name="damagable">IDamagable from other object</param>
    void DealDamage(IDamagable damagable);
}
