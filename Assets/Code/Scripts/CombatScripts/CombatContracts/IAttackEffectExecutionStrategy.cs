using UnityEngine;

public interface IAttackEffectExecutionStrategy
{
    
    /// <summary>
    /// Must check for corresponding "tag" (interface) and call for corresponding method on the target
    /// </summary>
    /// <param name="target"></param>
    public void Execute(GameObject target);
}
