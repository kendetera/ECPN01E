using System;

namespace Elective
{
    internal sealed class InventoryDB
    {
        public string MyConnection()
        {
            // Trusted connection with encryption and bypassed certificate validation (dev-friendly).
            return "Server=KEN\\SQLEXPRESS;Database=InventoryDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
        }
    }
}
