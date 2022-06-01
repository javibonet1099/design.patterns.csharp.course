using Common;
using design.patterns.csharp.course;
using design.patterns.csharp.course.Events;
using System;

/// <summary>
/// Sealed class to prevent inheritance.
/// </summary>
public sealed class PrimaryPlayer
{
    
    private static readonly PrimaryPlayer _instance;

    //Added with observer
    private int _health;

    private event EventHandler<HealthChangedEventArgs> HealthChanged;

    public string Name { get; set; }
    public int Level { get; set; }

    public IWeapon Weapon { get; set; }

    public int Armor { get; set; }

    //Change to event due to observer pattern
    //public int Health { get; set; }
    public int Health
    {
        get
        {
            return _health;
        }

        private set
        {
            _health = Health;

            HealthChanged?.Invoke(this, new HealthChangedEventArgs(Health));
        }
    }

    //Register observer
    public void RegisterObserver(EventHandler<HealthChangedEventArgs> observer)
    {
        HealthChanged += observer;
    }

    public void UnregisterObserver(EventHandler<HealthChangedEventArgs> observer)
    {
        HealthChanged -= observer;
    }

    public void Hit (int damage)
    {
        Health -= damage;
    }

    public Card[] Cards { get; set; }

    /// <summary>
    /// Static constructor.
    /// it's called right before the first use of a class.
    /// </summary>
    static PrimaryPlayer()
    {
        _instance = new PrimaryPlayer()
        { 
            Name = "Raptor",
            Level = 1,
            Armor = 25,
            Health = 100
        };
    }


    public static PrimaryPlayer Instance { 
        get
        {
            return _instance;
        }
    }

    /// <summary>
    /// Private constructor.
    /// Avoids creating different instances.
    /// </summary>
    private PrimaryPlayer() { }

}
