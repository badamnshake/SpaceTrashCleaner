
public interface IHealth {
    public float GetMaxHealth(); 
    public void TakeDamage(float damage);
    public void Restore(float percentageFraction);
    public void Die();
}