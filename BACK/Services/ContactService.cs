using MongoDB.Bson;
using MongoDB.Driver;
using seguimiento_expotec.Connection;
using seguimiento_expotec.DTOs;
using seguimiento_expotec.Models;

namespace seguimiento_expotec.Services
{
    public class ContactService
    {
        private readonly ConnectionDB connection;

        public ContactService(ConnectionDB connection)
        {
            this.connection = connection;
        }

        // Convertir de modelo a DTO
        private ContactDTO ConvertToDTO(ContactModel contact)
        {
            return new ContactDTO
            {
                Id = contact.Id?.ToString() ?? string.Empty,
                Name = contact.Name,
                Dni = contact.Dni,
                Position = contact.Position,
                Area = contact.Area,
                Emails = contact.Emails,
                Phones = contact.Phones,
                InvitationSentDate = contact.InvitationSentDate
            };
        }

        // Crear un nuevo contacto
        public async Task<ContactDTO> CreateContactAsync(ContactDTO contactDTO)
        {
            var contact = new ContactModel
            {
                Name = contactDTO.Name,
                Dni = contactDTO.Dni,
                Position = contactDTO.Position,
                Area = contactDTO.Area,
                Emails = contactDTO.Emails,
                Phones = contactDTO.Phones,
                InvitationSentDate = contactDTO.InvitationSentDate
            };
            await connection.ContactCollection.InsertOneAsync(contact);
            return ConvertToDTO(contact);
        }


        // Obtener todos los contactos
        public async Task<List<ContactDTO>> GetAllContactsAsync()
        {
            var contacts = await connection.ContactCollection.Find(_ => true).ToListAsync();
            return contacts.Select(contact => ConvertToDTO(contact)).ToList();
        }

        public async Task<ContactDTO?> GetContactByIdAsync(string id)
        {
            FilterDefinition<ContactModel> filter;
            if (ObjectId.TryParse(id, out var objectId))
            {
                filter = Builders<ContactModel>.Filter.Eq(c => c.Id, id);
            }
            else
            {
                filter = Builders<ContactModel>.Filter.Eq(c => c.Dni, id);
            }
            var contact = await connection.ContactCollection.Find(filter).FirstOrDefaultAsync();
            return contact != null ? ConvertToDTO(contact) : null;
        }

        public async Task<ContactDTO?> UpdateContactAsync(string id, ContactDTO contactDTO)
        {
            var filter = Builders<ContactModel>.Filter.Eq(c => c.Id, id);
            var update = Builders<ContactModel>.Update
                .Set(c => c.Name, contactDTO.Name)
                .Set(c => c.Position, contactDTO.Position)
                .Set(c => c.Area, contactDTO.Area)
                .Set(c => c.Emails, contactDTO.Emails)
                .Set(c => c.Phones, contactDTO.Phones)
                .Set(c => c.InvitationSentDate, contactDTO.InvitationSentDate);
            var result = await connection.ContactCollection.FindOneAndUpdateAsync(
                filter,
                update,
                new FindOneAndUpdateOptions<ContactModel> { ReturnDocument = ReturnDocument.After }
            );
            return result != null ? ConvertToDTO(result) : null;
        }

        public async Task<ContactDTO?> DeleteContactAsync(string id)
        {
            var filter = Builders<ContactModel>.Filter.Eq(c => c.Id, id);
            var result = await connection.ContactCollection.FindOneAndDeleteAsync(filter);
            return result != null ? ConvertToDTO(result) : null;
        }
    }
}
