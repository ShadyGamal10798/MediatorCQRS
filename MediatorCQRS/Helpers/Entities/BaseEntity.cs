using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediatorCQRS.Helpers.Entities
{
    public class BaseEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public T Id { get; protected set; }
        [Column(Order = 2)]
        public string? CreatedBy { get; set; }
        [Column(Order = 3)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Column(Order = 4)]
        public int? ModifiedBy { get; protected set; }
        [Column(Order = 5)]
        public DateTime? ModifiedDate { get; protected set; }
        [Column(Order = 6)]
        public bool IsActive { get; protected set; } = true;

        public virtual BaseEntity<T> Delete(int? modifiedBy)
        {
            IsActive = false;
            ModifiedDate = DateTime.Now;
            ModifiedBy = modifiedBy;
            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj is not BaseEntity<T> other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetUnproxiedType(this) != GetUnproxiedType(other))
                return false;

            if (Id.Equals(default) || other.Id.Equals(default))
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(BaseEntity<T> a, BaseEntity<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity<T> a, BaseEntity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetUnproxiedType(this).ToString() + Id).GetHashCode();
        }

        internal static Type GetUnproxiedType(object obj)
        {
            const string EFCoreProxyPrefix = "Castle.Proxies.";
            const string NHibernateProxyPostfix = "Proxy";

            Type type = obj.GetType();
            string typeString = type.ToString();

            if (typeString.Contains(EFCoreProxyPrefix) || typeString.EndsWith(NHibernateProxyPostfix))
                return type.BaseType;

            return type;
        }
    }
}
