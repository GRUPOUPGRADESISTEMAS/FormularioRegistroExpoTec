using MongoDB.Driver;
using seguimiento_expotec.Connection;
using seguimiento_expotec.DTOs;
using seguimiento_expotec.Models;

namespace seguimiento_expotec.Services
{
    public class BusinessExecutiveService
    {
        private readonly ConnectionDB connection;

        public BusinessExecutiveService(ConnectionDB connection)
        {
            this.connection = connection;
        }

        private BusinessExecutiveDTO ConvertToDTO(BusinessExecutivesModel executive)
        {
            return new BusinessExecutiveDTO
            {
                Id = executive.Id,
                Name = executive.Name,
                Dni = executive.Dni
            };
        }

        public async Task<BusinessExecutiveDTO> CreateBusinessExecutiveAsync(BusinessExecutiveDTO businessExecutiveDTO)
        {
            var businessExecutive = new BusinessExecutivesModel
            {
                Name = businessExecutiveDTO.Name,
                Dni = businessExecutiveDTO.Dni
            };
            await connection.BusinessExecutivesCollection.InsertOneAsync(businessExecutive);
            return ConvertToDTO(businessExecutive);
        }

        public async Task<List<BusinessExecutiveDTO>> GetAllBusinessExecutivesAsync()
        {
            var executives = await connection.BusinessExecutivesCollection.Find(_ => true).ToListAsync();
            return executives.Select(executive => ConvertToDTO(executive)).ToList();
        }

        public async Task<BusinessExecutiveDTO> GetBusinessExecutiveByIdAsync(string id)
        {
            var filter = Builders<BusinessExecutivesModel>.Filter.Eq(e => e.Id, id);
            var executive = await connection.BusinessExecutivesCollection.Find(filter).FirstOrDefaultAsync();
            return executive != null ? ConvertToDTO(executive) : null!;
        }

        public async Task<BusinessExecutiveDTO?> UpdateBusinessExecutiveAsync(string id, BusinessExecutiveDTO businessExecutiveDTO)
        {
            var filter = Builders<BusinessExecutivesModel>.Filter.Eq(e => e.Id, id);
            var update = Builders<BusinessExecutivesModel>.Update
                .Set(e => e.Name, businessExecutiveDTO.Name)
                .Set(e => e.Dni, businessExecutiveDTO.Dni);
            var result = await connection.BusinessExecutivesCollection
                .FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<BusinessExecutivesModel>
                {
                    ReturnDocument = ReturnDocument.After
                });
            return result != null ? ConvertToDTO(result) : null;
        }

        public async Task<BusinessExecutiveDTO?> DeleteBusinessExecutiveAsync(string id)
        {
            var filter = Builders<BusinessExecutivesModel>.Filter.Eq(e => e.Id, id);
            var result = await connection.BusinessExecutivesCollection
                .FindOneAndDeleteAsync(filter);
            return result != null ? ConvertToDTO(result) : null;
        }


    }
}
