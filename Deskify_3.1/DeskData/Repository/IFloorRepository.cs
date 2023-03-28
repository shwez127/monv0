using DeskEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskData.Repository
{
    public interface IFloorRepository
    {
        void AddFloor(Floor floor);
        void UpdateFloor(Floor floor);
        void DeleteFloor(int floorId);
        Floor GetFloorById(int floorId);
        IEnumerable<Floor> GetFloor();
    }
}

