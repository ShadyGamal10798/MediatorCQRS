using System.ComponentModel.DataAnnotations.Schema;

namespace MediatorCQRS.Helpers.Entities.Zatca
{
    [Table("CSIDData", Schema = "zatca")]
    public class CSIDData
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CSR { get; set; }
        public string PrivateKey { get; set; }

        public string PublicKey { get; set; }
        public string SecretKey { get; set; }




    }
}
