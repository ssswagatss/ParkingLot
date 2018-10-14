using System;

namespace ParkingLot
{
    public abstract class Slot
    {
        private bool _isOccupied;
        private int _slotNumber;

        public Slot(int slotNumber)
        {
            _isOccupied = false;
            _slotNumber = slotNumber;
        }

        public bool IsOccupied()
        {
            return _isOccupied;
        }

        public int GetSlotNumber()
        {
            return _slotNumber;
        }

        public void Park()
        {
            this._isOccupied = true;
        }

        public void UnPark()
        {
            _isOccupied = false;
        }
        

    }
}
