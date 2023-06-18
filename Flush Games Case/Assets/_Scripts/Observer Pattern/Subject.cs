using System.Collections.Generic;
using StackGame.Player;
using UnityEngine;

namespace StackGame.Observer_Pattern
{
    public abstract class Subject : MonoBehaviour
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        protected void NotifyObservers(PlayerMovement movement)
        {
            _observers.ForEach((_observers) =>
            {
                _observers.OnNotify(movement);

            });
        }

    }
}
