using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestieAPI.Configs;
using RestieAPI.Models;
using RestieAPI.Service;

namespace RestieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Inventory : ControllerBase
    {
        private readonly DatabaseService _databaseService;
        public Inventory(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        [HttpGet]
        public ActionResult<List<InventoryItemModel>> GetInventory()
        {
            var sql = "SELECT * FROM Inventory;";
            var reader = _databaseService.ExecuteQuery(sql);

            // Process results
            var results = new List<InventoryItemModel>(); // Assuming InventoryItem is your model class
            while (reader.Read())
            {
                var inventoryItem = new InventoryItemModel
                {
                    code = reader.GetString(0), 
                    item = reader.GetString(1), 
                                                
                };

                results.Add(inventoryItem);
            }

            // Close the reader
            reader.Close();
            return Ok(results);
        }

    }
}
