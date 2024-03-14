using Microsoft.AspNetCore.Mvc;
using RestieAPI.Configs;

namespace RestieAPI.Service
{
    public class InventoryRepo
    {
        private readonly DatabaseService _databaseService;
        public InventoryRepo(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public ActionResult<string> GetInventory()
        {
            // Example query
            var sql = "SELECT * FROM Inventory;";
            var reader = _databaseService.ExecuteQuery(sql);

            // Process results
            // ...

            return "Query executed successfully.";
        }
    }
}
