using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.domain.Models;
using WPF.domain.Services;
using WPF.EF.Services;

namespace WPF.EF
{
    public class SensorCrudService : ICrud
    {
        private readonly IDataService<Sensor> _dataService;

        public SensorCrudService()
        {
            _dataService = new GenericDataService<Sensor>(new WpfDbContext());
        }

        public async Task<Sensor> Add(int id, string name, string type)
        {
            var sensor = new Sensor {Id = id, SensorName = name, SensoreType = type };
            return await _dataService.Create(sensor);
        }

        public async Task<bool> Delete(int id)
        {
            Sensor sensor = await _dataService.Get(id);
            return await _dataService.Delete(sensor);
        }

        public async Task<IEnumerable<Sensor>> ListOfAll()
        {
            return await _dataService.GetAll();
        }

        public async Task<Sensor> Update(int id, string name, string type)
        {
            Sensor sensor = await _dataService.Get(id);
            sensor.SensorName = name;
            sensor.SensoreType = type;
            return await _dataService.Update(sensor);
        }
    }
}
