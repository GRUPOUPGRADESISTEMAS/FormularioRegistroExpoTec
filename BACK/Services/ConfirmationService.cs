using MongoDB.Driver;
using seguimiento_expotec.Connection;
using seguimiento_expotec.Models;
using seguimiento_expotec.DTOs;

namespace seguimiento_expotec.Services
{
    public class ConfirmationService
    {
        private readonly ConnectionDB connection;

        public ConfirmationService(ConnectionDB connection)
        {
            this.connection = connection;
        }

        // Convierte el modelo ConfirmationModel a un DTO
        private ConfirmationDTO ConvertToDTO(ConfirmationModel confirmation)
        {
            return new ConfirmationDTO
            {
                Id = confirmation.Id,
                ConfirmedBy = confirmation.ConfirmedBy != null
                    ? new BusinessExecutiveDTO
                    {
                        Id = confirmation.ConfirmedBy.Id,
                        Name = confirmation.ConfirmedBy.Name,
                        Dni = confirmation.ConfirmedBy.Dni
                    }
                    : null,
                ConfirmationDate = confirmation.ConfirmationDate,
                Status = confirmation.Status,
                ValidityDate = confirmation.ValidityDate
            };
        }

        // Crear una nueva confirmación
        public async Task<ConfirmationDTO> CreateConfirmationAsync(ConfirmationDTO confirmationDTO)
        {
            var confirmation = new ConfirmationModel
            {
                ConfirmedBy = confirmationDTO.ConfirmedBy != null
                    ? new BusinessExecutivesModel
                    {
                        Id = confirmationDTO.ConfirmedBy.Id,
                        Name = confirmationDTO.ConfirmedBy.Name,
                        Dni = confirmationDTO.ConfirmedBy.Dni
                    }
                    : null,
                ConfirmationDate = confirmationDTO.ConfirmationDate,
                Status = confirmationDTO.Status,
                ValidityDate = confirmationDTO.ValidityDate
            };

            await connection.ConfirmationCollection.InsertOneAsync(confirmation);
            return ConvertToDTO(confirmation);
        }

        // Obtener todas las confirmaciones
        public async Task<List<ConfirmationDTO>> GetAllConfirmationsAsync()
        {
            var confirmations = await connection.ConfirmationCollection.Find(_ => true).ToListAsync();
            return confirmations.Select(confirmation => ConvertToDTO(confirmation)).ToList();
        }

        // Obtener una confirmación por ID
        public async Task<ConfirmationDTO?> GetConfirmationByIdAsync(string id)
        {
            var filter = Builders<ConfirmationModel>.Filter.Eq(c => c.Id, id);
            var confirmation = await connection.ConfirmationCollection.Find(filter).FirstOrDefaultAsync();
            return confirmation != null ? ConvertToDTO(confirmation) : null;
        }

        // Actualizar una confirmación
        public async Task<ConfirmationDTO?> UpdateConfirmationAsync(string id, ConfirmationDTO confirmationDTO)
        {
            var filter = Builders<ConfirmationModel>.Filter.Eq(c => c.Id, id);
            var update = Builders<ConfirmationModel>.Update
                .Set(c => c.ConfirmedBy, confirmationDTO.ConfirmedBy != null
                    ? new BusinessExecutivesModel
                    {
                        Id = confirmationDTO.ConfirmedBy.Id,
                        Name = confirmationDTO.ConfirmedBy.Name,
                        Dni = confirmationDTO.ConfirmedBy.Dni
                    }
                    : null)
                .Set(c => c.ConfirmationDate, confirmationDTO.ConfirmationDate)
                .Set(c => c.Status, confirmationDTO.Status)
                .Set(c => c.ValidityDate, confirmationDTO.ValidityDate);

            var result = await connection.ConfirmationCollection
                .FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<ConfirmationModel>
                {
                    ReturnDocument = ReturnDocument.After
                });

            return result != null ? ConvertToDTO(result) : null;
        }

        // Eliminar una confirmación
        public async Task<ConfirmationDTO?> DeleteConfirmationAsync(string id)
        {
            var filter = Builders<ConfirmationModel>.Filter.Eq(c => c.Id, id);
            var result = await connection.ConfirmationCollection
                .FindOneAndDeleteAsync(filter);
            return result != null ? ConvertToDTO(result) : null;
        }
    }
}
