using DeskData.Repository;
using DeskEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskBusiness.Services
{
    public class FloorService
    {
        IFloorRepository _floorRepository;
        public FloorService(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        // CRUD Service Operations for Floor

        public void AddFloor(Floor floor)
        {
            _floorRepository.AddFloor(floor);
        }
        public void UpdateFloor(Floor floor)
        {
            _floorRepository.UpdateFloor(floor);
        }
        public void DeleteFloor(int floorId)
        {
            _floorRepository.DeleteFloor(floorId);
        }

        //get Floor by id

        public Floor GetFloorById(int floorId)
        {
            return _floorRepository.GetFloorById(floorId);
        }

        //get Floor

        public IEnumerable<Floor> GetFloor()
        {
            return _floorRepository.GetFloor();
        }
    }
}
