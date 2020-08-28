using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    
    public class TaskManagerUser : MongoBaseModel
    {
        [BsonElement("Name"), DisplayName("Ad"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Name { get; set; }

        [BsonElement("Surname"), DisplayName("Soyad"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }

        [BsonElement("E-Email"), DisplayName("Email"), Required(ErrorMessage = "{0} alanı boş bırakılamaz."), StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }

        [BsonElement("Password"), DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş bırakılamaz."), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Password { get; set; }

        public virtual List<Plan> Plans { get; set; }

        public TaskManagerUser()
        {
            Plans = new List<Plan>();
        }
    }
}
