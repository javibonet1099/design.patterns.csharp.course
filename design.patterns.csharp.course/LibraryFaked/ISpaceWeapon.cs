namespace design.patterns.csharp.course.LibraryFaked
{
    /// <summary>
    /// this should be a 3r party library
    /// but we don't have the project so
    /// this is a fake
    /// </summary>
    public interface ISpaceWeapon
    {
        int ImpactDamage { get; }

        int LaserDamage { get; }

        int MissChance { get; }

        int Shoot();
    }
}