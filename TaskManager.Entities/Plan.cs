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
    public class Plan : MongoBaseModel
    {
        [BsonElement("Title"), DisplayName("Başlık"), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Title { get; set; }

        [BsonElement("Desc"), DisplayName("Açıklama"), StringLength(500, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Desc { get; set; }

        [BsonElement("Type"), DisplayName("Tip")]
        public string Type { get; set; }

        [BsonElement("EndTime"), DisplayName("BitisTarihi"), Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public DateTime EndTime { get; set; }

        [BsonElement("IsDone"), DisplayName("Yapıldı")]
        public bool IsDone { get; set; }

        [BsonElement("IsDeleted"), DisplayName("Silindi")]
        public bool IsDeleted { get; set; }

        public string UserId { get; set; }

        public virtual TaskManagerUser Owner { get; set; }
    }
}
