using System;
using System.Collections.Generic;

namespace Hotfolder2Database
{
    internal class Unsubscriber : IDisposable
    {
        private List<IObserver<object>> _observers;
        private IObserver<object> _observer;

        public Unsubscriber(List<IObserver<object>> observers, IObserver<object> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}