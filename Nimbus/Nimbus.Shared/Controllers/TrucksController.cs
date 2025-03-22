//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Mvc;
//using Nimbus.Shared.Entities;
//using Nimbus.Shared.Repositories;

//namespace Nimbus.Shared.Controllers
//{
//    [Route("api/[controller]")]
//    public class TrucksController : ControllerBase
//    {
//        private readonly TruckRepository _truckRepository;

//        public TrucksController(TruckRepository truckRepository)
//        {
//            _truckRepository = truckRepository;
//        }
//        [HttpGet]
//        public async Task<IActionResult> GetAllTrucksThroughApi()
//        {
//            var results = await _truckRepository.GetAllTrucksAsync();
//            return Ok(results);
//        }
//    }
//}
