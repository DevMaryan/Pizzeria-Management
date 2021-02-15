using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories
{
    public class DriverRepository
    {
        public DriverRepository()
        {
            Driver_DB = new List<Driver>();
            OnDelivery_Driver = new List<Driver>();
        }

        public List<Driver> Driver_DB { get; set; }
        public List<Driver> OnDelivery_Driver { get; set; }

        public void Create(Driver newDriver)
        {
            Driver_DB.Add(newDriver);
        }

        public void Delete(Driver selectedDriver)
        {
            Driver_DB.Remove(selectedDriver);
        }
        public void OnDelivery(Driver onDelivery)
        {
            OnDelivery_Driver.Add(onDelivery);
        }
        public void DoneDelivery(Driver deliveryFinish)
        {
            OnDelivery_Driver.Remove(deliveryFinish);
        }
    }
}
