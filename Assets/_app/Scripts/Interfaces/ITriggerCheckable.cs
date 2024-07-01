using UnityEngine;

namespace _app.Scripts.Interfaces
{
    public interface ITriggerCheckable
    {
        bool IsAggroed { get; set; }
        bool IsWithinStrikingDistance { get; set; }

        void SetAggroStatus(bool isAggroed);

        void SetStrikingDistanceBool(bool isWithinStrikingDistance);

    }
    
}