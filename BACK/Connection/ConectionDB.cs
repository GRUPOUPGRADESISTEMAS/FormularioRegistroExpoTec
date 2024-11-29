using MongoDB.Driver;
using seguimiento_expotec.Models;

namespace seguimiento_expotec.Connection
{
    public class ConnectionDB
    {
        private readonly IMongoDatabase _database;

        public ConnectionDB()
        {
            _database = Connect();
        }

        // Colección de BusinessExecutives
        public IMongoCollection<BusinessExecutivesModel> BusinessExecutivesCollection
        {
            get
            {
                return _database.GetCollection<BusinessExecutivesModel>("business_executives");
            }
        }

        // Colección de ConfirmationCollection
        public IMongoCollection<ConfirmationModel> ConfirmationCollection
        {
            get
            {
                return _database.GetCollection<ConfirmationModel>("confirmations");
            }
        }

        // Colección de Contactos
        public IMongoCollection<ContactModel> ContactCollection
        {
            get
            {
                return _database.GetCollection<ContactModel>("contacts");
            }
        }

        public IMongoDatabase Connect()
        {
            try
            {
                const string connectionUri = "mongodb+srv://grupoupgradeperu:CUhQCqGo3DG7z4sN@upgradedb.vcn6i.mongodb.net";
                var settings = MongoClientSettings.FromConnectionString(connectionUri);
                var client = new MongoClient(settings);
                var database = client.GetDatabase("seguimiento_expotec");
                return database;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
